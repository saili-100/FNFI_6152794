using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleVBNet
{
    public class ConnectedModel
    //internal class ConnectedModel
    {
        // info about ur server,its database and credentials...
        const string strConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FNFTraining;Integrated Security=True;Encrypt=False";
        const string STRGETALL = "SELECT * FROM Employee";
        const string INSERTCOMMAND = "INSERT INTO EMPLOYEE VALUES (@EmpName,@EmpAddress,@EmpSalary,@ID)";

        static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = strConnectionString;
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = STRGETALL;
            insertingrecordExample();
            try 
            {
                sqlCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    // u shall display all the details in the console>WriteLine.
                    //Console.WriteLine();
                    //Console.WriteLine(reader["EmpName"]);
                    Console.WriteLine($"Employee ID :{reader["EmpId"]}\nEmployee Name :{reader["EmpName"]} \nAddress: {reader["EmpAddress"]} \nSalary: {reader["EmpSalary"]}");

                    Console.WriteLine("--------------------------------------------------");
                    //Console.WriteLine($"Name: {reader[1]}\nAddress:{reader[2]}\nSalary:{reader[3]}\nEmployeeID:{reader[4]}");
                    // can give indexing too. starting from index 1.

                }
            }

            catch (SqlException sqlEx)
            {
                // handle the exception
                Console.WriteLine("Exception occured is" + sqlEx.Message);
            }
            finally
            {
                Console.WriteLine("Connection will be terminating");
                    sqlCon.Close();
                
            }


        }
        public static void insertingrecordExample()
        //private static void insertingrecordExample()
        {
            // todo: Take inputs from the user
            var con = new SqlConnection(strConnectionString);
            var cmd = new SqlCommand(INSERTCOMMAND,con);
            cmd.Parameters.AddWithValue("@EmpName", "Mona Lisa");
            cmd.Parameters.AddWithValue("@EmpAddress", "London");
            cmd.Parameters.AddWithValue("@EmpSalary", 10000);
            cmd.Parameters.AddWithValue("@ID ", 3);

            try
            {
                con.Open();
                _ = cmd.ExecuteNonQuery(); // Insert , delete,update commands are executed using Execute Non Query
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Exception while inserting the record:{sqlEx.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception while inserting the record:{ex.Message}");
            }

            finally
            {
                con.Close();
            }

        }
    }
}
// task is to take empid as input and implement it.
//int empid = int.Parse(Console.ReadLine());
//var con = new SqlConnection(strConnectioString);
//var cmd = con.CreateCommand();
//cmd.CommandText=$"SELECT * FROM EMPLOYEE WHERE EmpID ={empid}";
// try and catch block.