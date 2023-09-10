//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.Serialization.Formatters.Csv;
//using System.Configuration;
//using System.IO;
//using System.Runtime.Serialization;


//namespace MyAssignment1.Models1
//    {
//    class PatBinaryDatabase : IPatientDatabase
//        {
//        List<Patient> _list = new List<Patient>();
//        public Patient this[int index] => throw new NotImplementedException();
//        private readonly string fileName = ConfigurationManager.AppSettings["csvFile"];
//        //To save the _list thru binary serialization...
//        private void save()
//            {
//            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
//            BinaryFormatter fm = new BinaryFormatter();
//            fm.Serialize(fs, _list);
//            fs.Close();
//            }
//        //To load the _list thru binary deserialization...
//        private void load()
//            {
//            if (!File.Exists(fileName))
//                {
//                return;
//                }
//            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
//            CsvFormatter fm = new CsvFormatter();
//            _list = fm.Deserialize(fs) as List<Patient>;
//            fs.Close();
//            }
//        public int Count => throw new NotImplementedException();

//        public void AddPatient(Patient pat)
//            {
//            load();
//            _list.Add(pat);
//            save();
//            }

//        public void DeletePatient(int id)
//            {
//            load();
//            var foundRec = _list.Find(delegate (Patient temp)
//                {
//                    return temp.PatientId == id;
//                    });
//            if (foundRec != null)
//                {
//                _list.Remove(foundRec);
//                }
//            save();
//            }

//        public IEnumerator<Patient> GetEnumerator()
//            {
//            return _list.GetEnumerator();
//            }

//        IEnumerator IEnumerable.GetEnumerator()
//            {
//            return _list.GetEnumerator();
//            }

//        public void UpdatePatient(int id, Patient pat)
//            {
//            throw new NotImplementedException();
//            }
//        }
//    }