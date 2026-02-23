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
using shamilton_Lab_4_ClassLibrary;

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

            string selection = comboSearch.SelectedItem?.ToString() ?? "";
            string text = txtSearchBox.Text;

            if (string.IsNullOrEmpty(selection))
            {
                MessageBox.Show("Please Select Which Category and Text to Search By");
                return;
            }

            SearchClass searchStates = new SearchClass();
            string filterString = searchStates.Search(selection, text);

            Details detailSearch = new Details();
            detailSearch.StateFilter = filterString;
            detailSearch.ShowDialog();

            //clear the form when returning from viewing results
            txtSearchBox.Clear();
            comboSearch.SelectedIndex = -1;
            comboStates.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
