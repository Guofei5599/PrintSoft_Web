/**
 * html5调用摄像头扫码
 */
; (function (win, doc) {
    function QRScan(div_id) {
        this.div_id = div_id;
        this.div_can = null;
        this.videos = [];
        this.medioConfig = {};
        this.can_open = false;
        this.init();
    }

    QRScan.prototype = {
        init: function () {
            win.URL = (win.URL || win.webkitURL || win.mozURL || win.msURL);
            var promisifiedOldGUM = function (constraints) {
                var getUserMedia = (navigator.getUserMedia ||
                    navigator.webkitGetUserMedia || navigator.mozGetUserMedia);
                if (!getUserMedia) {
                    return Promise.reject(new Error('getUserMedia is not implemented in this browser'));
                }
                return new Promise(function (resolve, reject) {
                    getUserMedia.call(navigator, constraints, resolve, reject);
                });
            };
            if (navigator.mediaDevices === undefined) {
                navigator.mediaDevices = {};
            }
            if (navigator.mediaDevices.getUserMedia === undefined) {
                navigator.mediaDevices.getUserMedia = promisifiedOldGUM;
            }

            var self = this;
            self.div_can = doc.getElementById(self.div_id);
            //alert(self.div_id);
            navigator.mediaDevices.enumerateDevices().then(function (devices) {
                for (var i = 0; i < devices.length; i++) {
                    var deviceInfo = devices[i];
                    // 判断是否是相机设备
                    if (deviceInfo.kind == "videoinput") {
                        self.videos.push(deviceInfo.deviceId);
                    }
                }
                var len = self.videos.length;
                self.can_open = true;
                self.medioConfig = {
                    audio: false,
                    video: { deviceId: self.videos[len - 1] }
                }
            });
        },
        openScan: function () {
            var self = this;
            if (self.can_open) {
                var size = {
                    width: window.innerWidth || document.body.clientWidth,
                    height: window.innerHeight || document.body.clientHeight
                }
                var vd = doc.createElement('video');
                vd.setAttribute('id', 'video_id');
                navigator.mediaDevices.getUserMedia(self.medioConfig).then(function (stream) {
                    vd.src = win.URL.createObjectURL(stream);
                    //  vd.srcObject = stream  在新的浏览器中需使用此代替createObjectURL
                    self.div_can.appendChild(vd);
                }).catch(function (err) {
                    var p = doc.createElement('p');
                    p.innerHTML = 'ERROR: ' + err.name +
                                  '<br>该浏览器不支持调用摄像头，请使用夸克浏览器';
                    self.div_can.appendChild(p);
                });
                vd.play();
            }
        },

        closeScan: function () {
            this.div_can.innerHTML = '';
        },
        // 截图上传
        getImgDecode: function (func) {
            var self = this;
            var video = doc.getElementById('video_id');
            var canvas = doc.createElement('canvas');
            //var size = {
            //    width: window.innerWidth || document.body.clientWidth,
            //    height: window.innerHeight || document.body.clientHeight
            //}
            canvas.width = 350;
            canvas.height = 350;
            var ctx = canvas.getContext('2d');
           
            ctx.drawImage(video, 0, 0, 350, 350);

            var config = {
                readers: ["code_128_reader"],
                locate: true,
                src: canvas.toDataURL('images/png')
            }
            Quagga.decodeSingle(config, function (result) {
                console.log("decoding...");
                if (!result) {
                    console.log("图片中没有条形码！");
                    return false;
                }
                //识别结果
                if (result.codeResult) {
                    console.log("图片中的条形码为：" + result.codeResult.code);
                    alert("图片中的条形码为：" + result.codeResult.code);
                } else {
                    console.log("未识别到图片中的条形码！");
                    alert("未识别到图片中的条形码");
                }
            });

            //$.ajaxSettings.async = false;
            //$.post('/QRcode/QRcodeDecode', { "img": canvas.toDataURL('images/png').substr(22) },
            //       function (data, status) {
            //           if (status == "success" && data != "no")
            //               location.href = "/QRcode/Result/" + data;
            //       }, "text");

            //var image = new Image();
            //image.src = canvas.toDataURL('images/png');
            //qrcode.decode(image)
            //qrcode.callback = function (imgMsg) {
            //    alert(imgMsg)
            //}
        },

        sendBlob: function (blob, func) {
            var fd = new FormData();
            fd.append('auth', 'lkl123456');
            fd.append('file', blob);
            var xhr = new XMLHttpRequest();
            //xhr.open('post', 'http://123.206.7.80:10082/api/parse', true);
            //xhr.onload = function () {
            //    func ? func(JSON.parse(xhr.responseText)) : null;
            //};
            //xhr.send(fd);
        },

        Base64ToBlob: function (base64) {
            var code = win.atob(base64.split(',')[1]);
            var len = code.length;
            var as = new Uint8Array(len);
            for (var i = 0; i < len; i++) {
                as[i] = code.charCodeAt(i);
            }
            return new Blob([as], { type: 'image/png' });
        }
    }

    win.QRScan = QRScan;
}(window, document));
