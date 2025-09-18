using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDotNetCoreApp.Data
{
    [Table("Course")]
    internal class Courses
    {
        [Key]
        public int Id { get; set; }

        [Required]//NOT NULL
        [MaxLength(100)]
        public string CourseTitle { get; set; }

        
        [Required]
        public DateTime CourseDuration { get; set; }
        [Required]
        public int BookPrice { get; set; }
    }

    class CourseContext : DbContext
    {
        

        //"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = FNFTraining; Integrated Security = True; Encrypt=False;Trust Server Certificate=True"
        public DbSet<Courses> MyCourses { get; set; }

        private const string DB_SOURCE = "(localdb)\\MSSQLLocalDB"; //Your SQL Server instance name;
        private const string DB_NAME = "FNFTraining";

       
        /// ////////// Code for accessing COnnection string/////
        IConfigurationRoot?Configuration {  get; set; }

        private void ConfigureServices()
        {
            var conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false).Build();
            if (conf == null)
            {
                throw new Exception("Config Failed");
            }
            Configuration = conf;
        }
        
        /// //////////////////////////////
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ConfigureServices(); //call this function to access the data set from the appsetings.json
            //var connectionString = $"Data Source={DB_SOURCE};Initial Catalog={DB_NAME};Integrated Security=True;Encrypt=False; Trust Server Certificate=True";
            var connectionString = Configuration["connectionString"];

            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer($"")
        }
    }
}
