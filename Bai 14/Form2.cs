using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Bai_14
{
    public partial class Form2 : Form
    {
        DataTable tbGV;
        public Form2()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from GV";
            tbGV = Function.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridView1.DataSource = tbGV; //Hiển thị vào dataGridView
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.Columns[1].HeaderText = "Họ Tên Giáo Viên";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCoso = comboBox1.SelectedValue.ToString();
            
            string sql = $"SELECT * FROM DONVI WHERE macoso = '{selectedCoso}' ORDER BY tendonvi";
            DataTable donviTable = Function.GetDataToTable(sql);
            
            comboBox2.Items.Clear();
            
            foreach (DataRow row in donviTable.Rows)
            {
                string madonvi = row["madonvi"].ToString();
                string tendonvi = row["tendonvi"].ToString();
                
                sql = $"SELECT COUNT(*) FROM GV WHERE madonvi = '{madonvi}'";
                int count = Convert.ToInt32(Function.GetDataToTable(sql).Rows[0][0]);
                
                if (count == 0)
                {
                    comboBox2.Items.Add(new KeyValuePair<string, string>(madonvi, tendonvi));
                }
            }
            
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có đơn vị nào thuộc cơ sở đó không có giáo viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string selectedDonVi = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
                
                ShowGVListInDataGridView(selectedDonVi);
            }
        }

        private void LoadComboBox1()
        {
            try
            {
                string sql = "SELECT * FROM COSO";
                DataTable cosoTable = Function.GetDataToTable(sql);
                
                comboBox1.DataSource = cosoTable;
                comboBox1.DisplayMember = "tencoso"; 
                comboBox1.ValueMember = "macoso";  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu cơ sở: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowGVListInDataGridView(string madonvi)
        {
            try
            {
                string sql = $"SELECT hoten FROM GV WHERE madonvi = '{madonvi}'";
                DataTable gvTable = Function.GetDataToTable(sql);
                
                dataGridView1.DataSource = gvTable;
                
                dataGridView1.Columns[0].HeaderText = "Danh sách giáo viên";
                
                if (gvTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có giáo viên trong đơn vị này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu giáo viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
