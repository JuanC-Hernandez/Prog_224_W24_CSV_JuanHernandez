using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using CsvHelper;
using Prog_224_W24_CSV_JuanHernandez;

namespace Prog_224_W24_CSV_030424
{
    static class CSVExamples
    {

        static string folderPath = @"..\..\..\CSVFiles\";


        // Core Concept
        public static void CSVStringExample()
        {

            string userInformation = "Will,Cram,professor";

            string[] splitInformation = userInformation.Split(",", StringSplitOptions.TrimEntries);



            foreach (var item in splitInformation)
            {
                Console.WriteLine(item);
            }

            string firstName = splitInformation[0];
            string lastName = splitInformation[1];
            string profession = splitInformation[2];

            Faculty will = new Faculty(firstName, lastName, profession);

            Console.WriteLine(will);

        } 

        public static void ReadingACSV()
        {
            string location = $@"{folderPath}Faculty.csv";


            if (File.Exists(location))
            {
                string[] lines = File.ReadAllLines(location);

                foreach (string item in lines)
                {
                    Console.WriteLine(item);
                }

                List<Faculty> faculty = new List<Faculty>();

                foreach (string item in lines)
                {
                    string[] splitLine = item.Split(",", StringSplitOptions.TrimEntries);

                    faculty.Add(new Faculty()
                    {
                        FirstName = splitLine[0],
                        LastName = splitLine[1],
                        Profession = splitLine[2],
                        Senority = int.Parse(splitLine[3])

                    });
                }

                foreach (Faculty professors in faculty)
                {
                    Console.WriteLine(professors);
                }

            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }


        } // ReadACSV

        public static void WritingToACSV()
        {
            string location = @"..\..\..\CSVFiles\FacultyNew.csv";

            string[] strings = new string[]
            {
                "Will,Cram,Two"
            };

            using (StreamWriter sw = new StreamWriter(location, true))
            {
                foreach (string item in strings)
                {
                    sw.WriteLine(item);
                }
            }

        } // Writing to a CSV

        public static void ReadingWithCSVHelper()
        {
            List<Faculty> facultyList = new List<Faculty>();
            string fileName = $@"{folderPath}FacultyCSV.csv";

            using (StreamReader sr = new StreamReader(fileName))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                facultyList = csv.GetRecords<Faculty>().ToList();
            }

            foreach (Faculty item in facultyList)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public static void WritingWithCSVHelper()
        {
            List<Faculty> fac = new List<Faculty>()
            {
                new Faculty()
                {
                    FirstName = "Will",
                    LastName = "Cram",
                    Profession = "CheeseMaker",
                    Senority = 1
                }
            };

            using (var stream = File.Open($@"{folderPath}FacultyCSV.csv", FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(fac);

                        writer.Flush();
                    }
                }
            }
        }

        // Comprehension

        // Creative

    }// end class

} // namespace