using BankManagement.DTO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BankManagement.DAL
{
    public class BankDetailAccess
    {
        private Boolean boolvalue;

        //ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["Connection"];
        static string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        //SqlConnection bankdataconn = new SqlConnection(@"Data Source=CS68-PC\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");

        //public static void EstablishConnection()
        //{
        //    bankdataconn = new SqlConnection(@"Data Source=CS68-PC\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
        //}
        SqlDataAdapter dataadapter;
       // DataSet dataset;
      //  SqlCommand command;
        SqlConnection bankdataconn;
        private static DataTable datatable;
        SqlCommandBuilder sqlcommandbuilder;
        public void FillDetail()
        {
            bankdataconn = new SqlConnection(connect);
            string query = StringUtilityDAL.sqlSelectQuery;
            dataadapter = new SqlDataAdapter(query, bankdataconn);
            sqlcommandbuilder = new SqlCommandBuilder(dataadapter);
            datatable = new DataTable();
            dataadapter.Fill(datatable);
        }
        public void AddConstraint()
        {
            datatable.Constraints.Add("id", datatable.Columns[1], true);
        }
        public DataTable ShowBankDetail()
        {
            try
            {
                //   BankDetailAccess.EstablishConnection();
                //bankdataconn.Open();
                FillDetail();
            }
            catch (Exception e)
            {
                Console.WriteLine(StringUtilityDAL.exceptionCaught + e);
            }
            finally
            {
                bankdataconn.Close();
            }
            return datatable;
        }
        public DataTable GetSingleAccountDetail(int accountId)
        {
            string query = StringUtilityDAL.sqlSelectSingleQuery + accountId;
            dataadapter = new SqlDataAdapter(query, bankdataconn);
            // sqlcommandbuilder = new SqlCommandBuilder(dataadapter);
            datatable = new DataTable();
            dataadapter.Fill(datatable);
            return datatable;
        }
        //To Insert The Detail Of Bank To DataBase
        public void SaveBankDetail(BankDetail bankDetail)
        {
            FillDetail();
            try
            {/// code for connected architecture
                //bankdataconn.Open();
                //string qry = StringUtilityDAL.sqlInsertQuery;
                //command = new SqlCommand(qry, bankdataconn);
                //command.CommandType = CommandType.Text;
                //command.Parameters.AddWithValue("@AccountNumber", bankDetail.accountNumber);
                //command.Parameters.AddWithValue("@AccountType", bankDetail.accountType);
                //command.Parameters.AddWithValue("@CustomerName", bankDetail.customerName);
                //command.Parameters.AddWithValue("@CustomerAddress", bankDetail.customerAddress);
                //command.Parameters.AddWithValue("@CustomerEmail", bankDetail.customerEmail);
                //command.Parameters.AddWithValue("@CustomerPhoneNumber", bankDetail.customerPhoneNumber);
                //command.Parameters.AddWithValue("@NomineeName", bankDetail.nomieeName);
                //command.ExecuteNonQuery();
                //Console.WriteLine(StringUtilityDAL.accountDetailsAddedSuccessfully);



                /// code for disconnected architecture
                
                AddConstraint();
                DataRow dataRow = datatable.NewRow();
                dataRow[1] = bankDetail.accountNumber;
                dataRow[2] = bankDetail.accountType;
                dataRow[3] = bankDetail.customerName;
                dataRow[4] = bankDetail.customerAddress;
                dataRow[5] = bankDetail.customerEmail;
                dataRow[6] = bankDetail.customerPhoneNumber;
                dataRow[7] = bankDetail.nomieeName;

                datatable.Rows.Add(dataRow);
                dataadapter.Update(datatable);
                Console.WriteLine(StringUtilityDAL.accountDetailsAddedSuccessfully);
            }
            catch (Exception e)
            {
                Console.WriteLine(StringUtilityDAL.exceptionCaught + e);
            }
            finally
            {
                bankdataconn.Close();
            }
        }
        public void UpdateBankAccount(int accountid)
        {
            FillDetail();
            AddConstraint();
            if (datatable.Rows.Contains(accountid))
            {
                DataRow dataRow = datatable.Rows.Find(accountid);
                Console.WriteLine("record found for:");
                dataRow.BeginEdit();
                Console.Write("Enter the updated email of the customer: ");
                dataRow["CustomerEmail"] = Console.ReadLine();
                Console.WriteLine("mark record as updated");
                dataRow.EndEdit();
                dataadapter.Update(datatable);
                Console.WriteLine("Record has been updated Succesfully");
            }
        }

        public Boolean DeleteBankAccount(int accountId)
        {
            FillDetail();
            boolvalue = false;
            try
            {
                //bankdataconn.Open();
                //string query = "Delete from Bank where AccountNumber=" + Accountnumber;
                //dataadapter = new SqlDataAdapter("Select * from Bank", bankdataconn);
                Console.WriteLine("Find And Delete");
                AddConstraint();
                //  datatable.Constraints.Add("id", datatable.Columns[0], true);
                if (!datatable.Rows.Contains(accountId))
                {
                    Console.WriteLine("NO records found");
                }
                else
                {
                    DataRow dataRow = datatable.Rows.Find(accountId);
                    Console.WriteLine("record found for:" + dataRow[1] + dataRow[2]);
                    dataRow.Delete();
                    Console.WriteLine("mark record as deleted");
                    dataadapter.Update(datatable);
                    Console.WriteLine("Record deleted");
                }
                boolvalue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("execption caught" + e);
            }
            finally
            {
                // bankdataconn.Close();

            }
            return boolvalue;
        }
    }
}
