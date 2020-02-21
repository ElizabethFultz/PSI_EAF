using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace PSI_EAF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int score = 0;
            string[] info = new String[20];

            score += Convert.ToInt32(txtbx_Age.Text);
            info[0] = txtbx_Age.Text;


            if (rdbtn_Female.IsChecked == true && rdbtn_Male.IsChecked == false)
            {
                info[1] = "Female";
                score -= 10;
            }
            else if(rdbtn_Female.IsChecked == false && rdbtn_Male.IsChecked == true)
            {
                info[1] = "Male";
            }   

            if (chckbx_cmNursingHome.IsChecked == true)
            {
                score += 10;
                info[2] = "1";
            }
            else if(chckbx_cmNursingHome.IsChecked == false) 
            {
                info[2] = "0";
            }
            
            if (chckbx_cmNeoplastic.IsChecked == true)
            {
                score += 30;
                info[3] = "1";
            }
            else if(chckbx_cmNeoplastic.IsChecked == false)
            {
                info[3] = "0";
            }

            if (chckbx_cmLiver.IsChecked == true)
            {
                score += 20;
                info[4] = "1";
            }
            else if (chckbx_cmLiver.IsChecked == false)
            {
                info[4] = "0";
            }

            if (chckbx_cmHeartFailure.IsChecked == true)
            {
                score += 10;
                info[5] = "1";
            }
            else if(chckbx_cmHeartFailure.IsChecked == false)
            {
                info[5] = "0";
            }

            if (chckbx_cmCerebro.IsChecked == true)
            {
                score += 10;
                info[6] = "1";
            }
            else if (chckbx_cmCerebro.IsChecked == false)
            {
                info[6] = "0";
            }
                
            if (chckbx_cmRenal.IsChecked == true)
            {
                score += 10;
                info[7] = "1";
            }
            else if(chckbx_cmRenal.IsChecked == false)
            {
                info[7] = "0";
            }
                        
            if (chckbx_cmAlteredMental.IsChecked == true)
            {
                score += 20;
                info[8] = "1";
            }
            else if(chckbx_cmAlteredMental.IsChecked == false)
            {
                info[8] = "0";
            }
                
            if (chckbx_cmPleuralEffusion.IsChecked == true)
            {
                score += 10;
                info[19] = "1";
            }
            else if(chckbx_cmPleuralEffusion.IsChecked == false)
            {
                info[19] = "0";
            }


            info[9] = txtbx_Respiratory.Text;
            if (Convert.ToDouble(txtbx_Respiratory.Text) >= 30.0)
            {
                score += 20;
            }
                

            info[10] = txtbx_BloodPressure_0.Text;
            if (Convert.ToDouble(txtbx_BloodPressure_0.Text) < 90.0)
            {
                score += 20;
            }
                

            double temprature = Convert.ToDouble(txtbx_Temperature.Text);
            if (rdbtn_Fahrenheit.IsChecked == true && rdbtn_Celsius.IsChecked == false)
            {
                temprature = toCelsius(temprature);
            }     

            if (temprature < 35.0 || temprature > 39.9)
            {
                score += 15;
            }
            info[11] = Convert.ToString(temprature);


            info[12] = txtbx_Pulse.Text;
            if (Convert.ToDouble(txtbx_Pulse.Text) >= 125.0)
            {
                score += 10;
            }


            info[13] = txtbx_pH.Text;
            if (Convert.ToDouble(txtbx_pH.Text) < 7.35)
            {
                score += 30;
            }
                

            double value = Convert.ToDouble(txtbx_BUN.Text);
            if (rdbtn_BUN_mmolL.IsChecked == true && rdbtn_BUN_mgdL.IsChecked == false)
            {
                value = bunConversion(value);
            }
                
            if (value >= 30.0)
            {
                score += 20;
            }
            info[14] = Convert.ToString(value);


            info[15] = txtbx_Sodium.Text;
            if (Convert.ToDouble(txtbx_Sodium.Text) < 130.0)
            {
                score += 20;
            }
                

            double level = Convert.ToDouble(txtbx_Glucose.Text);
            if (rdbtn_Glucose_mmolL.IsChecked == true && rdbtn_Gulcose_mgdL.IsChecked == false)
            {
                level = glucoseConversion(level);
            }
                
            if (level >= 250.0)
            {
                score += 10;
            }
            info[16] = Convert.ToString(level);


            info[17] = txtbx_Hematocrit.Text;
            if (Convert.ToDouble(txtbx_Hematocrit.Text) < 30.0)
            {
                score += 10;
            }
                

            double pressure = Convert.ToDouble(txtbx_PartialPressure.Text);
            if (rdbtn_PartialPressure_kPa.IsChecked == true && rdbtn_PartialPressure_mmHG.IsChecked == false)
            {
                pressure = partialPressureConversion(pressure);
            }
                
            if (pressure < 60.0)
            {
                score += 10;
            }
            info[18] = Convert.ToString(pressure);

            StringBuilder builder = new StringBuilder();

            foreach (string index in info)
                builder.Append(index + ",");

            int id = 1;
            using(StreamReader reader = new StreamReader(@"C:\Users\elifu\source\repos\PSI_EAF\data.csv"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    id++;
                }
                    
            }
                
            using(StreamWriter file = new StreamWriter(@"C:\Users\elifu\source\repos\PSI_EAF\data.csv", true))
            {
                file.WriteLine(id + "," + builder.ToString());
            }


            if (score <= 70)
            {
                MessageBox.Show("Risk Class: II \nRisk Level: Low \nRecommended Action: Outpatient Care", "PSI Classification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(score > 70 && score <= 90)
            {
                MessageBox.Show("Risk Class: III \nRisk Level: Low \nRecommended Action: Outpatient Care or Observation Admission", "PSI Classification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(score > 90 && score <= 130)
            {
                MessageBox.Show("Risk Class: IV \nRisk Level: Moderate \nRecommended Action: Inpatient Admission", "PSI Classification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(score > 130)
            {
                MessageBox.Show("Risk Class: V \nRisk Level: High \nRecommended Action: Inpatient Admission; Check for Sepsis", "PSI Classification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private double toCelsius(double temp)
        {
            
            return Math.Round((temp - 32) * (5.0 / 9.0),2);
        }
        
        private double bunConversion(double value)
        {
            return Math.Round(value * 2.8, 2);
        }

        private double glucoseConversion(double level)
        {
            return Math.Round(level * 18, 2);
        }

        private double partialPressureConversion(double pressure)
        {
            return Math.Round(pressure * 7.50062, 2);
        }
    }
}
