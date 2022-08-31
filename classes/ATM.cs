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
            this.mainMenuList.Add("4. Check card details");
            this.mainMenuList.Add("\n0. Exit");
        }
        
        //Interface
        public Guid SessionId {get;}

        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine($"Your balance is: ${this.bankCard.CardBalance.ToString("0.00")}");
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
                Console.Clear();
                Console.WriteLine("ERROR: Invalid PIN Entered.\n");
                MainMenu();
            }

            Console.WriteLine("\nHow much would you like to deposit into your account: ");
            bool isValidDeposit = double.TryParse(Console.ReadLine(), out double deposit);
            if(isValidDeposit)
            {
                this.bankCard.AddBalance(deposit);
                Console.Clear();
                Console.WriteLine($"SUCCESS: Deposited ${deposit.ToString("0.00")} into your account.\n");
                MainMenu();
            } else
            {
                Console.WriteLine("ERROR: Deposit amount invalid.\n");
                MainMenu();
            }
        }

        public void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Please enter your 4-Digit PIN");
            
            bool isValidInt = int.TryParse(Console.ReadLine(), out int pin);
            if(!isValidInt || pin != bankCard.PinNumber)
            {
                Console.Clear();
                Console.WriteLine("ERROR: Invalid PIN Entered.\n");
                MainMenu();
            }

            Console.WriteLine("\nHow much would you like to withdraw from your account: ");
            bool isValidWithdraw = double.TryParse(Console.ReadLine(), out double withdraw);
            if(isValidWithdraw && withdraw <= bankCard.CardBalance)
            {
                this.bankCard.SubtractBalance(withdraw);
                Console.Clear();
                Console.WriteLine($"SUCCESS: Withdrew ${withdraw.ToString("0.00")} into your account.\n");
                MainMenu();
            } else if (!isValidWithdraw)
            {
                Console.Clear();
                Console.WriteLine("ERROR: Withdraw amount is invalid.\n");
                MainMenu();
            } else
            {
                Console.Clear();
                Console.WriteLine("ERROR: Cannot withdraw more than available funds.\n");
                MainMenu();
            }
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
                case 4:
                    ViewCardDetails();
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

        public void ViewCardDetails()
        {
            Console.Clear();
            Console.WriteLine(" - Here are your card's details - \n");
            Console.WriteLine($"This is your card number: {this.bankCard.CardNumber}");
            Console.WriteLine($"PIN number: {this.bankCard.PinNumber}");
            Console.WriteLine($"Security code: {this.bankCard.SecurityCode}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
    }
}