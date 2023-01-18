using System;
using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Module4HW3.DataModel;
using Module4HW3.Services;

namespace Module4HW3.LinqToEntities
{
    public class RequestManager
    {
        public static void Run()
        {
            using var context = new MyDependency().GetContext();
            var first = context.Employee.Include(e => e.EmployeeProjects).ThenInclude(p => p.Project);
            Console.WriteLine("1\n" + first.ToQueryString());
            var second = context.Employee.FromSqlRaw("SELECT [e].*, DATEDIFF(DD, GETDATE(), [e].HiredDate) FROM Employee [e]");
            Console.WriteLine("\n2\n" + second.ToQueryString());

            Console.WriteLine("3");
            var transaction = context.Database.BeginTransaction();

            try
            {
                var project = context.Project.First();
                project.Name = project.Name + "UPDATED_FIRST";

                transaction.CreateSavepoint("Update1");
                Console.WriteLine($"ID {project.ProjectId} {project.Name}");

                var project2 = context.Project.Find(2);
                project2.Name = project2.Name + "UPDATED_SECOND";
                transaction.Commit();
                Console.WriteLine($"ID {project2.ProjectId} {project2.Name}");
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

            var newTitle = new Title() { Name = "Project Manager" };
            context.Title.Add(newTitle);
            var newOffice = new Office() { Title = "Department1", Location = "Lviv" };
            context.Office.Add(newOffice);
            context.SaveChanges();

            var fourth = context.Employee.Add(new Employee()
            {
                DateOfBirth = DateTime.Today.AddYears(-22),
                TitleId = context.Title.Where(x => x.Name == "Project Manager").Select(x => x.TitleId).FirstOrDefault(),
                FirstName = "Ivan",
                LastName = "Seniv",
                HiredDate = DateTime.Today,
                OfficeId = context.Office.Where(x => x.Title == "Department1").Select(x => x.OfficeId).FirstOrDefault()
            });

            Console.WriteLine("\n4\n" + $"{fourth.Entity.FirstName} {fourth.Entity.LastName} officeId: {fourth.Entity.OfficeId} titleID: {fourth.Entity.TitleId}");

            context.SaveChanges();

            var fifth = context.Employee.Remove(context.Employee.OrderBy(e => e.EmployeeId).LastOrDefault());
            context.SaveChanges();
            Console.WriteLine("5 Deleted");

            var sixth = context.Employee.Select(e => e).Where(e => e.Title.Name.Contains("a")).GroupBy(e => e, e => e.Title);
            Console.WriteLine("\n6\n" + sixth.ToQueryString());
        }
    }
}
