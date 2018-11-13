using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorInpetFormPolimet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbComment1_CheckedChanged(this, null);
            rbComment2_CheckedChanged(this, null);
            rbComment3_CheckedChanged(this, null);
            rbComment4_CheckedChanged(this, null);
            rbComment5_CheckedChanged(this, null);

           // txtbTime.Text = DateTime.Now.ToLongDateString();
            txtbTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void rbComment1_CheckedChanged(object sender, EventArgs e)
        {
           if( rbValue1.Checked )
            {
                txtbComment1.Enabled = false;
                txtbComment1.Clear();
                txtbValueOpt1.Enabled = true;
                txtbValueReal1.Enabled = true;
            }
            else if (rbComment1.Checked)
            {
                txtbComment1.Enabled = true;
                txtbValueOpt1.Enabled = false;
                txtbValueReal1.Enabled = false;
                txtbValueOpt1.Clear();
                txtbValueReal1.Clear();
            }
        }

        private void rbComment2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValue2.Checked)
            {
                txtbComment2.Enabled = false;
                txtbComment2.Clear();
                txtbValueOpt2.Enabled = true;
                txtbValueReal2.Enabled = true;
            }
            else if (rbComment2.Checked)
            {
                txtbComment2.Enabled = true;
                txtbValueOpt2.Enabled = false;
                txtbValueReal2.Enabled = false;
                txtbValueOpt2.Clear();
                txtbValueReal2.Clear();
            }

        }

        private void rbComment3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValue3.Checked)
            {
                txtbComment3.Enabled = false;
                txtbComment3.Clear();
                txtbValueOpt3.Enabled = true;
                txtbValueReal3.Enabled = true;
            }
            else if (rbComment3.Checked)
            {
                txtbComment3.Enabled = true;
                txtbValueOpt3.Enabled = false;
                txtbValueReal3.Enabled = false;
                txtbValueOpt3.Clear();
                txtbValueReal3.Clear();
            }
        }

        private void rbComment4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValue4.Checked)
            {
                txtbComment4.Enabled = false;
                txtbComment4.Clear();
                txtbValueOpt4.Enabled = true;
                txtbValueReal4.Enabled = true;
            }
            else if (rbComment4.Checked)
            {
                txtbComment4.Enabled = true;
                txtbValueOpt4.Enabled = false;
                txtbValueReal4.Enabled = false;
                txtbValueOpt4.Clear();
                txtbValueReal4.Clear();
            }

        }

        private void rbComment5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValue5.Checked)
            {
                txtbComment5.Enabled = false;
                txtbComment5.Clear();
                txtbValueOpt5.Enabled = true;
                txtbValueReal5.Enabled = true;
            }
            else if (rbComment5.Checked)
            {
                txtbComment5.Enabled = true;
                txtbValueOpt5.Enabled = false;
                txtbValueReal5.Enabled = false;
                txtbValueOpt5.Clear();
                txtbValueReal5.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtbTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void rbValue4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string ss = Path.GetDirectoryName(Application.StartupPath);
            string strToCSV;

            String temp = txtbComment1.Text.Replace("\r\n", " ").Trim(); ;
            strToCSV = txtbTime.Text + ";"+temp;


            CSVLog csvLog = new CSVLog(ss);
            try
            {
                csvLog.WriteToCSV(strToCSV);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка записи данных", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            MessageBox.Show("Данные с меткой времени " + txtbTime.Text + " записаны!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        //Проверка что введенные данные корректны

        //Очистка формы после записи данных
        private void ClearForm()
        {
            txtbTime.Text = DateTime.Now.ToLocalTime().ToString();
            txtbValueOpt1.Clear();
            txtbValueReal1.Clear();
            txtbComment1.Clear();
            rbValue1.Checked = true;
            

            txtbValueOpt2.Clear();
            txtbValueReal2.Clear();
            txtbComment2.Clear();
            rbValue2.Checked = true;

            txtbValueOpt3.Clear();
            txtbValueReal3.Clear();
            txtbComment3.Clear();
            rbValue3.Checked = true;

            txtbValueOpt4.Clear();
            txtbValueReal4.Clear();
            txtbComment4.Clear();
            rbValue4.Checked = true;

            txtbValueOpt5.Clear();
            txtbValueReal5.Clear();
            txtbComment5.Clear();
            rbValue5.Checked = true;


            // txtbTime.Text = DateTime.Now.ToLongDateString();
            txtbTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox myTb = sender as TextBox;
            if (myTb!=null)
            { 
            if (e.KeyChar == ',')
            
                if (myTb.Text.Trim().Contains(',') || myTb.Text == string.Empty)
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    e.Handled = false;
                    return;
                }
            short res;
            if (Int16.TryParse(e.KeyChar.ToString(), out res))
                e.Handled = false;
            else
                e.Handled = true;
            }
        }

        private void txtbValueOpt1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
