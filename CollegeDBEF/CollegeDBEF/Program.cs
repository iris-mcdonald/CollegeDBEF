using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace CollegeDBEF 
{
    public class CollegeDBEF1: DbContext
    {
        public CollegeDBEF1() : base("CollegeDBEF")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CollegeDBEF1, Migrations.Configuration>());
        }

        public DbSet<Student> Students  { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Score> Scores  { get; set; }

    }
    public class Student
    {   [Key]
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Int64 SSN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public Int64 Phone { get; set;}
        public virtual List<Score> Grades { get; set; }
    }
    public class Class
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public string Department { get; set; }
        public string Instructor { get; set; }
               
    }
    
    public class Score
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int PointsEarned { get; set; }
        public int PointsPossible { get; set; }
        public virtual Class Class_obj { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CollegeDBEF1())
            {
                var class1 = new Class
                {
                    Title = "Calculus",
                    Number = 201,
                    Department = "Mathematics",
                };
                db.Classes.Add(class1);

                Class class2 = new Class
                {
                    Title = "Circus Arts",
                    Number = 150,
                    Department = "Physical Education"
                };
                db.Classes.Add(class2);

                Class class3 = new Class
                {
                    Title = "Biology",
                    Number = 110,
                    Department = "Sciences"
                };
                db.Classes.Add(class3);

                Class class4 = new Class
                {
                    Title = "Dodgeball",
                    Number = 180,
                    Department = "Physical Education"
                };
                db.Classes.Add(class4);

                var student1 = new Student
                {
                FName = "Susie",
                LName = "Smartie",
                SSN = 783776829,
                Address = "500 Peach Street",
                City = "Richfield",
                State = "Ohio",
                Zip = 44116,
                Phone = 3335463459,
                Grades = new List<Score>()
                };

                db.Students.Add(student1);

                Score student1Score1 = new Score
                {
                    Class_obj = class1,//ties the class object with the score 
                    Type = "Quiz",
                    Description = "Quiz 1: Derivatives",
                    DateAssigned = DateTime.Parse("01-03-18"),
                    DateDue = DateTime.Parse("01-10-18"),
                    DateSubmitted = DateTime.Parse("01-05-18"),
                    PointsEarned = 10,
                    PointsPossible = 10,
                };
                student1.Grades.Add(student1Score1);

                Score student1Score2 = new Score
                {
                    Class_obj = class1,//ties the class object with the score 
                    Type = "Quiz",
                    Description = "Quiz 2: Integrals",
                    DateAssigned = DateTime.Parse("02-15-18"),
                    DateDue = DateTime.Parse("02-25-18"),
                    DateSubmitted = DateTime.Parse("02-17-18"),
                    PointsEarned = 18,
                    PointsPossible = 20,
                };
                student1.Grades.Add(student1Score2);

                Score student1Score3 = new Score
                {
                    Class_obj = class1,//ties the class object with the score 
                    Type = "Midterm",
                    Description = "Everything We Covered",
                    DateAssigned = DateTime.Parse("03-02-18"),
                    DateDue = DateTime.Parse("03-02-18"),
                    DateSubmitted = DateTime.Parse("03-02-18"),
                    PointsEarned = 95,
                    PointsPossible = 100,
                };
                student1.Grades.Add(student1Score3);

                var student2 = new Student
                {
                FName = "Bob",
                LName = "Brownoser",
                SSN = 998763210,
                Address = "32 Cherry Lane",
                City = "Painesville",
                State = "Ohio",
                Zip = 40235,
                Phone = 2165438900,
                Grades = new List<Score>()
                };
                db.Students.Add(student2);

                Score student2Score1 = new Score
                {
                    Class_obj = class2,//ties the class object with the score 
                    Type = "Lab",
                    Description = "Lab1: Juggling",
                    DateAssigned = DateTime.Parse("01-12-18"),
                    DateDue = DateTime.Parse("01-15-18"),
                    DateSubmitted = DateTime.Parse("01-13-18"),
                    PointsEarned = 8,
                    PointsPossible = 10,
                };
                student2.Grades.Add(student2Score1);

                Score student2Score2 = new Score
                {
                    Class_obj = class4,//ties the class object with the score 
                    Type = "Test",
                    Description = "Intramural Match",
                    DateAssigned = DateTime.Parse("01-23-18"),
                    DateDue = DateTime.Parse("01-23-18"),
                    DateSubmitted = DateTime.Parse("01-23-18"),
                    PointsEarned = 75,
                    PointsPossible = 100,
                };
                student2.Grades.Add(student2Score2);

                var student3 = new Student
                {
                    FName = "Albert",
                    LName = "AlwaysLate",
                    SSN = 102667334,
                    Address = "90615 Kumquat Square",
                    City = "Avon",
                    State = "Ohio",
                    Zip = 45332,
                    Phone = 3389945320,
                    Grades = new List<Score>()
                };
                db.Students.Add(student3);

                Score student3Score1 = new Score
                {
                    Class_obj = class3,//ties the class object with the score 
                    Type = "Test",
                    Description = "Inner Secrets of Cells",
                    DateAssigned = DateTime.Parse("02-12-18"),
                    DateDue = DateTime.Parse("02-19-18"),
                    DateSubmitted = DateTime.Parse("03-02-18"),
                    PointsEarned = 72,
                    PointsPossible = 100,
                };
                student3.Grades.Add(student3Score1);

                Score student3Score2 = new Score
                {
                    Class_obj = class4,//ties the class object with the score 
                    Type = "Test",
                    Description = "Intramural Match",
                    DateAssigned = DateTime.Parse("01-23-18"),
                    DateDue = DateTime.Parse("01-23-18"),
                    DateSubmitted = DateTime.Parse("01-23-18"),
                    PointsEarned = 99,
                    PointsPossible = 100,
                };
                student3.Grades.Add(student3Score2);

                Score student3Score3 = new Score
                {
                    Class_obj = class3,//ties the class object with the score 
                    Type = "Midterm",
                    Description = "Botany",
                    DateAssigned = DateTime.Parse("03-02-18"),
                    DateDue = DateTime.Parse("03-18-18"),
                    DateSubmitted = DateTime.Parse("03-12-18"),
                    PointsEarned = 33,
                    PointsPossible = 50,
                };
                student3.Grades.Add(student3Score3);

                db.SaveChanges();//save the db changes

                var queryStudentScores =
                    from student in db.Students
                    //orderby student.Grades-this caused exception
                    select student;

                WriteLine("Student Grades Report");
                WriteLine("=====================");
                foreach (var student in queryStudentScores)
                {
                    WriteLine($"{student.FName} { student.LName}  SSN: { student.SSN}" + 
                    $"   Address: {student.Address}, {student.City}," +
                        $" {student.State}  {student.Zip} Phone: {student.Phone}");

                    foreach (Score score in student.Grades)
                    {
                        WriteLine($" Class: {score.Class_obj.Title} {score.Class_obj.Number}" +
                            $" Dept: {score.Class_obj.Department}");
                        WriteLine($"  { score.Type}-{score.Description}  -" +
                            $"Date Assigned: {score.DateAssigned.ToString("MM/dd/yyyy")}" +
                            $" Date Due: {score.DateDue.ToString("MM/dd/yyyy")}" +
                            $" Date Submitted: {score.DateSubmitted.ToString("MM/dd/yyyy")} " +
                            $"Score: {score.PointsEarned}/{score.PointsPossible}");
                    };
                }
            }//end of using code block
            WriteLine();
            WriteLine("Done!  Check out the db on MS SQL SERVER, too (hit Refresh,first!");
            WriteLine("Press any key to exit");
            ReadKey();
        }
        
    }
}
