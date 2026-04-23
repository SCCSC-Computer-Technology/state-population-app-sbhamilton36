using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shamilton_Lab_3
{


    public partial class Details : Form
    {
        private string GetDatabaseColumnName(string userSelection)
        {
            switch (userSelection)
            {
                case "State Names": return "[StateNames]";
                case "Population": return "[StatePopulation]";
                case "Flag Description": return "[StateFlagDesc]";
                case "State Flower": return "[StateFlower]";
                case "State Bird": return "[StateBird]";
                case "State Colors": return "[StateColors]";
                case "Largest City": return "[LargestCities]";
                case "State Capital": return "[StateCapital]";
                case "Median Income": return "[MedianIncome]";
                case "Computer Related Jobs": return "[PercentageOfJobs]";
                default: return "[StateNames]";
            }
        }


        public string StateFilter { get; set; }
        public Details()
        {
            InitializeComponent();
        }

        private void statesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.statesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.unitedStates1DataSet);

        }

        private void Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'unitedStates1DataSet.States' table. You can move, or remove it, as needed.
            this.statesTableAdapter.Fill(this.unitedStates1DataSet.States);
            statesBindingSource.Filter = StateFilter;

            statesDataGridView.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSortASC_Click(object sender, EventArgs e)
        {
            if (comboSortBy.SelectedItem != null)
            { 
                string columnID = GetDatabaseColumnName(comboSortBy.SelectedItem.ToString());

                statesBindingSource.Sort = columnID + " ASC";
            }
        }

        private void btnSortDESC_Click(object sender, EventArgs e)
        {
            if (comboSortBy.SelectedItem != null)
            { 
                string columnID = GetDatabaseColumnName (comboSortBy.SelectedItem.ToString());

                statesBindingSource.Sort = columnID + " DESC";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            statesBindingSource.Sort = null;
            statesBindingSource.Filter = null;

            comboSortBy.SelectedIndex = -1;
            try
            {
                this.statesTableAdapter.Fill(this.unitedStates1DataSet.States);
            }
            catch
            {
                MessageBox.Show("Unable to Refresh Data.");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            statesBindingSource.Filter = null;
            statesBindingSource.Sort = null;

            try
            {
                this.statesTableAdapter.Fill(this.unitedStates1DataSet.States);
                statesBindingSource.MoveFirst();
            }
            catch
            {
                MessageBox.Show("Error Loading Data.....");
            }
        }
    }
}
