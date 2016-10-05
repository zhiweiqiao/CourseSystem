using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//管理员登陆后界面

namespace CourseSys
{
    public partial class adminlogin : Form
    {
      
        public adminlogin()
        {
            InitializeComponent();
        }

        private void adminlogin_Load(object sender, EventArgs e)
        {
            
        }

        //重新登陆按钮功能

        private void button1_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Close();
             
        }

        //退出按钮功能

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        //更改密码功能

        private void button15_Click(object sender, EventArgs e)
        {
            changepass f = new changepass();
            f.Show();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            SqlDataAdapter myDataAapter= new SqlDataAdapter("Select Sno as 学号,Sname as 姓名,Ssex as 性别,Sage as 年龄,Sdept as 专业 From Student ",
               "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //
            myDataAapter.Fill(myDataSet, "Student");
            dataGridView1.DataSource = myDataSet.Tables["Student"];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length <= 0)
            {
                MessageBox.Show("查询条件不能为空！");
            }

            string sql = "Select Sno as 学号,Sname as 姓名,Ssex as 性别,Sage as 年龄,Sdept as 专业 From Student where Sno='"+textBox6.Text+"'";

            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();

            SqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            //返回指定列
            {
                textBox7.Text = myReader.GetValue(0).ToString();
                textBox8.Text = myReader.GetValue(1).ToString();
                textBox9.Text = myReader.GetValue(2).ToString();
                textBox10.Text = myReader.GetValue(3).ToString();
                textBox11.Text = myReader.GetValue(4).ToString();
            }
            else
            {
                MessageBox.Show(this, "没有找到结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = ""; 
            }

            cnn.Close();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length <= 0)||(textBox2.Text.Length<=0)||(textBox3.Text.Length<=0)||(textBox4.Text.Length<=0)||(textBox5.Text.Length<=0))
            {
                MessageBox.Show("请填写完整数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "insert into Student(Sno,Sname,Ssex,Sage,Sdept,Spass) values ('" + textBox1.Text + "','" +textBox2.Text + "','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"',null)";
            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);  
            try  
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("数据插入成功！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
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
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Sno as 学号,Sname as 姓名,Ssex as 性别,Sage as 年龄,Sdept as 专业 From Student ",
               "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //
            myDataAapter.Fill(myDataSet, "Student");
            dataGridView1.DataSource = myDataSet.Tables["Student"];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length<=0)
            {
                MessageBox.Show("没有可更新的数据或更新错误！");
                return;
            }
            else
            {
                DialogResult dl1 = MessageBox.Show(this, "确定要更新这些数据吗？", "系统提示", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information);
                if (dl1 == DialogResult.OK)
                {
                    string sql = "update Student set Sno='" + textBox7.Text + "',Sname='" + textBox8.Text + "',Ssex='" + textBox9.Text + "',Sage='" + textBox10.Text + "',Sdept='" + textBox11.Text + "' where Sno='" + textBox7.Text + "'";
                    SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据更新成功！");
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


                }
                if (dl1 == DialogResult.Cancel)
                {
                    return;
                }
                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Sno as 学号,Sname as 姓名,Ssex as 性别,Sage as 年龄,Sdept as 专业 From Student ",
                  "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                DataSet myDataSet = new DataSet();
                //
                myDataAapter.Fill(myDataSet, "Student");
                dataGridView1.DataSource = myDataSet.Tables["Student"];
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length<=0)
            {
                MessageBox.Show("没有可删除的数据或删除错误！");
                return;
            }
            else 
            {
                DialogResult dl1 = MessageBox.Show(this, "确定要删除这些数据吗？", "系统提示", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information);
                if (dl1 == DialogResult.OK)
                {
                    string sql = "delete from Student where Sno='" + textBox7.Text + "'";
                    SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据删除成功！");
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
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


                }
                if (dl1 == DialogResult.Cancel)
                {
                    return;
                }

                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Sno as 学号,Sname as 姓名,Ssex as 性别,Sage as 年龄,Sdept as 专业 From Student ",
                  "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                DataSet myDataSet = new DataSet();
                //
                myDataAapter.Fill(myDataSet, "Student");
                dataGridView1.DataSource = myDataSet.Tables["Student"];
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox16.Text.Length <= 0)
            {
                MessageBox.Show("查询条件不能为空！");
            }

            string sql = "Select Cno as 课程号,Cname as 课程名,Ccredit as 学分,Semester as 学期 From Course where Cno='" + textBox16.Text + "'";

            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();

            SqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            //返回指定列
            {
                textBox17.Text = myReader.GetValue(0).ToString();
                textBox18.Text = myReader.GetValue(1).ToString();
                textBox19.Text = myReader.GetValue(2).ToString();
                textBox20.Text = myReader.GetValue(3).ToString();
                
            }
            else
            {
                MessageBox.Show(this, "没有找到结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                
            }

            cnn.Close();  
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Cno as 课程号,Cname as 课程名,Ccredit as 学分,Semester as 学期 From Course ",
                   "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //
            myDataAapter.Fill(myDataSet, "Course");
            dataGridView2.DataSource = myDataSet.Tables["Course"];

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((textBox12.Text.Length <= 0) || (textBox13.Text.Length <= 0) || (textBox14.Text.Length <= 0) || (textBox15.Text.Length <= 0))
            {
                MessageBox.Show("请填写完整数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "insert into Course(Cno,Cname,Ccredit,Semester) values ('" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "')";
            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("数据插入成功！");
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
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

            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Cno as 课程号,Cname as 课程名,Ccredit as 学分,Semester as 学期 From Course ",
                   "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //
            myDataAapter.Fill(myDataSet, "Course");
            dataGridView2.DataSource = myDataSet.Tables["Course"];
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox17.Text.Length <= 0)
            {
                MessageBox.Show("没有可更新的数据或更新错误！");
                return;
            }
            else
            {
                DialogResult dl1 = MessageBox.Show(this, "确定要更新这些数据吗？", "系统提示", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information);
                if (dl1 == DialogResult.OK)
                {
                    string sql = "update Course set Cno='" + textBox17.Text + "',Cname='" + textBox18.Text + "',Ccredit='" + textBox19.Text + "',Semester='" + textBox20.Text + "'  where Cno='" + textBox17.Text + "'";
                    SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据更新成功！");
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


                }
                if (dl1 == DialogResult.Cancel)
                {
                    return;
                }

                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Cno as 课程号,Cname as 课程名,Ccredit as 学分,Semester as 学期 From Course ",
                       "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                DataSet myDataSet = new DataSet();
                //
                myDataAapter.Fill(myDataSet, "Course");
                dataGridView2.DataSource = myDataSet.Tables["Course"];
                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox17.Text.Length <= 0)
            {
                MessageBox.Show("没有可删除的数据或删除错误！");
                return;
            }
            else
            {
                DialogResult dl1 = MessageBox.Show(this, "确定要删除这些数据吗？", "系统提示", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information);
                if (dl1 == DialogResult.OK)
                {
                    string sql = "delete from Course where Cno='" + textBox17.Text + "'";
                    SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据删除成功！");
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        textBox20.Text = "";

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


                }
                if (dl1 == DialogResult.Cancel)
                {
                    return;
                }
                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Cno as 课程号,Cname as 课程名,Ccredit as 学分,Semester as 学期 From Course ",
                      "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                DataSet myDataSet = new DataSet();
                //
                myDataAapter.Fill(myDataSet, "Course");
                dataGridView2.DataSource = myDataSet.Tables["Course"];
            }
                
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Tno as 教师号,Tname as 姓名,Tsex as 性别,Tcourse as 所教课程名,Tcollege as 所在院系,Tcno as 所教课程号  From Teacher ",
               "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet(); 
            //
            myDataAapter.Fill(myDataSet, "Teacher");
            dataGridView3.DataSource = myDataSet.Tables["Teacher"];

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if ((textBox21.Text.Length <= 0) || (textBox22.Text.Length <= 0) || (textBox23.Text.Length <= 0) || (textBox24.Text.Length <= 0) || (textBox25.Text.Length <= 0)||(textBox26.Text.Length<=0))
            {
                MessageBox.Show("请填写完整数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "insert into Teacher(Tno,Tname,Tsex,Tcourse,Tcollege,Tpass,Tcno) values ('" + textBox21.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + textBox24.Text + "','" + textBox25.Text + "',null,'"+textBox26.Text+"')";
            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("数据插入成功！");
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox24.Text = "";
                textBox25.Text = "";
                textBox26.Text = "";
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
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Tno as 教师号,Tname as 姓名,Tsex as 性别,Tcourse as 所教课程名,Tcollege as 所在院系,Tcno as 所教课程号  From Teacher ",
               "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //
            myDataAapter.Fill(myDataSet, "Teacher");
            dataGridView3.DataSource = myDataSet.Tables["Teacher"];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox27.Text.Length <= 0)
            {
                MessageBox.Show("查询条件不能为空！");
            }

            string sql = "Select Tno as 教师号,Tname as 姓名,Tsex as 性别,Tcourse as 所教课程名,Tcollege as 所在院系,Tcno as 所教课程号  From Teacher  where Tno='" + textBox27.Text + "'";

            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();

            SqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            //返回指定列
            {
                textBox28.Text = myReader.GetValue(0).ToString();
                textBox29.Text = myReader.GetValue(1).ToString();
                textBox30.Text = myReader.GetValue(2).ToString();
                textBox31.Text = myReader.GetValue(3).ToString();
                textBox32.Text = myReader.GetValue(4).ToString();
                textBox33.Text = myReader.GetValue(5).ToString();

            }
            else
            {
                MessageBox.Show(this, "没有找到结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox28.Text = "";
                textBox29.Text = "";
                textBox30.Text = "";
                textBox31.Text = "";
                textBox32.Text = "";
                textBox33.Text = "";

            }

            cnn.Close();  
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox28.Text.Length <= 0)
            {
                MessageBox.Show("没有可更新的数据或更新错误！");
                return;
            }
            else
            {
                DialogResult dl1 = MessageBox.Show(this, "确定要更新这些数据吗？", "系统提示", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information);
                if (dl1 == DialogResult.OK)
                {
                    string sql = "update Teacher set Tno='" + textBox28.Text + "',Tname='" + textBox29.Text + "',Tsex='" + textBox30.Text + "',Tcourse='" + textBox31.Text + "',Tcollege='" + textBox32.Text + "',Tcno='" + textBox33.Text + "' where Tno='" + textBox28.Text + "'";
                    SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据更新成功！");
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


                }
                if (dl1 == DialogResult.Cancel)
                {
                    return;
                }
                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Tno as 教师号,Tname as 姓名,Tsex as 性别,Tcourse as 所教课程名,Tcollege as 所在院系,Tcno as 所教课程号  From Teacher ",
              "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                DataSet myDataSet = new DataSet();
                //
                myDataAapter.Fill(myDataSet, "Teacher");
                dataGridView3.DataSource = myDataSet.Tables["Teacher"];
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox28.Text.Length <= 0)
            {
                MessageBox.Show("没有可删除的数据或删除错误！");
                return;
            }
            else
            {
                DialogResult dl1 = MessageBox.Show(this, "确定要删除这些数据吗？", "系统提示", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information);
                if (dl1 == DialogResult.OK)
                {
                    string sql = "delete from Teacher where Tno='" + textBox28.Text + "'";
                    SqlConnection cnn = new SqlConnection
                        ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据删除成功！");
                        textBox28.Text = "";
                        textBox29.Text = "";
                        textBox30.Text = "";
                        textBox31.Text = "";
                        textBox32.Text = "";
                        textBox33.Text = "";
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


                }
                if (dl1 == DialogResult.Cancel)
                {
                    return;
                }
                SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Tno as 教师号,Tname as 姓名,Tsex as 性别,Tcourse as 所教课程名,Tcollege as 所在院系,Tcno as 所教课程号  From Teacher ",
            "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                DataSet myDataSet = new DataSet();
                //
                myDataAapter.Fill(myDataSet, "Teacher");
                dataGridView3.DataSource = myDataSet.Tables["Teacher"];
            }
        }
    }
}