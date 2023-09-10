using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.Common1
    {
    using MyAssignment1.Models1;
    class PatFactory
        {
        public static IPatientDatabase GetComponent(string type)
            {
            switch (type.ToLower())
                {
                case "list": return new PatientListDatabase();
                //case "csv": return new PatBinaryDatabase();
                default: return new PatientListDatabase(); ;
                }
            }
        }
    }

