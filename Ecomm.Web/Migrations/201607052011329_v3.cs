namespace Ecomm.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferenceCode = c.String(),
                        Title = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeliveryAddresses");
        }
    }
}
