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
using System.Windows.Media.Animation;
using System.Data;
using System.Data.SqlClient;
using cource.Connection;
using System.Drawing;
using cource.Main;

namespace cource
{
    public partial class MainWindow : Window
    {
        SolidColorBrush myAnimatedBrush = new SolidColorBrush();

        List<UIElement> Panels = new List<UIElement>();
        List<WrapPanel> Wrap = new List<WrapPanel>();

        int swit, AdEdDel;

        public MainWindow()
        {
            InitializeComponent();

            Panels.Add(Catalog);
            Panels.Add(Orders);
            Panels.Add(table);
            Panels.Add(WarningDelEdAd);

            Wrap.Add(panelCat);
            Wrap.Add(panelOrd);

            swit = 0;
            AdEdDel = 0;

            if (!Data.admin)
            {
                Row.Height = new GridLength(0);
                Users_button.Visibility = Visibility.Hidden;
            }
            else
            {
                Row.Height = new GridLength(60);
                Users_button.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation();

            anim.From = this.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.4);
            anim.EasingFunction = new QuarticEase();

            anim.Completed += (s, a) =>
            {
                Environment.Exit(0);
            };

            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Button_Click_Min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RadioButton_Checked_Reports(object sender, RoutedEventArgs e)
        {
            Reports_button.IsChecked = false;
            swit = 5;
            AdEdDel = 3;

            WarningDelEdAd.Content = "Tap twice to create a contract";
            Animation.CreateWrap(Wrap);
            Animation.CreateAnimCloseCol(Panels, table);
            CreateTable.GetTableAllOrdr(table, dataTable, panelOrd, Orders, swit, ButtonsAll);
            Animation.CreateAnimOpenClose(WarningDelEdAd, WarningDelEdAd);
        }

        private void MouseLeftButtonDown_Drag(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void RadioButton_Checked_Catalog(object sender, RoutedEventArgs e)
        {            
            Catalog_button.IsChecked = false;
            swit = 0;

            Animation.CreateWrap(Wrap);
            Animation.CreateAnimCloseCol(Panels, Catalog);
            Animation.CreateAnimOpen(Catalog);
        }

        private void RadioButton_Checked_Orders(object sender, RoutedEventArgs e)
        {
            Orders_button.IsChecked = false;
            swit = 1;

            Animation.CreateWrap(Wrap);
            Animation.CreateAnimCloseCol(Panels, Orders);
            Animation.CreateAnimOpen(Orders);
        }

        private void Manufacturer_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableProd(table, dataTable, panelCat, Catalog, "Manufacturer", ButtonsAll);
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableProd(table, dataTable, panelCat, Catalog, "Category", ButtonsAll);
        }

        private void Model_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableProd(table, dataTable, panelCat, Catalog, "Model", ButtonsAll);
        }

        private void All_Cat_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableAllProd(table, dataTable, panelCat, Catalog, ButtonsAll);
        }

