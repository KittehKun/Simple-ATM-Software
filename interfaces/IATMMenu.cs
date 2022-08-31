namespace Simple_ATM_Software.interfaces
{
    public interface IATMMenu
    {
        public Guid SessionId{ get; }
        public void MainMenu();
        public void Deposit();
        public void Withdraw();
        public void CheckBalance();
        public void ViewCardDetails();
    }
}