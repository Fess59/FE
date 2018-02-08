namespace GateDB.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FlowInstanceParameters", "CurrentState");
            DropColumn("dbo.FlowInstanceParameters", "CurrentStateEnum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FlowInstanceParameters", "CurrentStateEnum", c => c.Int(nullable: false));
            AddColumn("dbo.FlowInstanceParameters", "CurrentState", c => c.Int(nullable: false));
        }
    }
}
