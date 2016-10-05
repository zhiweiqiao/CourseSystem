using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//教师身份登陆后界面

namespace CourseSys
{
    public partial class teacherlogin : Form
    {
        String TxtValue = "";
        public teacherlogin(String TxtValue) 
        {
            InitializeComponent();
            this.TxtValue = TxtValue; 
            this.label2.Text = "你的教师号是：" + TxtValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        private void button15_Click(object sender, EventArgs e)
        {
            changepass f = new changepass();
            f.Show();
        }

        private void teacherlogin_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select t.Tno as 教师号, t.Tname as 姓名, c.Cno as 课程号,c.Cname as 课程名,c.Ccredit as 学分,c.Semester as 学期 From Course c join Teacher t on c.Cname=t.Tcourse where t.Tno='"+TxtValue+"' ",
                  "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");

            try
            {
                DataSet myDataSet = new DataSet(); 

                myDataAapter.Fill(myDataSet, "Course,Teacher");
                dataGridView1.DataSource = myDataSet.Tables["Course,Teacher"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误,错误原因为" + ex.Message,
                  "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length <= 0))
            {
                MessageBox.Show("查询条件不能为空或条件错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select t.Tno as 教师号, t.Tcno as 课程号,t.Tcourse as 课程名,s.Sno as 学号,s.Sname as 姓名,c.Grade as 成绩 From SC c join Teacher t on c.Cno=t.Tcno join Student s on c.Sno=s.Sno where t.Tno='"+TxtValue+"' and t.Tcno='"+textBox1.Text+"' ",
                  "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");

            try 
            {
                DataSet myDataSet = new DataSet();

                myDataAapter.Fill(myDataSet, "SC,Teacher,Student");
                dataGridView2.DataSource = myDataSet.Tables["SC,Teacher,Student"];
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误,错误原因为" + ex.Message,
                  "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text.Length <= 0))
            {
                MessageBox.Show("查询条件不能为空或条件错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                        
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select t.Tno as 教师号, t.Tcno as 课程号,t.Tcourse as 课程名,s.Sno as 学号,s.Sname as 姓名,c.Grade as 成绩 From SC c join Teacher t on c.Cno=t.Tcno join Student s on c.Sno=s.Sno where t.Tno='" + TxtValue + "' and t.Tcno='" + textBox1.Text + "' and s.Sno='"+textBox2.Text+"' ",
                  "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");

            try 
            { 
                DataSet myDataSet = new DataSet();

                myDataAapter.Fill(myDataSet, "SC,Teacher,Student");
                dataGridView3.DataSource = myDataSet.Tables["SC,Teacher,Student"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误,错误原因为" + ex.Message,
                  "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text.Length <= 0)||(textBox3.Text.Length>3))
            {
                MessageBox.Show("输入有误！请输入要录入或修改的成绩！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;  
            }

            if (dataGridView3.CurrentCell == null)
            {
                MessageBox.Show("没有可更改的成绩！");
            }
            else
            {

                string sql = "update SC set Grade=" + textBox3.Text + " where Sno='" + textBox2.Text + "' and Cno='" + textBox1.Text + "'";

                SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, cnn);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("成绩录入或修改成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误,错误原因为" + ex.Message,
                        "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();//关闭连接
                }
                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select t.Tno as 教师号, t.Tcno as 课程号,t.Tcourse as 课程名,s.Sno as 学号,s.Sname as 姓名,c.Grade as 成绩 From SC c join Teacher t on c.Cno=t.Tcno join Student s on c.Sno=s.Sno where t.Tno='" + TxtValue + "' and t.Tcno='" + textBox1.Text + "' and s.Sno='" + textBox2.Text + "' ",
                     "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");

                try
                {
                    DataSet myDataSet = new DataSet();

                    myDataAapter.Fill(myDataSet, "SC,Teacher,Student");
                    dataGridView3.DataSource = myDataSet.Tables["SC,Teacher,Student"];

                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误,错误原因为" + ex.Message,
                      "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}