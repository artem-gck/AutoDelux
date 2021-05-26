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
using System.Windows.Shapes;
using cource.Main;
using System.Data.SqlClient;
using System.Data;
using cource.Connection;
using cource.AddEdit;
using cource.Log_Reg;

namespace cource
{
    public partial class AddEditWindow : Window
    {
        List<string> spis;
        int swich, AdEd;
        string tab00, tab01, tab02, tab0, tab1, tab2, tab3, tab4, tab5;
        public AddEditWindow()
        {
            InitializeComponent();
        }
        public AddEditWindow(int AdEdDel, int swit, string name, string tb00, string tb01, string tb02, string tb0, string tb1, string tb2, string tb3, string tb4, string tb5)
        {
            InitializeComponent();

            tab00 = tb00;
            tab01 = tb01;
            tab02 = tb02;
            tab0 = tb0;
            tab1 = tb1;
            tab2 = tb2;
            tab3 = tb3;
            tab4 = tb4;
            tab5 = tb5;

            switch (AdEdDel)
            {
                case 0:
                    AdEd = AdEdDel;
                    swich = swit;
                    Labl.Text = name;
                    AddButton.Content = name;
                    ComboBox0.SelectedItem = tb00;
                    ComboBox1.SelectedItem = tb01;
                    TextBlock02.Text = "Model";
                    ComboBox2.SelectedItem = tb02;
                    TextBox0.Text = tb0;
                    TextBox1.Text = tb1;
                    TextBox2.Text = tb2;
                    TextBox3.Text = tb3;
                    TextBox4.Text = tb4;
                    TextBox5.Text = tb5;
                    break;
                case 2:
                    AdEd = AdEdDel;
                    swich = swit;
                    Labl.Text = name;
                    AddButton.Content = name;
                    TextBlock00.Text = tb00;
                    TextBlock01.Text = tb01;
                    TextBlock02.Text = tb02;
                    TextBlock0.Text = tb0;
                    TextBlock1.Text = tb1;
                    TextBlock2.Text = tb2;
                    TextBlock3.Text = tb3;
                    TextBlock4.Text = tb4;
                    TextBlock5.Text = tb5;
                    break;
            }

            switch (swit)
            {
                case 0:
                    Border3.Visibility = Visibility.Collapsed;
                    Border4.Visibility = Visibility.Collapsed;
                    Border5.Visibility = Visibility.Collapsed;
                    CreateForm.CreateCat(ComboBox0, ComboBox1, ComboBox2);
                    break;
                case 1:
                    Border3.Visibility = Visibility.Collapsed;
                    Border4.Visibility = Visibility.Collapsed;
                    Border5.Visibility = Visibility.Collapsed;
                    CreateForm.CreateOrd(ComboBox0, ComboBox1, ComboBox2);
                    break;
                case 2:
                    Border00.Visibility = Visibility.Collapsed;
                    Border01.Visibility = Visibility.Collapsed;
                    Border02.Visibility = Visibility.Collapsed;
                    Border3.Visibility = Visibility.Collapsed;
                    Border4.Visibility = Visibility.Collapsed;
                    Border5.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    Border00.Visibility = Visibility.Collapsed;
                    Border01.Visibility = Visibility.Collapsed;
                    Border02.Visibility = Visibility.Collapsed;
                    Border4.Visibility = Visibility.Collapsed;
                    Border5.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    Border00.Visibility = Visibility.Collapsed;
                    Border01.Visibility = Visibility.Collapsed;
                    Border02.Visibility = Visibility.Collapsed;
                    Border4.Visibility = Visibility.Collapsed;
                    Border5.Visibility = Visibility.Collapsed;
                    break;
            }

            spis = new List<string>();
            spis.Add(ComboBox0.Text);
            spis.Add(ComboBox1.Text);
            spis.Add(ComboBox2.Text);
            spis.Add(TextBox0.Text);
            spis.Add(TextBox1.Text);
            spis.Add(TextBox2.Text);
            spis.Add(TextBox3.Text);
        }
        private void MouseLeftButtonDown_Drag(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Animation.CreateAnimClose(this);
        }

