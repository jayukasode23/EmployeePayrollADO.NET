using EmployeePayRoll;
using System;

namespace EmployeePyroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the EmployeePayroll porblem in ADO.Net");
            EmployeeRepo employeeRepo = new EmployeeRepo();

            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeName = "Shiv";
            employeeModel.PhoneNumber = "9685632154";
            employeeModel.Address = "134-25-66";
            employeeModel.Department = "Hr";
            employeeModel.Gender = 'M';
            employeeModel.BasicPay = 5400000.00;
            employeeModel.Deductions = 2500.00;
            employeeModel.TaxablePay = 200.00;
            employeeModel.Tax = 300.00;
            //employeeModel.EmployeeID = 1;
            employeeModel.NetPay = 250000.00;
            employeeModel.City = "Hydrabad";
            employeeModel.Country = "India";
            employeeModel.StartDate = DateTime.Now;
            employeeRepo.AddEmployee(employeeModel);
            //employeeRepo.GetAllEmployees();

        }
    }
}