using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shamilton_Lab_4_ClassLibrary
{
    public class SearchClass
    {

        public string Search(string userSelection, string searchText)
        {
            string columnID = "";
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
            string searching = searchText.Replace("'", "''");
            string filterString = "";

            if (columnID == "[Population]" || columnID == "[MedianIncome]" || columnID == "[PercentageOfJobs]")
            {
                filterString = string.Format("{0} = {1}", columnID, searching);
            }
            else
            {
                filterString = string.Format("{0} LIKE '{1}%'", columnID, searching, searchText.Replace("'", "''"));
            }

            return filterString;
        }
    }
}