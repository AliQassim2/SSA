using System.Data;
using System.Windows.Forms;

namespace Login
{
    static internal class Functions
    {
        static internal void SetComboBox(ref ComboBox t, DataTable data)
        {
            t.Items.Clear();
            if (data.Rows.Count == 0 ) {  t.Text = "لاتوجد بيانات"; return; }
            foreach(DataRow row in data.Rows)
            {
                t.Items.Add(row[0].ToString());
            }
            if(t.Items.Count>0) t.Text = t.Items[t.Items.Count - 1].ToString();

        }

    }
}