        private void All_Ord_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableAllOrdr(table, dataTable, panelOrd, Orders, swit, ButtonsAll);
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableOrdr(table, dataTable, panelOrd, Orders, "Product", ButtonsAll);
        }

        private void Buyer_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableOrdr(table, dataTable, panelOrd, Orders, "Buyer", ButtonsAll);
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            CreateTable.GetTableOrdr(table, dataTable, panelOrd, Orders, "Supplier", ButtonsAll);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AdEdDel = 2;

            AddEditWindow win = null;

            switch (swit)
            {
                case 0:
                    win = new AddEditWindow(AdEdDel, swit, "Add", "Manufacturer", "Category", "Model", "Name", "Amount", "Price", "", "", "");
                    break;
                case 1:
                    win = new AddEditWindow(AdEdDel, swit, "Add", "Product", "Buyer", "Supplier", "Amount", "Order date", "Supply date", "", "", "");
                    break;
                case 2:
                    win = new AddEditWindow(AdEdDel, swit, "Add", "", "", "", "Name", "Country", "Town", "", "", "");
                    break;
                case 3:
                    win = new AddEditWindow(AdEdDel, swit, "Add", "", "", "", "Name", "Term of Pay", "Country", "Town", "", "");
                    break;
                case 4:
                    win = new AddEditWindow(AdEdDel, swit, "Add", "", "", "", "Login", "Password", "Role", "Access", "", "");
                    break;
            }
            Animation.CreateAnimOpen(NewWindowAddEdit.CreateWin(swit, win));
            Animation.CreateAnimClose(WarningDelEdAd);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            AdEdDel = 1;

            WarningDelEdAd.Content = "Tap twice on the line to delete";
            Animation.CreateAnimOpenClose(WarningDelEdAd, WarningDelEdAd);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AdEdDel = 0;

            WarningDelEdAd.Content = "Tap twice on the line to edit";
            Animation.CreateAnimOpenClose(WarningDelEdAd, WarningDelEdAd);
        }

        private void DataGridDelete(object sender, MouseButtonEventArgs e)
        {
            List<string> spis = new List<string>();
            IList<DataGridCellInfo> cellInfo = dataTable.SelectedCells;

            foreach (var item in cellInfo)
            {
                try
                {
                    spis.Add((item.Column.GetCellContent(item.Item) as TextBlock).Text);
                }
                catch (Exception)
                {
                    spis.Add((item.Column.GetCellContent(item.Item) as TextBox).Text);
                }
            }

            if (sender != null)
            {
                int a;
                DataGrid grid = sender as DataGrid;

                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    string stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = stringConnection;
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    a = grid.SelectedIndex;

                    switch (AdEdDel)
                    {
                        case 0:
                            AddEditWindow win = null;

                            switch (swit)
                            {
                                case 0:
                                    Catalog row = (Catalog)grid.SelectedItem;
                                    win = new AddEditWindow(AdEdDel, swit, "Edit", row.Manufacturer, row.Category, row.Model, row.Name, row.Amount, row.Price, "", "", "");
                                    break;
                                case 1:
                                    Product row1 = (Product)grid.SelectedItem;
                                    win = new AddEditWindow(AdEdDel, swit, "Edit", row1.Productt, row1.Buyer, row1.Supplier, row1.Amount, DateFormat.FormatStr(row1.OrderDate), DateFormat.FormatStr(row1.SupplyDate), "", "", "");
                                    break;
                                case 2:
                                    Buyer row2 = (Buyer)grid.SelectedItem;
                                    win = new AddEditWindow(AdEdDel, swit, "Edit", "", "", "", row2.Name, row2.Country, row2.Town, "", "", "");
                                    break;
                                case 3:
                                    Supplier row3 = (Supplier)grid.SelectedItem;
                                    win = new AddEditWindow(AdEdDel, swit, "Edit", "", "", "", row3.Name, row3.TermsOfPay, row3.Country, row3.Town, "", "");
                                    break;
                                case 4:
                                    User row4 = (User)grid.SelectedItem;
                                    win = new AddEditWindow(AdEdDel, swit, "Edit", "", "", "", row4.Login, "New password", row4.Role, row4.Access, "", "");
                                    break;
                            }

                            Animation.CreateAnimOpen(NewWindowAddEdit.CreateWin(swit, win));
                            Animation.CreateAnimClose(WarningDelEdAd);
                            break;

                        case 1:
                            switch (swit)
                            {
                                case 0:
                                    ServerConnection.DelCat(command, connection, spis);
                                    All_Cat_Click(sender, e);
                                    break;
                                case 1:
                                    DateFormat.Format(spis);
                                    ServerConnection.DelOrd(command, connection, spis);
                                    All_Ord_Click(sender, e);
                                    break;
                                case 2:
                                    ServerConnection.DelCust(command, connection, spis);
                                    RadioButton_Checked_Customers(sender, e);
                                    break;
                                case 3:
                                    ServerConnection.DelSupl(command, connection, spis);
                                    RadioButton_Checked_Suppliers(sender, e);
                                    break;
                                case 4:
                                    ServerConnection.DelUser(command, connection, spis);
                                    RadioButton_Checked_Users(sender, e);
                                    break;
                            }
                            break;
                        case 3:
                            DateFormat.Format(spis);
                            ServerConnection.CreateContract(command, connection, spis);
                            
                            Animation.CreateWrap(Wrap);
                            Animation.CreateAnimCloseCol(Panels, table);
                            CreateTable.GetTableAllOrdr(table, dataTable, panelOrd, Orders, swit, ButtonsAll);

                            WarningDelEdAd.Content = "Contract successfully saved";
                            Animation.CreateAnimOpenClose(WarningDelEdAd, WarningDelEdAd);
                            break;
                    }
                }
            }

            
        }

        private void RadioButton_Checked_Customers(object sender, RoutedEventArgs e)
        {
            Customers_button.IsChecked = false;
            swit = 2;

            Animation.CreateWrap(Wrap);
            Animation.CreateAnimCloseCol(Panels, table);
            CreateTable.GetTableAllCust(table, dataTable, panelOrd, Orders, ButtonsAll);
        }

        private void RadioButton_Checked_Suppliers(object sender, RoutedEventArgs e)
        {
            Suppliers_button.IsChecked = false;
            swit = 3;

            Animation.CreateWrap(Wrap);
            Animation.CreateAnimCloseCol(Panels, table);
            CreateTable.GetTableAllSupl(table, dataTable, panelOrd, Orders, ButtonsAll);
        }

        private void RadioButton_Checked_Users(object sender, RoutedEventArgs e)
        {
            Users_button.IsChecked = false;
            swit = 4;

            Animation.CreateWrap(Wrap);
            Animation.CreateAnimCloseCol(Panels, table);
            CreateTable.GetTableAllUser(table, dataTable, panelOrd, Orders, ButtonsAll);
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            LoginWindow win = new LoginWindow();
            win.Opacity = 0;

            DoubleAnimation anim = new DoubleAnimation();

            anim.From = this.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.4);
            anim.EasingFunction = new QuarticEase();

            anim.Completed += (s, a) =>
            {
                DoubleAnimation anim1 = new DoubleAnimation();

                win.Visibility = Visibility.Visible;

                anim1.From = win.Opacity;
                anim1.To = 1;
                anim1.Duration = TimeSpan.FromSeconds(0.4);
                anim1.EasingFunction = new QuarticEase();

                win.BeginAnimation(UIElement.OpacityProperty, anim1);
                this.Close();
            };

            this.BeginAnimation(UIElement.OpacityProperty, anim);

            
        }

        public void Add()
        {
            CreateTable.GetTableAllProd(table, dataTable, panelCat, Catalog, ButtonsAll);
        }
    }
}
