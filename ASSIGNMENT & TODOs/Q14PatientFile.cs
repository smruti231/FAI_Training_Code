using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    using MyAssignment1.Models1;
    using System.Collections.Generic;
    using System.IO;

    class Q14PatientFile
        {
        const string filename = "PatientData.csv";

        static void Main(string[] args)
            {
            //var emp = new Models2.Employee();
            //emp.EmpId = Utilities.GetInteger("Enter the Id");
            //emp.EmpName = Utilities.GetString("Enter the Name");
            //emp.EmpAddress = Utilities.GetString("Enter the Address");
            //emp.EmpSalary = Utilities.Getdouble("Enter the Salary");
            //writeEmpRecordToFile(emp);
            int id = Utilities.GetInteger("Enter the Id of the record to delete");
            deleteRecordFromFile(id);
            }

        private static void deleteRecordFromFile(int id)
            {
            var records = readAllRecords(filename);
            for (int i = 0; i < records.Count; i++)
                {
                if (records[i].PatientId == id)
                    {
                    records.RemoveAt(i);
                    break;
                    }
                }
            File.Delete(filename);
            bulkInsertRecords(records);
            }
        private static void bulkInsertRecords(List<Models1.Patient> records)
            {
            foreach (var emp in records)
                {
                writeEmpRecordToFile(emp);
                }
            }

        private static List<Models1.Patient> readAllRecords(string filename)
            {
            //Create a blank List<Employee>....
            List<Models1.Patient> patList = new List<Models1.Patient>();
            //Get all the lines. 
            string[] lines = File.ReadAllLines(filename);
            //Iterate each line and split the line into words. 
            foreach (string line in lines)
                {
                string[] words = line.Split(',');
                //1st Word is id, and .....
                //Create the Emp object and set the values from the words taken
                var emp = new Models1.Patient
                    {
                    PatientId = int.Parse(words[0]),
                    PatientName = words[1],
                    Contact = (int)long.Parse(words[2]),
                    BillAmount = (int)double.Parse(words[3])
                    };
                //Add the obj to the List collection
                patList.Add(emp);
                }
            return patList;
            }

        private static void writeEmpRecordToFile(Models1.Patient pat)
            {
            var line = $"{pat.PatientId},{pat.PatientName},{pat.Contact},{pat.BillAmount}\n";
            File.AppendAllText(filename, line);
            Console.WriteLine("Data Saved to the file");
            }

        private static void readAllContents(string filename)
            {
            var content = File.ReadAllText(filename);
            Console.WriteLine(content);
            }
        }
    }