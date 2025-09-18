using SampleDotNetCoreApp.Data;

namespace SampleDotNetCoreApp
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            insertExample();
            //getAllExample();
            //updateExample();
            //deleteExample();




        }

        private static void deleteExample()
        {
            try
            {
                var context = new CourseContext();
                var rec = context.MyCourses.Find(3);
                if (rec == null)
                {
                    Console.WriteLine("No Record found to delete");
                    return;
                }
                context.MyCourses.Remove(rec);
                context.SaveChanges();
                Console.WriteLine("Course deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
            }

        }

        private static void updateExample()
        {

            try
            {
                var context = new CourseContext();
                var rec = context.MyCourses.Find(1);//Find by ID...
                if (rec != null)
                {
                    rec.CourseTitle = "FNF .NET";
                    rec.BookPrice = 15000;
                   
                }
                else
                {
                    Console.WriteLine("No Record found to update");
                    return;
                }
                context.SaveChanges();
                Console.WriteLine("Changes updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);//Called only if InnerException Exists
            }
        }

        private static void getAllExample()
        {
            try
            {
                var context = new CourseContext();
                var records = context.MyCourses.ToList();
                foreach (var record in records)
                {
                    Console.WriteLine(record.CourseTitle.ToUpper());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
            }
        }

        private static void insertExample()
        {

            try
            {
                var dbContext = new CourseContext();
                //var newCourse = new Courses
                //{

                //    CourseTitle = "DotNet Core",
                //    CourseDuration = new DateTime(2025, 5, 10), // Fixed: Correctly initializing DateTime
                //    BookPrice = 20000
                //};

                var newCourse1 = new Courses
                {

                    CourseTitle = "Python",
                    CourseDuration = new DateTime(2024, 3, 10), // Fixed: Correctly initializing DateTime
                    BookPrice = 40000
                };

                //dbContext.MyCourses.Add(newCourse);
                dbContext.MyCourses.Add(newCourse1);
                dbContext.SaveChanges();
                Console.WriteLine("Course Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
            }
        }
    }
}


