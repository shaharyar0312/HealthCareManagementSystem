using dbms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace dbms
{ 
    public partial class Form1 : Form
    {
        public SqlConnection con = new SqlConnection();
        public DataTable data = new DataTable();
        public SqlCommand com = new SqlCommand();
        public SqlDataReader dr;
        static int a = 0;
        static int b = 0;
        static int c = 0;
        public void access_to_database()
        {

            con.Close();
            con.ConnectionString = @"Data Source=HP-PC;Initial Catalog=Healthcare Management System;Integrated Security=True"; //@"Data Source=DESKTOP-OABQ59I;Initial Catalog= Healthcare Management System;Integrated Security=True"
            com.Connection = con;
            con.Open();
            com = con.CreateCommand();
            com.Connection = con;

            if (con.State.ToString() == "Closed")
            {
                MessageBox.Show("Unable to set connections");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        





        private void pictureBox1_login_Click(object sender, EventArgs e)//main page ka login btn
        {
            
           panel1_login.Visible = true;
//            panel1_signup.Visible = false;
            
        }



        private void pictureBox1_login_MouseHover(object sender, EventArgs e)//main page ka login btn ka mouse hover
        {
            pictureBox1_login.Image = Resources.LOGIN;
        }

        private void pictureBox1_login_MouseLeave(object sender, EventArgs e)//main page ka login btn ka mouse leave
        {
            pictureBox1_login.Image = Resources.login_light;
        }

        private void pictureBox1_exit_Click(object sender, EventArgs e)//main page ka cross
        {
            Application.Exit();
        }

        private void pictureBox1_exit_MouseHover(object sender, EventArgs e)//main page ka cross ka mouse hover
        {
            pictureBox1_exit.Image = Resources.red;
        }

        private void pictureBox1_exit_MouseLeave(object sender, EventArgs e)//main page ka cross ka mouse leave
        {
            pictureBox1_exit.Image = Resources.black;
        }

        private void panel1_login_Paint(object sender, PaintEventArgs e)//member login panel ka login btn
        {

        }

        private void textBox1_mob_no_TextChanged(object sender, EventArgs e)//member login panel ka mob no ka textbox
        {

        }

        private void textBox2_password_TextChanged(object sender, EventArgs e)//member login panel ka password ka textbox
        {
            
            textBox2_password.PasswordChar = '*';
           
            textBox2_password.MaxLength = 14;
           
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }
    

        private void pictureBox3_login_Click(object sender, EventArgs e)//member login
        {
            /*panel1_signup.Visible = true;
            panel1_homepage.Visible = true;
            panel1_menu_homepage.Visible = true;*/
            access_to_database();

            com.CommandType = CommandType.Text;
            com.CommandText = "select Mobile_Number , Password  from User_Info  where Mobile_Number = @Mobile_Number and Password=@Password";
            com.Parameters.AddWithValue("@Mobile_Number", textBox1_mob_no.Text);
            com.Parameters.AddWithValue("@Password", textBox2_password.Text);
            com.ExecuteNonQuery();
            dr = com.ExecuteReader();
            if (dr.Read())
            { panel1_homepage.Visible = panel1_signup.Visible = panel1_menu_homepage.Visible = true; }
            else
            {
                MessageBox.Show("Account not exist kindly register");
                panel1_homepage.Visible = panel1_signup.Visible = panel1_menu_homepage.Visible = false;
                panel1_login.Visible = true;
            }
            con.Close();

        }

        private void pictureBox3_login_MouseHover(object sender, EventArgs e)//member login ka mouse hover
        {
            pictureBox3_login.Image = Resources.LOGIN;
        }

        private void pictureBox3_login_MouseLeave(object sender, EventArgs e)//member login ka mouseleave
        {
            pictureBox3_login.Image = Resources.login_light;
        }

        private void pictureBox3_exit_Click(object sender, EventArgs e)//member login ka exit
        {
            Application.Exit();
        }

        private void pictureBox3_exit_MouseHover(object sender, EventArgs e)//member login ka exit hover
        {
            pictureBox3_exit.Image = Resources.red;
        }

        private void pictureBox3_exit_MouseLeave(object sender, EventArgs e)//member login ka exit leave
        {
            pictureBox3_exit.Image = Resources.black;
        }

        private void textBox1_mob_no_MouseClick(object sender, MouseEventArgs e)//member login ke mob no k text box me agar click karega to empty krdega 
        {
            
           

        }

        private void textBox2_password_MouseClick(object sender, MouseEventArgs e)//member login ke passwrd k text box me agar click karega to empty krdega 
        {
        }


        private void linkLabel1_create_one_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//create one wala link ko sign up ke panel par lejaega
        {

            panel1_signup.Visible = true;
            
           
        }

        private void textBox1_mob_no_Enter(object sender, EventArgs e)// mob no ka text of sign in panel( textbox_enter)
        {
            if (textBox1_mob_no.Text == "Mobile Number")
            { textBox1_mob_no.Text = "";
                textBox1_mob_no.ForeColor = Color.Black;
            }
        }

        private void textBox1_mob_no_Leave(object sender, EventArgs e)// mob no ka text of sign in panel( textbox_leave)
        {
            if (textBox1_mob_no.Text == "")
            {
                textBox1_mob_no.Text = "Mobile Number";
                textBox1_mob_no.ForeColor = Color.Silver;
            }
        }

        private void textBox2_password_Enter(object sender, EventArgs e)// password ka text of sign in panel( textbox_enter)
        {
         if (textBox2_password.Text == "Password")
            {
                textBox2_password.Text = "";
                textBox2_password.ForeColor = Color.Black;
            }
        }

        private void textBox2_password_Leave(object sender, EventArgs e)// mob no ka text of sign in panel( textbox_leave)
        {
            if (textBox2_password.Text == "")
            {
                textBox2_password.Text = "Password";
                textBox2_password.ForeColor = Color.Silver;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//hiding and showing password ka check box(eye)
        {
            if (checkBox1.Checked)
            {
                textBox2_password.UseSystemPasswordChar = true;
            }
            else {
                textBox2_password.UseSystemPasswordChar = false;
            }
        }

        
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_signup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_register_form1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_register_form1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1_signup.Visible = true;
            panel1_login.Visible = true;
        }

        private void pictureBox1_register_form1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1_register_form1.Image = Resources.REGISTER;
        }

        private void pictureBox1_register_form1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1_register_form1.Image = Resources.LIGHT_REGISTER;
        }

        private void tb_mob_no_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_name_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_f_name_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_age_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_gender_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_password_signup_TextChanged(object sender, EventArgs e)
        {
            tb_password_signup.PasswordChar = '*';

            tb_password_signup.MaxLength = 14;

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }

        private void tb_mob_no_signup_Enter(object sender, EventArgs e)
        {
            if (tb_mob_no_signup.Text == "Mobile Number")
            {
                tb_mob_no_signup.Text = "";
                tb_mob_no_signup.ForeColor = Color.Black;
            }
        }

        private void tb_mob_no_signup_Leave(object sender, EventArgs e)
        {
            if (tb_mob_no_signup.Text == "")
            {
                tb_mob_no_signup.Text = "Mobile Number";
                tb_mob_no_signup.ForeColor = Color.Silver;
            }
        }

        private void tb_name_signup_Enter(object sender, EventArgs e)
        {
            if (tb_name_signup.Text == "First Name")
            {
                tb_name_signup.Text = "";
                tb_name_signup.ForeColor = Color.Black;
            }
        }

        private void tb_name_signup_Leave(object sender, EventArgs e)
        {
            if (tb_name_signup.Text == "")
            {
                tb_name_signup.Text = "First Name";
                tb_name_signup.ForeColor = Color.Silver;
            }
        }

        private void tb_f_name_signup_Enter(object sender, EventArgs e)
        {
            if (tb_f_name_signup.Text == "Father Name")
            {
                tb_f_name_signup.Text = "";
                tb_f_name_signup.ForeColor = Color.Black;
            }
        }

        private void tb_f_name_signup_Leave(object sender, EventArgs e)
        {
            if (tb_f_name_signup.Text == "")
            {
                tb_f_name_signup.Text = "Father Name";
                tb_f_name_signup.ForeColor = Color.Silver;
            }
        }

        private void tb_age_signup_Enter(object sender, EventArgs e)
        {
            if (tb_age_signup.Text == "Age")
            {
                tb_age_signup.Text = "";
                tb_age_signup.ForeColor = Color.Black;
            }
        }

        private void tb_age_signup_Leave(object sender, EventArgs e)
        {
            if (tb_age_signup.Text == "")
            {
                tb_age_signup.Text = "Age";
                tb_age_signup.ForeColor = Color.Silver;
            }
        }

        private void tb_gender_signup_Enter(object sender, EventArgs e)
        {
            if (tb_gender_signup.Text == "Gender")
            {
                tb_gender_signup.Text = "";
                tb_gender_signup.ForeColor = Color.Black;
            }
        }

        private void tb_gender_signup_Leave(object sender, EventArgs e)
        {
            if (tb_gender_signup.Text == "")
            {
                tb_gender_signup.Text = "Gender";
                tb_gender_signup.ForeColor = Color.Silver;
            }
        }

        private void tb_password_signup_Enter(object sender, EventArgs e)
        {
            if (tb_password_signup.Text == "Password")
            {
                tb_password_signup.Text = "";
                tb_password_signup.ForeColor = Color.Black;
            }
        }

        private void tb_password_signup_Leave(object sender, EventArgs e)
        {
            if (tb_password_signup.Text == "")
            {
                tb_password_signup.Text = "Password";
                tb_password_signup.ForeColor = Color.Silver;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//show of password signup
        {
            if (checkBox2.Checked)
            {
                tb_password_signup.UseSystemPasswordChar = true;
            }
            else
            {
                tb_password_signup.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_register_signup_Click(object sender, EventArgs e)
        {
            try
            {
                access_to_database();
                com.CommandType = CommandType.Text;
                com.CommandText = "Insert into User_Info(Mobile_Number,First_Name,Last_Name,Full_Name,Father_Full_Name,Gender,age,Password) values (@Mobile_Number,@First_Name,@Last_Name,@Full_Name,@Father_Full_Name,@Gender,@age,@Password)";
                com.Parameters.AddWithValue("@Mobile_Number", tb_mob_no_signup.Text);
                com.Parameters.AddWithValue("@First_Name", tb_name_signup.Text);
                com.Parameters.AddWithValue("@Last_Name", textBox1_l_name_signup.Text);
                com.Parameters.AddWithValue("@Full_Name", tb_name_signup.Text + " " + textBox1_l_name_signup.Text);
                com.Parameters.AddWithValue("@Father_Full_Name", tb_f_name_signup.Text);
                com.Parameters.AddWithValue("@Gender", tb_gender_signup.Text);
                com.Parameters.AddWithValue("@age", tb_age_signup.Text);
                com.Parameters.AddWithValue("@Password", tb_password_signup.Text);
                com.ExecuteNonQuery();
                // com.Parameters.AddWithValue("@Visit_No", "0");
                MessageBox.Show("You are registered!");
                panel1_login.Visible = true;
                panel1_signup.Visible = false;
            }
            catch (Exception exceptions)
            {
                Console.WriteLine(" Exception caught.", exceptions);
                MessageBox.Show("you break some rules :");

            }
        }

        private void pictureBox5_register_signup_MouseHover(object sender, EventArgs e)
        {
            pictureBox5_register_signup.Image = Resources.REGISTER;
        }

        private void pictureBox5_register_signup_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5_register_signup.Image = Resources.LIGHT_REGISTER;
        }

        private void linkLabel1_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1_login.Visible = true;
            panel1_signup.Visible = false;
        }

        private void pictureBox5_home_MouseHover(object sender, EventArgs e)
        {
            pictureBox5_home.Image = Resources.home;
        }

        private void pictureBox5_home_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5_home.Image = Resources.home_light;
        }

        private void pictureBox5_home_Click(object sender, EventArgs e)
        {
            panel1_signup.Visible = false;
            panel1_login.Visible = false;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Image = Resources.red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = Resources.black;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1_signup.Visible = false;
            panel1_login.Visible = false;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Image = Resources.home;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Resources.home_light;
        }

        private void panel1_homepage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_menu_homepage_Click(object sender, EventArgs e)
        {
    
            if (panel1_menu_homepage.Height == 600 & panel1_menu_homepage.Width ==208)
            {
                
                panel1_menu_homepage.Height = 600;
                panel1_menu_homepage.Width = 44;
                button1_menu_homepage.Left = 5;
             

            }
        
            else
            {
               
                panel1_menu_homepage.Height = 600;
                panel1_menu_homepage.Width = 208;
                button1_menu_homepage.Left = 169;
             
            }
     
        }

        private void panel1_menu_homepage_Paint(object sender, PaintEventArgs e)
        {
            panel1_menu_homepage.Height = 600;
            panel1_menu_homepage.Width = 208;
            button1_menu_homepage.Left = 169;
           
     
               
            

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void btn_view_profile_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_select_symptom_Click(object sender, EventArgs e)
        {
            panel1_test_guidance.Visible = false;
            a++;
            if (a % 2 != 0)
            {
                pane1_symptom_select.Visible = true;
            }
            else { pane1_symptom_select.Visible = false; }
           
        }


        private void btn_test_recommended_Click(object sender, EventArgs e)
        {
            b++;
            if (b % 2 != 0)
            {
                pane1_symptom_select.Visible = true;
                panel1_test_guidance.Visible = true;
                
                panel1_report.Visible = false;
            }
            else { pane1_symptom_select.Visible = false;
                panel1_test_guidance.Visible = false;
                panel1_report.Visible = false;
            }
           
        }

        private void btn_possible_diseases_Click(object sender, EventArgs e)
        {
            c++;
            if (c % 2 != 0)
            {
                pane1_symptom_select.Visible = true;
                
                panel1_test_guidance.Visible = true;
                panel1_report.Visible = true;

            }
            else
            {
                pane1_symptom_select.Visible = false;
                panel1_test_guidance.Visible = false;
                panel1_report.Visible =false;
            }

        }

        private void btn_your_record_Click(object sender, EventArgs e)
        {
            
        }

        private void pane1_symptom_select_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_view_prof_slide_Click(object sender, EventArgs e)
        {

        }

        private void btn_view_profile_MouseHover(object sender, EventArgs e)
        {
            textBox1_profile_from_db.Visible = true;
            pictureBox8_view_prof_slide.Visible = true;
            access_to_database();
                com.CommandText="Select Full_Name from User_Info where Mobile_Number = @Mobile_Number ";
            com.Parameters.AddWithValue("@Mobile_Number", textBox1_mob_no.Text);
            dr = com.ExecuteReader();
            if (dr.Read())
            { textBox1_profile_from_db.Text= dr["Full_Name"].ToString(); ; }
        }

        private void btn_view_profile_MouseLeave(object sender, EventArgs e)
        {
            textBox1_profile_from_db.Visible = false;
            pictureBox8_view_prof_slide.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.Image = Resources.red;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = Resources.black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_mob_no.ResetText();
            textBox2_password.ResetText();
            panel1_homepage.Visible = false;
            panel1_login.Visible = false;
            panel1_signup.Visible = false;
            panel1_menu_homepage.Visible = false;
            

        }

        private void checkedListBox1_SymptomCheck_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_SUBMIT_SYMPTOMS_Click(object sender, EventArgs e)
        {
            checkedListBox2_TestCheck.Items.Clear();
            DialogResult dialogResult = MessageBox.Show("Proceed?", "Symptom", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pane1_symptom_select.Visible = true;
                panel1_test_guidance.Visible =false;
                string Symptom;





                if (checkedListBox1_SymptomCheck.CheckedItems.Count == 1)
                {
                    foreach (string s in checkedListBox1_SymptomCheck.CheckedItems)
                    {


                        Symptom = s;

                        access_to_database();

                        com.CommandType = CommandType.Text;
                        com.CommandText = "Select Test_Name from Verified_By where( Disease_Name = ANY(Select Disease_Name   from Might_Diagnose where  Symptom_Name = @Symptom_Name ))";

                        com.Parameters.AddWithValue("@Symptom_Name", Symptom);

                        //com.Parameters.AddWithValue("@Symptom_Name2", "Forget the names");

                        com.ExecuteNonQuery();
                        dr = com.ExecuteReader(); while (dr.Read())
                        {
                            if (!(checkedListBox2_TestCheck.Items.Contains((dr["Test_Name"]).ToString())))
                                checkedListBox2_TestCheck.Items.Add(dr["Test_Name"]).ToString();
                        }
                        con.Close();


                    }
                }

                else
                {
                    MessageBox.Show("You have either selected no or more than ONE symptoms");

                    pane1_symptom_select.Visible = true;
                    panel1_test_guidance.Visible = false;

                }
            }

            if (dialogResult == DialogResult.No)
            {
                pane1_symptom_select.Visible = true;
                panel1_test_guidance.Visible = false;
            }


            //checkedListBox1_SymptomCheck.SelectedItems.Remove(checkedListBox2_TestCheck.SelectedItems);
            foreach (int i in checkedListBox1_SymptomCheck.CheckedIndices)
            {
                checkedListBox1_SymptomCheck.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void pictureBox10_SUBMIT_SYMPTOMS_MouseHover(object sender, EventArgs e)
        {
            pictureBox10_SUBMIT_SYMPTOMS.Image = Resources.submit;
        }

        private void pictureBox10_SUBMIT_SYMPTOMS_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10_SUBMIT_SYMPTOMS.Image = Resources.submit_light;
        }

        private void btn_select_symptom_Enter(object sender, EventArgs e)
        {

            pane1_symptom_select.Visible = true; 
            
             pane1_symptom_select.Visible = false; 
        }

        private void btn_select_symptom_Leave(object sender, EventArgs e)
        {
            
        }

        private void btn_select_symptom_MouseClick(object sender, MouseEventArgs e)
        {
            
        }



        private void textBox1_l_name_signup_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_l_name_signup_Enter(object sender, EventArgs e)
        {
            if (textBox1_l_name_signup.Text == "Last Name")
            {
                textBox1_l_name_signup.Text = "";
                textBox1_l_name_signup.ForeColor = Color.Black;
            }
        }

        private void textBox1_l_name_signup_Leave(object sender, EventArgs e)
        {
            if (textBox1_l_name_signup.Text == "")
            {
                textBox1_l_name_signup.Text = "Last Name";
                textBox1_l_name_signup.ForeColor = Color.Silver;
            }
        }

        private void pictureBox9_submit_test_MouseHover(object sender, EventArgs e)
        {
            pictureBox9_submit_test.Image = Resources.submit;
        }

        private void pictureBox9_submit_test_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9_submit_test.Image = Resources.submit_light;
        }

        private void panel1_test_guidance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_Test_Recommended_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_report_Paint(object sender, PaintEventArgs e)
        {
          

        }

        private void pictureBox9_submit_test_Click(object sender, EventArgs e)
        {
            if (checkedListBox2_TestCheck.CheckedItems.Count >= 1)
            {
                foreach (string s in checkedListBox2_TestCheck.CheckedItems)
                {

                    access_to_database();

                    com.CommandType = CommandType.Text;
                    com.CommandText = "Select Disease_Name from Verified_By where Test_Name =@Test_Name";

                    com.Parameters.AddWithValue("@Test_Name", s);

                    //com.Parameters.AddWithValue("@Symptom_Name2", "Forget the names");

                    pane1_symptom_select.Visible = false;
                    panel1_report.Visible = true;
                    com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!(listBox1_Disease_from_Test.Items.Contains((dr["Disease_Name"]).ToString())))
                        { listBox1_Disease_from_Test.Items.Add(dr["Disease_Name"]).ToString(); }
                    }
                    con.Close();

                    //--------------------------
                    con.Open();
                    com.CommandText = "Select Medicine_Name from Need where Disease_Name  IN(Select Disease_Name from Verified_By where Test_Name =@Teest_Name) ";
                    com.Parameters.AddWithValue("@Teest_Name", s);
                    com.ExecuteNonQuery();
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!(listBox3_medicine_from_Disease.Items.Contains((dr["Medicine_Name"]).ToString())))
                        { listBox3_medicine_from_Disease.Items.Add(dr["Medicine_Name"]).ToString(); }
                    }
                    con.Close();
                }
                foreach (string r in checkedListBox2_TestCheck.CheckedItems)

                    listBox2_Test_Recommended.Items.Add(r);
                //--------------------------




                checkedListBox2_TestCheck.Items.Clear();
            }
            else
            { MessageBox.Show("You are good :) !! khaao peyyo eshh karo :P ,although visit our heatlhcare for more satisfaction"); }
        }

        private void textBox1_profile_from_db_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

