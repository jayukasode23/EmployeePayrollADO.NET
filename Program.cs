using EmployeePayRoll;
using System;

namespace EmployeePyroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Welcome To EmployeePayroll Problem in ADO.Net-------");
            EmployeeRepo employeeRepo = new EmployeeRepo();

            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeName = "Bruce Wayne";
            employeeModel.PhoneNumber = "9685632154";
            employeeModel.Address = "Banglore";
            employeeModel.Department = "Hr";
            employeeModel.Gender = 'F';
            employeeModel.BasicPay = 3400000.00;
            employeeModel.Deductions = 2500.00;
            employeeModel.TaxablePay = 200.00;
            employeeModel.Tax = 300.00;
            //employeeModel.EmployeeID = 1;
            employeeModel.NetPay = 250000.00;
            employeeModel.City = "Banglore";
            employeeModel.Country = "India";
            employeeModel.StartDate = DateTime.Now;
            employeeRepo.AddEmployee(employeeModel);
            //employeeRepo.GetAllEmployees();

        }
    }
}