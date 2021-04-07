using System;

namespace Barbosa_101337690_Assignment2
{
    class Contacts
    {
        //declarations
        private string firstName;
        private string lastName;
        private string phone;
        private string email;
        private int dayOfBirth;
        private int monthOfBirth;
        private int yearOfBirth;

        //Object
        public Contacts(string firstName, string lastName, string phone, string email, int dayOfBirth, int monthOfBirth, int yearOfBirth)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.phone = phone ?? throw new ArgumentNullException(nameof(phone));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.dayOfBirth = dayOfBirth;
            this.monthOfBirth = monthOfBirth;
            this.yearOfBirth = yearOfBirth;
        }

        //all names had to be first letter capitalized unless I would get a warning. So, I had to digress from the UML
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLasttName()
        {
            return firstName;
        }

        public string GetFullName()
        {
            return firstName + " " + lastName;
        }

        public string GetPhone()
        {
            return phone;
        }

        public string GetDateOfBirth()
        {
            return dayOfBirth + "-" + monthOfBirth + "-" + yearOfBirth;
        }

        public string ToInfo()
        {
            return $"Name: {GetFullName()}\nPhone Number: {GetPhone()}\nEmail: {email}\nDate of Birth: {GetDateOfBirth()}\n";
        }
    }


    class MainProgram
    {
        public static void Main(string[] args)
        {
            //declarations
            string firstName;
            string lastName;
            string email;
            string phoneNumber;
            int birthDay;
            int birthMonth;
            int birthYear;
            int contactsSize = 100;
            int limit = 0;
            Contacts[] ct = new Contacts[contactsSize];
            int userChoice;
            string val;

            //while (userChoice != 5)
            //{
                Console.WriteLine("Assigment2 - Contact Manager:");
                Console.WriteLine();
                Console.WriteLine("Select one of the options:");
                Console.WriteLine();
                Console.WriteLine("1) Add Contact");
                Console.WriteLine("2) View Contact List");
                Console.WriteLine("3) View a Contact");
                Console.WriteLine("4) Delete Contact");
                Console.WriteLine("5) Exit");
                Console.WriteLine();

            //}

            // Contacts allContacts = new Contacts(firstName, lastName, email, phoneNumber, birthDay, birthMonth, birthYear);

        }
    }
}
