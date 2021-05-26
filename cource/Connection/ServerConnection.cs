using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using cource.Main;

namespace cource.Connection
{
    class ServerConnection
    {
        public static string stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";
        public static DataTable executeSQL(string sql)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dt = new DataTable();
            try
            {
                connection.ConnectionString = stringConnection;
                connection.Open();

                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);

                connection.Close();
                connection = null;
                return dt;
            }
            catch (Exception)
            {
                MessageBox.Show("SQL Server Connection Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                dt = null;
            }

            return dt;
        }

        public static void DelCat(SqlCommand command, SqlConnection connection, List<string> spis)
        {
            command.CommandText = string.Format("DELETE p FROM Product p " +
                                                "INNER JOIN Manufacturer m ON p.Manufacturer_id = m.Manufacturer_id " +
                                                "INNER JOIN Category c ON p.Category_id = c.Category_id " +
                                                "INNER JOIN Model n ON p.Model_id = n.Model_id " +
                                                "WHERE m.Manufacturer = '{0}' AND c.Category = '{1}' AND n.Model = '{2}' " +
                                                "AND p.Name = '{3}' AND p.Amount = '{4}' AND p.Price = '{5}'", spis[0], spis[1], spis[2], spis[3], spis[4], spis[5]);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void DelOrd(SqlCommand command, SqlConnection connection, List<string> spis)
        {
            command.CommandText = string.Format("DELETE o FROM Orderr o " +
                                                "INNER JOIN Product p ON o.Product_id = p.Product_id " +
                                                "INNER JOIN Buyer b ON o.Buyer_id = b.Buyer_id " +
                                                "INNER JOIN Supplier s ON o.Supplier_id = s.Supplier_id " +
                                                "WHERE p.Name = '{0}' AND b.Name = '{1}' AND s.Name = '{2}' AND o.Amount = '{3}' AND o.DateOfOrder = '{4}' AND o.DateOfSupply = '{5}'", spis[0], spis[1], spis[2], spis[3], spis[4], spis[5]);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void DelCust(SqlCommand command, SqlConnection connection, List<string> spis)
        {
            command.CommandText = string.Format("DELETE b FROM Buyer b " +
                                                "INNER JOIN Address a ON a.Address_id = b.Address_id " +
                                                "WHERE b.Name = '{0}' AND a.Country = '{1}' AND a.Town = '{2}'", spis[0], spis[1], spis[2]);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void DelSupl(SqlCommand command, SqlConnection connection, List<string> spis)
        {
            command.CommandText = string.Format("DELETE s FROM Supplier s " +
                                                "INNER JOIN Address a ON a.Address_id = s.Address_id " +
                                                "WHERE s.Name = '{0}' AND s.TermsOfPay = '{1}' AND a.Country = '{2}' AND a.Town = '{3}'", spis[0], spis[1], spis[2], spis[3]);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void DelUser(SqlCommand command, SqlConnection connection, List<string> spis)
        {
            command.CommandText = string.Format("DELETE l FROM LoginTable l " +
                                                "WHERE l.Login = '{0}' AND l.Role = '{1}' AND l.Access = '{2}'", spis[0], spis[1], spis[2]);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void CreateContract(SqlCommand command, SqlConnection connection, List<string> spis)
        {
            Word._Application application;
            Word._Document document = null;

            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;

            application = new Word.Application();
            Object templatePathObj = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Tample.dotx");
         
            try
            {
                document = application.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
            }
            catch (Exception)
            {
                document.Close(ref falseObj, ref missingObj, ref missingObj);
                application.Quit(ref missingObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
            }
            application.Visible = false;

            object strToFindObj1 = "@@buyer";
            object strToFindObj2 = "@@supplier";
            object strToFindObj3 = "@@date";
            object strToFindObj4 = "@@orderDate";
            object strToFindObj5 = "@@supplyDate";
            object strToFindObj6 = "@@amount";

            DateTime date = new DateTime();
            date = DateTime.Today;
            string date1 = date.ToString();

            Word.Range wordRange;
            object replaceTypeObj;
            replaceTypeObj = Word.WdReplace.wdReplaceAll;

            for (int i = 1; i <= document.Sections.Count; i++)
            {
                wordRange = document.Sections[i].Range;

                Word.Find wordFindObj = wordRange.Find;

                object[] wordFindParameters = new object[15] { strToFindObj1, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, spis[1], replaceTypeObj, missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { strToFindObj2, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, spis[2], replaceTypeObj, missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { strToFindObj3, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, DateFormat.FormatStr(date1.Substring(0, 10)), replaceTypeObj, missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { strToFindObj4, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, spis[4], replaceTypeObj, missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { strToFindObj5, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, spis[5], replaceTypeObj, missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                wordFindParameters = new object[15] { strToFindObj6, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, missingObj, spis[3], replaceTypeObj, missingObj, missingObj, missingObj, missingObj };
                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);
            }

            Object pathToSaveObj = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Document Word|*.docx|Document Word 97-2003|*.doc",
                FileName = "Contract.docx",
                Title = "Save an Contract File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                pathToSaveObj = saveFileDialog.FileName;
            }
            
            if (pathToSaveObj != null)
            {
                document.SaveAs(ref pathToSaveObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj);
            }

            document.Close(ref falseObj, ref missingObj, ref missingObj);
            application.Quit(ref missingObj, ref missingObj, ref missingObj);
        }
    }
}
