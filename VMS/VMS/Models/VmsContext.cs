using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class VmsContext:DbContext
    {
        public VmsContext(): base("VmsContextString")
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarAssignToDriver> CarAssignToDrivers { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<UserRequest> UserRequests { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AllRequestsFromUser> AllRequestsFromUsers { get; set; }
    }
}