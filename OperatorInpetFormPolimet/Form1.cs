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
        Param[] Params = new Param[5];
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

            Params[0] = new Param() { NameShort = "Param_1" };
            Params[1] = new Param() { NameShort = "Param_2" };
            Params[2] = new Param() { NameShort = "Param_3" };
            Params[3] = new Param() { NameShort = "Param_4" };
            Params[4] = new Param() { NameShort = "Param_5" };
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
            if (CheckParamInputAll())
            {
                string ss = Path.GetDirectoryName(Application.StartupPath);
                StringBuilder sb = new StringBuilder(txtbTime.Text);
                sb.Append(";" + Params[0].GetStringToCSV(rbValue1.Checked, txtbValueOpt1.Text, txtbValueReal1.Text, txtbComment1.Text));
                sb.Append(";" + Params[1].GetStringToCSV(rbValue2.Checked, txtbValueOpt2.Text, txtbValueReal2.Text, txtbComment2.Text));
                sb.Append(";" + Params[2].GetStringToCSV(rbValue3.Checked, txtbValueOpt3.Text, txtbValueReal3.Text, txtbComment3.Text));
                sb.Append(";" + Params[3].GetStringToCSV(rbValue4.Checked, txtbValueOpt4.Text, txtbValueReal4.Text, txtbComment4.Text));
                sb.Append(";" + Params[4].GetStringToCSV(rbValue5.Checked, txtbValueOpt5.Text, txtbValueReal5.Text, txtbComment5.Text));
                WriteToCSV(sb.ToString());
            }


        }

        //Запись в csv файл
        private void WriteToCSV (string strToWrite)
        {
            string ss = Path.GetDirectoryName(Application.StartupPath);
            CSVLog csvLog = new CSVLog(ss);
            try
            {
                csvLog.WriteToCSV(strToWrite);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка записи данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            MessageBox.Show("Данные с меткой времени " + txtbTime.Text + " записаны!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();

        }

        //Проверка ввода для всех параметров
        private bool CheckParamInputAll()
        {
            if (!CheckParamInput1())
            {
                MessageBox.Show("Значение не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckParamInput2())
            {
                MessageBox.Show("Значение не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckParamInput3())
            {
                MessageBox.Show("Значение не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckParamInput4())
            {
                MessageBox.Show("Значение не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckParamInput5())
            {
                MessageBox.Show("Значение не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Проверка что введенные данные корректны для 1 параметра
        private bool CheckParamInput1()
        {
            if (rbValue1.Checked)
            {
                if(string.IsNullOrEmpty(txtbValueOpt1.Text) && string.IsNullOrEmpty(txtbValueReal1.Text))
                {
                    if (string.IsNullOrEmpty(txtbValueOpt1.Text))
                    {
                        txtbValueOpt1.Select();
                    }
                    else
                    {
                        txtbValueReal1.Select();
                    }
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtbComment1.Text))
                {
                    txtbComment1.Select();
                    return false;
                }
            }
            return true;
        }

        //Проверка что введенные данные корректны для 2 параметра
        private bool CheckParamInput2()
        {
            if (rbValue2.Checked)
            {
                if (string.IsNullOrEmpty(txtbValueOpt2.Text) && string.IsNullOrEmpty(txtbValueReal2.Text))
                {
                    if (string.IsNullOrEmpty(txtbValueOpt2.Text))
                    {
                        txtbValueOpt2.Select();
                    }
                    else
                    {
                        txtbValueReal2.Select();
                    }
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtbComment2.Text))
                {
                    txtbComment2.Select();
                    return false;
                }
            }
            return true;
        }

        //Проверка что введенные данные корректны для 3 параметра
        private bool CheckParamInput3()
        {
            if (rbValue3.Checked)
            {
                if (string.IsNullOrEmpty(txtbValueOpt3.Text) && string.IsNullOrEmpty(txtbValueReal3.Text))
                {
                    if (string.IsNullOrEmpty(txtbValueOpt3.Text))
                    {
                        txtbValueOpt3.Select();
                    }
                    else
                    {
                        txtbValueReal3.Select();
                    }
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtbComment3.Text))
                {
                    txtbComment3.Select();
                    return false;
                }
            }
            return true;
        }

        //Проверка что введенные данные корректны для 4 параметра
        private bool CheckParamInput4()
        {
            if (rbValue4.Checked)
            {
                if (string.IsNullOrEmpty(txtbValueOpt4.Text) && string.IsNullOrEmpty(txtbValueReal4.Text))
                {
                    if (string.IsNullOrEmpty(txtbValueOpt4.Text))
                    {
                        txtbValueOpt4.Select();
                    }
                    else
                    {
                        txtbValueReal4.Select();
                    }
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtbComment4.Text))
                {
                    txtbComment4.Select();
                    return false;
                }
            }
            return true;
        }

        //Проверка что введенные данные корректны для 5 параметра
        private bool CheckParamInput5()
        {
            if (rbValue5.Checked)
            {
                if (string.IsNullOrEmpty(txtbValueOpt5.Text) && string.IsNullOrEmpty(txtbValueReal5.Text))
                {
                    if (string.IsNullOrEmpty(txtbValueOpt5.Text))
                    {
                        txtbValueOpt5.Select();
                    }
                    else
                    {
                        txtbValueReal5.Select();
                    }
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtbComment5.Text))
                {
                    txtbComment5.Select();
                    return false;
                }
            }
            return true;
        }

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
