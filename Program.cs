using System.Globalization;
using System.IO;
using CsvHelper;


namespace Prog_224_W24_CSV_JuanHernandez
{

    //Juan Hernandez
    // Lecture Read / Writing CSV files
    // 03/03/23
    internal class Program
    {
        static string folderPath = @"..\..\..\CSVFiles\";
        static string fileName = @"inClassExampleCSVHelper.csv";
        static void Main(string[] args)
        {
            List<Professor> proList = new List<Professor>()
            {
                new Professor()
                {
                    FirstName = "Juan",
                    LastName = "Hernandez",
                    Role = "Student"
                }
            };
            string fullPath = folderPath + fileName;

            // using File.Open
            // using writer
            // using csv Write

            using (var stream = File.Open(fullPath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(proList);

                        writer.Flush();
                    }
                }
            }
        }
        public static void ReadingWithCSVHelper()
        {
            // How to work with an external package

            List<Professor> newListProfessor = new List<Professor>();

            string fullPath = folderPath + fileName;

            // Using 1, StreamReader to read a file
            using (StreamReader sr = new StreamReader(fullPath))
            {
                // CultureInfo.InvariantCulture
                using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    newListProfessor = csv.GetRecords<Professor>().ToList();
                }
            }

            foreach (Professor item in newListProfessor)
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

        // ------------------------------

        public static void ReadingFromACsv()
        {
            // File.Exists() returns a bool

            string fullPath = folderPath + "inClassExample.csv";

            if (File.Exists(fullPath))
            {
                // Contains an array of every line in our csv
                // File.ReadAllLines()
                string[] lines = File.ReadAllLines(fullPath);

                List<Professor> professors = new List<Professor>();

                foreach (string item in lines)
                {
                    string[] professorFields = item.Split(",", StringSplitOptions.TrimEntries);
                    string firstName = professorFields[0];
                    string lastName = professorFields[1];
                    string role = professorFields[2];

                    professors.Add(new Professor(firstName, lastName, role));

                }

                foreach (Professor fessor in professors)
                {
                    Console.WriteLine(fessor);
                }

            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            // --------------------------------------------------------------


        }

        public static void SavingToACSV()
        {

            string[] csvStrings = new string[]
{
                "Lisa,Cai,Professor",
                "Juan,Hernandez,Professor",
                "Matthew,Vargas,Professor"
};

            // String literal = $
            // Verbatium String = @


            // "..\..\..\inClassExample.csv"

            // is it frowned upon if I just type the whole file location?

            using (StreamWriter sw = new StreamWriter(folderPath + "inClassExample.csv", false))
            {
                foreach (string item in csvStrings)
                {
                    sw.WriteLine(item);
                }
            } // end using
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

        public static void CSVExample()
        {
            // CSV
            // Comma Seperate Value

            string csvString = "Will,Cram,Professor";

            string[] csvStrings = new string[]
            {
                "Lisa,Cai,Professor",
                "Juan,Hernandez,Professor",
                "Matthew,Vargas,Professor"
            };

            // string.Split()
            // Split the string

            List<Professor> professors = new List<Professor>();

            foreach (string csv in csvStrings)
            {
                string[] splitString = csv.Split(",", StringSplitOptions.TrimEntries);


                string firstName = splitString[0];
                string lastName = splitString[1];
                string role = splitString[2];

                Professor newProfessor = new Professor(firstName, lastName, role);

                professors.Add(newProfessor);

            } // After the loop

            foreach (Professor professor in professors)
            {
                Console.WriteLine(professor);
            }





        }


        
    } 
}

