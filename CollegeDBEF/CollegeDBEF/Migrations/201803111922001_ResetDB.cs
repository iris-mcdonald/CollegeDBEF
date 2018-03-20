namespace CollegeDBEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Number = c.Int(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        DateAssigned = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        PointsEarned = c.Int(nullable: false),
                        PointsPossible = c.Int(nullable: false),
                        Class_obj_ID = c.Int(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.Class_obj_ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Class_obj_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        SSN = c.Long(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Scores", "Class_obj_ID", "dbo.Classes");
            DropIndex("dbo.Scores", new[] { "Student_ID" });
            DropIndex("dbo.Scores", new[] { "Class_obj_ID" });
            DropTable("dbo.Students");
            DropTable("dbo.Scores");
            DropTable("dbo.Classes");
        }
    }
}
