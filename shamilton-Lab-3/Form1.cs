using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shamilton_Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnViewStates_Click(object sender, EventArgs e)
        {

            if (comboStates.SelectedItem != null)
            {

                string selectedState = comboStates.SelectedItem.ToString();
                Details detailForm = new Details();


                if (selectedState == "All States")
                {
                    detailForm.StateFilter = null;
                }
                else
                {
                    detailForm.StateFilter = string.Format("StateNames = '{0}'", selectedState.Replace("'", "''"));
                }

                detailForm.ShowDialog();

                //clear the form when returning from viewing results
                txtSearchBox.Clear();
                comboSearch.SelectedIndex = -1;
                comboStates.SelectedIndex = -1;
            }
            else 
            {
                MessageBox.Show("Please Select a State First.");
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear states drop down
            statesBindingSource.Filter = null;
            comboStates.SelectedIndex = -1;

            comboSearch.SelectedIndex = -1;
            txtSearchBox.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboSearch.SelectedItem == null || string.IsNullOrWhiteSpace(txtSearchBox.Text))
            {
                MessageBox.Show("Please Select Which Category and Text to Search By");
            }
            else
            {
                string columnID = "";
                string userSelection = comboSearch.SelectedItem.ToString();

                switch (userSelection)
                {
                    case "State Names": columnID = "[StateNames]"; break;
                    case "Flag Description": columnID = "[StateFlagDesc]"; break;
                    case "State Flower": columnID = "[StateFlower]"; break;
                    case "State Bird": columnID = "[StateBird]"; break;
                    case "State Colors": columnID = "[StateColors]"; break;
                    case "Median Income": columnID = "[MedianIncome]"; break;
                    case "Computer Related Jobs": columnID = "[PercentageOfJobs]"; break;
                    default: columnID = "[StateNames]"; break;
                }


                //string columnName = comboSearch.SelectedItem.ToString();
                string searching = txtSearchBox.Text.Replace("'", "''");
                string filterString = "";

                if (columnID == "[Population]" || columnID == "[MedianIncome]" || columnID == "[PercentageOfJobs]")
                {
                    if (!decimal.TryParse(searching, out _))
                    {
                        MessageBox.Show("Please enter a vaild number.");
                        return;
                    }
                    filterString = string.Format("{0} = {1}", columnID, searching);
                }
                else
                {
                    filterString = string.Format("{0} LIKE '{1}%'", columnID, searching, txtSearchBox.Text.Replace("'", "''"));
                }

                Details detailSearch = new Details();
                detailSearch.StateFilter = filterString;
                detailSearch.ShowDialog();




                //clear the form when returning from viewing results
                txtSearchBox.Clear();
                comboSearch.SelectedIndex = -1;
                comboStates.SelectedIndex = -1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
