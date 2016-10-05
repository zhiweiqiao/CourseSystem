using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//学生身份登陆后界面

namespace CourseSys
{
    public partial class studentlogin : Form
    {
      String TxtValue="";

        public studentlogin(String TxtValue)
        {
            InitializeComponent();
            this.TxtValue = TxtValue;  
            this.label6.Text ="你的学号是："+ TxtValue;  　
        }

        private void studentlogin_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select Cno as 课程号,Cname as 课程名,Ccredit as 学分,Semester as 学期 From Course ",
                  "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");

            try   
            {
                DataSet myDataSet = new DataSet();

                myDataAapter.Fill(myDataSet, "Course");
                dataGridView1.DataSource = myDataSet.Tables["Course"];
                   
            }
            catch (Exception ex)
            {
                  MessageBox.Show("出现错误,错误原因为" + ex.Message,
                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button3_Click(object sender, EventArgs e)   
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("查询条件不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            string sql = "insert into SC(Sno,Cno,Grade,XKLB) values ('"+this.TxtValue+"','"+this.textBox1.Text+"',null,null)";
            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            try 
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("选课成功！");
            }
            catch (Exception)
            {
                MessageBox.Show("你已经选了这门课了！");
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();//关闭连接  
            }
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select s.Sno as 学号,s.Cno as 课程号,c.Cname as 课程名,c.Ccredit as 学分,c.Semester as 学期 from SC s join Course c on s.Cno=c.Cno where s.Sno='"+this.TxtValue+"'",
                "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");  
            DataSet myDataSet = new DataSet();
            //
             
            myDataAapter.Fill(myDataSet, "SC,Course");  
            dataGridView3.DataSource = myDataSet.Tables["SC,Course"]; 
           
            
              


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("查询条件不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           

            string sql = "Select Cname,Ccredit,Semester from Course where Cno='" + textBox1.Text + "'";

            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();  

            SqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            //返回指定列
            {
                label7.Text = myReader.GetValue(0).ToString();      
                label10.Text = myReader.GetValue(1).ToString();
                label11.Text = myReader.GetValue(2).ToString();
            }
            else MessageBox.Show(this, "没有找到结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cnn.Close();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("查询条件不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            
            string sql = "delete from SC where Sno='"+TxtValue+"'and Cno='"+textBox1.Text+"' ";  
            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            try
            {  
                cnn.Open();
                 
                cmd.ExecuteNonQuery();
                MessageBox.Show("退选成功！"); 
               
            }
            catch (Exception)
            {
                MessageBox.Show("你还没有选这门课！");
            }
            finally
            {
              
                if (cnn.State == ConnectionState.Open) 
                    cnn.Close();//关闭连接  
            }
                  SqlDataAdapter myDataAapter = new SqlDataAdapter("Select s.Sno as 学号,s.Cno as 课程号,c.Cname as 课程名,c.Ccredit as 学分,c.Semester as 学期 from SC s join Course c on s.Cno=c.Cno where s.Sno='" + this.TxtValue + "'",
                "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //
              myDataAapter.Fill(myDataSet, "SC,Course");
            dataGridView3.DataSource = myDataSet.Tables["SC,Course"];
                
        
            
           
        }

        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
           //  if (dataGridView2.CurrentCell == null)
              // MessageBox.Show("你还没有选择一门课程！");
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myDataAapter = new SqlDataAdapter("Select s.Sno as 学号,s.Cno as 课程号,c.Cname as 课程名,s.Grade as 成绩,排名=(select count(Grade)+1 from SC where Grade>s.Grade)  from SC s  join Course c on s.Cno=c.Cno where s.Sno='" + this.TxtValue + "'",
               "Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            DataSet myDataSet = new DataSet();
            //   
            myDataAapter.Fill(myDataSet, "SC,Course");
            dataGridView2.DataSource = myDataSet.Tables["SC,Course"];


            string sql = "Select sum(s.Grade) as 总分,avg(s.Grade) as 平均分 from SC s  join Course c on s.Cno=c.Cno where s.Sno='" + TxtValue　 + "' group by  s.Sno";

            SqlConnection cnn = new SqlConnection
                ("Data Source=.;Initial Catalog=CourseSys;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();

            SqlDataReader myReader = cmd.ExecuteReader();
            while  (myReader.Read())
            //返回指定列
            {
                label14.Text = myReader.GetValue(0).ToString()+"分";
                label15.Text = myReader.GetValue(1).ToString() + "分";
                
            }
            cnn.Close();
        }
    }
}