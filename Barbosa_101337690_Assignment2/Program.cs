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
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.dayOfBirth = dayOfBirth;
            this.monthOfBirth = monthOfBirth;
            this.yearOfBirth = yearOfBirth;
        }

        //all names had to be first letter capitalized unless I would get a warning. So, I had to digress from the UML
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
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
            return $"Name: {GetFullName()}\nPhone Number: {GetPhone()}\nEmail: {email}\nDate of Birth: {GetDateOfBirth()}";
        }
    }


    class MainProgram
    {
        public static void Main(string[] args)
        {
            //declarations
            string uFirstName;
            string uLastName;
            string uEmail;
            string uPhoneNumber;
            int uBirthDay;
            int uBirthMonth;
            int uBirthYear;
            int contactsSize = 100;
            int counter = 0;
            Contacts[] contact = new Contacts[contactsSize];
            int userChoice = 0;

            //menu loop
            do
            {
                Console.Clear();
                Console.WriteLine("Assigment2 - Contact Manager:\n");
                Console.WriteLine("Select one of the options:\n");
                Console.WriteLine("1) Add Contact");
                Console.WriteLine("2) View Contact List");
                Console.WriteLine("3) View a Contact");
                Console.WriteLine("4) Delete Contact");
                Console.WriteLine("5) Exit \n");
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
                                Console.WriteLine("Do you wish to continue?\n");
                                Console.WriteLine("Y or Yes to continue, any other key to stop\n");
                                addNew = Console.ReadLine().ToLowerInvariant();
                                Console.WriteLine();

                            } while (addNew == "yes" || addNew == "y");
                        }
                        else
                        {
                            Console.WriteLine("ALERT: Contact list is full \n");
                            Console.WriteLine("Press enter to return to menu\n");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (counter == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("ALERT: The contact list is empty \n");
                            Console.WriteLine("Press enter to return to menu \n");
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
                    case 4:
                        deleteContact();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Thank you for using this COMP1202 Assignment Program");
                        Console.WriteLine("\nMade by Otavio Barbosa");
                        Console.WriteLine("\nStudent ID: 101337690");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection! Try again! \n");
                        break;
                }
            } while (userChoice != 5);

            void addContact()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter all information for New Contact ");
                    Console.Write("\nFirst Name: ");
                    uFirstName = Console.ReadLine().ToString();
                    if (String.IsNullOrEmpty(uFirstName))
                    {
                        throw new ArgumentException("First name cannot be blank");
                    }

                    Console.Write("\nLast Name: ");
                    uLastName = Console.ReadLine().ToString();
                    if (String.IsNullOrEmpty(uLastName))
                    {
                        throw new ArgumentException("Last name cannot be blank");
                    }

                    Console.Write("\nE-mail address: ");
                    uEmail = Console.ReadLine().ToString();
                    if (String.IsNullOrEmpty(uEmail))
                    {
                        throw new ArgumentException("Email cannot be blank");
                    }

                    Console.Write("\nPhone Number: ");
                    uPhoneNumber = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(uPhoneNumber))
                    {
                        throw new ArgumentException("Phone number cannot be blank");
                    }

                    Console.Write("\nDay of Birth: ");
                    uBirthDay = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.Write("\nMonth of Birth: ");
                    uBirthMonth = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.Write("\nYear of Birth: ");
                    uBirthYear = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.WriteLine();

                    contact[counter] = new Contacts(uFirstName, uLastName, uEmail, uPhoneNumber, uBirthDay, uBirthMonth, uBirthYear);
                    counter++;

                    Console.Clear();
                    Console.WriteLine("Contact added to the list! \n");


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nUSER ERROR: {ex.Message}\n");
                }
            }

            void displayContactList()
            {
                Console.Clear();
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
                Console.Clear();
                bool found = false;
                Console.WriteLine("Contact finder - Enter the information:");
                Console.Write("\nFirst Name: ");
                uFirstName = Console.ReadLine().ToString();
                Console.Write("\nLast Name: ");
                uLastName = Console.ReadLine().ToString();

                for (int i = 0; i < counter; i++)
                {
                    // You got to love Microsoft documentation:
                    if (contact[i].GetFirstName().Equals(uFirstName, StringComparison.OrdinalIgnoreCase) && (contact[i].GetLastName().Equals(uLastName, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.Clear();
                        Console.WriteLine("Contact found: \n");
                        Console.WriteLine($"{contact[i].ToInfo()} \n");
                        found = true;
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        found = false;
                    }  
                }
                if (!found)
                {
                    Console.WriteLine("\nContact NOT found! \n");
                }
            }

            void deleteContact()
            {
                Console.Clear();
                Console.WriteLine("Delete Contact - Enter the information: ");
                Console.WriteLine();
                Console.Write("\nFirst Name: ");
                uFirstName = Console.ReadLine().ToString();
                Console.Write("\nLast Name: ");
                uLastName = Console.ReadLine().ToString();
                bool found = false;

                for (int i = 0; i < counter; i++)
                {
                    if (contact[i].GetFirstName().Equals(uFirstName, StringComparison.OrdinalIgnoreCase) && (contact[i].GetLastName().Equals(uLastName, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (i + 1 <= counter)
                        {
                            contact[i] = contact[i + 1]; //concept borrowed from COMP1231 assignment 3
                            counter--;
                        }
                        else
                        {
                            counter--;
                        }
                        found = true;
                        Console.WriteLine("\nContact deleted\n");
                        break;
                    }
                    else
                    {
                        found = false;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("\nContact NOT found!\n");
                }

            }

        }
    }
}