using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using EmployeeTest.Models;

namespace EmployeeTest.Data_Access_Layer
{
    public class SalesERPDAL:DbContext
    {
        public DbSet<Employee> Employees { set; get; }
        public DbSet<GroupMsg> GroupMsgs { set; get; }
        public DbSet<FileMsg> FileMsgs { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            modelBuilder.Entity<GroupMsg>().ToTable("TblGroupMsg");
            modelBuilder.Entity<FileMsg>().ToTable("TblFileMsg");
            base.OnModelCreating(modelBuilder);
        }
    }
}