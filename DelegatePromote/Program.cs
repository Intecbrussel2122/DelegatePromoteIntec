using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePromote
{
    //public delegate bool PromoteDelegate(Employee employeeToPromote);
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearExperience { get; set; }
        public double Salary { get; set; }

        //Method with delegate
        public static void PromoteEmployee(List<Employee> employeeList, Func<Employee, bool> promoteDelegate)
        {
            foreach (Employee employee in employeeList)
            {
                if (promoteDelegate(employee))
                {
                    Console.WriteLine($"Employee {employee.Name} promoted ");
                }
            }
        }
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Employee employee1 = new Employee() { Id = 1, Name = "Florian", YearExperience = 2, Salary = 3000.00 };
            Employee employee2 = new Employee() { Id = 2, Name = "Sagar", YearExperience = 3, Salary = 2000.00 };
            Employee employee3 = new Employee() { Id = 3, Name = "Tibo", YearExperience = 4, Salary = 2500.00 };
            Employee employee4 = new Employee() { Id = 4, Name = "Serap", YearExperience = 5, Salary = 3200.00 };
            Employee employee5 = new Employee() { Id = 5, Name = "Fatih", YearExperience = 6, Salary = 3100.00 };
            employees.Add(employee1); employees.Add(employee2); employees.Add(employee3);
            employees.Add(employee4); employees.Add(employee5);


            //using methods in traditional way so no delegates at all 
            //foreach (var item in employees)
            //{
            //    Promote(item);
            //}


            //---------------------------------------------------------


            Employee emp = new Employee();
            //using methods as parameter 
            //Console.WriteLine("PromoteBasedOnExeprience ");
            //Employee.PromoteEmployee(employees, PromoteBasedOnExeprience);
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("PromoteBasedOnSalary");
            //Employee.PromoteEmployee(employees, PromoteBasedOnSalary);

            //using lambdas
            Employee.PromoteEmployee(employees, x => x.Salary < 3000.00);
            Console.WriteLine("");
            Employee.PromoteEmployee(employees, x => x.YearExperience > 4);


            Console.Read();
        }


        // method without delegate
        public static void Promote(Employee employee)
        {
            if (employee.YearExperience > 3)
            {
                Console.WriteLine(employee.Name + " Promoted new salary is " + (employee.Salary += employee.Salary * 0.05));
            }
            else
            {
                Console.WriteLine(employee.Name + " " + " is not promoted");
            }
        }

        // method to be used by delegate
        public static bool PromoteBasedOnExeprience(Employee employee)
        {
            if (employee.YearExperience > 3)
            {
                Console.WriteLine(employee.Name + " " + " new salary is " + (employee.Salary += employee.Salary * 0.05));
                return true;
            }
            else
            {
                Console.WriteLine(employee.Name + " " + " is not promoted");
                return false;
            }
        }

        // method to be used by delegate
        public static bool PromoteBasedOnSalary(Employee employee)
        {

            if (employee.Salary < 3000.00)
            {
                Console.WriteLine(employee.Name + " Promoted new salary is " + (employee.Salary += employee.Salary * 0.05));
                return true;
            }
            else
            {
                Console.WriteLine(employee.Name + " " + " is not promoted");
                return false;
            }
        }

    }
}
