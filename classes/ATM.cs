using System.Collections;
using Simple_ATM_Software.interfaces;

namespace Simple_ATM_Software.classes
{
    public class ATM : IATMMenu
    {
        //Fields
        private ArrayList mainMenuList;
        BankCard bankCard;
        //Constructor
        public ATM(BankCard bankCard)
        {
            this.mainMenuList = new ArrayList();
            this.bankCard = bankCard;
            this.SessionId = Guid.NewGuid();
            this.mainMenuList.Add("1. Check Balance");
            this.mainMenuList.Add("2. Deposit");
            this.mainMenuList.Add("3. Withdraw");
            this.mainMenuList.Add("\n0. Exit");
        }
        
        //Interface
        public Guid SessionId {get;}

        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine($"Your balance is: ${this.bankCard.CardBalance.ToString("#.00")}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        public void Deposit()
        {
            Console.Clear();
            Console.WriteLine("Please enter your 4-Digit PIN");
            bool isValidInt = int.TryParse(Console.ReadLine(), out int pin);
            if(!isValidInt || pin != bankCard.PinNumber)
            {
                Console.WriteLine("ERROR: Invalid PIN Entered.");
                MainMenu();
            }
            
        }

        public void Withdraw()
        {

        }

        /// <summary>
        /// Displays the main menu to the console.
        /// </summary>
        public void MainMenu()
        {

            Console.WriteLine($"Your session ID is {this.SessionId}");

            foreach(string option in mainMenuList)
            {
                Console.WriteLine(option);
            }
            
            bool isValidChoice = int.TryParse(Console.ReadLine(), out int selection);
            if(!isValidChoice)
            {
                Console.Clear();
                Console.WriteLine("ERROR: Please select a valid option.\n");
                MainMenu();
            } else
            {
                ProcessOption(selection);
            }
            
        }

        private void ProcessOption(int selection)
        {
            switch(selection)
            {
                case 1:
                    CheckBalance();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Thank you for your patronage. Have a good day!\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Something went wrong. Exiting application...");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}