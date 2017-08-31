namespace step.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StrengthsResult", c => c.String());
            AddColumn("dbo.AspNetUsers", "TemperamrntResult", c => c.String());
            AddColumn("dbo.AspNetUsers", "OrientationResult", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OrientationResult");
            DropColumn("dbo.AspNetUsers", "TemperamrntResult");
            DropColumn("dbo.AspNetUsers", "StrengthsResult");
        }
    }
}
