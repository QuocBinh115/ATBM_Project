using Oracle.DataAccess.Client;
using qlCSYT.SqlConn;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace qlCSYT
{
    public partial class frm_addPatient : Form
    {
        public frm_addPatient()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy thao tác?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK) this.Close();
        }

        private void frm_addPatient_Load(object sender, EventArgs e)
        {


            cb_gender.DisplayMember = "Phai";
            cb_gender.ValueMember = "Value";

            var gender = new[] {
            new { Phai = "Nam",Value=1},
            new { Phai = "Nữ",Value=0}
            };

            cb_gender.DataSource = gender;

            qryGetMedFac();
        }
        private void qryGetMedFac()
        {
            OracleConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                string sql = "Select * from CSYT";

                // Tạo một đối tượng Command.
                OracleCommand cmd = new OracleCommand(sql, conn);

                using (DbDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.HasRows)
                    {

                        DataTable tbl = new DataTable();
                        tbl.Columns.Add("MaCSYT", typeof(string));
                        tbl.Columns.Add("TenCSYT", typeof(string));
                        while (reader.Read())
                        {
                            string medFacID = reader.GetString(1);
                            tbl.Rows.Add(reader.GetString(0), reader.GetString(1));
                        }
                        cbMedFac.DataSource = tbl;
                        cbMedFac.DisplayMember = "TenCSYT";
                        cbMedFac.ValueMember = "MaCSYT";
                    }
                    else
                    {
                        Console.WriteLine("failed");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();

            }
            Console.Read();



        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            DateTime ntns = time_Birth.Value;
            string gender = cb_gender.SelectedValue.ToString();
            string houseNo = txt_houseNo.Text;
            string street = txt_street.Text;
            string district = txt_district.Text;
            string city = txt_city.Text;
            string sickHist = rtxt_sickHis.Text;
            string famSickkHist = rtxt_famSickHis.Text;
            string allergy = rtxt_allergy.Text;

            OracleConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();

                CreatePatient(conn, username, password);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
                Console.WriteLine(err.StackTrace);
            }
            finally
            {
                Console.WriteLine("Completed!");
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Thêm bệnh nhân thành công!", "Thông báo");
                this.Close();
            }
            Console.Read();

        }
        private void CreatePatient(OracleConnection conn, string username, string password)
        {

            OracleCommand cmd = new OracleCommand("CreateUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@pi_username", username);
            cmd.Parameters.Add("@pi_password", password);
            cmd.ExecuteNonQuery();
        }

        private void rtxt_sickHis_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_username_Click(object sender, EventArgs e)
        {

        }

        private void lb_name_Click(object sender, EventArgs e)
        {

        }

        private void lb_idNumber_Click(object sender, EventArgs e)
        {

        }

        private void lb_birth_Click(object sender, EventArgs e)
        {

        }

        private void lb_Gender_Click(object sender, EventArgs e)
        {

        }

        private void lb_houseNo_Click(object sender, EventArgs e)
        {

        }

        private void lb_street_Click(object sender, EventArgs e)
        {

        }

        private void lb_district_Click(object sender, EventArgs e)
        {

        }

        private void lb_city_Click(object sender, EventArgs e)
        {

        }

        private void lb_csytID_Click(object sender, EventArgs e)
        {

        }

        private void lb_allergy_Click(object sender, EventArgs e)
        {

        }

        private void lb_famSickHis_Click(object sender, EventArgs e)
        {

        }

        private void lb_sickHis_Click(object sender, EventArgs e)
        {

        }

        private void lb_password_Click(object sender, EventArgs e)
        {

        }
    }
}
