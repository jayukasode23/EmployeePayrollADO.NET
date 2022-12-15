using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace EmployeePayRoll
{
    public class EmployeeRepo
    {
        public static string connectionstring = @"Data Source=DESKTOP-F2Q23RG\SQLEXPRESS;Initial Catalog=EmployeeService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionstring);

        public void GetAllEmployees()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select EmployeeID,EmployeeName, PhoneNumber, Address, Department, Gender, BasicPay, Deductions, TaxablePay, Tax, NetPay, StartDate, City,Country from EmployeePayroll34";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            Console.WriteLine(employeeModel.EmployeeID + " " + employeeModel.EmployeeName);
                            Console.WriteLine("------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Datan found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);

                    //command.Parameters.AddWithValue("@EmployeeID", employeeModel.EmployeeID);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Department", employeeModel.Department);
                    command.Parameters.AddWithValue("@Tax", employeeModel.Tax);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    command.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    command.Parameters.AddWithValue("@City", employeeModel.City);
                    command.Parameters.AddWithValue("@Country", employeeModel.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                this.connection.Close();
            }


        }
    }

}
