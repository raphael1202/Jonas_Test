namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MultipleChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MultipleChoices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.MultipleChoices", new[] { "QuestionId" });
            DropTable("dbo.Questions");
            DropTable("dbo.MultipleChoices");
        }
    }
}
