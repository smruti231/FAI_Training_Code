using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.Models1
    {

    class PatientListDatabase : IPatientDatabase
        {
        private List<Patient> patient = new List<Patient>();
        
        //Indexer to access employees by Index
        public Patient this[int index] => patient[index];

        //Count property to get the number of employees
        public int Count => patient.Count;

        public void AddPatient(Patient pat) => patient.Add(pat);

        public void DeletePatient(int id)
            {
            foreach (var pat in patient)
                {
                if (pat.PatientId == id)
                    {
                    patient.Remove(pat);
                    return;
                    }
                }
            throw new Exception("No Employee found to Delete");
            }
        public IEnumerator GetEnumerator()
            {
            //It gets each object at a time when its executed in a foreach statement. 
            return patient.GetEnumerator();
            }
        public void UpdatePatient(int id, Patient pat)
            {
            foreach (var copy in patient)
                {
                if (copy.PatientId == id)
                    {
                    copy.DeepCopy(pat);
                    return;
                    }
                }
            throw new Exception("No Employee found to update");
            }

        //explicit implementatoin
        IEnumerator<Patient> IEnumerable<Patient>.GetEnumerator()
            {
            foreach (var element in patient)
                yield return element;
            }
        static void Main(string[] args)
            {
            Patient pat = new Patient();
            int id = Utilities.GetInteger("Enter Patient Id to be updated: ");
            //UpdatePatient(id, pat);
            }
        }
    }
