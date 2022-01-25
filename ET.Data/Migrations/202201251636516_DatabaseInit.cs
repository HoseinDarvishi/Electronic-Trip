namespace ET.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        CarName = c.String(nullable: false, maxLength: 300),
                        Model = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 300),
                        DriverId = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Users", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 300),
                        UserName = c.String(nullable: false, maxLength: 300),
                        Password = c.String(nullable: false, maxLength: 1500),
                        Email = c.String(nullable: false, maxLength: 500),
                        RoleId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Requestes",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 2000),
                        DetachCode = c.String(nullable: false, maxLength: 255),
                        RequestDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete:false)
                .Index(t => t.UserId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requestes", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "DriverId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Requestes", "UserId", "dbo.Users");
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropIndex("dbo.Requestes", new[] { "CarId" });
            DropIndex("dbo.Requestes", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Cars", new[] { "DriverId" });
            DropTable("dbo.Permissions");
            DropTable("dbo.Roles");
            DropTable("dbo.Requestes");
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}
