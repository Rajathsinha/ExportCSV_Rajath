using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Database connection string
        //string connectionString = "Server = 600071sqlvm.int.campusnexus.dev; Database = CSVExport; uid = dtladmin; password = Dev_Test_Labs42^ ; Integrated Security = false";
        string connectionString = "Server = 600071sqlvm.int.campusnexus.dev; Database = ExportCSV; uid = dtladmin; password = Dev_Test_Labs42^; Integrated Security = false";

        string query = "SELECT ExternalStudentID, FirstName, LastName, DOB, SSN, Adddress, City, State, Email, MaritalStatus FROM StudentDetails";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {//for path
                    using (StreamWriter file = new StreamWriter(@"C:\students.csv"))
                    {
                        file.WriteLine("ExternalStudentID|FirstName|LastName|DOB|SSN|Adddress|City|State|Email|MaritalStatus");

                        while (reader.Read())
                        {
                            file.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                                reader["ExternalStudentID"],
                                reader["FirstName"],
                                reader["LastName"],
                                reader["DOB"],
                                reader["SSN"],
                                reader["Adddress"],
                                reader["City"],
                                reader["State"],
                                reader["Email"],
                                reader["MaritalStatus"]);
                        }
                    }
                }
            }
        }

        Console.WriteLine("Export complete.");
        Console.ReadLine();
    }
}
