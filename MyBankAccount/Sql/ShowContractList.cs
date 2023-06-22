using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using MyBankAccount.Sql;
using System.Collections;

namespace MyBankAccount.Sql
{
    public class ShowContractList : SqlConn
    {
        //string[] result;
        List<string> result = new List<string>();
        public List<string> ShowMeListOfContracts(int id)
        {
            
            string query = @"select description from dbo.contracts where AccId = '" + id + "'";
            try
            {
                OpenConnection();
                using SqlCommand command = new SqlCommand(query, _sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                
                while (dataReader.Read())
                {
                    result.Add(dataReader["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;


        }
    }
}
