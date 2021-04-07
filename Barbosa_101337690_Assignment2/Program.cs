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
            int userChoice = 0;
            string val;

            //menu loop
            while (userChoice != 5)
            {
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
                Console.Write("Your choice from 1 to 5: ");
                userChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                //menu selections

                switch (userChoice)
                {
                    case 1:
                        if (limit < contactsSize)
                        {
                            Console.WriteLine("Enter all information for New Contact ");
                            Console.WriteLine();
                            Console.Write("First Name: ");
                            firstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            lastName = Console.ReadLine();
                            Console.Write("E-mail address: ");
                            email = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            phoneNumber = Console.ReadLine();
                            Console.Write("Day of Birth: ");
                            birthDay = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Month of Birth: ");
                            birthMonth = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Year of Birth: ");
                            birthYear = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            ct[limit] = new Contacts(firstName, lastName, email, phoneNumber, birthDay, birthMonth, birthYear);
                            limit++;
                            Console.WriteLine("Contact added to the list");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("ALERT: Contact list is full");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (limit == 0)
                        {
                            Console.WriteLine("ALERT: The contact list is empty");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("The full contact list is:");
                            for (int i = 0; i < limit; i++)
                            {
                                Console.WriteLine($"\nContact {i}) {ct[i].GetFullName()}");
                            }
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        break;
                }
            }



            // Contacts allContacts = new Contacts(firstName, lastName, email, phoneNumber, birthDay, birthMonth, birthYear);

        }
    }
}
