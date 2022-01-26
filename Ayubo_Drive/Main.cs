using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Ayubo_Drive
{
    public partial class Main : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\HND-13\Programming\Final Project\Ayubo Drive\Ayubo_Drive\Ayubo_Drive\AyuboDb.mdf;Integrated Security=True");

        string nic;


        public Main()
        {
            InitializeComponent();
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //upload owner img on picturebox
            OpenFileDialog openownerimg = new OpenFileDialog();
            openownerimg.InitialDirectory = "F:\\";
            openownerimg.Filter = "Image Files(.jpg; *.jpeg; *.gif; *.bmp)|.jpg; *.jpeg; *.gif; *.bmp";
            openownerimg.FilterIndex = 1;
            string temId = nicTxt.Text;
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string temfilepath = paths + "\\images\\" + temId + ".jpg";

            if (File.Exists(photoTxt.Text))
            {
                photoPicBox.Image.Dispose();
                File.Delete(photoTxt.Text);
                if (openownerimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(openownerimg.FileName, paths + "\\images\\" + temId + ".jpg");
                    photoTxt.Text = paths + "\\images\\" + temId + ".jpg";
                    photoPicBox.Image = new Bitmap(openownerimg.FileName);

                }
            }
            else
            {
                if (openownerimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openownerimg.CheckFileExists)
                    {
                        System.IO.File.Copy(openownerimg.FileName, paths + "\\images\\" + temId + ".jpg");
                        photoTxt.Text = paths + "\\images\\" + temId + ".jpg";
                        photoPicBox.Image = new Bitmap(openownerimg.FileName);
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            VehiClear();
        }

        public void VehiClear() 
        {
            vehiCategoryCmb.ResetText();
            vehiNo.Clear();
            chassieNo.Clear();
            vehiYear.ResetText();
            vehiFule.ResetText();
            vehiSeat.Clear();
            vehiEngine.Clear();
            vehiMileage.Clear();
            vehiPhoto.Image = null;
            vehiPicTxt.Clear();
            vehiDaily.Clear();
            vehiWeekly.Clear();
            vehiMonthly.Clear();
            vehiOwnerName.Clear();
            vehiNic.Clear();
            vehiLicence.Clear();
            vehiAddress.Clear();
            vehiOwnerPhoto.Image = null;
            vehiOwnerPhototxt.Clear();
            vehiSearch.Clear();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DriverClear();
        }

        public void DriverClear() 
        {
            fnameTxt.Clear();
            lnameTxt.Clear();
            dnicTxt.Clear();
            mobileTxt.Clear();
            emailTxt.Clear();
            dobDatePicker.ResetText();
            dlicenseTxt.Clear();
            daddressRichTxt.Clear();
            dphotoPicBox.Image = null;
            dpicTxt.Clear();
            medicalTxt.Clear();
            bankcmbBox.ResetText();
            branchcmbBox.ResetText();
            accTxt.Clear();
            paymentTxt.Clear();
            searchnic.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            RentClear();
        }

        public void RentClear() 
        {
            rcusnameTxt.Clear();
            rnicTxt.Clear();
            rmobileTxt.Clear();
            rvehicalCmbBox.ResetText();
            rvehicalnoCmbBox.ResetText();
            rdriverCmbBox.ResetText();
            rfromDatePicker.ResetText();
            rtoDatePicker.ResetText();
            rdailyTxt.Clear();
            rweeklyTxt.Clear();
            rmonthlyTxt.Clear();
            rdriverchargeTxt.Clear();
            rphotoPicBox.Image = null;
            rpaymentLbl.Text = "Rs";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login logfrm = new Login();
            logfrm.Show();
            this.Hide();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashfrm = new Dashboard();
            dashfrm.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //Save and update vehical
            string category = vehiCategoryCmb.Text;
            string vehicleNo = vehiNo.Text;
            string chassieNum = chassieNo.Text;
            int year = int.Parse(vehiYear.Text);
            string fule = vehiFule.Text;
            int seats = int.Parse(vehiSeat.Text);
            int enginCC = int.Parse(vehiEngine.Text);
            int mileage = int.Parse(vehiMileage.Text);
            string vehiclePhoto = vehiPicTxt.Text;
            double dailyRent = double.Parse(vehiDaily.Text);
            double weeklyRent = double.Parse(vehiWeekly.Text);
            double monthlyRent = double.Parse(vehiMonthly.Text);
            string ownerName = vehiOwnerName.Text;
            string nic = vehiNic.Text;
            string licence = vehiLicence.Text;
            string address = vehiAddress.Text;
            string ownerPhoto = vehiOwnerPhototxt.Text;
            int vstatus = 1;
            string check = "SELECT * FROM vehical_details WHERE vehicleNo = @vehicleNo";
            conn.Open();
            SqlCommand cmdcheck = new SqlCommand(check, conn);
            cmdcheck.Parameters.AddWithValue("@vehicleNo", vehicleNo);
            SqlDataReader result = cmdcheck.ExecuteReader();
            int tem=0;
            if (result.HasRows) 
            {
                tem++;
            }

            conn.Close();



            if (tem==1)
                {
                    try
                    {
                        //string temvehicleNo = searchTxt.Text;
                        string vehicalupdate = "UPDATE vehical_details SET category=@category,vehicleNo=@vehicleNo,chassieNum=@chassieNum,year=@year,fule=@fule,seats=@seats,enginCC=@enginCC,mileage=@mileage,vehiclePhoto=@vehiclePhoto,dailyRent=@dailyRent,weeklyRent=@weeklyRent,monthlyRent=@monthlyRent,ownerName=@ownerName,nic=@nic,licence=@licence,address=@address,ownerPhoto=@ownerPhoto WHERE vehicleNo=@vehicleNo";
                        conn.Open();
                        SqlCommand cmdupdate = new SqlCommand(vehicalupdate,conn);
                        cmdupdate.Parameters.AddWithValue("@category", category);
                        cmdupdate.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                        cmdupdate.Parameters.AddWithValue("@chassieNum", chassieNum);
                        cmdupdate.Parameters.AddWithValue("@year", year);
                        cmdupdate.Parameters.AddWithValue("@fule", fule);
                        cmdupdate.Parameters.AddWithValue("@seats", seats);
                        cmdupdate.Parameters.AddWithValue("@enginCC", enginCC);
                        cmdupdate.Parameters.AddWithValue("@mileage", mileage);
                        cmdupdate.Parameters.AddWithValue("@vehiclePhoto", vehiclePhoto);
                        cmdupdate.Parameters.AddWithValue("@dailyRent", dailyRent);
                        cmdupdate.Parameters.AddWithValue("@weeklyRent", weeklyRent);
                        cmdupdate.Parameters.AddWithValue("@monthlyRent", monthlyRent);
                        cmdupdate.Parameters.AddWithValue("@ownerName", ownerName);
                        cmdupdate.Parameters.AddWithValue("@nic", nic);
                        cmdupdate.Parameters.AddWithValue("@licence", licence);
                        cmdupdate.Parameters.AddWithValue("@address", address);
                        cmdupdate.Parameters.AddWithValue("@ownerPhoto", ownerPhoto);
                        //cmdupdate.Parameters.AddWithValue("@vstatus", vstatus);
                        cmdupdate.ExecuteNonQuery();
                        MessageBox.Show("Data update");
                        VehiClear();

                }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Not update " + ex);
                    }
                    finally 
                    {
                        conn.Close();
                    }

                }
            else
                {
                    try
                    {
                        string vehicalinsert = "INSERT INTO vehical_details (category,vehicleNo,chassieNum,year,fule,seats,enginCC,mileage,vehiclePhoto,dailyRent,weeklyRent,monthlyRent,ownerName,nic,licence,address,ownerPhoto,vstatus) VALUES   (@category,@vehicleNo,@chassieNum,@year,@fule,@seats,@enginCC,@mileage,@vehiclePhoto,@dailyRent,@weeklyRent,@monthlyRent,@ownerName,@nic,@licence,@address,@ownerPhoto,@vstatus)";
                        conn.Open();
                        SqlCommand cmdinsert = new SqlCommand(vehicalinsert, conn);
                        cmdinsert.Parameters.AddWithValue("@category", category);
                        cmdinsert.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                        cmdinsert.Parameters.AddWithValue("@chassieNum", chassieNum);
                        cmdinsert.Parameters.AddWithValue("@year", year);
                        cmdinsert.Parameters.AddWithValue("@fule", fule);
                        cmdinsert.Parameters.AddWithValue("@seats", seats);
                        cmdinsert.Parameters.AddWithValue("@enginCC", enginCC);
                        cmdinsert.Parameters.AddWithValue("@mileage", mileage);
                        cmdinsert.Parameters.AddWithValue("@vehiclePhoto", vehiclePhoto);
                        cmdinsert.Parameters.AddWithValue("@dailyRent", dailyRent);
                        cmdinsert.Parameters.AddWithValue("@weeklyRent", weeklyRent);
                        cmdinsert.Parameters.AddWithValue("@monthlyRent", monthlyRent);
                        cmdinsert.Parameters.AddWithValue("@ownerName", ownerName);
                        cmdinsert.Parameters.AddWithValue("@nic", nic);
                        cmdinsert.Parameters.AddWithValue("@licence", licence);
                        cmdinsert.Parameters.AddWithValue("@address", address);
                        cmdinsert.Parameters.AddWithValue("@ownerPhoto", ownerPhoto);
                        cmdinsert.Parameters.AddWithValue("@vstatus", vstatus);
                        cmdinsert.ExecuteNonQuery();
                        MessageBox.Show("Data saved");
                        VehiClear();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Not saved " + ex);
                    }
                    finally 
                    {
                        conn.Close();
                    }


                    
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //search details
                string vehicleNo = searchTxt.Text;
                string searchvehi = "SELECT * FROM vehical_details WHERE vehicleNo=@vehicleNo AND vstatus='1'";
                conn.Open();
                SqlCommand cmdsearch = new SqlCommand(searchvehi, conn);
                cmdsearch.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                SqlDataReader result = cmdsearch.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read()) 
                    {
                        catCmbBox.Text = result[1].ToString();
                        vehiNoTxt.Text = result[2].ToString();
                        chassiNoTxt.Text = result[3].ToString();
                        yearCmbBox.Text = result[4].ToString();
                        fuelCmbBox.Text = result[5].ToString();
                        seatTxt.Text = result[6].ToString();
                        engineTxt.Text = result[7].ToString();
                        mileageTxt.Text = result[8].ToString();
                        picTxt.Text = result[9].ToString();
                        //OpenFileDialog openvehiimg = new OpenFileDialog();
                        vehiPicBox.Image = new Bitmap(result[9].ToString());
                        //vehiPicBox.Image = result[9].ToString();
                        dailyTxt.Text = result[10].ToString();
                        weekTxt.Text = result[11].ToString();
                        monthTxt.Text = result[12].ToString();
                        nameTxt.Text = result[13].ToString();
                        nicTxt.Text = result[14].ToString();
                        licenseTxt.Text = result[15].ToString();
                        addRichText.Text = result[16].ToString();
                        photoTxt.Text = result[17].ToString();
                        photoPicBox.Image = new Bitmap(result[17].ToString());

                    }
                }
                else 
                {
                    MessageBox.Show("Unregister vehical");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on searching " + ex);
            }
            finally 
            {
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //delete vehical
                string vehicleNo = vehiSearch.Text;
                string deletevehical = "DELETE FROM vehical_details WHERE vehicleNo=@vehicleNo";
                conn.Open();
                SqlCommand cmddelete = new SqlCommand(deletevehical, conn);
                cmddelete.Parameters.AddWithValue("vehicleNo", vehicleNo);
                cmddelete.ExecuteNonQuery();
                MessageBox.Show("Delete success");
                VehiClear();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on Delete "+ ex);
            }
            finally 
            {
                conn.Close();
            }
        }

        private void vehiPicBox_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //upload vehical img on picturebox
            OpenFileDialog openvehimg = new OpenFileDialog();
            openvehimg.InitialDirectory = "F:\\";
            openvehimg.Filter = "Image Files(.jpg; *.jpeg; *.gif; *.bmp)|.jpg; *.jpeg; *.gif; *.bmp";
            openvehimg.FilterIndex = 1;
            string temId = vehiNoTxt.Text;
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string temfilepath = paths + "\\images\\" + temId + ".jpg";

            if (File.Exists(picTxt.Text))
            {
                vehiPicBox.Image.Dispose();
                File.Delete(picTxt.Text);
                if (openvehimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(openvehimg.FileName, paths + "\\images\\" + temId + ".jpg");
                    picTxt.Text = paths + "\\images\\" + temId + ".jpg";
                    vehiPicBox.Image = new Bitmap(openvehimg.FileName);

                }
            }
            else 
            {
                if (openvehimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openvehimg.CheckFileExists)
                    {
                        System.IO.File.Copy(openvehimg.FileName, paths + "\\images\\" + temId + ".jpg");
                        picTxt.Text = paths + "\\images\\" + temId + ".jpg";
                        vehiPicBox.Image = new Bitmap(openvehimg.FileName);
                    }
                }
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Save and update driver
            string nic = dnicTxt.Text;
            string fname = fnameTxt.Text;
            string lname = lnameTxt.Text;
            string photo = dpicTxt.Text;
            string mobile = mobileTxt.Text;
            string email = emailTxt.Text;
            DateTime dob = dobDatePicker.Value.Date;
            string address = daddressRichTxt.Text;
            string licenNum = dlicenseTxt.Text;
            string medicalReport = medicalTxt.Text;
            string bank = bankcmbBox.Text;
            string branch = branchcmbBox.Text;
            string accountNum = accTxt.Text;
            double driverCost = double.Parse(paymentTxt.Text);
            int dstatus = 1;

            string check = "SELECT * FROM driver_details WHERE nic = @nic";
            conn.Open();
            SqlCommand cmdcheck = new SqlCommand(check, conn);
            cmdcheck.Parameters.AddWithValue("@nic", nic);
            SqlDataReader result = cmdcheck.ExecuteReader();
            int tem = 0;

             if (result.HasRows)
            {
                tem++;
            }

            conn.Close();
            if (tem == 1)
            {
                try
                {
                    string driverupdate = "UPDATE driver_details SET nic=@nic, fname=@fname, lname=@lname, photo=@photo, mobile=@mobile, email=@email, dob=@dob, address=@address, licenNum=@licenNum, medicalReport=@medicalReport, bank=@bank, branch=@branch, accountNum=@accountNum, driverCost=@driverCost WHERE nic=@nic";
                    conn.Open();
                    SqlCommand cmdupdate = new SqlCommand(driverupdate, conn);
                    cmdupdate.Parameters.AddWithValue("@nic", nic);
                    cmdupdate.Parameters.AddWithValue("@fname", fname);
                    cmdupdate.Parameters.AddWithValue("@lname", lname);
                    cmdupdate.Parameters.AddWithValue("@photo", photo);
                    cmdupdate.Parameters.AddWithValue("@mobile", mobile);
                    cmdupdate.Parameters.AddWithValue("@email", email);
                    cmdupdate.Parameters.AddWithValue("@dob", dob);
                    cmdupdate.Parameters.AddWithValue("@address", address);
                    cmdupdate.Parameters.AddWithValue("@licenNum", licenNum);
                    cmdupdate.Parameters.AddWithValue("@medicalReport", medicalReport);
                    cmdupdate.Parameters.AddWithValue("@bank", bank);
                    cmdupdate.Parameters.AddWithValue("@branch", branch);
                    cmdupdate.Parameters.AddWithValue("@accountNum", accountNum);
                    cmdupdate.Parameters.AddWithValue("@driverCost", driverCost);
                    cmdupdate.ExecuteNonQuery();
                    MessageBox.Show("Data update");
                    DriverClear();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Not update " + ex);
                }
                finally
                {
                    conn.Close();
                }

            }
            else
            {
                try
                {
                    string driverinsert = "INSERT INTO driver_details (nic,fname,lname,photo,mobile,email,dob,address,licenNum,medicalReport,bank,branch,accountNum,driverCost,dstatus) VALUES   (@nic,@fname,@lname,@photo,@mobile,@email,@dob,@address,@licenNum,@medicalReport,@bank,@branch,@accountNum,@driverCost,@dstatus)";
                    conn.Open();
                    SqlCommand cmdinsert = new SqlCommand(driverinsert, conn);
                    cmdinsert.Parameters.AddWithValue("@nic", nic);
                    cmdinsert.Parameters.AddWithValue("@fname", fname);
                    cmdinsert.Parameters.AddWithValue("@lname", lname);
                    cmdinsert.Parameters.AddWithValue("@photo", photo);
                    cmdinsert.Parameters.AddWithValue("@mobile", mobile);
                    cmdinsert.Parameters.AddWithValue("@email", email);
                    cmdinsert.Parameters.AddWithValue("@dob", dob);
                    cmdinsert.Parameters.AddWithValue("@address", address);
                    cmdinsert.Parameters.AddWithValue("@licenNum", licenNum);
                    cmdinsert.Parameters.AddWithValue("@medicalReport", medicalReport);
                    cmdinsert.Parameters.AddWithValue("@bank", bank);
                    cmdinsert.Parameters.AddWithValue("@branch", branch);
                    cmdinsert.Parameters.AddWithValue("@accountNum", accountNum);
                    cmdinsert.Parameters.AddWithValue("@driverCost", driverCost);
                    cmdinsert.Parameters.AddWithValue("@dstatus", dstatus);
                    cmdinsert.ExecuteNonQuery();
                    MessageBox.Show("Data saved");
                    DriverClear();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Not saved " + ex);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void seatTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void lnameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                //search driver details
                string nic = searchnic.Text;
                string searchdriver = "SELECT * FROM driver_details WHERE nic=@nic";
                conn.Open();
                SqlCommand cmdsearch = new SqlCommand(searchdriver, conn);
                cmdsearch.Parameters.AddWithValue("@nic", nic);
                SqlDataReader result = cmdsearch.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        dnicTxt.Text = result[1].ToString();
                        fnameTxt.Text = result[2].ToString();
                        lnameTxt.Text = result[3].ToString();
                        dpicTxt.Text = result[4].ToString();
                        dphotoPicBox.Image = new Bitmap(result[4].ToString());
                        mobileTxt.Text = result[5].ToString();
                        emailTxt.Text = result[6].ToString();
                        dobDatePicker.Text = result[7].ToString();
                        daddressRichTxt.Text = result[8].ToString();
                        dlicenseTxt.Text = result[9].ToString();
                        medicalTxt.Text = result[10].ToString();
                        bankcmbBox.Text = result[11].ToString();
                        branchcmbBox.Text = result[12].ToString();
                        accTxt.Text = result[13].ToString();
                        paymentTxt.Text = result[14].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Unregister driver");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on searching " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //delete driver
                string nic = searchnic.Text;
                string deletedriver = "DELETE FROM driver_details WHERE nic=@nic";
                conn.Open();
                SqlCommand cmddelete = new SqlCommand(deletedriver, conn);
                cmddelete.Parameters.AddWithValue("nic", nic);
                cmddelete.ExecuteNonQuery();
                
                MessageBox.Show("Delete success");
                DriverClear();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on Delete " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //upload driver img on picturebox
            OpenFileDialog opendrivimg = new OpenFileDialog();
            opendrivimg.InitialDirectory = "F:\\";
            opendrivimg.Filter = "Image Files(.jpg; *.jpeg; *.gif; *.bmp)|.jpg; *.jpeg; *.gif; *.bmp";
            opendrivimg.FilterIndex = 1;
            string temId = dnicTxt.Text;
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string temfilepath = paths + "\\images\\" + temId + ".jpg";

            if (File.Exists(dpicTxt.Text))
            {
                dphotoPicBox.Image.Dispose();
                File.Delete(dpicTxt.Text);
                if (opendrivimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(opendrivimg.FileName, paths + "\\images\\" + temId + ".jpg");
                    dpicTxt.Text = paths + "\\images\\" + temId + ".jpg";
                    dphotoPicBox.Image = new Bitmap(opendrivimg.FileName);

                }
            }
            else
            {
                if (opendrivimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (opendrivimg.CheckFileExists)
                    {
                        //string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        System.IO.File.Copy(opendrivimg.FileName, paths + "\\images\\" + temId + ".jpg");
                        dpicTxt.Text = paths + "\\images\\" + temId + ".jpg";
                        dphotoPicBox.Image = new Bitmap(opendrivimg.FileName);
                    }
                }
            }
        }

        private void rvehicalCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fillcombo();
            
        }

        private void rvehiNoCmbBox() 
        {
         
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDbDataSet.vehical_details' table. You can move, or remove it, as needed.
            this.vehical_detailsTableAdapter.Fill(this.ayuboDbDataSet.vehical_details);

        }

        //fill rent vehicalno cmbbox
        void Fillcombo() 
        {
            string category = this.rvehicalCmbBox.Text;
            string check = "SELECT * FROM vehical_details WHERE category=@category AND vstatus='1'";


            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(check, conn);
                cmdcheck.Parameters.AddWithValue("@category", category);
                SqlDataReader result = cmdcheck.ExecuteReader();

                rvehicalnoCmbBox.Items.Clear();
             

                while (result.Read()) 
                {
                    
                    rvehicalnoCmbBox.Items.Add(result[2].ToString());
             
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally 
            {
                conn.Close();
            }
        }

        //fill rent driver combobox
        void DriverCombo() 
        {
            string check = "SELECT * FROM driver_details WHERE dstatus='1'";


            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(check, conn);
                SqlDataReader result = cmdcheck.ExecuteReader();
                rdriverCmbBox.Items.Clear();

                while (result.Read())
                {                    
                    string dName = result[2].ToString() + " " + result[3].ToString() + " | " +  result[1].ToString();  
                    rdriverCmbBox.Items.Add(dName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //get rent  driver payment
        void getRentDriverPayment() 
        {
            string driverNameId = rdriverCmbBox.Text;
        
            string[] driverId = Regex.Split(driverNameId, @"\D+");
            string tempNic = null;
            foreach (string value in driverId)
            {
                int number;
                


                if (int.TryParse(value, out number))
                {
                    string temp = value;
                    tempNic += value;
                    
                }
            }

           nic = tempNic + "V";
        }

        //get driver payment
        void Payements() 
        {
            try
            {
                DateTime from = rfromDatePicker.Value;
                DateTime to = rtoDatePicker.Value;
                int days = 0;
                int noOfMonths = 0;
                int noOfWeeks = 0;
                int noOfDays = 0;
                float driverCost = 0;
                float dailyRent = 0;
                float weeklyRent = 0;
                float monthlyRent = 0;
                float payment = 0;

                days = (to - from).Days + 1;
                noOfMonths = days / 30;
                noOfWeeks = (days - (noOfMonths * 30)) / 7;
                noOfDays = days - ((noOfMonths * 30) + (noOfWeeks * 7));
                driverCost = float.Parse(rdriverchargeTxt.Text);
                dailyRent = float.Parse(rdailyTxt.Text);
                weeklyRent = float.Parse(rweeklyTxt.Text);
                monthlyRent = float.Parse(rmonthlyTxt.Text);
                payment = (dailyRent * noOfDays) + (weeklyRent * noOfWeeks) + (monthlyRent * noOfMonths) + (days * driverCost);


                rpaymentLbl.Text = "Rs. " + payment.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //get hire vehical Id
        void Fillcombohire()
        {
            string category = this.hVehical.Text;
            string check = "SELECT * FROM vehical_details WHERE category=@category AND vstatus='1'";


            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(check, conn);
                cmdcheck.Parameters.AddWithValue("@category", category);
                SqlDataReader result = cmdcheck.ExecuteReader();

                hVehicalNo.Items.Clear();


                while (result.Read())
                {

                    hVehicalNo.Items.Add(result[2].ToString());

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally
            {
                conn.Close();
            }
        }


        private void rvehicalnoCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vehicleNo = this.rvehicalnoCmbBox.Text;
            string getPrice = "SELECT * FROM vehical_details WHERE vehicleNo=@vehicleNo";

            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(getPrice, conn);
                cmdcheck.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                SqlDataReader result = cmdcheck.ExecuteReader();


                while (result.Read())
                {
                    rphotoPicBox.Image = new Bitmap(result[9].ToString());
                    rdailyTxt.Text = result[10].ToString();
                    rweeklyTxt.Text = result[11].ToString();
                    rmonthlyTxt.Text = result[12].ToString();
                    

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally 
            {
                conn.Close();
            }

            DriverCombo();


        }

        private void button13_Click(object sender, EventArgs e)
        {
            string cusName = rcusnameTxt.Text;
            string nic = rnicTxt.Text;
            string tel = rmobileTxt.Text;
            string category = rvehicalCmbBox.Text;
            string vehicalId = rvehicalnoCmbBox.Text;
            string driverId = rdriverCmbBox.Text;
            DateTime rfrom = rfromDatePicker.Value.Date;
            DateTime rto = rtoDatePicker.Value.Date;
            double dailyRent = double.Parse(rdailyTxt.Text);
            double weeklyRent = double.Parse(rweeklyTxt.Text);
            double monthlyRent = double.Parse(rmonthlyTxt.Text);
            double driverCharge = double.Parse(rdriverchargeTxt.Text);
            string payment = rpaymentLbl.Text;
            int rstatus = 0;

            //if (driverId == "Without Driver")
            //{
            //    rstatus = 0;
            //}
            //else 
            //{
            //    rstatus = 1;
            //}

            


            try
            {
                string insertRvehical = "INSERT INTO rent_details (cusName,nic,tel,category,vehicalId,driverId,rfrom,rto,dailyRent,weeklyRent,monthlyRent,driverCharge,payment,rstatus) VALUES (@cusName,@nic,@tel,@category,@vehicalId,@driverId,@rfrom,@rto,@dailyRent,@weeklyRent,@monthlyRent,@driverCharge,@payment,@rstatus)";
                conn.Open();

                SqlCommand cmdins = new SqlCommand(insertRvehical, conn);

                cmdins.Parameters.AddWithValue("@cusName", cusName);
                cmdins.Parameters.AddWithValue("@nic", nic);
                cmdins.Parameters.AddWithValue("@tel", tel);
                cmdins.Parameters.AddWithValue("@category", category);
                cmdins.Parameters.AddWithValue("@vehicalId", vehicalId);
                cmdins.Parameters.AddWithValue("@driverId", driverId);
                cmdins.Parameters.AddWithValue("@rfrom", rfrom);
                cmdins.Parameters.AddWithValue("@rto", rto);
                cmdins.Parameters.AddWithValue("@dailyRent", dailyRent);
                cmdins.Parameters.AddWithValue("@weeklyRent", weeklyRent);
                cmdins.Parameters.AddWithValue("@monthlyRent", monthlyRent);
                cmdins.Parameters.AddWithValue("@driverCharge", driverCharge);
                cmdins.Parameters.AddWithValue("@payment", payment);
                cmdins.Parameters.AddWithValue("@rstatus", rstatus);

               // string vehicalStatus = "UPDATE driver_details SET nic=@nic, fname=@fname, lname=@lname, photo=@photo, mobile=@mobile, email=@email, dob=@dob, address=@address, licenNum=@licenNum, medicalReport=@medicalReport, bank=@bank, branch=@branch, accountNum=@accountNum, driverCost=@driverCost WHERE nic=@nic";


                DialogResult dialogResult = MessageBox.Show("Do you want to confirm a " + category + " for Mr/Ms " + cusName + "?","Summerize",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmdins.ExecuteNonQuery();
                    MessageBox.Show("Thank you and come again");
                    RentClear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do somthing
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally 
            {
                conn.Close();
            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fuelCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yearCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdriverCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdriverchargeTxt.Clear();
            getRentDriverPayment();
            string getPrice = "SELECT * FROM driver_details WHERE nic=@nic";

            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(getPrice, conn);
                cmdcheck.Parameters.AddWithValue("@nic", nic);
                SqlDataReader result = cmdcheck.ExecuteReader();

                while (result.Read())
                {

                    rdriverchargeTxt.Text = result[14].ToString();
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally 
            {
                conn.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            
        }

        private void rphotoPicBox_Click(object sender, EventArgs e)
        {

        }

        private void rmobileTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtoDatePicker_ValueChanged(object sender, EventArgs e)
        {
            Payements();
        }

        private void rpaymentLbl_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            HireClear();
        }
        void HireClear() 
        {
            hcusName.Clear();
            hNic.Clear();
            hMobile.Clear();
            hVehical.ResetText();
            hVehicalNo.ResetText();
            hDriver.ResetText();
            hDate.ResetText();
            hStart.Clear();
            hEnd.Clear();
            hPerKm.Clear();
            hWaitingCharge.Clear();
            hDriverCharge.Clear();
            hVehicalPhoto.Image = null;
            hPayment.Text = "Rs";
            hcategory.ResetText();

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string cusName = hcusName.Text;
            string nic = hNic.Text;
            string tel = hMobile.Text;
            string vehical = hVehical.Text;
            string vehicalId = hVehicalNo.Text;
            string driverId = hDriver.Text;
            DateTime hireDate = hDate.Value.Date;
            float startKm = float.Parse(hStart.Text);
            float endKm = float.Parse(hEnd.Text);
            int perKm = int.Parse(hPerKm.Text);
            float waiting = float.Parse(hWaitingCharge.Text);
            string payment = hPayment.Text;
            string category = hcategory.Text;

            try
            {
                string insertHvehical = "INSERT INTO hire_details (cusName,nic,tel,vehical,vehicalId,driverId,hireDate,startKm,endKm,perKm,waiting,payment,category) VALUES (@cusName,@nic,@tel,@vehical,@vehicalId,@driverId,@hireDate,@startKm,@endKm,@perKm,@waiting,@payment,@category)";
                conn.Open();

                SqlCommand cmdins = new SqlCommand(insertHvehical, conn);

                cmdins.Parameters.AddWithValue("@cusName", cusName);
                cmdins.Parameters.AddWithValue("@nic", nic);
                cmdins.Parameters.AddWithValue("@tel", tel);
                cmdins.Parameters.AddWithValue("@vehical", vehical);
                cmdins.Parameters.AddWithValue("@vehicalId", vehicalId);
                cmdins.Parameters.AddWithValue("@driverId", driverId);
                cmdins.Parameters.AddWithValue("@hireDate", hireDate);
                cmdins.Parameters.AddWithValue("@startKm", startKm);
                cmdins.Parameters.AddWithValue("@endKm", endKm);
                cmdins.Parameters.AddWithValue("@perKm", perKm);
                cmdins.Parameters.AddWithValue("@waiting", waiting);
                cmdins.Parameters.AddWithValue("@payment", payment);
                cmdins.Parameters.AddWithValue("@category", category);


                DialogResult dialogResult = MessageBox.Show("Do you want to confirm a " + category + " for Mr/Ms " + cusName + "?", "Summerize", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmdins.ExecuteNonQuery();
                    MessageBox.Show("Thank you and come again");
                    HireClear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do somthing
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void hVehical_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPerKm();
            Fillcombohire();
        }
        void GetPerKm() 
        {

            string vhicalCat = hVehical.Text;
            switch(vhicalCat)
            {
                case "Car":
                    hPerKm.Text = "100";
                    break;

                case "Van":
                    hPerKm.Text = "100";
                    break;

                case "SUV":
                    hPerKm.Text = "120";
                    break;

                case "Motocycle":
                    hPerKm.Text = "60";
                    break;

                case "Wagon":
                    hPerKm.Text = "100";
                    break;

                case "Pickup":
                    hPerKm.Text = "120";
                    break;

                case "Bus":
                    hPerKm.Text = "130";
                    break;

                case "Lorry":
                    hPerKm.Text = "140";
                    break;

                case "Crew Cab":
                    hPerKm.Text = "120";
                    break;

                case "Three Wheel":
                    hPerKm.Text = "50";
                    break;

                case "Tractor":
                    hPerKm.Text = "100";
                    break;

                case "Heavy - Duty":
                    hPerKm.Text = "140";
                    break;

                default:
                    MessageBox.Show("Please select a Vehical");
                    break;

            }
        }

        private void hWaitingCharge_TextChanged(object sender, EventArgs e)
        {
            HirePayment();
        }

        void HirePayment() 
        {
            //            Airport Drop
            //Airport Pickup
            //100KM
            //200KM 

            string category = hcategory.Text;
            //int perKm = int.Parse(category);
            switch (category) 
            {
                case "Airport Drop":
                    AirDropandpickup();
                    break;
                case "Airport Pickup":
                    AirDropandpickup();
                    break;
                case "100KM":
                    KM100and200();
                    break;
                case "200KM":
                    KM100and200();
                    break;
                default:
                    MessageBox.Show("Please select Hire type");
                    break;
            }
        

        }

        void AirDropandpickup() 
        {
            float startMeter = float.Parse(hStart.Text);
            float endMeter = float.Parse(hEnd.Text);
            float km = endMeter - startMeter;

            int perKm = int.Parse(hPerKm.Text);
            float waitingCha = float.Parse(hWaitingCharge.Text);
            waitingCha = waitingCha * 75;

            float payment = (km * perKm) + waitingCha;

            hPayment.Text = "Rs " + payment;

        }

        void KM100and200() 
        {
            float startMeter = float.Parse(hStart.Text);
            float endMeter = float.Parse(hEnd.Text);
            float km = endMeter - startMeter;
            float additionalKm;
            float payment;

            if ("100KM" == hcategory.Text)
            {
                if (km > 100)
                {
                    additionalKm = km - 100;
                    payment = (additionalKm * 70) + (100 * int.Parse(hPerKm.Text));
                    hPayment.Text = "Rs " + payment;
                }
                else
                {
                    payment = km * int.Parse(hPerKm.Text);
                    hPayment.Text = "Rs " + payment;
                }
            }
            else if ("200KM" == hcategory.Text) 
            {
                if (km > 200)
                {
                    additionalKm = km - 200;
                    payment = (additionalKm * 50) + (200 * int.Parse(hPerKm.Text));
                    hPayment.Text = "Rs " + payment;
                }
                else
                {
                    payment = km * int.Parse(hPerKm.Text);
                    hPayment.Text = "Rs " + payment;
                }
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void hcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void hVehicalNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string check = "SELECT * FROM driver_details WHERE dstatus='1'";


            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(check, conn);
                SqlDataReader result = cmdcheck.ExecuteReader();
                hDriver.Items.Clear();

                while (result.Read())
                {
                    string dName = result[2].ToString() + " " + result[3].ToString() + " | " + result[1].ToString();
                    hDriver.Items.Add(dName);

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally
            {
                conn.Close();
                hireVehicalPhoto();
            }
        }

        //get hire vehical photo
        void hireVehicalPhoto() 
        {
            string vehicleNo = this.hVehicalNo.Text;
            string getPhoto = "SELECT * FROM vehical_details WHERE vehicleNo=@vehicleNo";

            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(getPhoto, conn);
                cmdcheck.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                SqlDataReader result = cmdcheck.ExecuteReader();


                while (result.Read())
                {
                    hVehicalPhoto.Image = new Bitmap(result[9].ToString());

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //get hire drivers
        private void hDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            hDriverCharge.Clear();
            getHireDriverPayment();
            string getPrice = "SELECT * FROM driver_details WHERE nic=@nic";

            try
            {
                conn.Open();
                SqlCommand cmdcheck = new SqlCommand(getPrice, conn);
                cmdcheck.Parameters.AddWithValue("@nic", nic);
                SqlDataReader result = cmdcheck.ExecuteReader();

                while (result.Read())
                {

                   hDriverCharge.Text = result[14].ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //get hire drivers payments
        void getHireDriverPayment()
        {
            string driverNameId = hDriver.Text;

            string[] driverId = Regex.Split(driverNameId, @"\D+");
            string tempNic = null;
            foreach (string value in driverId)
            {
                int number;



                if (int.TryParse(value, out number))
                {
                    string temp = value;
                    tempNic += value;

                }
            }

            nic = tempNic + "V";
        }

        private void hEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void hStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            //upload vehical img on picturebox
            OpenFileDialog openvehimg = new OpenFileDialog();
            openvehimg.InitialDirectory = "F:\\";
            openvehimg.Filter = "Image Files(.jpg; *.jpeg; *.gif; *.bmp)|.jpg; *.jpeg; *.gif; *.bmp";
            openvehimg.FilterIndex = 1;
            string temId = vehiNo.Text;
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string temfilepath = paths + "\\images\\" + temId + ".jpg";

            if (File.Exists(vehiPicTxt.Text))
            {
                vehiPhoto.Image.Dispose();
                File.Delete(vehiPicTxt.Text);
                if (openvehimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(openvehimg.FileName, paths + "\\images\\" + temId + ".jpg");
                    vehiPicTxt.Text = paths + "\\images\\" + temId + ".jpg";
                    vehiPhoto.Image = new Bitmap(openvehimg.FileName);

                }
            }
            else
            {
                if (openvehimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openvehimg.CheckFileExists)
                    {
                        System.IO.File.Copy(openvehimg.FileName, paths + "\\images\\" + temId + ".jpg");
                        vehiPicTxt.Text = paths + "\\images\\" + temId + ".jpg";
                        vehiPhoto.Image = new Bitmap(openvehimg.FileName);
                    }
                }
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            //upload owner img on picturebox
            OpenFileDialog openownerimg = new OpenFileDialog();
            openownerimg.InitialDirectory = "F:\\";
            openownerimg.Filter = "Image Files(.jpg; *.jpeg; *.gif; *.bmp)|.jpg; *.jpeg; *.gif; *.bmp";
            openownerimg.FilterIndex = 1;
            string temId = vehiNic.Text;
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string temfilepath = paths + "\\images\\" + temId + ".jpg";

            if (File.Exists(vehiOwnerPhototxt.Text))
            {
                vehiOwnerPhoto.Image.Dispose();
                File.Delete(vehiOwnerPhototxt.Text);
                if (openownerimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(openownerimg.FileName, paths + "\\images\\" + temId + ".jpg");
                    vehiOwnerPhototxt.Text = paths + "\\images\\" + temId + ".jpg";
                    vehiOwnerPhoto.Image = new Bitmap(openownerimg.FileName);

                }
            }
            else
            {
                if (openownerimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openownerimg.CheckFileExists)
                    {
                        System.IO.File.Copy(openownerimg.FileName, paths + "\\images\\" + temId + ".jpg");
                        vehiOwnerPhototxt.Text = paths + "\\images\\" + temId + ".jpg";
                        vehiOwnerPhoto.Image = new Bitmap(openownerimg.FileName);
                    }
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                //search details
                string vehicleNo = vehiSearch.Text;
                string searchvehi = "SELECT * FROM vehical_details WHERE vehicleNo=@vehicleNo AND vstatus='1'";
                conn.Open();
                SqlCommand cmdsearch = new SqlCommand(searchvehi, conn);
                cmdsearch.Parameters.AddWithValue("@vehicleNo", vehicleNo);
                SqlDataReader result = cmdsearch.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        vehiCategoryCmb.Text = result[1].ToString();
                        vehiNo.Text = result[2].ToString();
                        chassieNo.Text = result[3].ToString();
                        vehiYear.Text = result[4].ToString();
                        vehiFule.Text = result[5].ToString();
                        vehiSeat.Text = result[6].ToString();
                        vehiEngine.Text = result[7].ToString();
                        vehiMileage.Text = result[8].ToString();
                        vehiPicTxt.Text = result[9].ToString();
                        //OpenFileDialog openvehiimg = new OpenFileDialog();
                        vehiPhoto.Image = new Bitmap(result[9].ToString());
                        //vehiPicBox.Image = result[9].ToString();
                        vehiDaily.Text = result[10].ToString();
                        vehiWeekly.Text = result[11].ToString();
                        vehiMonthly.Text = result[12].ToString();
                        vehiOwnerName.Text = result[13].ToString();
                        vehiNic.Text = result[14].ToString();
                        vehiLicence.Text = result[15].ToString();
                        vehiAddress.Text = result[16].ToString();
                        vehiOwnerPhototxt.Text = result[17].ToString();
                        vehiOwnerPhoto.Image = new Bitmap(result[17].ToString());

                    }
                }
                else
                {
                    MessageBox.Show("Unregister vehical");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on searching " + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
