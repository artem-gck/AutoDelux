using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Data;
using cource.Connection;

namespace cource.Main
{
    class CreateTable
    {
        public static void GetTableAllProd(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, StackPanel ButtonsAll)
        {
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();

            table.Visibility = Visibility.Visible;

            var mySQL = "SELECT Manufacturer.Manufacturer, Category.Category, Model.Model, Product.Name, Product.Amount, Product.Price " +
                        "FROM Product " +
                        "INNER JOIN Manufacturer ON Product.Manufacturer_id = Manufacturer.Manufacturer_id " +
                        "INNER JOIN Category ON Product.Category_id = Category.Category_id " +
                        "INNER JOIN Model ON Product.Model_id = Model.Model_id ";

            DataTable userData = ServerConnection.executeSQL(mySQL);

            List<Catalog> list = new List<Catalog>();

            ButtonsAll.Visibility = Visibility.Visible;

            Catalog header = new Catalog() { Manufacturer = "Manufacturer", Category = "Category", Model = "Model", Name = "Name", Amount = "Amount", Price = "Price" };
            list.Add(header);

            foreach (DataRow item in userData.Rows)
            {
                list.Add(new Catalog() { Manufacturer = (string)item[0], Category = (string)item[1], Model = (string)item[2], Name = (string)item[3], Amount = (string)item[4], Price = (string)item[5] });
            }

            dataTable.ColumnWidth = 654 / 6;
            dataTable.ItemsSource = list;

            anim.From = Catalog.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

            Catalog.Visibility = Visibility.Hidden;
            table.Visibility = Visibility.Visible;

            anim.From = 0;
            anim.To = 1;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            table.BeginAnimation(Border.OpacityProperty, anim);    
        }
        public static void GetTableAllOrdr(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, int swit, StackPanel ButtonsAll)
        {
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();

            table.Visibility = Visibility.Visible;

            var mySQL = "SELECT Product.Name, Buyer.Name, Supplier.Name, Orderr.Amount, Orderr.DateOfOrder, Orderr.DateOfSupply " +
                        "FROM Orderr " +
                        "INNER JOIN Product ON Orderr.Product_id = Product.Product_id " +
                        "INNER JOIN Buyer ON Orderr.Buyer_id = Buyer.Buyer_id " +
                        "INNER JOIN Supplier ON Orderr.Supplier_id = Supplier.Supplier_id ";

            DataTable userData = ServerConnection.executeSQL(mySQL);

            List<Product> list = new List<Product>();

            Product header = new Product() { Productt = "Product", Buyer = "Buyer", Supplier = "Supplier", Amount = "Amount", OrderDate = "Order date", SupplyDate = "Supply date" };
            list.Add(header);

            foreach (DataRow item in userData.Rows)
            {
                list.Add(new Product() { Productt = item[0].ToString(), Buyer = item[1].ToString(), Supplier = item[2].ToString(), Amount = item[3].ToString(), OrderDate = item[4].ToString().Substring(0, 10), SupplyDate = item[5].ToString().Substring(0, 10) });
            }

            ButtonsAll.Visibility = swit == 5 ? Visibility.Hidden : Visibility.Visible;

            dataTable.ColumnWidth = 654 / 6;
            dataTable.ItemsSource = list;

            anim.From = Catalog.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

            Catalog.Visibility = Visibility.Hidden;
            table.Visibility = Visibility.Visible;

            anim.From = 0;
            anim.To = 1;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            table.BeginAnimation(Border.OpacityProperty, anim);
        }
        public static void GetTableAllCust(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, StackPanel ButtonsAll)
        {
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();

            table.Visibility = Visibility.Visible;

            var mySQL = "SELECT Buyer.Name, Address.Country, Address.Town " +
                        "FROM Buyer " +
                        "INNER JOIN Address ON Buyer.Address_id = Address.Address_id";

            DataTable userData = ServerConnection.executeSQL(mySQL);

            List<Buyer> list = new List<Buyer>();

            ButtonsAll.Visibility = Visibility.Visible;

            Buyer header = new Buyer() { Name = "Name", Country = "Country", Town = "Town" };
            list.Add(header);

            foreach (DataRow item in userData.Rows)
            {
                list.Add(new Buyer() { Name = item[0].ToString(), Country = item[1].ToString(), Town = item[2].ToString() });
            }

            dataTable.ColumnWidth = 654 / 3;
            dataTable.ItemsSource = list;

            anim.From = Catalog.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

            Catalog.Visibility = Visibility.Hidden;
            table.Visibility = Visibility.Visible;

            anim.From = table.Opacity;
            anim.To = 1;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            table.BeginAnimation(Border.OpacityProperty, anim);
        }
        public static void GetTableAllSupl(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, StackPanel ButtonsAll)
        {
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();

            table.Visibility = Visibility.Visible;

            var mySQL = "SELECT Supplier.Name, Supplier.TermsOfPay, Address.Country, Address.Town " +
                    "FROM Supplier " +
                    "INNER JOIN Address ON Supplier.Address_id = Address.Address_id";

            DataTable userData = ServerConnection.executeSQL(mySQL);

            List<Supplier> list = new List<Supplier>();

            ButtonsAll.Visibility = Visibility.Visible;

            Supplier header = new Supplier() { Name = "Name", TermsOfPay = "Term of pay", Country = "Country", Town = "Town" };
            list.Add(header);

            foreach (DataRow item in userData.Rows)
            {
                list.Add(new Supplier() { Name = item[0].ToString(), TermsOfPay = item[1].ToString(), Country = item[2].ToString(), Town = item[3].ToString() });
            }

            dataTable.ColumnWidth = 656 / 4;
            dataTable.ItemsSource = list;

            anim.From = Catalog.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

            Catalog.Visibility = Visibility.Hidden;
            table.Visibility = Visibility.Visible;

            anim.From = table.Opacity;
            anim.To = 1;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            table.BeginAnimation(Border.OpacityProperty, anim);
        }
        public static void GetTableAllUser(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, StackPanel ButtonsAll)
        {
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();

            table.Visibility = Visibility.Visible;

            var mySQL = "SELECT LoginTable.Login, LoginTable.Role, LoginTable.Access " +
                        "FROM LoginTable";

            DataTable userData = ServerConnection.executeSQL(mySQL);

            List<User> list = new List<User>();

            ButtonsAll.Visibility = Visibility.Visible;

            User header = new User() { Login = "Login", Role = "Role", Access = "Access" };
            list.Add(header);

            foreach (DataRow item in userData.Rows)
            {
                list.Add(new User() { Login = item[0].ToString(), Role = item[1].ToString(), Access = item[2].ToString() });
            }

            dataTable.ColumnWidth = 654 / 3;
            dataTable.ItemsSource = list;

            anim.From = Catalog.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

            Catalog.Visibility = Visibility.Hidden;
            table.Visibility = Visibility.Visible;

            anim.From = table.Opacity;
            anim.To = 1;
            anim.Duration = TimeSpan.FromSeconds(0.3);
            table.BeginAnimation(Border.OpacityProperty, anim);
        }
        public static void GetTableProd(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, string nameOfTab, StackPanel ButtonsAll)
        {
            var mySQL = "SELECT " + nameOfTab + " FROM " + nameOfTab;
            
            DataTable userData = ServerConnection.executeSQL(mySQL);
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();

            ButtonsAll.Visibility = Visibility.Visible;

            foreach (DataRow row in userData.Rows)
            {
                Border rect = new Border();
                Label name = new Label();

                name.Content = (string)row[0];
                name.VerticalAlignment = VerticalAlignment.Center;
                name.HorizontalAlignment = HorizontalAlignment.Center;
                name.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                name.FontSize = 24;
                name.FontFamily = new FontFamily("/Fonts/#Poppins");

                rect.MouseLeftButtonDown += delegate
                {
                    var nameOfBut = (string)name.Content;

                    table.Visibility = Visibility.Visible;

                    mySQL = "SELECT Manufacturer.Manufacturer, Category.Category, Model.Model, Product.Name, Product.Amount, Product.Price " +
                            "FROM Product " +
                            "INNER JOIN Manufacturer ON Product.Manufacturer_id = Manufacturer.Manufacturer_id " +
                            "INNER JOIN Category ON Product.Category_id = Category.Category_id " +
                            "INNER JOIN Model ON Product.Model_id = Model.Model_id " +
                            "WHERE " + nameOfTab + "." + nameOfTab + " = '" + nameOfBut + "'";
                    userData = ServerConnection.executeSQL(mySQL);

                    List<Catalog> list = new List<Catalog>();

                    Catalog header = new Catalog() { Manufacturer = "Manufacturer", Category = "Category", Model = "Model", Name = "Name", Amount = "Amount", Price = "Price" };
                    list.Add(header);

                    foreach (DataRow item in userData.Rows)
                    {
                        list.Add(new Catalog() { Manufacturer = (string)item[0], Category = (string)item[1], Model = (string)item[2], Name = (string)item[3], Amount = (string)item[4], Price = (string)item[5] });
                    }

                    dataTable.ColumnWidth = 654 / 6;
                    dataTable.ItemsSource = list;

                    anim.From = Catalog.Opacity;
                    anim.To = 0;
                    anim.Duration = TimeSpan.FromSeconds(0.3);
                    Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

                    Catalog.Visibility = Visibility.Hidden;
                    table.Visibility = Visibility.Visible;

                    anim.From = table.Opacity;
                    anim.To = 1;
                    anim.Duration = TimeSpan.FromSeconds(0.3);
                    table.BeginAnimation(Border.OpacityProperty, anim);
                };

                rect.MouseEnter += delegate
                {
                    SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5f960d"));
                    rect.Background = brush;

                    ColorAnimation animation = new ColorAnimation((Color)ColorConverter.ConvertFromString("#5f960d"), (Color)ColorConverter.ConvertFromString("#3e610a"), new Duration(TimeSpan.FromSeconds(0.2)));

                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                };

                rect.MouseLeave += delegate
                {
                    SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3e610a"));
                    rect.Background = brush;

                    ColorAnimation animation = new ColorAnimation((Color)ColorConverter.ConvertFromString("#3e610a"), (Color)ColorConverter.ConvertFromString("#5f960d"), new Duration(TimeSpan.FromSeconds(0.2)));

                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                };

                rect.Opacity = 0;
                rect.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5f960d"));
                rect.Cursor = Cursors.Hand;

                rect.Child = name;
                rects.Add(rect);
            }

            if (panel.Children.Count != 0)
            {
                panel.Children.Clear();
            }

            foreach (Border item in rects)
            {
                panel.Children.Add(item);

                anim.From = item.Opacity;
                anim.To = 1;
                anim.Duration = TimeSpan.FromSeconds(0.3);
                item.BeginAnimation(Border.OpacityProperty, anim);
            }
        }
        public static void GetTableOrdr(StackPanel table, DataGrid dataTable, WrapPanel panel, StackPanel Catalog, string nameOfTab, StackPanel ButtonsAll)
        {
            var mySQL = "SELECT Name FROM " + nameOfTab;

            DataTable userData = ServerConnection.executeSQL(mySQL);
            List<Border> rects = new List<Border>();
            DoubleAnimation anim = new DoubleAnimation();
            ColorAnimation animColor = new ColorAnimation();

            ButtonsAll.Visibility = Visibility.Visible;

            foreach (DataRow row in userData.Rows)
            {
                Border rect = new Border();
                Label name = new Label();

                name.Content = (string)row[0];
                name.VerticalAlignment = VerticalAlignment.Center;
                name.HorizontalAlignment = HorizontalAlignment.Center;
                name.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                name.FontSize = 24;
                name.FontFamily = new FontFamily("/Fonts/#Poppins");

                rect.MouseLeftButtonDown += delegate
                {
                    var nameOfBut = (string)name.Content;

                    table.Visibility = Visibility.Visible;

                    mySQL = "SELECT Product.Name, Buyer.Name, Supplier.Name, Orderr.Amount, Orderr.DateOfOrder, Orderr.DateOfSupply " +
                            "FROM Orderr " +
                            "INNER JOIN Product ON Orderr.Product_id = Product.Product_id " +
                            "INNER JOIN Buyer ON Orderr.Buyer_id = Buyer.Buyer_id " +
                            "INNER JOIN Supplier ON Orderr.Supplier_id = Supplier.Supplier_id " +
                            "WHERE " + nameOfTab + ".Name = '" + nameOfBut + "'";
                    userData = ServerConnection.executeSQL(mySQL);

                    List<Product> list = new List<Product>();

                    Product header = new Product() { Productt = "Product", Buyer = "Buyer", Supplier = "Supplier", Amount = "Amount", OrderDate = "Order date", SupplyDate = "Supply date" }; 
                    list.Add(header);

                    foreach (DataRow item in userData.Rows)
                    {
                        list.Add(new Product() { Productt = item[0].ToString(), Buyer = item[1].ToString(), Supplier = item[2].ToString(), Amount = item[3].ToString(), OrderDate = item[4].ToString().Substring(0, 10), SupplyDate = item[5].ToString().Substring(0, 10) });
                    }

                    dataTable.ColumnWidth = 654 / 6;
                    dataTable.ItemsSource = list;

                    anim.From = Catalog.Opacity;
                    anim.To = 0;
                    anim.Duration = TimeSpan.FromSeconds(0.3);
                    Catalog.BeginAnimation(StackPanel.OpacityProperty, anim);

                    Catalog.Visibility = Visibility.Hidden;
                    table.Visibility = Visibility.Visible;

                    anim.From = table.Opacity;
                    anim.To = 1;
                    anim.Duration = TimeSpan.FromSeconds(0.3);
                    table.BeginAnimation(Border.OpacityProperty, anim);
                };

                rect.MouseEnter += delegate
                {
                    SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#be3e2d"));
                    rect.Background = brush;

                    ColorAnimation animation = new ColorAnimation((Color)ColorConverter.ConvertFromString("#be3e2d"), (Color)ColorConverter.ConvertFromString("#81291d"), new Duration(TimeSpan.FromSeconds(0.2)));

                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                };

                rect.MouseLeave += delegate
                {
                    SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#81291d"));
                    rect.Background = brush;

                    ColorAnimation animation = new ColorAnimation((Color)ColorConverter.ConvertFromString("#81291d"), (Color)ColorConverter.ConvertFromString("#be3e2d"), new Duration(TimeSpan.FromSeconds(0.2)));

                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                };

                rect.Opacity = 0;
                rect.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#be3e2d"));
                rect.Cursor = Cursors.Hand;

                rect.Child = name;
                rects.Add(rect);
            }

            if (panel.Children.Count != 0)
            {
                panel.Children.Clear();
            }

            foreach (Border item in rects)
            {
                panel.Children.Add(item);

                anim.From = item.Opacity;
                anim.To = 1;
                anim.Duration = TimeSpan.FromSeconds(0.3);
                item.BeginAnimation(Border.OpacityProperty, anim);
            }
        }
    }
}