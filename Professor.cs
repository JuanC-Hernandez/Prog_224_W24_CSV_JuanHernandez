using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_224_W24_CSV_JuanHernandez
{
    internal class Professor
    {
        string _firstName;
        string _lastName;
        string _role;

        // To work with CSVHelper, make sure to create a default constructor
        public Professor()
        {

        }

        public Professor(string firstName, string lastName, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        // First Name = ""

        public string FirstName
        {
            get => _firstName;
            set
            {
                // if the value is not an empty string
                if (!value.Equals(""))
                {
                    _firstName = value;
                }
                else
                {
                    throw new Exception("Please enter a valid first name");
                }
            }
        } // FirstName

        public string LastName { get => _lastName; set => _lastName = value; }
        public string Role { get => _role; set => _role = value; }

        public override string ToString()
        {
            return $"First Name: {FirstName}\n" +
                $"Last Name: {LastName}\n" +
                $"Role: {Role}\n";
        }
    }
}
