using BankManagement.BLL;

using System;
namespace BankManagement
{
    class BankManagement
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            int AcceptNumber;
            do
            {
                Console.WriteLine(StringUtilityMain.menu);
                Console.WriteLine(StringUtilityMain.select);
                Console.WriteLine(StringUtilityMain.insert);
                Console.WriteLine(StringUtilityMain.update);
                Console.WriteLine(StringUtilityMain.delete);
                Console.WriteLine(StringUtilityMain.selectAll);
                Console.WriteLine(StringUtilityMain.exit);
                AcceptNumber = int.Parse(Console.ReadLine());
               
                switch (AcceptNumber)
                {
                    case 1:
                        bank.GetSingleBankAccountDetail();
                        break;
                    case 2:
                        bank.GetBankDetail();
                        break;
                    case 3:
                        bank.UpdatebankDetail();
                        break;
                    case 4:
                        bank.DeleteBankDetail();
                        break;
                    case 5:
                        bank.ShowBankDetail();
                        break;
                    case 6:
                        break;
                   default:
                        Console.WriteLine(StringUtilityMain.option);
                        break;
                }
            }
            while (AcceptNumber != 6);
            Console.ReadKey();
        }
    }
}

