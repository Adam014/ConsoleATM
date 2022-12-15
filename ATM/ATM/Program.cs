using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        public static void Main(string[] args)
        {

            void printOptions(cardHolder currentUser)
            {
                Console.WriteLine("Please choose from on of the following options...");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Show UserInfo");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("5. Exit");
                Console.WriteLine("----------------------------------------");
                Console.Write("Your option: ");
                string option = "";

                do
                {
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            Deposit(currentUser);
                            break;
                        case "2":
                            Console.Clear();
                            Withdraw(currentUser);
                            break;
                        case "3":
                            Console.Clear();
                            Balance(currentUser);
                            break;
                        case "4":
                            Console.Clear();
                            userInfo(currentUser);
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("See ya!");
                            Console.ReadKey();
                            Environment.Exit(1);
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Bad input. Please try again.");
                            Console.ResetColor();
                            printOptions(currentUser);
                            break;
                    }
                } while (option != "5");
   
            }

            void Deposit(cardHolder currentUser)
            {
                Console.Write("How much $$ would you like to deposit: ");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit + currentUser.getBalance());
                Console.WriteLine("Thank you for choosing us! Your new balance is: " + currentUser.getBalance());
            }

            void Withdraw(cardHolder currentUser)
            {
                Console.Write("How much $$ would you like to withdraw: ");
                double withdrawal = double.Parse(Console.ReadLine());
                // kontrola jestli uziv. ma dostatek financi 
                if (currentUser.getBalance() < withdrawal)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient balance!");
                    Console.ResetColor();
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("Thank you for choosing us!");
                }
            }

            void Balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }
            
            void userInfo(cardHolder currentUser)
            {
                Console.WriteLine("Firstname: " + currentUser.getFirstName());
                Console.WriteLine("Lastname: " + currentUser.getLastName());
                Console.WriteLine("Balance: " + currentUser.getBalance());
                Console.WriteLine("Card Number: " + currentUser.getNum());
                Console.WriteLine("PIN: " + currentUser.getPin());        
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("234567", 1234, "John", "Jones", 150.31));
            cardHolders.Add(new cardHolder("938123", 8271, "Pavel", "Calta", 106.59));
            cardHolders.Add(new cardHolder("732612", 9127, "Martin", "Bily", 58.21));
            cardHolders.Add(new cardHolder("812351", 4721, "Adam", "Kamen", 10.23));

            //prompt user
            Console.WriteLine("Welcome to TheATM");
            Console.Write("Please enter your debit card: ");
            string debitCardNum = "";
            cardHolder currentUser1;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    // zkontrolovat v db cislo karty
                    currentUser1 = cardHolders.FirstOrDefault(a => a.getNum() == debitCardNum);
                    if (currentUser1 != null) { break; }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Card not recognized. Please try again.");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Card not recognized. Please try again.");
                    Console.ResetColor();
                }
            }

            Console.Write("Please enter your pin: ");
            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    // zkontrolovat v db cislo karty
      
                    if (currentUser1.getPin() == userPin) { break; }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect pin. Please try again.");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect pin. Please try again.");
                    Console.ResetColor();
                }
            }

            Console.Clear();
            Console.WriteLine("Welcome " + currentUser1.getFirstName());
            printOptions(currentUser1);
            


        }
    }

    public class cardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;
        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string getNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }
    }

}
