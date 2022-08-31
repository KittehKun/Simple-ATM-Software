// See https://aka.ms/new-console-template for more information
using Simple_ATM_Software.classes;

BankCard bankCard = new BankCard();
ATM atmMachine = new ATM(bankCard);
atmMachine.MainMenu();