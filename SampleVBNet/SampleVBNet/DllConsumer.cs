using SampleLib;
using System;
using System.Data.SqlClient;
using EmployeeDB1 = SampleLib.EmployeeDB1;

namespace SampleVBNet
{
    //internal class DLLConsumer
    //{
    //    static void Main(string[] args)
    //    {
    //        var mathComponenet = new MathClass { FirstValue = 10, SecondValue = 5 };
    //        var resultAdd = mathComponenet.Add();
    //        Console.WriteLine($"Addition Result: {resultAdd}");

    //        var resultSubtract = mathComponenet.Subtract();
    //        Console.WriteLine($"Subtraction Result: {resultSubtract}");

    //        var resultMultiply = mathComponenet.Multiply();
    //        Console.WriteLine($"Multiplication Result: {resultMultiply}");

    //        try
    //        {
    //            var resultDivide = mathComponenet.Divide();
    //            Console.WriteLine($"Division Result: {resultDivide}");
    //        }
    //        catch (DivideByZeroException ex)
    //        {
    //            Console.WriteLine($"Error: {ex.Message}");
    //        }

    //        var resultSquareRoot = mathComponenet.SquareRoot();
    //        Console.WriteLine($"Square Root Result: {resultSquareRoot}");

    //        var resultSquare = mathComponenet.Square();
    //        Console.WriteLine($"Square Result: {resultSquare}");

    //    }
    //}

    internal class DLLConsumer
    {
        const string strConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FNFTraining;Integrated Security=True;Encrypt=False";
        const string STRGETALL = "Select * from Employee";
        static void Main(string[] args)
        {
            FirstEample();
            //GetEmployees();
            //FindEmployee();
            //InsertingRecordEx();
            //InsertUsingStoredProc();
            //UpdateUsingStoredProc();
            //DeleteEmployee();
        }

        private static void DeleteEmployee()
        {
            SampleLib.IDBLayer db = new SampleLib.EmployeeDB1();
            try
            {
                db.DeleteEmployee(1010);
                Console.WriteLine("Employee Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting record: {ex.Message}");
            }
        }

        private static void UpdateUsingStoredProc()
        {
            var emp = new Employee
            {
                EmpId = 1011,
                EmpName = "Kane",
                EmpAddress = "New York",
                EmpSalary = 60000,
                DeptId = 2
            };

            SampleLib.IDBLayer db = new SampleLib.EmployeeDB1();
            try
            {
                db.UpdateEmployee(emp);
                Console.WriteLine($"Record Updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting record: {ex.Message}");
            }
        }

        private static void InsertUsingStoredProc()
        {
            var emp = new Employee
            {
                EmpName = "Jane",
                EmpAddress = "New York",
                EmpSalary = 60000,
                DeptId = 2
            };

            SampleLib.IDBLayer db = new SampleLib.EmployeeDB1();
            try
            {
                db.InsertEmployee(emp);
                Console.WriteLine($"Record inserted successfully. The Generated Id is: {emp.EmpId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting record: {ex.Message}");
            }
        }

        private static void InsertingRecordEx()
        {
            var con = new SqlConnection(strConnectionString);
            var cmd = new SqlCommand("Insert into Employee(EmpName,EmpAddress,EmpSalary,DeptId) values(@EmpName,@EmpAddress,@EmpSalary,@DeptId)", con);
            cmd.Parameters.AddWithValue("@EmpName", "John Doe");
            cmd.Parameters.AddWithValue("@EmpAddress", "Chicago");
            cmd.Parameters.AddWithValue("@EmpSalary", 50000);
            cmd.Parameters.AddWithValue("@DeptId", 1);
            try
            {
                con.Open();
                _ = cmd.ExecuteNonQuery();// ExecuteNonQuery is used for INSERT, UPDATE, DELETE commands
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void FindEmployee()
        {
            SampleLib.IDBLayer db = new SampleLib.EmployeeDB1();
            var emp1 = db.FindEmployeeById(1);
            Console.WriteLine($"Id: {emp1.EmpId}\nName: {emp1.EmpName}\nAddress: {emp1.EmpAddress}\nSalary: {emp1.EmpSalary}\nDeptId: {emp1.DeptId}");
        }

        private static SampleLib.IDBLayer GetEmployees()
        {
            SampleLib.IDBLayer db = new SampleLib.EmployeeDB1();
            db = new EmployeeDB1();
            var records = db.GetAllEmployees();
            foreach (var emp in records)
            {
                Console.WriteLine($"Id: {emp.EmpId}\nName: {emp.EmpName}\nAddress: {emp.EmpAddress}\nSalary: {emp.EmpSalary}\nDeptId: {emp.DeptId}");
            }

            return db;
        }

        private static void FirstEample()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = strConnectionString;
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = STRGETALL;
            try
            {
                sqlCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["EmpId"]}\nName: {reader["EmpName"]}\nAddress: {reader["EmpAddress"]}\nSalary: {reader["EmpSalary"]}\n");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}