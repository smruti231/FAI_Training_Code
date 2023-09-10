using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Customer
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        }
    class CustomerRepo
        {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
            {
            customers.Add(customer);
            }

        public bool RemoveCustomer(int id)
            {
            Customer customer = FindCustomerById(id);
            if (customer != null)
                {
                customers.Remove(customer);
                return true;
                }
            return false;
            }

        public bool UpdateCustomer(Customer customer)
            {
            Customer existingCustomer = FindCustomerById(customer.Id);
            if (existingCustomer != null)
                {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                return true;
                }
            return false;
            }

        public Customer FindCustomerById(int id)
            {
            return customers.Find(customer => customer.Id == id);
            }

        public List<Customer> GetAllCustomers()
            {
            return customers;
            }
        }

    class UI
        {
        private CustomerRepo customerRepo = new CustomerRepo();

        public void Start()
            {
            while (true)
                {
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Remove Customer");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Find Customer by ID");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                    switch (choice)
                        {
                        case 1:
                            AddCustomer();
                            break;
                        case 2:
                            RemoveCustomer();
                            break;
                        case 3:
                            UpdateCustomer();
                            break;
                        case 4:
                            FindCustomerById();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                        }
                    }
                else
                    {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }

        private void AddCustomer()
            {
            Console.Write("Enter Customer ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                {
                if (customerRepo.FindCustomerById(id) != null)
                    {
                    Console.WriteLine("Customer with the same ID already exists.");
                    return;
                    }

                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Customer Email: ");
                string email = Console.ReadLine();

                Customer customer = new Customer { Id = id, Name = name, Email = email };
                customerRepo.AddCustomer(customer);
                Console.WriteLine("Customer added successfully.");
                }
            else
                {
                Console.WriteLine("Invalid input for Customer ID.");
                }
            }

        private void RemoveCustomer()
            {
            Console.Write("Enter Customer ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                {
                if (customerRepo.RemoveCustomer(id))
                    {
                    Console.WriteLine("Customer removed successfully.");
                    }
                else
                    {
                    Console.WriteLine("Customer not found.");
                    }
                }
            else
                {
                Console.WriteLine("Invalid input for Customer ID.");
                }
            }

        private void UpdateCustomer()
            {
            Console.Write("Enter Customer ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                {
                Customer existingCustomer = customerRepo.FindCustomerById(id);
                if (existingCustomer != null)
                    {
                    Console.Write("Enter new Customer Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter new Customer Email: ");
                    string email = Console.ReadLine();

                    Customer updatedCustomer = new Customer { Id = id, Name = name, Email = email };
                    if (customerRepo.UpdateCustomer(updatedCustomer))
                        {
                        Console.WriteLine("Customer updated successfully.");
                        }
                    else
                        {
                        Console.WriteLine("Failed to update customer.");
                        }
                    }
                else
                    {
                    Console.WriteLine("Customer not found.");
                    }
                }
            else
                {
                Console.WriteLine("Invalid input for Customer ID.");
                }
            }

        private void FindCustomerById()
            {
            Console.Write("Enter Customer ID to find: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                {
                Customer customer = customerRepo.FindCustomerById(id);
                if (customer != null)
                    {
                    Console.WriteLine($"Customer ID: {customer.Id}");
                    Console.WriteLine($"Customer Name: {customer.Name}");
                    Console.WriteLine($"Customer Email: {customer.Email}");
                    }
                else
                    {
                    Console.WriteLine("Customer not found.");
                    }
                }
            else
                {
                Console.WriteLine("Invalid input for Customer ID.");
                }
            }
        }


    class Q12Customer
        {
        static void Main(string[] args)
            {
            UI ui = new UI();
            ui.Start();

            }
        }
    }
