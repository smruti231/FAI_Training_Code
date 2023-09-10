using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyAssignment1.Q15MenuEmpPrg
    {
    public class Employee
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        }

    public interface IDataComponent
        {
        void Add(Employee employee);
        void Remove(int id);
        void Update(Employee employee);
        Employee FindByID(int id);
        List<Employee> FindByName(string name);
        }

    public class FileComponent : IDataComponent
        {
        private const string FilePath = "employees.csv";

        public void Add(Employee employee)
            {
            using (var writer = File.AppendText(FilePath))
                {
                writer.WriteLine($"{employee.Id},{employee.Name},{employee.Address},{employee.Salary}");
                }
            }

        public void Remove(int id)
            {
            var linesToKeep = File.ReadLines(FilePath)
                .Where(line => line.Split(',')[0] != id.ToString());

            File.WriteAllLines(FilePath, linesToKeep);
            }

        public void Update(Employee employee)
            {
            var lines = File.ReadAllLines(FilePath);
            using (var writer = new StreamWriter(FilePath))
                {
                foreach (var line in lines)
                    {
                    var values = line.Split(',');
                    if (values.Length >= 4 && Convert.ToInt32(values[0]) == employee.Id)
                        {
                        writer.WriteLine($"{employee.Id},{employee.Name},{employee.Address},{employee.Salary}");
                        }
                    else
                        {
                        writer.WriteLine(line);
                        }
                    }
                }
            }

        public Employee FindByID(int id)
            {
            var line = File.ReadLines(FilePath)
                .FirstOrDefault(l => l.Split(',')[0] == id.ToString());

            if (line != null)
                {
                var values = line.Split(',');
                return new Employee
                    {
                    Id = Convert.ToInt32(values[0]),
                    Name = values[1],
                    Address = values[2],
                    Salary = Convert.ToDecimal(values[3])
                    };
                }
            return null;
            }

        public List<Employee> FindByName(string name)
            {
            var employees = new List<Employee>();

            foreach (var line in File.ReadLines(FilePath))
                {
                var values = line.Split(',');
                if (values.Length >= 4 && values[1].Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                    employees.Add(new Employee
                        {
                        Id = Convert.ToInt32(values[0]),
                        Name = values[1],
                        Address = values[2],
                        Salary = Convert.ToDecimal(values[3])
                        });
                    }
                }
            return employees;
            }
        }

    class Q15MenuEmpPrg
        {
        static void Main(string[] args)
            {
            IDataComponent dataComponent = new FileComponent();
            bool exit = false;

            while (!exit)
                {
                Console.Clear();
                Console.WriteLine("Employee Management System\n");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Find Employee by ID");
                Console.WriteLine("5. Find Employees by Name");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                    switch (choice)
                        {
                        case 1:
                            AddEmployee(dataComponent);
                            break;

                        case 2:
                            RemoveEmployee(dataComponent);
                            break;

                        case 3:
                            UpdateEmployee(dataComponent);
                            break;

                        case 4:
                            FindEmployeeByID(dataComponent);
                            break;

                        case 5:
                            FindEmployeesByName(dataComponent);
                            break;

                        case 6:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                        }
                    }
                else
                    {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                }
            }

        static void AddEmployee(IDataComponent dataComponent)
            {
            Console.Clear();
            Console.WriteLine("Add Employee\n");

            Console.Write("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                Console.WriteLine("Invalid ID. Please enter a positive integer.");
                return;
                }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(name))
                {
                Console.WriteLine("Name cannot be empty.");
                return;
                }

            Console.Write("Enter Address: ");
            string address = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(address))
                {
                Console.WriteLine("Address cannot be empty.");
                return;
                }

            Console.Write("Enter Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary < 0)
                {
                Console.WriteLine("Invalid salary. Please enter a non-negative number.");
                return;
                }

            var newEmployee = new Employee { Id = id, Name = name, Address = address, Salary = salary };
            dataComponent.Add(newEmployee);
            Console.WriteLine("Employee added successfully.");
            }

        static void RemoveEmployee(IDataComponent dataComponent)
            {
            Console.Clear();
            Console.WriteLine("Remove Employee\n");

            Console.Write("Enter ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                Console.WriteLine("Invalid ID. Please enter a positive integer.");
                return;
                }

            var employee = dataComponent.FindByID(id);
            if (employee == null)
                {
                Console.WriteLine("Employee not found.");
                return;
                }

            Console.WriteLine($"Are you sure you want to remove employee {employee.Name}? (Y/N): ");
            if (Console.ReadLine().Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                dataComponent.Remove(id);
                Console.WriteLine("Employee removed successfully.");
                }
            }

        static void UpdateEmployee(IDataComponent dataComponent)
            {
            Console.Clear();
            Console.WriteLine("Update Employee\n");

            Console.Write("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                Console.WriteLine("Invalid ID. Please enter a positive integer.");
                return;
                }

            var existingEmployee = dataComponent.FindByID(id);
            if (existingEmployee == null)
                {
                Console.WriteLine("Employee not found.");
                return;
                }

            Console.WriteLine($"Updating employee: {existingEmployee.Name}\n");

            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(newName))
                {
                Console.WriteLine("Name cannot be empty.");
                return;
                }

            Console.Write("Enter new Address: ");
            string newAddress = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(newAddress))
                {
                Console.WriteLine("Address cannot be empty.");
                return;
                }

            Console.Write("Enter new Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newSalary) || newSalary < 0)
                {
                Console.WriteLine("Invalid salary. Please enter a non-negative number.");
                return;
                }

            var updatedEmployee = new Employee
                {
                Id = existingEmployee.Id,
                Name = newName,
                Address = newAddress,
                Salary = newSalary
                };
            dataComponent.Update(updatedEmployee);
            Console.WriteLine("Employee updated successfully.");
            }

        static void FindEmployeeByID(IDataComponent dataComponent)
            {
            Console.Clear();
            Console.WriteLine("Find Employee by ID\n");

            Console.Write("Enter ID to find: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                Console.WriteLine("Invalid ID. Please enter a positive integer.");
                return;
                }

            var employee = dataComponent.FindByID(id);
            if (employee != null)
                {
                Console.WriteLine("Employee found:");
                PrintEmployeeDetails(employee);
                }
            else
                {
                Console.WriteLine("Employee not found.");
                }
            }

        static void FindEmployeesByName(IDataComponent dataComponent)
            {
            Console.Clear();
            Console.WriteLine("Find Employees by Name\n");

            Console.Write("Enter Name to find: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(name))
                {
                Console.WriteLine("Name cannot be empty.");
                return;
                }

            var employees = dataComponent.FindByName(name);
            if (employees.Count > 0)
                {
                Console.WriteLine($"Employees with the name '{name}':");
                foreach (var employee in employees)
                    {
                    PrintEmployeeDetails(employee);
                    }
                }
            else
                {
                Console.WriteLine("No employees found with the given name.");
                }
            }

        static void PrintEmployeeDetails(Employee employee)
            {
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"Address: {employee.Address}");
            Console.WriteLine($"Salary: {employee.Salary:C}\n");
            }
        }
    }