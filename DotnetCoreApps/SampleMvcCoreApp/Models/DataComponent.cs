using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvcCoreApp.Models
{
    
        [Table("CstTable")]
        public class MyCustomer
        {
            [Key]
            public int CstId { get; set; }

            [Required (ErrorMessage = "Customer Name is Mandatory")]
            public string CstName { get; set; }
            [Required(ErrorMessage = "Customer Address is Mandatory")]
        public string CstAddress { get; set; }
        [Required(ErrorMessage = "Bill amount is Mandatory")]
        public double BillAmount { get; set; }
        }

        public class CstDbContext : DbContext
        {
            public DbSet<MyCustomer> MyCustomers { get; set; }

        //IConfigurationRoot? Configuration { get; set; }

        //private void ConfigureServices()
        //{
        //    var conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false).Build();
        //    if (conf == null)
        //    {
        //        throw new Exception("Config Failed");
        //    }
        //    Configuration = conf;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FNFTraining;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
           // ConfigureServices();
            //var connectionString = Configuration["connectionString"];
            //optionsBuilder.UseSqlServer(connectionString);

            var connectionString = Program.Configuration["ConnectionStrings:myCon"];
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);

        }

       

    }

    }

