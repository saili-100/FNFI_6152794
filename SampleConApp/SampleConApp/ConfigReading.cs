using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.Binder;


namespace SampleConApp
{
    internal class ConfigReading
    {
        public static IConfigurationRoot AppConfig { get; private set; }

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)//Add the json file
                .Build();//Build the configuration
            AppConfig = config; // Store the configuration in a static property for later use
            var appName = config["AppSettings:AppName"]; // Read a specific configuration value
            var title = config["AppSettings:Title"];
            Console.WriteLine($"******* {appName.ToUpper()} *******");
            Console.WriteLine($"******{title.ToUpper()}");
            Console.ReadLine();

            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings); // Bind the configuration section to the AppSettings class. Use Microsoft.Extensions.Configuration.Binder package. This is the widely used approach to read the configuration settings in a strongly typed manner.
            Console.WriteLine(appSettings.Title);
        }
    }
    class AppSettings
    {
        public string AppName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;   
    }
}
