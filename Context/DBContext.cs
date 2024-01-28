using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
    
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Context
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=dbCon")
        {
                            
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}