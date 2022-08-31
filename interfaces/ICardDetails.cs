namespace Simple_ATM_Software.classes
{
    public interface ICardDetails
    {
        //Properties
        public long CardNumber {get;}
        public string Name {get;}
        public int PinNumber {get;}
        public int SecurityCode {get;}
        
        //Methods
        public void CreateCard();
    }
}