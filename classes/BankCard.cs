namespace Simple_ATM_Software.classes
{
    public class BankCard : ICardDetails
    {
        //Fields
        private Random random;
        
        //Interface
        public int CardNumber {get; private set;}
        public string Name {get; private set;}
        public int PinNumber {get; private set;}
        public int SecurityCode {get; private set;}
        public void CreateCard()
        {
            Console.WriteLine("Welcome to Kitteh's Banking! To get setup, we will need to create a card.");
            Console.WriteLine("To get started, fill out the form below to get registered.");
            CreateName();
            GenerateCardDetails();
        }

        public void VerifyCard()
        {

        }

        //Constructor
        public BankCard()
        {
            this.random = new Random();
            this.CardNumber = 0;
            this.Name = "";
            this.PinNumber = 0;
            this.SecurityCode = 0;
            CreateCard();
        }

        private void CreateName()
        {
            Console.WriteLine("\nPlease enter your name:");
            string? input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input))
            {
                this.Name = input;
                Console.WriteLine($"You entered: {this.Name}. Continue with that name? [Y/N]");
                bool isValidName = VerifyName(this.Name);
            } else
            {
                Console.Clear();
                Console.WriteLine("ERROR: Name cannot be empty. Please enter your name:");
                CreateName();
            }
        }

        private bool VerifyName(string name)
        {
            
        }

        private void GenerateCardDetails()
        {

        }

    }
}