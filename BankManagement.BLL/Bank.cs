using BankManagement.DAL;
using BankManagement.DTO;
using System;
using System.Data;

namespace BankManagement.BLL
{
    public class Bank
    {
        private static DataTable dataTable = new DataTable();
        private BankDetailAccess _bankDataBase = new BankDetailAccess();
        BankDetail bankDetail = new BankDetail();
        public void GetBankDetail()
        {

            Console.WriteLine(StringUtilityBLL.accountnumber);
            bankDetail.accountNumber = int.Parse(Console.ReadLine());
              

            Console.WriteLine(StringUtilityBLL.accounttype);
            bankDetail.accountType = Console.ReadLine();

            Console.WriteLine(StringUtilityBLL.customername);
            bankDetail.customerName = Console.ReadLine();

            Console.WriteLine(StringUtilityBLL.customeraddress);
            bankDetail.customerAddress = Console.ReadLine();

            Console.WriteLine(StringUtilityBLL.customeremail);
            bankDetail.customerEmail = Console.ReadLine();

            Console.WriteLine(StringUtilityBLL.customerphonenumber);
            bankDetail.customerPhoneNumber = Console.ReadLine();

            Console.WriteLine(StringUtilityBLL.nomineename);
            bankDetail.nomieeName = Console.ReadLine();
            if (bankDetail.accountNumber != 0)
            {
                _bankDataBase.SaveBankDetail(bankDetail);
            }
            else
            {
                Console.WriteLine(StringUtilityBLL.pleaseenterid);
            }
        }

        public void ShowBankDetail()
        {
            dataTable = _bankDataBase.ShowBankDetail();
            
            foreach(DataColumn columnName in dataTable.Columns)
            {
                Console.Write(columnName.ColumnName + StringUtilityBLL.tab);
            }

            // Console.WriteLine(" Account Number,AccountType,\t CustomerName, \t CustomerAddress,   CustomerEmail, CustomerPhoneNumber,  NomineeName");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row[StringUtilityBLL.accountnumberfield ] + StringUtilityBLL.tab + row[StringUtilityBLL.accounttypefield] + StringUtilityBLL.tab + row[StringUtilityBLL.customernamefield] + StringUtilityBLL.tab + row[StringUtilityBLL.customeraddressfield] + StringUtilityBLL.tab + row[StringUtilityBLL.customeremailfield] + "\t" + row[StringUtilityBLL.customerphonenumberfield ] + StringUtilityBLL.tab + row[StringUtilityBLL.nomineenamefield ]);

            }
        }
        public void UpdatebankDetail()
        {
            int accountId;
            Console.WriteLine(StringUtilityBLL.enteraccountid);
            accountId = int.Parse(Console.ReadLine());

            _bankDataBase.UpdateBankAccount(accountId);
        }
        public void DeleteBankDetail()
        {
            int accountId;
            Console.WriteLine(StringUtilityBLL.enteraccountid);
            accountId = int.Parse(Console.ReadLine());

            _bankDataBase.DeleteBankAccount(accountId);

        }
        public void GetSingleBankAccountDetail()
        {
            int accountId;
            Console.WriteLine(StringUtilityBLL.enteraccountid);
            accountId = int.Parse(Console.ReadLine());
            // dataTable = _bankDataBase.GetSingleAccountDetail();
            dataTable=_bankDataBase.GetSingleAccountDetail(accountId);

            foreach (DataColumn columnName in dataTable.Columns)
            {
                Console.Write(columnName.ColumnName + StringUtilityBLL.tab);
            }

            // Console.WriteLine(" Account Number,AccountType,\t CustomerName, \t CustomerAddress,   CustomerEmail, CustomerPhoneNumber,  NomineeName");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row[StringUtilityBLL.accountnumberfield] + StringUtilityBLL.tab + row[StringUtilityBLL.accounttypefield] + StringUtilityBLL.tab + row[StringUtilityBLL.customernamefield] + StringUtilityBLL.tab + row[StringUtilityBLL.customeraddressfield] + StringUtilityBLL.tab + row[StringUtilityBLL.customeremailfield] + StringUtilityBLL.tab + row[StringUtilityBLL.customerphonenumberfield] + StringUtilityBLL.tab + row[StringUtilityBLL.nomineenamefield]);

            }
        }

    }
}
