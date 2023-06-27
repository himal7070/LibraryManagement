using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementFinalProjectVersion2
{
    class SqlDataHelper
    {
        string connection = "Data Source=DESKTOP-MC5L8BB\\SQLEXPRESS;Initial Catalog=libraryDatabaseVersion;Integrated Security=True";

        SqlConnection con = null;


        public SqlDataHelper()
        {
            con = new SqlConnection(connection);

        }

        public string Execute(string query)
        {
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }

            return string.Empty;

        }
        public SqlDataReader select(string query)
        {
            con.Open();

            try
            {

                SqlCommand cmd = new SqlCommand(query, con);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;

        }

    }
}
