namespace graduate_work_itstep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LifeValuesAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LifeValuesKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LifeValuesQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrientationAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Attribute = c.String(),
                        OrientationQuestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrientationQuestions", t => t.OrientationQuestion_Id)
                .Index(t => t.OrientationQuestion_Id);
            
            CreateTable(
                "dbo.OrientationQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrientationAnswers", "OrientationQuestion_Id", "dbo.OrientationQuestions");
            DropIndex("dbo.OrientationAnswers", new[] { "OrientationQuestion_Id" });
            DropTable("dbo.OrientationQuestions");
            DropTable("dbo.OrientationAnswers");
            DropTable("dbo.LifeValuesQuestions");
            DropTable("dbo.LifeValuesKeys");
            DropTable("dbo.LifeValuesAnswers");
        }
    }
}
