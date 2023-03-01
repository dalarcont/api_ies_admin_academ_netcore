using MySql.Data.MySqlClient;
using System.Data;

namespace IES_ADMIN_ACADEM_API.Repository
{
    public class daoManager
    {

        private readonly IConfiguration _configuration;

        public daoManager()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        /// <summary>
        /// Get data from DATABASE
        /// </summary>
        /// <param name="sql">Query to perform</param>
        /// <returns>DataTable with results</returns>
        public DataTable retrieveData(string sql)
        {

            //Set connection object
            using MySqlConnection con = new(_configuration.GetConnectionString("IES_DB").ToString());
            //Open the connection
            con.Open();
            MySqlCommand cmd = new(sql, con);

            DataTable dt = new();

            try
            {
                new MySqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }

            //Close connection
            con.Close();

            //Return object
            return dt;
        }

        public int updateData(string sql) {
            //Set connection object
            using MySqlConnection con = new(_configuration.GetConnectionString("IES_DB").ToString());
            //Open the connection
            con.Open();
            MySqlCommand cmd = new(sql, con);
            //Counting execute operations
            return cmd.ExecuteNonQuery();
            //Close connection
            con.Close() ;
            

        }
    }
}
