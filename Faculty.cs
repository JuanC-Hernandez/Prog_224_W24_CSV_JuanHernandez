using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_224_W24_CSV_JuanHernandez
{
    internal class Faculty
    {
        string _firstName;
        string _lastName;
        string _profession;
        int _senority;

        public Faculty()
        {
        }

        public Faculty(string firstName, string lastName, string profession, int senority)
        {
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;
            Senority = senority;
        }

        public Faculty(string firstName, string lastName, string profession)
        {
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;

        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Profession { get => _profession; set => _profession = value; }
        public int Senority
        {
            get => _senority;
            set
            {
                if (value >= 0 && value < 80)
                {
                    _senority = value;
                }
                else
                {
                    throw new Exception("Please enter a valid senority");
                }
            }
        } // Senority

        public string DisplayVacationTime()
        {
            int time = 0;

            if (Senority < 3)
            {
                time = 1;
            }
            else if (Senority >= 3 && Senority <= 10)
            {
                time = 2;
            }
            else
            {
                time = 4;
            }

            return $"Vaction Time: {time} weeks";
        }
        public override string ToString()
        {
            return $"First Name: {_firstName}\n" +
                $"Last Name: {_lastName}\n" +
                $"Profession: {_profession}\n" +
                $"{DisplayVacationTime()}\n";
        }

    }
}
