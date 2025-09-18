using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLib
{
    public interface IDBLayer
    {
        List<Employee> GetAllEmployees();
        Employee FindEmployeeById(int empId);

        void InsertEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
    }
    public class EmployeeDB1 : IDBLayer
    {
        //const string STRCONNECTION = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FNFTraining;Integrated Security=True;Encrypt=False";
        readonly string STRCONNECTION = ConfigurationManager.ConnectionStrings["connectionConfig"].ConnectionString;
        const string STRSELECTALL = "Select * from Employee";
        const string STRSELECTBYID = "Select * from Employee where EmpId = @EmpId";

        public  List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(STRSELECTALL, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("No records found in the database.");
                }
                while (reader.Read())
                {
                    var emp = new Employee
                    {
                        EmpId = (int)reader["EmpId"],
                        EmpName = reader["EmpName"].ToString(),
                        EmpAddress = reader["EmpAddress"].ToString(),
                        EmpSalary = (decimal)reader["EmpSalary"],
                        DeptId = (int)reader["DeptId"]
                    };
                    list.Add(emp);
                }
            }
            catch
            {
                throw new Exception("An error occurred while fetching employee data from the database.");
            }
            return list;
        }

        public Employee FindEmployeeById(int empId)
        {
            Employee emp = null;
            using (var con = new SqlConnection(STRCONNECTION))
            using (var cmd = new SqlCommand(STRSELECTBYID, con))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        emp = new Employee
                        {
                            EmpId = (int)reader["EmpId"],
                            EmpName = reader["EmpName"].ToString(),
                            EmpAddress = reader["EmpAddress"].ToString(),
                            EmpSalary = (decimal)reader["EmpSalary"],
                            DeptId = (int)reader["DeptId"]
                        };
                    }
                }
                catch
                {
                    throw new Exception("An error occurred while fetching employee by ID from the database.");
                }
            }
            return emp;
        }

        public void InsertEmployee(Employee emp)
        {
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand("InsertEmp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure; // Assuming you are using a stored procedure
            int generatedId = 0; // Variable to hold the generated ID
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
            cmd.Parameters.AddWithValue("@generatedEmpId", generatedId).Direction = System.Data.ParameterDirection.Output; // Assuming the stored procedure returns the generated ID
            try
            {
                con.Open();
                _ = cmd.ExecuteNonQuery();// ExecuteNonQuery is used for INSERT, UPDATE, DELETE commands
                generatedId = (int)cmd.Parameters["@generatedEmpId"].Value; // Retrieve the generated ID
                emp.EmpId = generatedId; // Set the generated ID to the employee object
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

        public void UpdateEmployee(Employee emp)
        {
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand("UpdateEmp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empId", emp.EmpId);
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
            try
            {
                con.Open();
                _ = cmd.ExecuteNonQuery();
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

        public void DeleteEmployee(int id)
        {
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand("Delete from Employee where Empid=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("No record found to delete.");
                }
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

        

        //public class GetAllEmployees : List<Employee>
        //{
        //}
    }
    public enum SqlQueryType
    {
        Query, Insert, Update, Delete
    }
    public static class SqlData
    {
        public static DataTable ExecuteQuery(string commandText, params SqlParameter[] parameters)
        {
            string strCon = ConfigurationManager.ConnectionStrings["connectionConfig"].ConnectionString;
            using (var con = new SqlConnection(strCon))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    foreach (var pm in parameters)
                    {
                        cmd.Parameters.Add(pm);
                    }
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var table = new DataTable("Data");
                    table.Load(reader);
                    con.Close();
                    return table;
                }
            }
        }
        public static void ExecuteNonQuery(SqlQueryType queryType, string commandText, params SqlParameter[] parameters)
        {
            string strCon = ConfigurationManager.ConnectionStrings["connectionConfig"].ConnectionString;
            using (var con = new SqlConnection(strCon))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    foreach (var pm in parameters)
                    {
                        cmd.Parameters.Add(pm);
                    }
                    con.Open();
                    if (queryType != SqlQueryType.Query)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }
    }
}
