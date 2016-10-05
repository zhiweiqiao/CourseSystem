using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseSys
{
    public partial class changepass : Form
    {
        public changepass()
        {
            InitializeComponent();       
        }

        //更改密码功能

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "--选择身份--")
            {
                MessageBox.Show("请选择身份并填写数据！");
            }
            try
            {
                if (comboBox1.SelectedItem.ToString() == "管理员")
                {

                    string sql = "select userID,password from admin where userID='" + textBox1.Text + "'";
                    string sql2 = "update admin set password ='" + textBox4.Text + "' where userID='" + textBox1.Text + "'";

                    SqlConnection cnn = new SqlConnection
                            ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    cnn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    if (!myReader.HasRows)
                    {
                        MessageBox.Show("用户名不存在，请重新输入！");
                        this.errorProvider1.SetError(this.textBox1, "用户名输入错误");
                        label5.Text = "用户名不存在";
                        textBox1.Text = "";
                        return;
                    }
                    while (myReader.Read())
                    {
                        //判断用户输入是否正确  
                        if (myReader["password"].ToString().Trim() != textBox2.Text.Trim())
                        {
                            MessageBox.Show("用户密码不正确，请重新输入！");
                            this.errorProvider1.SetError(this.textBox2, "用户密码输入错误");
                            label6.Text = "密码输入错误";
                            textBox2.Text = "";
                            return;
                        }


                    }
                    cnn.Close();
                    if (textBox3.Text != textBox4.Text)
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入！");
                        this.errorProvider1.SetError(this.textBox4, "密码输入不一致");
                        label7.Text = "两次密码输入不一致";
                        textBox4.Text = "";
                        return;

                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                        try
                        {
                            cnn.Open();
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("密码修改成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出现错误,错误原因为" + ex.Message,
                                "系统提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (cnn.State == ConnectionState.Open)
                                cnn.Close();//关闭连接
                        }

                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else if (comboBox1.SelectedItem.ToString() == "学生")
                {
                    string sql = "select Sno,Spass from Student where Sno='" + textBox1.Text + "'";
                    string sql2 = "update Student set Spass ='" + textBox4.Text + "' where Sno='" + textBox1.Text + "'";

                    SqlConnection cnn = new SqlConnection
                            ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    cnn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    if (!myReader.HasRows)
                    {
                        MessageBox.Show("用户名不存在，请重新输入！");
                        this.errorProvider1.SetError(this.textBox1, "用户名输入错误");
                        label5.Text = "用户名不存在";
                        textBox1.Text = "";
                        return;
                    }
                    while (myReader.Read())
                    {
                        //判断用户输入是否正确  
                        if (myReader["Spass"].ToString().Trim() != textBox2.Text.Trim())
                        {
                            MessageBox.Show("用户密码不正确，请重新输入！");
                            this.errorProvider1.SetError(this.textBox2, "用户密码输入错误");
                            label6.Text = "密码输入错误";
                            textBox2.Text = "";
                            return;
                        }


                    }
                    cnn.Close();
                    if (textBox3.Text != textBox4.Text)
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入！");
                        this.errorProvider1.SetError(this.textBox4, "密码输入不一致");
                        label7.Text = "两次密码输入不一致";
                        textBox4.Text = "";
                        return;

                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                        try
                        {
                            cnn.Open();
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("密码修改成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出现错误,错误原因为" + ex.Message,
                                "系统提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (cnn.State == ConnectionState.Open)
                                cnn.Close();//关闭连接
                        }
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else if (comboBox1.SelectedItem.ToString() == "老师")
                {
                    string sql = "select Tno,Tpass from Teacher where Tno='" + textBox1.Text + "'";
                    string sql2 = "update Teacher set Tpass ='" + textBox4.Text + "' where Tno='" + textBox1.Text + "'";

                    SqlConnection cnn = new SqlConnection
                            ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    cnn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    if (!myReader.HasRows)
                    {
                        MessageBox.Show("用户名不存在，请重新输入！");
                        this.errorProvider1.SetError(this.textBox1, "用户名输入错误");
                        label5.Text = "用户名不存在";
                        textBox1.Text = "";
                        return;
                    }
                    while (myReader.Read())
                    {
                        //判断用户输入是否正确  
                        if (myReader["Tpass"].ToString().Trim() != textBox2.Text.Trim())
                        {
                            MessageBox.Show("用户密码不正确，请重新输入！");
                            this.errorProvider1.SetError(this.textBox2, "用户密码输入错误");
                            label6.Text = "密码输入错误";
                            textBox2.Text = "";
                            return;
                        }


                    }
                    cnn.Close();
                    if (textBox3.Text != textBox4.Text)
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入！");
                        this.errorProvider1.SetError(this.textBox4, "密码输入不一致");
                        label7.Text = "两次密码输入不一致";
                        textBox4.Text = "";
                        return;

                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                        try
                        {
                            cnn.Open();
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("密码修改成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出现错误,错误原因为" + ex.Message,
                                "系统提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (cnn.State == ConnectionState.Open)
                                cnn.Close();//关闭连接
                        }
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else if (comboBox1.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("你还没有选择身份！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误,错误原因为" + ex.Message,
                    "系统提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}