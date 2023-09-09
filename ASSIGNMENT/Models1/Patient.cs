using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.Models1
    {
    [Serializable]
    class Patient
        {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public long Contact { get; set; }
        public int BillAmount { get; set; }


        public override int GetHashCode()
            {
            return PatientId;
            }

        public override bool Equals(object obj)
            {
            if (obj is Patient)//is checks if the object is of the type Employee
                {
                var temp = obj as Patient;//Unboxing reference types using as keyword...
                return temp.PatientId == this.PatientId;
                }
            return false;
            }

        public void DeepCopy(Patient other)
            {
            PatientId = other.PatientId;
            PatientName = other.PatientName;
            Contact = other.Contact;
            BillAmount = other.BillAmount;
            }
        }
    class PatientCollection
        {
        private Patient[] _patList;

        public PatientCollection()
            {
            _patList = new Patient[100];
            }

        private Patient deepCopy(Patient pat)
            {
            Patient temp = new Patient();
            temp.PatientId = pat.PatientId;
            temp.PatientName = pat.PatientName;
            temp.Contact = pat.Contact;
            temp.BillAmount = pat.BillAmount;
            return temp;
            }
        public void AddNewPatient(Patient emp)
            {
            for (int i = 0; i < 100; i++)
                {
                if (_patList[i] == null)
                    {
                    _patList[i] = deepCopy(emp);
                    }
                }
            }

        public Patient FindPatient(int id)
            {
            return new Patient { PatientId = 111, PatientName = "Phaniraj", Contact = 7327862425, BillAmount = 56000 };
            }

        public Patient[] FindAllPatients()
            {
            return _patList;
            }

        public void DeletePatient(int id)
            {
            Console.WriteLine("Patient deleted successfully");
            }

        public void UpdatePatient(int id, Patient updatedRec)
            {
            Console.WriteLine("Patient updated successfully");
            }
        }

    class MainClass
        {
        static void Main(string[] args)
            {
            //How to use the class:
            Patient pat = new Patient();
            pat.PatientId = 3;
            pat.PatientName = "Suresh";
            pat.Contact = 8765456789;
            pat.BillAmount = 45000;

            PatientCollection mgr = new PatientCollection();
            mgr.AddNewPatient(pat);

            }
        }
    }
