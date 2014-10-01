namespace VMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllRequestsFromUsers",
                c => new
                    {
                        AllRequestsFromUserId = c.Int(nullable: false, identity: true),
                        UserRequestId = c.Int(nullable: false),
                        RequestStatusName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllRequestsFromUserId)
                .ForeignKey("dbo.UserRequests", t => t.UserRequestId, cascadeDelete: true)
                .Index(t => t.UserRequestId);
            
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        UserRequestId = c.Int(nullable: false, identity: true),
                        JourneyStartTime = c.DateTime(nullable: false),
                        JourneyEndTime = c.DateTime(nullable: false),
                        Purpose = c.String(),
                        CompanyName = c.String(),
                        Destination = c.String(),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRequestId)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.CarAssignToDrivers",
                c => new
                    {
                        CarAssignToDriverId = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        FromCarAssignDate = c.DateTime(nullable: false),
                        ToCarAssignDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CarAssignToDriverId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        TypeOfCar = c.Int(nullable: false),
                        CarStatus = c.Int(),
                        CarName = c.String(nullable: false),
                        CarNumber = c.String(nullable: false),
                        PurchasingDate = c.DateTime(nullable: false),
                        ChassisNo = c.String(),
                        SeatCapacity = c.String(),
                    })
                .PrimaryKey(t => t.CarId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        DriverName = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        LiscenceNo = c.String(nullable: false),
                        Address = c.String(),
                        Experience = c.Double(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        DriverStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        OfficialId = c.String(),
                        Name = c.String(),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CarAssignToDrivers", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.CarAssignToDrivers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.AllRequestsFromUsers", "UserRequestId", "dbo.UserRequests");
            DropForeignKey("dbo.UserRequests", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Users", new[] { "DesignationId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.CarAssignToDrivers", new[] { "DriverId" });
            DropIndex("dbo.CarAssignToDrivers", new[] { "CarId" });
            DropIndex("dbo.AllRequestsFromUsers", new[] { "UserRequestId" });
            DropIndex("dbo.UserRequests", new[] { "DesignationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
            DropTable("dbo.CarAssignToDrivers");
            DropTable("dbo.Designations");
            DropTable("dbo.UserRequests");
            DropTable("dbo.AllRequestsFromUsers");
        }
    }
}
