using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using cource.Connection;
using System.Windows.Controls;

namespace cource.AddEdit
{
    class CreateForm
    {
        public static void CreateCat(ComboBox comboBox0, ComboBox comboBox1, ComboBox comboBox2)
        {
            string sql = "SELECT Manufacturer FROM Manufacturer";
            DataTable table = ServerConnection.executeSQL(sql);
            List<string> str = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                str.Add((string)item[0]);
            }

            comboBox0.ItemsSource = str;

            sql = "SELECT Category FROM Category";
            table = ServerConnection.executeSQL(sql);
            List<string> str1 = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                str1.Add((string)item[0]);
            }

            comboBox1.ItemsSource = str1;

            sql = "SELECT Model FROM Model";
            table = ServerConnection.executeSQL(sql);
            List<string> str2 = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                str2.Add((string)item[0]);
            }

            comboBox2.ItemsSource = str2;
        }
        public static void CreateOrd(ComboBox comboBox0, ComboBox comboBox1, ComboBox comboBox2)
        {
            string sql = "SELECT Name FROM Product";
            DataTable table = ServerConnection.executeSQL(sql);
            List<string> str = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                str.Add((string)item[0]);
            }

            comboBox0.ItemsSource = str;

            sql = "SELECT Name FROM Buyer";
            table = ServerConnection.executeSQL(sql);
            List<string> str1 = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                str1.Add((string)item[0]);
            }

            comboBox1.ItemsSource = str1;

            sql = "SELECT Name FROM Supplier";
            table = ServerConnection.executeSQL(sql);
            List<string> str2 = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                str2.Add((string)item[0]);
            }

            comboBox2.ItemsSource = str2;
        }
    }
}
