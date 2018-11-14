using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorInpetFormPolimet
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            string nameRusParam1=null;
            string nameRusParam2 = null;
            string nameRusParam3 = null;
            string nameRusParam4 = null;
            string nameRusParam5 = null;
            string fileNameCSV = null;

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                nameRusParam1 = appSettings["Param_1"] ;
                nameRusParam2 = appSettings["Param_2"] ;
                nameRusParam3 = appSettings["Param_3"] ;
                nameRusParam4 = appSettings["Param_4"] ;
                nameRusParam5 = appSettings["Param_5"];
                fileNameCSV = appSettings["FileNameCSV"]  ;
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу настроек", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtbParam1.Text = nameRusParam1;
            txtbParam2.Text = nameRusParam2;
            txtbParam3.Text = nameRusParam3;
            txtbParam4.Text = nameRusParam4;
            txtbParam5.Text = nameRusParam5;
            txtbNameCSVFile.Text = fileNameCSV;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (!string.IsNullOrEmpty(txtbParam1.Text.Trim()))
                {
                    if (settings["Param_1"] == null)
                    {
                        settings.Add("Param_1", txtbParam1.Text.Trim());
                    }
                    else
                    {
                        settings["Param_1"].Value = txtbParam1.Text.Trim();
                    }
                }

                if (!string.IsNullOrEmpty(txtbParam2.Text.Trim()))
                {
                    if (settings["Param_2"] == null)
                    {
                        settings.Add("Param_2", txtbParam2.Text.Trim());
                    }
                    else
                    {
                        settings["Param_2"].Value = txtbParam2.Text.Trim();
                    }
                }

                if (!string.IsNullOrEmpty(txtbParam3.Text.Trim()))
                {
                    if (settings["Param_3"] == null)
                    {
                        settings.Add("Param_3", txtbParam3.Text.Trim());
                    }
                    else
                    {
                        settings["Param_3"].Value = txtbParam3.Text.Trim();
                    }
                }

                if (!string.IsNullOrEmpty(txtbParam4.Text.Trim()))
                {
                    if (settings["Param_4"] == null)
                    {
                        settings.Add("Param_4", txtbParam4.Text.Trim());
                    }
                    else
                    {
                        settings["Param_4"].Value = txtbParam4.Text.Trim();
                    }
                }

                if (!string.IsNullOrEmpty(txtbParam5.Text.Trim()))
                {
                    if (settings["Param_5"] == null)
                    {
                        settings.Add("Param_5", txtbParam5.Text.Trim());
                    }
                    else
                    {
                        settings["Param_5"].Value = txtbParam5.Text.Trim();
                    }
                }

                if (!string.IsNullOrEmpty(txtbNameCSVFile.Text.Trim()))
                {
                    if (settings["FileNameCSV"] == null)
                    {
                        settings.Add("FileNameCSV", txtbNameCSVFile.Text.Trim());
                    }
                    else
                    {
                        settings["FileNameCSV"].Value = txtbNameCSVFile.Text.Trim();
                    }
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
