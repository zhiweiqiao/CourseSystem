using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//用户登陆界面

namespace CourseSys
{
    public partial class login : Form
    {
        public login()
        {   
            
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            this.Close();
            Application.Exit();    
        }

        //登陆按钮功能

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
                MessageBox.Show(this, "用户名不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (radioadmin.Checked)
            {
                string sql = "Select userID,password  From admin where userID='" + textBox1.Text + "'";

                SqlConnection cnn = new SqlConnection
                    ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                if (!myReader.HasRows)
                {
                    MessageBox.Show("用户名不存在，请重新输入！");
                    this.errorProvider1.SetError(this.textBox1, "用户名输入错误");
                    label3.Visible = true;
                    label3.Text = "用户名不存在";    
                    textBox1.Text = "";
                    return;
                }
                while (myReader.Read())
                {
                    //判断用户输入是否正确
                    if (myReader["password"].ToString().Trim() != textBox2.Text.Trim())
                    {
                        MessageBox.Show("密码不正确，请重新输入！");
                        this.errorProvider1.SetError(this.textBox2, "密码输入错误");
                        label4.Visible = true;
                        label4.Text = "密码输入错误";
                        textBox2.Text = "";
                        return;
                    }

                    else
                    {
                        adminlogin f2 = new adminlogin();  //管理员身份登陆后界面
                        f2.Show();
                        this.Hide();
                    }
                }
            }  
            else if (radiostu.Checked)  
            {   
                string sql = "Select Sno,Spass  From Student where Sno='" + textBox1.Text + "'";

                SqlConnection cnn = new SqlConnection
                    ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                if (!myReader.HasRows)
                {
                    MessageBox.Show("用户名不存在，请重新输入！");
                    this.errorProvider1.SetError(this.textBox1, "用户名输入错误");
                    label3.Visible = true;
                    label3.Text = "用户名不存在";
                    textBox1.Text = "";
                    return;
                }
                while (myReader.Read())
                {
                    //判断用户输入是否正确
                    if (myReader["Spass"].ToString().Trim() != textBox2.Text.Trim())
                    {
                        MessageBox.Show("密码不正确，请重新输入！");
                        this.errorProvider1.SetError(this.textBox2, "密码输入错误");
                        label4.Visible = true;
                        label4.Text = "密码输入错误";

                        textBox2.Text = "";
                        return;
                    }
                       
                    else
                    {
                        studentlogin f3 = new studentlogin(this.textBox1.Text);
                        f3.Show();              //学生身份登陆后界面
                        this.Hide();
                    }
                }
            }
            else if (radioteac.Checked)
            {
                string sql = "Select distinct Tno,Tpass  From Teacher where Tno='" + textBox1.Text + "'";

                SqlConnection cnn = new SqlConnection
                    ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                if (!myReader.HasRows)
                {
                    MessageBox.Show("用户名不存在，请重新输入！");
                    this.errorProvider1.SetError(this.textBox1, "用户名输入错误");
                    label3.Visible = true;
                    label3.Text = "用户名不存在";
                    textBox1.Text = "";
                    return;
                }
                while (myReader.Read())
                {
                    //判断用户输入是否正确
                    if (myReader["Tpass"].ToString().Trim() != textBox2.Text.Trim())
                    {
                        MessageBox.Show("密码不正确，请重新输入！");
                        this.errorProvider1.SetError(this.textBox2, "密码输入错误");
                        label4.Visible = true;
                        label4.Text = "密码输入错误";
                        textBox2.Text = "";
                        return;
                    }

                    else
                    {
                        teacherlogin f4 = new teacherlogin(this.textBox1.Text);
                        f4.Show();                //教师身份登陆后界面
                        this.Hide();
                    }
                }
            }
            else
                MessageBox.Show("请选择登陆身份！");
        }

        private void login_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }    
    }
}