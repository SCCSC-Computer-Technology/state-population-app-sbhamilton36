using shamilton_Lab_3.UnitedStates1DataSetTableAdapters;
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
	public static class AutoFilter
	{
		public static void AddFilters(DataGridView dataGridView, BindingSource source, int columnIndex)
		{
            DataTable dt = ((DataView)source.List).Table;
            string columnName = dataGridView.Columns[columnIndex].DataPropertyName;

            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add("(All)", null, (s, e) => source.Filter = null);
            menu.Items.Add(new ToolStripSeparator());

            DataView view = new DataView(dt);
            DataTable uniqueValues = view.ToTable(true, columnName);

            foreach (DataRow row in uniqueValues.Rows)
            {
                string val = row[columnName].ToString();
                menu.Items.Add(val, null, (s, e) => {
                    source.Filter = $"[{columnName}] = '{val.Replace("'", "''")}'";
                });
            }

            var rect = dataGridView.GetCellDisplayRectangle(columnIndex, -1, true);
            menu.Show(dataGridView, rect.Left, rect.Bottom);
        }
	}
}