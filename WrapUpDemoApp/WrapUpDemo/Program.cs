using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapUpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Shane", LastName = "Le", Email = "shane@gmail.com" },
                new PersonModel{ FirstName = "Jennie", LastName = "Kim", Email = "jennie@gmail.com" },
                new PersonModel{ FirstName = "Sakura", LastName = "Miyawaki", Email = "sakura@gmail.com" },
            };

            List<CarModel> cars = new List<CarModel>
            {
                new CarModel{ Manufacturer = "Lexus", Model = "UX" },
                new CarModel{ Manufacturer = "BMW", Model = "M3" },
                new CarModel{ Manufacturer = "Audi", Model = "R8" },
            };

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PeopleData_BadEntryFound;
            peopleData.SaveToCSV(people, @"C:\Temp\SavedFiles\people.csv");

            DataAccess<CarModel> carsData = new DataAccess<CarModel>();
            carsData.BadEntryFound += CarsData_BadEntryFound;
            carsData.SaveToCSV(cars, @"C:\Temp\SavedFiles\cars.csv");

            Console.ReadLine();
        }

        private static void PeopleData_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry found for { e.FirstName } { e.LastName }");
        }

        private static void CarsData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry found for { e.Manufacturer } { e.Model }");
        }
    }

    public class DataAccess<T> where T: new()
    {
        public event EventHandler<T> BadEntryFound;

        public void SaveToCSV(List<T> items, string filePath)
        {
            List<string> rows = new List<string>(); 
            T entry = new T();
            var cols = entry.GetType().GetProperties(); 
            
            string row = "";
            foreach (var col in cols)
            {
                row += $",{ col.Name }";
            }
            row = row.Substring(1);
            rows.Add(row);

            foreach (var item in items)
            {
                row = "";
                bool badWordDetected = false;

                foreach (var col in cols)
                {
                    string val = col.GetValue(item, null).ToString();

                    badWordDetected = BadWordDetector(val);
                    if (badWordDetected == true)
                    {
                        BadEntryFound?.Invoke(this, item);
                        break;
                    }
                    
                    row += $",{val }";
                }

                if (badWordDetected == false)
                {
                    row = row.Substring(1);
                    rows.Add(row);
                }
            }

            File.WriteAllLines(filePath, rows);
        }

        private bool BadWordDetector(string stringToTest)
        {
            bool output = false;
            string lowerCaseTest = stringToTest.ToLower();

            if (lowerCaseTest.Contains("fuck") || lowerCaseTest.Contains("shit"))
            {
                output = true;
            }

            return output;
        }
    }
}
