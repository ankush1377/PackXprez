using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PackXprezDataAccessLayer
{
    public class DataAccessLayer
    {
        SqlConnection conPackXprez;
        public DataAccessLayer()
        {
            conPackXprez = new SqlConnection(ConfigurationManager.ConnectionStrings["conPackXprez"].ToString());
        }
        
        public bool TestConnection()
        {
           
            bool status = false;
            try
            {
                //Open connection
                if (conPackXprez.State == System.Data.ConnectionState.Closed)
                {
                    conPackXprez.Open();
                    status = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            finally
            {
                //Close connection
                conPackXprez.Close();
            }
            return status;
        }






    }
}
