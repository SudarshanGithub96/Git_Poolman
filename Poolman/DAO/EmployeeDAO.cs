using Microsoft.Extensions.Options;
using Poolman.Interface;
using Poolman.Models;
using System.Data;
using System.Data.SqlClient;

namespace Poolman.DAO
{
    public class EmployeeDAO: IEmployee
    {
        private readonly string _connectionString;

        public EmployeeDAO(IOptions<ConnectionString> connectionString)
        {
            this._connectionString = connectionString.Value.SQLDatabse;
        }

        public int SaveEmployeeData(Employee employee) 
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(this._connectionString))
            {
                string Query = "SP_Add_EmployeeLog";
                SqlCommand cmd= new SqlCommand(Query, con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Firstname", employee.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", employee.Lastname);
                    cmd.Parameters.AddWithValue("@Username", employee.Username);
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(employee.Age));
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", employee.ConfirmPassword);
                    cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@State", employee.State);
                    cmd.Parameters.AddWithValue("@Country", employee.Country);
                    cmd.Parameters.AddWithValue("@Zipcode", Convert.ToInt32(employee.Zipcode));
                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Log or handle SQL exceptions
                    throw new Exception("An error occurred while saving email data.", ex);
                }
                finally
                {
                    // Ensures the connection is closed
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return rowsAffected;
            }
        }
    }
}
