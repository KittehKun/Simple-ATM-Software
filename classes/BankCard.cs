namespace Simple_ATM_Software.classes
{
    public class BankCard : ICardDetails
    {
        //Fields
        private Random random;
        private double cardBalance;
        public double CardBalance { get => cardBalance; private set => cardBalance = value; }
        
        //Interface
        public long CardNumber {get; private set;}
        public string Name {get; private set;}
        public int PinNumber {get; private set;}
        public int SecurityCode {get; private set;}

        public void CreateCard()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Kitteh's Banking! To get setup, we will need to create a card.");
            Console.WriteLine("To get started, fill out the form below to get registered.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            CreateName();
            GenerateCardDetails();
        }

        //Constructor
        public BankCard()
        {
            this.random = new Random();
            this.CardNumber = 0;
            this.Name = "";
            this.PinNumber = 0;
            this.SecurityCode = 0;
            this.CardBalance = 50.00; //Default value
            CreateCard();
        }

        //Methods
        private void CreateName()
        {
            Console.WriteLine("\nPlease enter your name:");
            string? input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input))
            {
                Console.Clear();
                this.Name = input;
                if(this.Name == "KittehKun")
                {
                    Console.WriteLine($"Welcome back developer!\n");
                } else
                {
                    
                    Console.WriteLine($"Welcome {this.Name}!\n");
                }
                
            } else
            {
                Console.Clear();
                Console.WriteLine("ERROR: Name cannot be empty.");
                CreateName();
            }
        }

        internal void AddBalance(double depositAmount)
        {
            this.CardBalance += depositAmount;
        }

        private void GenerateCardDetails()
        {
            this.CardNumber = random.NextInt64(10000000000);
            string cardNumber = (string.Format("{0:00000000}", this.CardNumber));
            Console.WriteLine($"This is your card number: {cardNumber}");
            this.PinNumber = random.Next(1000, 10000);
            Console.WriteLine($"PIN number: {this.PinNumber}");
            this.SecurityCode = random.Next(100, 1000);
            Console.WriteLine($"Security code: {this.SecurityCode}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal void SubtractBalance(double withdrawAmount)
        {
            this.CardBalance -= withdrawAmount;
        }

    }
}