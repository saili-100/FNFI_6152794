////using System;
////using System.IO; // namespace for File IO operations

////namespace SampleConApp
////{
////    internal class FileIOExample
////    {
////        static void Main(string[] args)
////        {
////            var files = Directory.GetFiles("C: \\Users\\6152794\\Desktop\\Saili");
////            foreach (var file in files)
////            {
////                var selected_file = new FileInfo(file);
////                Console.WriteLine($"The Name: {selected_file.Name}, Created on {selected_file.CreationTime}");

////            }
////        }
////    }
////}


using System;
using System.IO;
//namespace for File IO operations. 

namespace SampleConApp
{
    internal class FileIOExample
    {
                static void Main(string[] args)
        {
            var files = Directory.GetFiles("C:\\Users\\6152794\\Desktop\\Saili");
            foreach (var file in files)
            {
                var selected_file = new FileInfo(file);
                Console.WriteLine($"The Name: {selected_file.Name}, Created on {selected_file.CreationTime}");

            }
            Console.WriteLine("Displaying Directories and its Info");
            var directorys = Directory.GetDirectories("C:\\Users\\6152794\\Desktop");
            foreach (var dirPath in directorys)
            {
                var dir = new DirectoryInfo(dirPath);
                Console.WriteLine(dir.Name);
            }

            var newDir = "C:\\Users\\6152794\\Desktop\\Saili\\TestDir";
            var dirInfo = Directory.CreateDirectory(newDir);
            var parent = dirInfo.Parent;
            foreach (var dir_path in directorys)
            {
                var info = new DirectoryInfo(dir_path);
                foreach (var file in info.GetFiles())
                {
                    Console.WriteLine(file.Name);
                }
            }
            creatingCsvFile();
        }

        private static void creatingCsvFile()
        {
            var customer = new Customer
                        {
                CustomerId = 100 ,CustomerName = "Saili",BillAmount = 10000
            };
            var filePath = "C:\\Users\\6152784\\Desktop\\Saili";
            var content = $"{customer.CustomerId},{customer.CustomerName},{customer.BillAmount}\n";
            File.WriteAllText(filePath, content); // writes to the file,if the file doesn't exist it shall create the file and write to it, if the file exists,it shall overwrite the contents.

        }
        class Customer//Entity class
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public double BillAmount { get; set; }
        }

        private static void ReadingCSVFile()
        {
            var filePath = "C:\\Users\\6152794\\Desktop\\Saili";
            if (File.Exists(filePath))
            {
                var content = File.ReadAllText(filePath);
                var parts = content.Split(',');
                if (parts.Length == 3)
                {
                    var customer = new Customer
                    {
                        CustomerId = int.Parse(parts[0]),
                        CustomerName = parts[1],
                        BillAmount = double.Parse(parts[2])
                    };
                    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.CustomerName}, Bill Amount: {customer.BillAmount}");
                }
                else
                    {
                        Console.WriteLine("Invalid CSV format.");
                    }

            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}





