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
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection! Try again! \n");
                        break;
                }
            }

            void addContact()
            {
                try
                {
                    Console.WriteLine("Enter all information for New Contact \n");
                    Console.Write("First Name: ");
                    firstName = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(firstName)) {
                        throw new ArgumentException("First name cannot be blank");
                    }

                    Console.Write("Last Name: ");
                    lastName = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(lastName))
                    {
                        throw new ArgumentException("Last name cannot be blank");
                    }

                    Console.Write("E-mail address: ");
                    email = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(email))
                    {
                        throw new ArgumentException("Email cannot be blank");
                    }

                    Console.Write("Phone Number: ");
                    phoneNumber = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(phoneNumber))
                    {
                        throw new ArgumentException("Phone number cannot be blank");
                    }

                    Console.Write("Day of Birth: ");
                    birthDay = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.Write("Month of Birth: ");
                    birthMonth = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.Write("Year of Birth: ");
                    birthYear = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.WriteLine();

                    contact[counter] = new Contacts(firstName, lastName, email, phoneNumber, birthDay, birthMonth, birthYear);
                    counter++;

                    Console.WriteLine("Contact added to the list! \n");
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nUSER ERROR: {ex.Message}\n");
                }
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
                Console.WriteLine("Contact finder - Enter the information: \n");
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
                        Console.WriteLine($"{contact[i].ToInfo()} \n");
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nContact NOT found: \n");
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                    }
                }

            }

            void deleteContact()
            {
                string userConfirmation;
                Console.WriteLine("Delete Contact - Enter the information: ");
                Console.WriteLine();
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();

                for (int i = 0; i < counter; i++)
                {
                    if (contact[i].GetFirstName().Equals(firstName, StringComparison.OrdinalIgnoreCase) && (contact[i].GetLasttName().Equals(lastName, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("\nContact found! \n");
                        Console.WriteLine("Are you sure that you want to delete it?");
                        Console.WriteLine("Type yes or y to confirm, any other key to cancel?");
                        userConfirmation = Console.ReadLine().ToLower();
                        if (userConfirmation == "yes" || userConfirmation == "y")
                        {
                            if ((i + 1) <= counter)
                            {
                                contact[i] = contact[i + 1]; //concept borrowed from JS assigment 3
                                counter--;
                                //something is making it loop again
                            }
                            else
                            {
                                counter--;
                                Console.WriteLine("\nContact deleted\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nYou have chosen to cancel\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nContact NOT found: \n");
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                    }
                }


            }

        }
    }
}
