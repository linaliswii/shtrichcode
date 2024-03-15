using System;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using Font = System.Drawing.Font;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace strichcode
{
    public partial class Form1 : Form
    {
        private string article;
        private Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            LoadProductName();
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            cmbSorting.SelectedIndexChanged += cmbSorting_SelectedIndexChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void RealTimeSearch()
        {
            string searchString = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchString))
            {
                string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT Артикул, Название, Стоимость_руб FROM Товары WHERE Название ILIKE @searchString";

                    using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string productName = reader["Название"].ToString();
                                string artikul = reader["Артикул"].ToString();
                                string count = reader["Стоимость_руб"].ToString();
                                label1.Text = productName;
                                label3.Text = count;
                                linkLabel1.Text = artikul;
                            }
                            else
                            {
                                label1.Text = "Товар не найден";
                                label3.Text = "Товар не найден";
                                linkLabel1.Text = "Товар не найден";
                            }
                        }
                    }
                }
            }
        }


        private void LoadProductName()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Название FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label1.Text = productName;
                        }
                        else
                        {
                            label1.Text = "Товар не найден";
                        }
                    }
                }

                string selectart = "SELECT Артикул FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel1.Text = productart;
                        }
                        else
                        {
                            linkLabel1.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery1 = "SELECT Стоимость_руб FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label3.Text = productcost;
                        }
                        else
                        {
                            label3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery2 = "SELECT Название FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label6.Text = productName;
                        }
                        else
                        {
                            label6.Text = "Товар не найден";
                        }
                    }
                }

                string selectart2 = "SELECT Артикул FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel2.Text = productart;
                        }
                        else
                        {
                            linkLabel2.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery21 = "SELECT Стоимость_руб FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery21, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label4.Text = productcost;
                        }
                        else
                        {
                            label4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery3 = "SELECT Название FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label9.Text = productName;
                        }
                        else
                        {
                            label9.Text = "Товар не найден";
                        }
                    }
                }

                string selectart3 = "SELECT Артикул FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel3.Text = productart;
                        }
                        else
                        {
                            linkLabel3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery31 = "SELECT Стоимость_руб FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery31, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label7.Text = productcost;
                        }
                        else
                        {
                            label7.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery4 = "SELECT Название FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label12.Text = productName;
                        }
                        else
                        {
                            label12.Text = "Товар не найден";
                        }
                    }
                }

                string selectart4 = "SELECT Артикул FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel4.Text = productart;
                        }
                        else
                        {
                            linkLabel4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery41 = "SELECT Стоимость_руб FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery41, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label10.Text = productcost;
                        }
                        else
                        {
                            label10.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery5 = "SELECT Название FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label15.Text = productName;
                        }
                        else
                        {
                            label15.Text = "Товар не найден";
                        }
                    }
                }

                string selectart5 = "SELECT Артикул FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel5.Text = productart;
                        }
                        else
                        {
                            linkLabel5.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery51 = "SELECT Стоимость_руб FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery51, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label13.Text = productcost;
                        }
                        else
                        {
                            label13.Text = "Товар не найден";
                        }
                    }
                }
            }
        }

        private void LoadProductName2()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Название FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label1.Text = productName;
                        }
                        else
                        {
                            label1.Text = "Товар не найден";
                        }
                    }
                }

                string selectart = "SELECT Артикул FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel1.Text = productart;
                        }
                        else
                        {
                            linkLabel1.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery1 = "SELECT Стоимость_руб FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label3.Text = productcost;
                        }
                        else
                        {
                            label3.Text = "Товар не найден";
                        }
                    }
                }


                string selectQuery2 = "SELECT Название FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label6.Text = productName;
                        }
                        else
                        {
                            label6.Text = "Товар не найден";
                        }
                    }
                }

                string selectart7 = "SELECT Артикул FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart7, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel2.Text = productart;
                        }
                        else
                        {
                            linkLabel2.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery21 = "SELECT Стоимость_руб FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery21, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label4.Text = productcost;
                        }
                        else
                        {
                            label4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery3 = "SELECT Название FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label9.Text = productName;
                        }
                        else
                        {
                            label9.Text = "Товар не найден";
                        }
                    }
                }

                string selectart8 = "SELECT Артикул FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart8, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel3.Text = productart;
                        }
                        else
                        {
                            linkLabel3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery31 = "SELECT Стоимость_руб FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery31, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label7.Text = productcost;
                        }
                        else
                        {
                            label7.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery4 = "SELECT Название FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label12.Text = productName;
                        }
                        else
                        {
                            label12.Text = "Товар не найден";
                        }
                    }
                }

                string selectart9 = "SELECT Артикул FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart9, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel4.Text = productart;
                        }
                        else
                        {
                            linkLabel4.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery41 = "SELECT Стоимость_руб FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery41, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label10.Text = productcost;
                        }
                        else
                        {
                            label10.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery5 = "SELECT Название FROM Товары WHERE ID = 10";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label15.Text = productName;
                        }
                        else
                        {
                            label15.Text = "Товар не найден";
                        }
                    }
                }

                string selectart1 = "SELECT Артикул FROM Товары WHERE ID = 10";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel5.Text = productart;
                        }
                        else
                        {
                            linkLabel5.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery51 = "SELECT Стоимость_руб FROM Товары WHERE ID = 10";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery51, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label13.Text = productcost;
                        }
                        else
                        {
                            label13.Text = "Товар не найден";
                        }
                    }
                }
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            LoadProductName();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            LoadProductName2();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RealTimeSearch();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            article = linkLabel1.Text;
            print(article);
        }


        private Bitmap DrawBarcode(string code, int resolution = 20) // resolution - пикселей на миллиметр
        {
            int numberCount = 6;
            float height = 25.93f * resolution;
            float lineHeight = 22.85f * resolution;
            float leftOffset = 3.63f * resolution;
            float rightOffset = 2.31f * resolution;
            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 2.75f * resolution;
            float lineToFontOffset = 0.165f * resolution;
            float lineWidthDelta = 0.15f * resolution;
            float lineWidthFull = 1.35f * resolution;
            float lineOffset = 0.2f * resolution;
            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset);
            Bitmap bitmap = new Bitmap((int)width, (int)height);
            Graphics g = Graphics.FromImage(bitmap);
            Font font = new Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel);
            StringFormat fontFormat = new StringFormat();
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;
            float x = leftOffset;
            for (int i = 0; i < numberCount; i++)
            {
                int number = Convert.ToInt32(code[i].ToString());
                if (number != 0)
                {
                    g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight);
                }
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight);
                g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat);
                x += lineWidthFull + lineOffset;

                if (i == 0 || i == numberCount / 2 || i == numberCount - 1)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight);
                        x += lineWidthDelta + lineOffset;
                    }
                }
            }
            return bitmap;
        }

        private void print(string article)
        {
            Bitmap bitmap = DrawBarcode(article);

            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.PrintPage += (s, e) =>
                {

                    RectangleF imageRect = new RectangleF(100, 100, 200, 150);
                    e.Graphics.DrawImage(bitmap, imageRect);
                    e.HasMorePages = false;
                };
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            article = linkLabel2.Text;
            print(article);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            article = linkLabel3.Text;
            print(article);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            article = linkLabel4.Text;
            print(article);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            article = linkLabel5.Text;
            print(article);
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cmbFilter.SelectedItem.ToString();
            switch (selectedOption)
            {
                case "Дополнительное":
                    stDop();
                    break;

                case "Основное":
                    stOsn();
                    break;

                case "Всё":
                    LoadProductName();
                    break;
            }
        }

        private void stOsn()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Название FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label1.Text = productName;
                        }
                        else
                        {
                            label1.Text = "Товар не найден";
                        }
                    }
                }

                string selectart = "SELECT Артикул FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel1.Text = productart;
                        }
                        else
                        {
                            linkLabel1.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery1 = "SELECT Стоимость_руб FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label3.Text = productcost;
                        }
                        else
                        {
                            label3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery2 = "SELECT Название FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label6.Text = productName;
                        }
                        else
                        {
                            label6.Text = "Товар не найден";
                        }
                    }
                }

                string selectart2 = "SELECT Артикул FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel2.Text = productart;
                        }
                        else
                        {
                            linkLabel2.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery21 = "SELECT Стоимость_руб FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery21, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label4.Text = productcost;
                        }
                        else
                        {
                            label4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery3 = "SELECT Название FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label9.Text = productName;
                        }
                        else
                        {
                            label9.Text = "Товар не найден";
                        }
                    }
                }

                string selectart3 = "SELECT Артикул FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel3.Text = productart;
                        }
                        else
                        {
                            linkLabel3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery31 = "SELECT Стоимость_руб FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery31, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label7.Text = productcost;
                        }
                        else
                        {
                            label7.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery4 = "SELECT Название FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label12.Text = productName;
                        }
                        else
                        {
                            label12.Text = "Товар не найден";
                        }
                    }
                }

                string selectart4 = "SELECT Артикул FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel4.Text = productart;
                        }
                        else
                        {
                            linkLabel4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery41 = "SELECT Стоимость_руб FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery41, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label10.Text = productcost;
                        }
                        else
                        {
                            label10.Text = "Товар не найден";
                        }
                    }
                }
            }
        }

        private void stDop()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Название FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label1.Text = productName;
                        }
                        else
                        {
                            label1.Text = "Товар не найден";
                        }
                    }
                }

                string selectart = "SELECT Артикул FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel1.Text = productart;
                        }
                        else
                        {
                            linkLabel1.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery1 = "SELECT Стоимость_руб FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label3.Text = productcost;
                        }
                        else
                        {
                            label3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery2 = "SELECT Название FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label6.Text = productName;
                        }
                        else
                        {
                            label6.Text = "Товар не найден";
                        }
                    }
                }

                string selectart2 = "SELECT Артикул FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel2.Text = productart;
                        }
                        else
                        {
                            linkLabel2.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery21 = "SELECT Стоимость_руб FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery21, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label4.Text = productcost;
                        }
                        else
                        {
                            label4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery3 = "SELECT Название FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label9.Text = productName;
                        }
                        else
                        {
                            label9.Text = "Товар не найден";
                        }
                    }
                }

                string selectart3 = "SELECT Артикул FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel3.Text = productart;
                        }
                        else
                        {
                            linkLabel3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery31 = "SELECT Стоимость_руб FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery31, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label7.Text = productcost;
                        }
                        else
                        {
                            label7.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery4 = "SELECT Название FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label12.Text = productName;
                        }
                        else
                        {
                            label12.Text = "Товар не найден";
                        }
                    }
                }

                string selectart4 = "SELECT Артикул FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel4.Text = productart;
                        }
                        else
                        {
                            linkLabel4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery41 = "SELECT Стоимость_руб FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery41, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label10.Text = productcost;
                        }
                        else
                        {
                            label10.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery5 = "SELECT Название FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label15.Text = productName;
                        }
                        else
                        {
                            label15.Text = "Товар не найден";
                        }
                    }
                }

                string selectart5 = "SELECT Артикул FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel5.Text = productart;
                        }
                        else
                        {
                            linkLabel5.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery51 = "SELECT Стоимость_руб FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery51, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label13.Text = productcost;
                        }
                        else
                        {
                            label13.Text = "Товар не найден";
                        }
                    }
                }
            }
        }

        private void cmbSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cmbSorting.SelectedItem.ToString();
            switch (selectedOption)
            {
                case "Стоимость минимальная":
                    stMin();
                    break;

                case "Стоимость максимальная":
                    stMax();
                    break;

                case "Всё":
                    LoadProductName();
                    break;
            }
        }

        private void stMax()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Название FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label1.Text = productName;
                        }
                        else
                        {
                            label1.Text = "Товар не найден";
                        }
                    }
                }

                string selectart = "SELECT Артикул FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel1.Text = productart;
                        }
                        else
                        {
                            linkLabel1.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery1 = "SELECT Стоимость_руб FROM Товары WHERE ID = 1";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label3.Text = productcost;
                        }
                        else
                        {
                            label3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery2 = "SELECT Название FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label6.Text = productName;
                        }
                        else
                        {
                            label6.Text = "Товар не найден";
                        }
                    }
                }

                string selectart2 = "SELECT Артикул FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel2.Text = productart;
                        }
                        else
                        {
                            linkLabel2.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery21 = "SELECT Стоимость_руб FROM Товары WHERE ID = 2";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery21, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label4.Text = productcost;
                        }
                        else
                        {
                            label4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery3 = "SELECT Название FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label9.Text = productName;
                        }
                        else
                        {
                            label9.Text = "Товар не найден";
                        }
                    }
                }

                string selectart3 = "SELECT Артикул FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel3.Text = productart;
                        }
                        else
                        {
                            linkLabel3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery31 = "SELECT Стоимость_руб FROM Товары WHERE ID = 4";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery31, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label7.Text = productcost;
                        }
                        else
                        {
                            label7.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery4 = "SELECT Название FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label12.Text = productName;
                        }
                        else
                        {
                            label12.Text = "Товар не найден";
                        }
                    }
                }

                string selectart4 = "SELECT Артикул FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel4.Text = productart;
                        }
                        else
                        {
                            linkLabel4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery41 = "SELECT Стоимость_руб FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery41, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label10.Text = productcost;
                        }
                        else
                        {
                            label10.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery5 = "SELECT Название FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label15.Text = productName;
                        }
                        else
                        {
                            label15.Text = "Товар не найден";
                        }
                    }
                }

                string selectart5 = "SELECT Артикул FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel5.Text = productart;
                        }
                        else
                        {
                            linkLabel5.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery51 = "SELECT Стоимость_руб FROM Товары WHERE ID = 7";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery51, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label13.Text = productcost;
                        }
                        else
                        {
                            label13.Text = "Товар не найден";
                        }
                    }
                }
            }
    } 

        private void stMin()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=shtrichcode";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Название FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label1.Text = productName;
                        }
                        else
                        {
                            label1.Text = "Товар не найден";
                        }
                    }
                }

                string selectart = "SELECT Артикул FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel1.Text = productart;
                        }
                        else
                        {
                            linkLabel1.Text = "Товар не найден";
                        }
                    }
                }
                string selectQuery1 = "SELECT Стоимость_руб FROM Товары WHERE ID = 3";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery1, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label3.Text = productcost;
                        }
                        else
                        {
                            label3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery2 = "SELECT Название FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label6.Text = productName;
                        }
                        else
                        {
                            label6.Text = "Товар не найден";
                        }
                    }
                }

                string selectart2 = "SELECT Артикул FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart2, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel2.Text = productart;
                        }
                        else
                        {
                            linkLabel2.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery21 = "SELECT Стоимость_руб FROM Товары WHERE ID = 5";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery21, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label4.Text = productcost;
                        }
                        else
                        {
                            label4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery3 = "SELECT Название FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label9.Text = productName;
                        }
                        else
                        {
                            label9.Text = "Товар не найден";
                        }
                    }
                }

                string selectart3 = "SELECT Артикул FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart3, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel3.Text = productart;
                        }
                        else
                        {
                            linkLabel3.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery31 = "SELECT Стоимость_руб FROM Товары WHERE ID = 6";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery31, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label7.Text = productcost;
                        }
                        else
                        {
                            label7.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery4 = "SELECT Название FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label12.Text = productName;
                        }
                        else
                        {
                            label12.Text = "Товар не найден";
                        }
                    }
                }

                string selectart4 = "SELECT Артикул FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart4, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel4.Text = productart;
                        }
                        else
                        {
                            linkLabel4.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery41 = "SELECT Стоимость_руб FROM Товары WHERE ID = 8";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery41, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label10.Text = productcost;
                        }
                        else
                        {
                            label10.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery5 = "SELECT Название FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["Название"].ToString();
                            label15.Text = productName;
                        }
                        else
                        {
                            label15.Text = "Товар не найден";
                        }
                    }
                }

                string selectart5 = "SELECT Артикул FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectart5, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productart = reader["Артикул"].ToString();
                            linkLabel5.Text = productart;
                        }
                        else
                        {
                            linkLabel5.Text = "Товар не найден";
                        }
                    }
                }

                string selectQuery51 = "SELECT Стоимость_руб FROM Товары WHERE ID = 9";

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery51, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productcost = reader["Стоимость_руб"].ToString();
                            label13.Text = productcost;
                        }
                        else
                        {
                            label13.Text = "Товар не найден";
                        }
                    }
                }
            }
        }
        }
    }







