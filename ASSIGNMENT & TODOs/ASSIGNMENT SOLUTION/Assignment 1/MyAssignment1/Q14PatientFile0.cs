using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q14PatientFile0
        {
        const string filename = "PatientData.csv";
        static void Main(string[] args)
            {
            var pat = new Models1.Patient();
            pat.PatientId = Utilities.GetInteger("Enter the Id: ");
            pat.PatientName = Utilities.GetString("Enter the Name: ");
            pat.Contact = Utilities.GetInteger("Enter the contact number: ");
            pat.BillAmount = (int)Utilities.Getdouble("Enter the Bill Amount: ");
            writeEmpRecordToFile(pat);
            }

        private static void writeEmpRecordToFile(Models1.Patient pat)
            {
            var line = $"{pat.PatientId},{pat.PatientName},{pat.Contact},{pat.BillAmount}\n";
            File.AppendAllText(filename, line);
            Console.WriteLine("Data Saved to the file");
            }
        }
    }