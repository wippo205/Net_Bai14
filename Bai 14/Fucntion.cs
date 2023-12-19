using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bai_14
{
    class Function
    {
        private static string connectionString = @"Data Source=LAPTOP-L0J0D79V\WIPPOO;Initial Catalog=bai14;Integrated Security=True";
        private static SqlConnection connection;

        public static void Connect()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        public static void Disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public static DataTable GetDataToTable(string sql)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-L0J0D79V\WIPPOO;Initial Catalog=bai14;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter dap = new SqlDataAdapter(command))
                    {
                        dap.SelectCommand = command;
                        
                        dap.Fill(table);
                    }
                }
            }

            return table;
        }



        public static void RunSQL(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public static void RunSqlDel(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
