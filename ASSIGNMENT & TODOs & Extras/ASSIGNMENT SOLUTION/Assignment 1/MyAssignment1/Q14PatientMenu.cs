using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {

    public class Patient
        {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public decimal BillAmount { get; set; }

        public override string ToString()
            {
            return $"{ID},{Name},{PhoneNo},{BillAmount}";
            }
        }

    public class PatientManager
        {
        private const string FilePath = "Patients.csv";

        public void WritePatientDetails(List<Patient> patients)
            {
            using (var writer = new StreamWriter(FilePath))
                {
                foreach (var patient in patients)
                    {
                    writer.WriteLine(patient);
                    }
                }
            }

        public List<Patient> ReadPatientDetails()
            {
            var patients = new List<Patient>();

            if (File.Exists(FilePath))
                {
                foreach (var line in File.ReadLines(FilePath))
                    {
                    var values = line.Split(',');
                    if (values.Length >= 4)
                        {
                        patients.Add(new Patient
                            {
                            ID = Convert.ToInt32(values[0]),
                            Name = values[1],
                            PhoneNo = values[2],
                            BillAmount = Convert.ToDecimal(values[3])
                            });
                        }
                    }
                }

            return patients;
            }
        }

    class Q14PatientMenu
        {
        static void Main(string[] args)
            {
            PatientManager patientManager = new PatientManager();

            bool exit = false;

            while (!exit)
                {
                Console.Clear();
                Console.WriteLine("Patient Management System\n");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Read Patient Details");
                Console.WriteLine("3. Exit");
                Console.Write("\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                    switch (choice)
                        {
                        case 1:
                            AddPatient(patientManager);
                            break;

                        case 2:
                            ReadPatientDetails(patientManager);
                            break;

                        case 3:
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

        static void AddPatient(PatientManager patientManager)
            {
            Console.Clear();
            Console.WriteLine("Add Patient\n");

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

            Console.Write("Enter Phone Number: ");
            string phoneNo = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(phoneNo))
                {
                Console.WriteLine("Phone number cannot be empty.");
                return;
                }

            Console.Write("Enter Bill Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal billAmount) || billAmount < 0)
                {
                Console.WriteLine("Invalid bill amount. Please enter a non-negative number.");
                return;
                }

            var newPatient = new Patient { ID = id, Name = name, PhoneNo = phoneNo, BillAmount = billAmount };

            List<Patient> patients = patientManager.ReadPatientDetails();
            patients.Add(newPatient);

            patientManager.WritePatientDetails(patients);

            Console.WriteLine("Patient added successfully.");
            }

        static void ReadPatientDetails(PatientManager patientManager)
            {
            Console.Clear();
            Console.WriteLine("Read Patient Details\n");

            List<Patient> patients = patientManager.ReadPatientDetails();

            if (patients.Count > 0)
                {
                Console.WriteLine("Patient Details:");
                foreach (var patient in patients)
                    {
                    PrintPatientDetails(patient);
                    }
                }
            else
                {
                Console.WriteLine("No patient details found.");
                }
            }

        static void PrintPatientDetails(Patient patient)
            {
            Console.WriteLine($"ID: {patient.ID}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Phone Number: {patient.PhoneNo}");
            Console.WriteLine($"Bill Amount: {patient.BillAmount:C}\n");
            }
        }
    }