using Oracle.DataAccess.Client;
using qlCSYT.SqlConn;
using System;
using System.Windows.Forms;

namespace qlCSYT
{
    public partial class frm_addRole : Form
    {
        public frm_addRole()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy thao tác?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK) this.Close();
        }

        private void btn_addRole_Click(object sender, EventArgs e)
        {
            string roleName = tb_roleName.Text;
            Console.WriteLine(roleName);
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("createRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pi_roleName", roleName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            finally
            {
                conn.Close();
                MessageBox.Show("Thêm role thành công!", "Thông báo");
                this.Close();
            }


        }
    }
}
