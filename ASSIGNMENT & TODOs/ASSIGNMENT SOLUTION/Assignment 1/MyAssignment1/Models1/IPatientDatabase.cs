using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.Models1
    {
    interface IPatientDatabase : IEnumerable<Patient>
        {
        void AddPatient(Patient pat);
        void UpdatePatient(int id, Patient pat);
        void DeletePatient(int id);
        int Count { get; }

        Patient this[int index] { get; }

        }
    }