        private void Button_Click_Min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Animation.CreateAnimClose(this);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool raz = true;

            foreach(var item in spis)
            {
                if (!string.IsNullOrWhiteSpace(item) && AdEd != 0)
                {
                    raz = false;
                }
            }

            if (raz)
            {
                switch(AdEd)
                {
                    case 0:
                        switch (swich)
                        {
                            case 0:
                                string sql;
                                DataTable table;
                                DataRow row;
                                SqlConnection connection;
                                SqlCommand command;
                                string stringConnection;

                                sql = string.Format("SELECT Manufacturer_id FROM Manufacturer WHERE Manufacturer = '{0}'", tab00);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int manufact = (int)row[0];

                                sql = string.Format("SELECT Category_id FROM Category WHERE Category = '{0}'", tab01);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int categ = (int)row[0];

                                sql = string.Format("SELECT Model_id FROM Model WHERE Model = '{0}'", tab02);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int model = (int)row[0];

                                sql = string.Format("SELECT Manufacturer_id FROM Manufacturer WHERE Manufacturer = '{0}'", ComboBox0.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int manufact1 = (int)row[0];

                                sql = string.Format("SELECT Category_id FROM Category WHERE Category = '{0}'", ComboBox1.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int categ1 = (int)row[0];

                                sql = string.Format("SELECT Model_id FROM Model WHERE Model = '{0}'", ComboBox2.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int model1 = (int)row[0];

                                stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                connection = new SqlConnection();
                                connection.ConnectionString = stringConnection;
                                connection.Open();

                                command = connection.CreateCommand();

                                command.CommandText = string.Format("UPDATE Product SET Manufacturer_id = '{0}', Category_id = '{1}', Model_id = '{2}', Name = '{3}', Amount = '{4}', Price = '{5}' WHERE Manufacturer_id = '{6}' AND Category_id = '{7}' AND Model_id = '{8}' AND Name = '{9}' AND Amount = '{10}' AND Price = '{11}'", manufact1, categ1, model1, TextBox0.Text, TextBox1.Text, TextBox2.Text, manufact, categ, model, tab0, tab1, tab2);
                                command.ExecuteNonQuery();
                                connection.Close();

                                Animation.CreateAnimClose(this);
                                this.Close();
                                break;
                            case 1:
                                sql = string.Format("SELECT Product_id FROM Product WHERE Name = '{0}'", tab00);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int prod = (int)row[0];

                                sql = string.Format("SELECT Buyer_id FROM Buyer WHERE Name = '{0}'", tab01);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int buyer = (int)row[0];

                                sql = string.Format("SELECT Supplier_id FROM Supplier WHERE Name = '{0}'", tab02);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int suppl = (int)row[0];

                                sql = string.Format("SELECT Product_id FROM Product WHERE Name = '{0}'", ComboBox0.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int prod1 = (int)row[0];

                                sql = string.Format("SELECT Buyer_id FROM Buyer WHERE Name = '{0}'", ComboBox1.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int buyer1 = (int)row[0];

                                sql = string.Format("SELECT Supplier_id FROM Supplier WHERE Name = '{0}'", ComboBox2.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int suppl1 = (int)row[0];

                                stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                connection = new SqlConnection();
                                connection.ConnectionString = stringConnection;
                                connection.Open();

                                command = connection.CreateCommand();

                                command.CommandText = string.Format("UPDATE Orderr SET Product_id = '{0}', Buyer_id = '{1}', Supplier_id = '{2}', Amount = '{3}', DateOfOrder = '{4}', DateOfSupply = '{5}' WHERE Product_id = '{6}' AND Buyer_id = '{7}' AND Supplier_id = '{8}' AND Amount = '{9}' AND DateOfOrder = '{10}' AND DateOfSupply = '{11}'", prod1, buyer1, suppl1, TextBox0.Text, TextBox1.Text, TextBox2.Text, prod, buyer, suppl, tab0, tab1, tab2);
                                command.ExecuteNonQuery();
                                connection.Close();

                                Animation.CreateAnimClose(this);
                                this.Close();
                                break;
                            case 2:
                                sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", tab1, tab2);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int addr = (int)row[0];

                                stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", TextBox1.Text, TextBox2.Text);
                                table = ServerConnection.executeSQL(sql);

                                connection = new SqlConnection();
                                connection.ConnectionString = stringConnection;
                                connection.Open();
                                command = connection.CreateCommand();

                                if (table.Rows.Count == 0)
                                {
                                    command.CommandText = string.Format("INSERT INTO Address VALUES('{0}', '{1}')", TextBox1.Text, TextBox2.Text);
                                    command.ExecuteNonQuery();
                                }

                                sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", TextBox1.Text, TextBox2.Text);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int addr1 = (int)row[0];

                                command.CommandText = string.Format("UPDATE Buyer SET Name = '{0}', Address_id = {1} WHERE Name = '{2}' AND Address_id = {3}", TextBox0.Text, addr1, tab0, addr);
                                command.ExecuteNonQuery();

                                Animation.CreateAnimClose(this);
                                this.Close();
                                break;
                            case 3:
                                sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", tab2, tab3);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                addr = (int)row[0];

                                stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", TextBox2.Text, TextBox3.Text);
                                table = ServerConnection.executeSQL(sql);

                                connection = new SqlConnection();
                                connection.ConnectionString = stringConnection;
                                connection.Open();
                                command = connection.CreateCommand();

                                if (table.Rows.Count == 0)
                                {
                                    command.CommandText = string.Format("INSERT INTO Address VALUES('{0}', '{1}')", TextBox2.Text, TextBox3.Text);
                                    command.ExecuteNonQuery();
                                }

                                sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", TextBox2.Text, TextBox3.Text);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                addr1 = (int)row[0];

                                command.CommandText = string.Format("UPDATE Supplier SET Name = '{0}', TermsOfPay = '{1}', Address_id = {2} WHERE Name = '{3}' AND TermsOfPay = '{4}' AND Address_id = {5}", TextBox0.Text, TextBox1.Text, addr1, tab0, tab1, addr);
                                command.ExecuteNonQuery();

                                Animation.CreateAnimClose(this);
                                this.Close();
                                break;
                            case 4:
                                sql = string.Format("SELECT * FROM LoginTable WHERE Login = '{0}'", TextBox0.Text);
                                table = ServerConnection.executeSQL(sql);

                                    bool role, access;

                                    role = TextBox2.Text == "True" ? true : false;
                                    access = TextBox3.Text == "True" ? true : false;

                                    stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                    connection = new SqlConnection();
                                    connection.ConnectionString = stringConnection;
                                    connection.Open();

                                    command = connection.CreateCommand();

                                    if (TextBox1.Text == "New password")
                                    {
                                        command.CommandText = string.Format("UPDATE LoginTable SET Login = '{0}', Role = @value0, Access = @value1 WHERE Login = '{1}'", TextBox0.Text, tab0);
                                    }
                                    else
                                    {
                                        command.CommandText = string.Format("UPDATE LoginTable SET Login = '{0}', HashPassword = '{1}', Role = @value0, Access = @value1 WHERE Login = '{2}'", TextBox0.Text, Hashing.HashPassword(TextBox1.Text), tab0);
                                    }
                                    command.Parameters.Add("@value0", SqlDbType.Bit).Value = role;
                                    command.Parameters.Add("@value1", SqlDbType.Bit).Value = access;
                                    command.ExecuteNonQuery();

                                    connection.Close();

                                    Animation.CreateAnimClose(this);
                                this.Close();
                                break;
                        }
                        break;
                    case 2:
                        switch (swich)
                        {
                            case 0:
                                string sql = string.Format("SELECT * FROM Product WHERE Name = '{0}'", TextBox0.Text);
                                DataTable table = ServerConnection.executeSQL(sql);
                                DataRow row;
                                SqlConnection connection;
                                SqlCommand command;
                                string stringConnection;

                                if (table.Rows.Count == 0)
                                {
                                    sql = string.Format("SELECT Manufacturer_id FROM Manufacturer WHERE Manufacturer = '{0}'", ComboBox0.SelectedItem);
                                    table = ServerConnection.executeSQL(sql);
                                    row = table.Rows[0];
                                    int manufact = (int)row[0];

                                    sql = string.Format("SELECT Category_id FROM Category WHERE Category = '{0}'", ComboBox1.SelectedItem);
                                    table = ServerConnection.executeSQL(sql);
                                    row = table.Rows[0];
                                    int categ = (int)row[0];

                                    sql = string.Format("SELECT Model_id FROM Model WHERE Model = '{0}'", ComboBox2.SelectedItem);
                                    table = ServerConnection.executeSQL(sql);
                                    row = table.Rows[0];
                                    int model = (int)row[0];

                                    stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                    connection = new SqlConnection();
                                    connection.ConnectionString = stringConnection;
                                    connection.Open();

                                    command = connection.CreateCommand();

                                    command.CommandText = string.Format("INSERT INTO Product VALUES({0}, {1}, {2}, '{3}', '{4}', '{5}')", manufact, categ, model, TextBox0.Text, TextBox1.Text, TextBox2.Text);
                                    command.ExecuteNonQuery();
                                    connection.Close();
                                    
                                    Animation.CreateAnimClose(this);
                                    this.Close();
                                }
                                break;
                            case 1:
                                sql = string.Format("SELECT Product_id FROM Product WHERE Name = '{0}'", ComboBox0.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int prod = (int)row[0];

                                sql = string.Format("SELECT Buyer_id FROM Buyer WHERE Name = '{0}'", ComboBox1.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int buyer = (int)row[0];

                                sql = string.Format("SELECT Supplier_id FROM Supplier WHERE Name = '{0}'", ComboBox2.SelectedItem);
                                table = ServerConnection.executeSQL(sql);
                                row = table.Rows[0];
                                int suppl = (int)row[0];

                                stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                connection = new SqlConnection();
                                connection.ConnectionString = stringConnection;
                                connection.Open();

                                command = connection.CreateCommand();

                                command.CommandText = string.Format("INSERT INTO Orderr VALUES({0}, {1}, {2}, '{3}', '{4}', '{5}')", prod, buyer, suppl, TextBox0.Text, TextBox1.Text, TextBox2.Text);
                                command.ExecuteNonQuery();
                                connection.Close();

                                Animation.CreateAnimClose(this);
                                this.Close();
                                break;
                            case 2:
                                sql = string.Format("SELECT * FROM Buyer WHERE Name = '{0}'", TextBox0.Text);
                                table = ServerConnection.executeSQL(sql);

                                if (table.Rows.Count == 0)
                                {
                                    stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                    connection = new SqlConnection();
                                    connection.ConnectionString = stringConnection;
                                    connection.Open();

                                    command = connection.CreateCommand();

                                    command.CommandText = string.Format("INSERT INTO Address VALUES('{0}', '{1}')", TextBox1.Text, TextBox2.Text);
                                    command.ExecuteNonQuery();

                                    sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", TextBox1.Text, TextBox2.Text);
                                    table = ServerConnection.executeSQL(sql);
                                    row = table.Rows[0];
                                    int addr = (int)row[0];

                                    command.CommandText = string.Format("INSERT INTO Buyer VALUES('{0}', {1})", TextBox0.Text, addr);
                                    command.ExecuteNonQuery();

                                    connection.Close();

                                    Animation.CreateAnimClose(this);
                                    this.Close();
                                }
                                break;
                            case 3:
                                sql = string.Format("SELECT * FROM Supplier WHERE Name = '{0}'", TextBox0.Text);
                                table = ServerConnection.executeSQL(sql);

                                if (table.Rows.Count == 0)
                                {
                                    stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                    connection = new SqlConnection();
                                    connection.ConnectionString = stringConnection;
                                    connection.Open();

                                    command = connection.CreateCommand();

                                    command.CommandText = string.Format("INSERT INTO Address VALUES('{0}', '{1}')", TextBox2.Text, TextBox3.Text);
                                    command.ExecuteNonQuery();

                                    sql = string.Format("SELECT Address_id FROM Address WHERE Country = '{0}' AND Town = '{1}'", TextBox2.Text, TextBox3.Text);
                                    table = ServerConnection.executeSQL(sql);
                                    row = table.Rows[0];
                                    int addr = (int)row[0];

                                    command.CommandText = string.Format("INSERT INTO Supplier VALUES('{0}', '{1}', {2})", TextBox0.Text, TextBox1.Text, addr);
                                    command.ExecuteNonQuery();

                                    connection.Close();

                                    Animation.CreateAnimClose(this);
                                    this.Close();
                                }
                                break;
                            case 4:
                                sql = string.Format("SELECT * FROM LoginTable WHERE Login = '{0}'", TextBox0.Text);
                                table = ServerConnection.executeSQL(sql);

                                if (table.Rows.Count == 0)
                                {
                                    bool role, access;

                                    role = TextBox2.Text == "true" ? true : false;
                                    access = TextBox3.Text == "true" ? true : false;

                                    stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                                    connection = new SqlConnection();
                                    connection.ConnectionString = stringConnection;
                                    connection.Open();

                                    command = connection.CreateCommand();
                                    command.CommandText = string.Format("INSERT INTO LoginTable VALUES('{0}', '{1}', @value0, @value1)", TextBox0.Text, Hashing.HashPassword(TextBox1.Text));
                                    command.Parameters.Add("@value0", SqlDbType.Bit).Value = role;
                                    command.Parameters.Add("@value1", SqlDbType.Bit).Value = access;
                                    command.ExecuteNonQuery();

                                    connection.Close();

                                    Animation.CreateAnimClose(this);
                                    this.Close();
                                }
                                break;
                        }
                        break;
                }
            }
        }

        private void ComboBox0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (swich)
            {
                case 0:
                    string sql = string.Format("SELECT Manufacturer_id FROM Manufacturer WHERE Manufacturer = '{0}'", ComboBox0.SelectedItem);
                    DataTable table = ServerConnection.executeSQL(sql);
                    DataRow row = table.Rows[0];

                    sql = string.Format("SELECT Model FROM Model WHERE Manufacturer_id = {0}", (int)row[0]);
                    table = ServerConnection.executeSQL(sql);
                    List<string> str2 = new List<string>();

                    foreach (DataRow item in table.Rows)
                    {
                        str2.Add((string)item[0]);
                    }

                    ComboBox2.ItemsSource = str2;
                    break;
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (swich)
            {
                case 0:
                    if (ComboBox0.SelectedItem == null)
                    {
                        string sql = string.Format("SELECT Manufacturer_id FROM Model WHERE Model = '{0}'", ComboBox2.SelectedItem);
                        DataTable table = ServerConnection.executeSQL(sql);
                        DataRow row = table.Rows[0];

                        sql = string.Format("SELECT Manufacturer FROM Manufacturer WHERE Manufacturer_id = {0}", (int)row[0]);
                        table = ServerConnection.executeSQL(sql);
                        row = table.Rows[0];

                        ComboBox0.SelectedItem = row[0];
                    }
                    break;
            }
        }
    }
}
