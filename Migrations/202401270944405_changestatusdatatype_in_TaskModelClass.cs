namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestatusdatatype_in_TaskModelClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Task", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Task", "Status", c => c.String());
        }
    }
}
