using Abp.Json;
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
        public DataTable retrieveDataObjects(string sql)
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
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            //Close connection
            con.Close();

            //Return object
            return dt;
        }

        /// <summary>
        /// Perform update query
        /// </summary>
        /// <param name="sql">SQL Query with fields to update each one with its new value</param>
        /// <returns></returns>
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

        /// <summary>
        /// Perform a select query of a single value or field
        /// </summary>
        /// <param name="sql">SQL Query where the select statement only takes 1 fields</param>
        /// <returns></returns>
        public Object retrieveSingleValue(string sql)
        {

            //Set connection object
            using MySqlConnection con = new(_configuration.GetConnectionString("IES_DB").ToString());
            //Open the connection
            con.Open();
            MySqlCommand cmd = new(sql, con);

            //Return object
            return cmd.ExecuteScalar();

            //Close connection
            con.Close();
        }
    }
}
