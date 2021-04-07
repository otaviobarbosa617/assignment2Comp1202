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
            int counter = 0;
            Contacts[] contact = new Contacts[contactsSize];
            int userChoice = 0;

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
                userChoice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //menu selections

                switch (userChoice)
                {
                    case 1:
                        if (counter < contactsSize)
                        {
                            string addNew;
                            do
                            {
                                addContact();
                                addNew = Console.ReadLine();
                                Console.WriteLine();

                            } while (addNew == "yes" || addNew == "Y" || addNew == "y");
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
                        if (counter == 0)
                        {
                            Console.WriteLine("ALERT: The contact list is empty");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to return to menu");
                            Console.ReadKey();
                        }
                        else
                        {
                            displayContactList();
                        }
                        break;
                    case 3:
                        findContact();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection! Try again!");
                        Console.WriteLine();
                        break;
                }
            }

            void addContact()
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
                birthDay = int.Parse(Console.ReadLine());
                Console.Write("Month of Birth: ");
                birthMonth = int.Parse(Console.ReadLine());
                Console.Write("Year of Birth: ");
                birthYear = int.Parse(Console.ReadLine());
                Console.WriteLine();
                contact[counter] = new Contacts(firstName, lastName, email, phoneNumber, birthDay, birthMonth, birthYear);
                counter++;
                Console.WriteLine("Contact added to the list!");
                Console.WriteLine();
                Console.WriteLine("Do you wish to continue?");
                Console.WriteLine("Y or Yes to continue, any other key to stop");
            }

            void displayContactList()
            {
                Console.WriteLine("The full contact list is:");
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine($"\nContact #{i + 1} - {contact[i].GetFullName()}");
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to return to menu");
                Console.ReadKey();
            }

            void findContact()
            {
                Console.WriteLine("Contact finder - Enter the information");
                Console.WriteLine();
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
                for (int i = 0; i < counter; i++)
                {
                    // You got to love Microsoft documentation:
                    if (contact[i].GetFirstName().Equals(firstName, StringComparison.OrdinalIgnoreCase) && (contact[i].GetLasttName().Equals(lastName, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("\nContact found: \n");
                        Console.WriteLine($"{contact[i].ToInfo()}");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nContact NOT found: \n");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                    }
                }

            }

        }
    }
}
