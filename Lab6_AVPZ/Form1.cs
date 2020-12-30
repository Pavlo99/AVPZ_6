using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Lab6_AVPZ
{
    public partial class Form1 : Form
    {
        private string[] criterias = { "Точність управління та обчислень", "Ступінь стандартності інтерфейсів", "Функціональна повнота", "Стійкість до помилок", "Можливість розширення", "Зручність роботи", "Простота роботи", "Відповідність чинним стандартам", "Переносимість між ПЗ", "Зручність навчання" };
        
        public Form1()
        {
            InitializeComponent();
            DV1();
            CalculateDV1();
            DV2();
            DV3();
            CalculateDV3();
            CalculateDV4();
            DV5();
            CalculateDV5();
            CalculateDV6();
            CreateDV(dataGridView7, dataGridView8);
            CalculateDV(dataGridView7, dataGridView1, dataGridView3, 1, dataGridView8, label12,label13,picture1);
            CreateDV(dataGridView10, dataGridView9);
            CalculateDV(dataGridView10, dataGridView1, dataGridView3, 2, dataGridView9, label15, label14, picture2);
            CreateDV(dataGridView12, dataGridView11);
            CalculateDV(dataGridView12, dataGridView1, dataGridView3, 3, dataGridView11, label17, label16, picture3);
            CreateDV(dataGridView14, dataGridView13);
            CalculateDV(dataGridView14, dataGridView1, dataGridView3, 4, dataGridView13, label19, label18, picture4);
            CreateDV(dataGridView15, dataGridView16);
            CalculateUZ();
            fullList.RemoveAt(4);
            sfullList.RemoveAt(4);
            CreateDV17();
            Sort(CalculateDV17());
            pictureBox2.Image=DrawFull();
            CreateDV18();
            CalculateDV18();
        }

        private Bitmap DrawFull()
        {
            Bitmap btm = new Bitmap(330, 330);
            Graphics g = Graphics.FromImage(btm);
            float k = 1.5f;
            g.TranslateTransform(110 * k, 110 * k);
            g.FillRectangle(new SolidBrush(Color.White), k * -110, k * -110, 327, 327);
            g.DrawRectangle(new Pen(Color.Black), k * -110, k * -110, 327, 327);
            Pen p = new Pen(Color.Green);
            Brush brush = new SolidBrush(Color.Green);
            //круги
            g.DrawEllipse(new Pen(Color.Black, 2), -100 * k, -100 * k, 200 * k, 200 * k);
            g.FillEllipse(new SolidBrush(Color.LightCyan), -100 * k, -100 * k, 200 * k, 200 * k);
            for (int i = 1; i < 10; i++)
            {
                g.DrawEllipse(new Pen(Color.Cyan, 1), -100 * k + i * 10 * k, -100 * k + i * 10 * k, 200 * k - i * 20 * k, 200 * k - i * 20 * k);
            }
            //--круги
            var gg = Graphics.FromImage(btm);
            for (int i = 0; i < 4; i++)
            {
                g.RotateTransform(-90);
                g.DrawPolygon(new Pen(Color.Black, 2), fullList[i].ToArray());
                g.FillPolygon(new SolidBrush(Color.FromArgb(125, Color.Yellow)), fullList[i].ToArray());
                g.RotateTransform(90);
                //
                var array = sfullList[i];
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int j = 1; j < 10; j++)
                {
                    gg.DrawLine(pen, array[j - 1], array[j]);
                }
                gg.DrawLine(pen, array[0], array[9]);
                //
                for(int j = 0; j < 10; j++)
                {
                    Arrow(110*k, 110*k, array[j].X, array[j].Y,gg);
                }
            }
            //прямі
            g.DrawLine(p, -110 * k, 0, 110 * k, 0);
            g.DrawLine(p, 0, -110 * k, 0, 110 * k);
            g.FillPolygon(brush, new PointF[] { new PointF(0, -110 * k), new PointF(5, -110 * k + 5), new PointF(-5, -110 * k + 5) });
            g.FillPolygon(brush, new PointF[] { new PointF(110 * k, 0), new PointF(110 * k - 5, 5), new PointF(110 * k - 5, -5) });
            //--прямі
            return btm;
        }

        private void CalculateDV18()
        {
            Random r = new Random();
            for (int i = 0; i < 15; i++)
            {
                int sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    dataGridView18.Rows[j].Cells[i+1].Value = Math.Min(10,((j == 0 || j == 3) ? 6 : 5) + (int)((r.Next(4) + 3) * r.NextDouble()));
                    sum += int.Parse(dataGridView18.Rows[j].Cells[i+1].Value.ToString());
                }
                dataGridView18.Rows[4].Cells[i+1].Value = sum.ToString();
            }
        }

        private void CreateDV18()
        {
            dataGridView18.Rows.Add(5);
            dataGridView18.Rows[0].Cells[0].Value = "Експерт галузі";
            dataGridView18.Rows[1].Cells[0].Value = "Експерт юзабіліті";
            dataGridView18.Rows[2].Cells[0].Value = "Експерт з програмування";
            dataGridView18.Rows[3].Cells[0].Value = "Потенційні користувачі";
        }

        private double[] CalculateDV17()
        {
            for(int i = 0; i < 5; i++)
            {
                dataGridView17.Rows[i].Cells[1].Value = dataGridView6.Columns[i+1].HeaderText;
            }
            double[] arr = new double[4];
            arr[0] = double.Parse(label12.Text.Split(' ')[1]);
            dataGridView17.Rows[0].Cells[2].Value = label12.Text.Split(' ')[1];
            dataGridView17.Rows[0].Cells[3].Value = label13.Text.Split(' ')[1];
            arr[1] = double.Parse(label15.Text.Split(' ')[1]);
            dataGridView17.Rows[1].Cells[2].Value = label15.Text.Split(' ')[1];
            dataGridView17.Rows[1].Cells[3].Value = label14.Text.Split(' ')[1];
            arr[2] = double.Parse(label17.Text.Split(' ')[1]);
            dataGridView17.Rows[2].Cells[2].Value = label17.Text.Split(' ')[1];
            dataGridView17.Rows[2].Cells[3].Value = label16.Text.Split(' ')[1];
            arr[3] = double.Parse(label19.Text.Split(' ')[1]);
            dataGridView17.Rows[3].Cells[2].Value = label19.Text.Split(' ')[1];
            dataGridView17.Rows[3].Cells[3].Value = label18.Text.Split(' ')[1];
            dataGridView17.Rows[4].Cells[2].Value = label25.Text.Split(' ')[1];
            dataGridView17.Rows[4].Cells[3].Value = label24.Text.Split(' ')[1];
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;
            for (int i = 0; i < 4; i++)
            {
                var first = double.Parse(dataGridView17.Rows[i].Cells[1].Value.ToString()) * double.Parse(dataGridView17.Rows[i].Cells[2].Value.ToString());
                var second = double.Parse(dataGridView17.Rows[i].Cells[1].Value.ToString()) * double.Parse(dataGridView17.Rows[i].Cells[3].Value.ToString());
                dataGridView17.Rows[i].Cells[4].Value = first.ToString();
                dataGridView17.Rows[i].Cells[5].Value = second.ToString();
                sum1 += double.Parse(dataGridView17.Rows[i].Cells[2].Value.ToString());
                sum2 += double.Parse(dataGridView17.Rows[i].Cells[3].Value.ToString());
                sum3 += first;
                sum4 += second;
            }
            dataGridView17.Rows[5].Cells[2].Value = (sum1 / 4).ToString("0.0000");
            dataGridView17.Rows[5].Cells[3].Value = (sum2 / 4).ToString("0.0000");
            dataGridView17.Rows[4].Cells[4].Value = (sum3 / 4).ToString("0.00");
            dataGridView17.Rows[4].Cells[5].Value = (sum4 / 4).ToString("0.0000");
            return arr;
        }
        private void Sort(double[] arr)
        {
            for(int i = 0; i < arr.Length-1;i++)
            {
                for(int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        var x = arr[j];
                        var y = fullList[j];
                        var z = sfullList[j];
                        arr[j] = arr[j + 1];
                        fullList[j] = fullList[j + 1];
                        sfullList[j] = sfullList[j + 1];
                        arr[j + 1] = x;
                        fullList[j + 1] = y;
                        sfullList[j + 1] = z;
                    }
                }
            }
        }
        private void CreateDV17()
        {
            string[] titles = "Експерт галузі;Експерт юзабіліті;Експерт з програмування;Потенційні користувачі;Усереднені оцінки (Xi)".Split(';');
            for (int i = 0; i < 5; i++)
            {
                dataGridView17.Rows.Add();
                dataGridView17.Rows[i].Cells[0].Value = titles[i];
            }
            dataGridView17.Rows.Add();
        }
        private void CalculateUZ()
        {
            DataGridView dv = dataGridView15;
            double d = double.Parse(dataGridView5.Rows[4].Cells[2].Value.ToString());
            dataGridView15.Columns[1].HeaderText = "Узагальнені значення";
            for (int i = 0; i < 10; i++)
            {
                dv.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[6].Value.ToString();
            }
            double sum = 0;
            for (int i = 0; i < dv.Rows.Count - 1; i++)
            {
                sum += double.Parse(dv.Rows[i].Cells[1].Value.ToString());
            }
            dv.Rows[10].Cells[1].Value = (sum).ToString("0.00");
            double secondSum = 0.0;
            for (int i = 0; i < dv.Rows.Count - 1; i++)
            {
                dv.Rows[i].Cells[2].Value = (double.Parse(dv.Rows[i].Cells[1].Value.ToString()) / sum * 360).ToString("0.00");
                secondSum += double.Parse(dv.Rows[i].Cells[2].Value.ToString());
            }
            dv.Rows[10].Cells[2].Value = secondSum.ToString("0.00");
            List<double> angles = new List<double>();
            angles.Add(-double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2);
            angles.Add(double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2);
            dv.Columns[3].HeaderText = (-double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2).ToString("0.00");
            dv.Rows[0].Cells[3].Value = (double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2).ToString("0.00");
            for (int i = 1; i < 10; i++)
            {
                angles.Add(double.Parse(dv.Rows[i].Cells[2].Value.ToString()) + double.Parse(dv.Rows[i - 1].Cells[3].Value.ToString()));
                dv.Rows[i].Cells[3].Value = (double.Parse(dv.Rows[i].Cells[2].Value.ToString()) + double.Parse(dv.Rows[i - 1].Cells[3].Value.ToString())).ToString("0.00");
            }
            dv.Rows[10].Cells[3].Value = (double.Parse(dv.Rows[9].Cells[3].Value.ToString()) - double.Parse(dv.Columns[3].HeaderText)).ToString("0.00");
            dv.Rows[0].Cells[4].Value = "0.00";
            dv.Rows[0].Cells[5].Value = "0.00";
            for (int i = 1; i < 10; i++)
            {
                dv.Rows[i].Cells[4].Value = ((double.Parse(dv.Rows[i].Cells[3].Value.ToString()) + double.Parse(dv.Rows[i - 1].Cells[3].Value.ToString())) / 2).ToString("0.00");
                dv.Rows[i].Cells[5].Value = (double.Parse(dv.Rows[i].Cells[4].Value.ToString()) / 180 * Math.PI).ToString("0.00");
            }
            List<double> a_array = new List<double>();
            List<double> b_array = new List<double>();
            double[] kx = { double.Parse(dataGridView6.Columns[1].HeaderText), double.Parse(dataGridView6.Columns[2].HeaderText), double.Parse(dataGridView6.Columns[3].HeaderText) , double.Parse(dataGridView6.Columns[4].HeaderText) }; 
            for(int i = 0; i < 10; i++)
            {
                double tmp_sum = 0;
                for(int j = 1; j < 5; j++)
                {
                    tmp_sum += double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) * double.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()) * kx[j-1];
                }
                dv.Rows[i].Cells[6].Value = (tmp_sum/d).ToString("0.00");
                var x = tmp_sum / d;
                var a = x * Math.Sin(double.Parse(dv.Rows[i].Cells[5].Value.ToString().Replace('.', ',')));
                var b = x * Math.Cos(double.Parse(dv.Rows[i].Cells[5].Value.ToString().Replace('.', ',')));
                dv.Rows[i].Cells[7].Value = (a).ToString("0.00");
                dv.Rows[i].Cells[8].Value = (b).ToString("0.00");
                a_array.Add(a);
                b_array.Add(b);
                dv.Rows[i].Cells[9].Value = (Math.Sqrt(a * a + b * b)).ToString("0.##");
            }
            dv.Rows[10].Cells[7].Value = dv.Rows[0].Cells[7].Value.ToString();
            dv.Rows[10].Cells[8].Value = dv.Rows[0].Cells[8].Value.ToString();
            double sum1 = 0.0;
            double sum2 = 0.0;
            double sum4 = 0.0;
            var second = dataGridView16;
            for (int i = 1; i < 11; i++)
            {
                var ai = double.Parse(dv.Rows[i].Cells[7].Value.ToString());
                var aim = double.Parse(dv.Rows[i - 1].Cells[7].Value.ToString());
                var bi = double.Parse(dv.Rows[i].Cells[8].Value.ToString());
                var bim = double.Parse(dv.Rows[i - 1].Cells[8].Value.ToString());
                second.Rows[i - 1].Cells[0].Value = (aim * bi).ToString("0.0");
                second.Rows[i - 1].Cells[1].Value = (bim * ai).ToString("0.0");
                second.Rows[i - 1].Cells[3].Value = Math.Abs(bim * ai - aim * bi).ToString("0.0");
                sum1 += aim * bi;
                sum2 += bim * ai;
                sum4 += Math.Abs(bim * ai - aim * bi);
            }
            second.Rows[10].Cells[0].Value = sum1.ToString("0.0");
            second.Rows[10].Cells[1].Value = sum2.ToString("0.0");
            second.Rows[10].Cells[2].Value = (Math.Abs(sum1 - sum2) / 2).ToString("0.00");
            second.Rows[10].Cells[3].Value = (sum4 / 2).ToString("0.0");
            label25.Text = "Sc" + " = " + (Math.Abs(sum1 - sum2) / 2).ToString("0.00") + "  ум. о.";
            label24.Text = "zc" + " = " + ((Math.Abs(sum1 - sum2) / 2) / (Math.PI * Math.Pow(100, 2))).ToString("0.0000");
            pictureBox1.Image = DrawPicture(a_array.ToArray(), b_array.ToArray(), angles.ToArray());
        }

        private void DV2()
        {
            string[] list = {"6;8;9;6;9;10;7;7;6;10;10;10;9;6;7;8;6;10;8;9;","6;8;6;5;8;6;9;7;7;10;10;10;9;10;6;7;5;10;6;5;","6;7;6;4;4;9;8;4;6;9;5;9;8;7;4;4;4;8;4;6;","6;8;7;8;8;9;10;10;6;7;7;8;9;8;6;6;6;10;6;9;","4;5;6;5;5;8;8;9;4;7;4;8;8;7;7;4;4;4;6;8;","6;6;10;6;7;9;8;10;6;10;10;8;6;9;6;6;8;10;6;10;","6;8;9;6;7;7;6;9;6;10;5;10;5;10;8;5;7;8;5;10;","6;4;6;4;5;6;8;7;5;6;5;5;4;7;4;4;6;9;6;4;","8;8;10;7;6;7;10;6;6;8;10;6;9;8;9;8;6;9;6;10;","3;4;6;3;3;3;6;5;5;7;5;5;3;5;3;4;4;3;5;4;"};
            for(int i = 0; i < list.Length; i++)
            {
                var index = dataGridView2.Rows.Add();
                var x = list[i].Split(';');
                dataGridView2.Rows[i].Cells[0].Value = criterias[i];
                for (int j = 0; j < x.Length - 1; j++)
                {
                    dataGridView2.Rows[index].Cells[j+1].Value = x[j];
                }
            }
            dataGridView2.Height = dataGridView2.RowTemplate.Height*(dataGridView2.RowCount+1)+5;
        }
        private void DV1()
        {
            string[] s = { "8;5;9;7","7;9;6;5","10;6;9;6","6;4;10;7","5;4;10;4","9;9;7;10","9;7;6;10","6;5;10;5","8;6;9;6","7;8;6;10"};
            for(int i = 0; i < s.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].Cells[0].Value = criterias[i];
                for (int j = 0; j < s[i].Split(';').Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j+1].Value = s[i].Split(';')[j];
                }
            }
            dataGridView1.Rows.Add();
            dataGridView1.Height = dataGridView1.RowTemplate.Height * (dataGridView1.RowCount+2);
            
        }
        private void DV3()
        {
            var val =new String[]{ "10;9;10", "9;8;8", "9;7;9", "6;5;8", "7;5;8", "9;7;7", "10;9;10", "6;8;7", "9;7;6", "6;5;9" };
            for(int i = 0; i < val.Length; i++)
            {
                dataGridView3.Rows.Add();
                var values = val[i].Split(';');
                dataGridView3.Rows[i].Cells[0].Value = criterias[i];
                for (int j=0;j<values.Length;j++)
                {
                    dataGridView3.Rows[i].Cells[j + 1].Value = values[j];
                }
            }
            dataGridView3.Rows.Add();
            dataGridView3.Height = dataGridView3.RowTemplate.Height * (dataGridView3.RowCount + 2) + 5;
            dataGridView4.Height=dataGridView3.Height;
            dataGridView4.Top = dataGridView3.Top + dataGridView3.Height + 5;
        }
        private void CalculateDV4()
        {
            dataGridView4.Rows.Clear();
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView4.Rows.Add();
                if(i!=dataGridView3.RowCount-1)dataGridView4.Rows[i].Cells[0].Value = criterias[i];
                for (int j = 1; j < dataGridView3.ColumnCount; j++)
                {
                    if (i == dataGridView3.RowCount - 1 && j != dataGridView3.ColumnCount - 1)
                        dataGridView4.Rows[i].Cells[j].Value = (double.Parse(dataGridView1.Rows[i].Cells[j == 5 ? 6 : j].Value.ToString()) / 10).ToString("0.00") + " / " + dataGridView3.Rows[i].Cells[j].Value.ToString();
                    else
                    dataGridView4.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j == 5?6:j].Value.ToString() + " / " + dataGridView3.Rows[i].Cells[j].Value.ToString();
                }
            }
        }
        private void CalculateDV5()
        {
            for (int j = 1; j < dataGridView5.ColumnCount; j++)
            {
                double sum = 0;
                for (int i = 0; i < dataGridView5.Rows.Count-1; i++)
                {
                    sum += double.Parse(dataGridView5.Rows[i].Cells[j].Value.ToString());
                }
                if (j == 1) dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[j].Value = ((int)(sum)).ToString();
                else dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[j].Value = ((sum)).ToString("0.00");
            }
        }
        private void DV5()
        {
            string[] val = {"Експерт галузі;7;0,7","Експерт юзабіліті;8;0,8","Експерт з програмування;9;0,9","Потенційні користувачі;5;0,5"};
            for(int i = 0; i < val.Length; i++)
            {
                dataGridView5.Rows.Add();
                var x = val[i].Split(';');
                for(int j = 0; j < 3; j++)
                {
                    dataGridView5.Rows[i].Cells[j].Value = x[j];
                }
            }
            dataGridView5.Rows.Add();
        }
        private void CalculateDV3()
        {
            for(int i = 0; i < dataGridView2.RowCount; i++)
            {
                double sum = 0;
                for (int j = 1; j < dataGridView2.ColumnCount; j++)
                {
                    sum += double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                }
                dataGridView3.Rows[i].Cells[4].Value = (sum / 20).ToString("0.00");
            }
            for(int i = 1; i < dataGridView3.Columns.Count - 1; i++)
            {
                double sum = 0;
                for (int j = 0; j < dataGridView3.RowCount-1; j++)
                {
                    sum += double.Parse(dataGridView3.Rows[j].Cells[i].Value.ToString());
                }
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[i].Value = (sum / 10).ToString("0.00");
            }
            for(int i = 0; i < dataGridView3.RowCount; i++)
            {
                double sum = 0;
                for (int j = 1; j < dataGridView3.ColumnCount - 1; j++)
                {
                    sum += double.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString());
                }
                dataGridView3.Rows[i].Cells[dataGridView3.ColumnCount - 1].Value = sum.ToString("0.00");
            }
        }
        private void CalculateDV1()
        {
               
            for (int i = 0; i < dataGridView1.Rows.Count-1;i++)
            {
                var sum = 0.0;
                for (int j = 1; j <= 4; j++) {
                    sum += int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                dataGridView1.Rows[i].Cells[5].Value = sum;
                dataGridView1.Rows[i].Cells[6].Value = (sum / 4).ToString("0.00");
            }
            for(int j = 1; j <= 6; j++)
            {
                if (j == 5) continue;
                double sum = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    sum += double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                if (j == 6) dataGridView1.Rows[10].Cells[j].Value = ((double)sum / 10).ToString("0.00");
                else dataGridView1.Rows[10].Cells[j].Value = (sum).ToString();
            }
        }

        private void CalculateDV(DataGridView dv, DataGridView source, DataGridView source1, int colnum,DataGridView second,Label label1,Label label2,PictureBox picture)
        {
            double d = double.Parse(dataGridView5.Rows[colnum-1].Cells[2].Value.ToString());
            dv.Columns[1].HeaderText = dataGridView1.Columns[colnum].HeaderText;
            for (int i = 0; i < 10; i++)
            {
                dv.Rows[i].Cells[1].Value = source.Rows[i].Cells[colnum].Value.ToString();
            }
            double sum = 0;
            for (int i = 0; i < dv.Rows.Count - 1; i++)
            {
                sum += int.Parse(dv.Rows[i].Cells[1].Value.ToString());
            }
            dv.Rows[10].Cells[1].Value = ((int)(sum)).ToString();
            double secondSum = 0.0;
            for(int i = 0; i < dv.Rows.Count - 1; i++)
            {
                dv.Rows[i].Cells[2].Value = (double.Parse(dv.Rows[i].Cells[1].Value.ToString()) / sum * 360).ToString("0.00");
                secondSum += double.Parse(dv.Rows[i].Cells[2].Value.ToString());
            }
            dv.Rows[10].Cells[2].Value = secondSum.ToString("0.00");
            List<double> angles = new List<double>();
            angles.Add(-double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2);
            angles.Add(double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2);
            dv.Columns[3].HeaderText = (-double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2).ToString();
            dv.Rows[0].Cells[3].Value = (double.Parse(dv.Rows[0].Cells[2].Value.ToString()) / 2).ToString();
            for(int i = 1; i < 10; i++)
            {
                angles.Add(double.Parse(dv.Rows[i].Cells[2].Value.ToString()) + double.Parse(dv.Rows[i - 1].Cells[3].Value.ToString()));
                dv.Rows[i].Cells[3].Value = (double.Parse(dv.Rows[i].Cells[2].Value.ToString()) + double.Parse(dv.Rows[i - 1].Cells[3].Value.ToString())).ToString("0.00");
            }
            dv.Rows[10].Cells[3].Value = (double.Parse(dv.Rows[9].Cells[3].Value.ToString()) - double.Parse(dv.Columns[3].HeaderText)).ToString("0.00");
            dv.Rows[0].Cells[4].Value = "0.00";
            dv.Rows[0].Cells[5].Value = "0.00";
            for (int i = 1; i < 10; i++)
            {
                dv.Rows[i].Cells[4].Value = ((double.Parse(dv.Rows[i].Cells[3].Value.ToString()) + double.Parse(dv.Rows[i - 1].Cells[3].Value.ToString()))/2).ToString("0.00");
                dv.Rows[i].Cells[5].Value = (double.Parse(dv.Rows[i].Cells[4].Value.ToString()) / 180 * Math.PI).ToString("0.00");
            }
            List<double> a_array = new List<double>();
            List<double> b_array = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                var x = double.Parse(source.Rows[i].Cells[colnum].Value.ToString()) * d * double.Parse(source1.Rows[i].Cells[colnum].Value.ToString());
                dv.Rows[i].Cells[6].Value = x.ToString("0.0");
                var a = x * Math.Sin(double.Parse(dv.Rows[i].Cells[5].Value.ToString().Replace('.', ',')));
                var b = x * Math.Cos(double.Parse(dv.Rows[i].Cells[5].Value.ToString().Replace('.', ',')));
                dv.Rows[i].Cells[7].Value = (a).ToString("0.0");
                dv.Rows[i].Cells[8].Value = (b).ToString("0.0");
                a_array.Add(a);
                b_array.Add(b);
                dv.Rows[i].Cells[9].Value = (Math.Sqrt(a*a+b*b)).ToString("0.###");
            }
            dv.Rows[10].Cells[7].Value = dv.Rows[0].Cells[7].Value.ToString();
            dv.Rows[10].Cells[8].Value = dv.Rows[0].Cells[8].Value.ToString();
            double sum1 = 0.0;
            double sum2 = 0.0;
            double sum4 = 0.0;
            for (int i = 1; i < 11; i++)
            {
                var ai = double.Parse(dv.Rows[i].Cells[7].Value.ToString());
                var aim = double.Parse(dv.Rows[i-1].Cells[7].Value.ToString());
                var bi = double.Parse(dv.Rows[i].Cells[8].Value.ToString());
                var bim = double.Parse(dv.Rows[i - 1].Cells[8].Value.ToString());
                second.Rows[i - 1].Cells[0].Value = (aim * bi).ToString("0.0");
                second.Rows[i - 1].Cells[1].Value = (bim * ai).ToString("0.0");
                second.Rows[i - 1].Cells[3].Value = Math.Abs(bim * ai- aim * bi).ToString("0.0");
                sum1 += aim * bi;
                sum2 += bim * ai;
                sum4 += Math.Abs(bim * ai - aim * bi);
            }
            second.Rows[10].Cells[0].Value = sum1.ToString("0.0");
            second.Rows[10].Cells[1].Value = sum2.ToString("0.0");
            second.Rows[10].Cells[2].Value = (Math.Abs(sum1-sum2)/2).ToString("0.00");
            second.Rows[10].Cells[3].Value = (sum4/2).ToString("0.0");
            //second.Rows[11].Cells[1].Value = (sum2 - sum1).ToString("0.0");
            label1.Text = "S" + (colnum).ToString() + " = " + (Math.Abs(sum1 - sum2) / 2).ToString("0.00")+" ум. о.";
            label2.Text = "z" + (colnum).ToString() + " = " + ((Math.Abs(sum1 - sum2) / 2)/(Math.PI*Math.Pow(100,2))).ToString("0.0000");
            picture.Image = DrawPicture(a_array.ToArray(), b_array.ToArray(),angles.ToArray());
        }
        private void Arrow(float x1, float y1, float x2, float y2, Graphics g)
        {
            Pen pen = new Pen(Color.Red);
            float d = (float)(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
            float X = (float)(x2 - x1);
            float Y = (float)(y2 - y1);
            float X3 = (float)(x2 - (X / d) * 7);
            float Y3 = (float)(y2 - (Y / d) * 7);
            float Xp = (float)(y2 - y1);
            float Yp = (float)(x1 - x2);
            float X4 = X3 + (Xp / d) * 2;
            float Y4 = Y3 + (Yp / d) * 2;
            float X5 = X3 - (Xp / d) * 2;
            float Y5 = Y3 - (Yp / d) * 2;
            g.DrawLine(pen,x1, y1, x2, y2);
            g.FillPolygon(new SolidBrush(Color.Red), new PointF[] { new PointF(x2, y2), new PointF(X4, Y4), new PointF(X5, Y5) });
        }
        List<List<PointF>> fullList = new List<List<PointF>>();
        List<PointF[]> sfullList = new List<PointF[]>();
        private Bitmap DrawPicture(double[] a,double[] b,double[] angles)
        {
            Bitmap btm = new Bitmap(330, 330);
            Graphics g = Graphics.FromImage(btm);
            float k = 1.5f;
            g.TranslateTransform(110 * k, 110 * k);
            g.FillRectangle(new SolidBrush(Color.White), k * -110, k * -110, 327, 327);
            g.DrawRectangle(new Pen(Color.Black), k * -110, k * -110, 327, 327);
            Pen p = new Pen(Color.Green);
            Brush brush = new SolidBrush(Color.Green);
            //прямі
            g.DrawLine(p, -110*k,0,110*k,0);
            g.DrawLine(p, 0,-110*k,0,110*k);
            g.FillPolygon(brush, new PointF[] { new PointF(0, -110 * k), new PointF(5, -110 * k + 5), new PointF(-5, -110 * k + 5) });
            g.FillPolygon(brush, new PointF[] { new PointF(110*k, 0), new PointF(110*k-5, 5), new PointF(110 * k - 5, -5) });
            //--прямі
            //круги
            g.DrawEllipse(new Pen(Color.Black, 2), -100 * k, -100 * k, 200 * k, 200 * k);
            g.FillEllipse(new SolidBrush(Color.LightCyan), -100 * k, -100 * k, 200 * k, 200 * k);
            for(int i = 1; i < 10; i++)
            {
                g.DrawEllipse(new Pen(Color.Cyan, 1), -100 * k+i*10*k, -100 * k + i * 10 * k, 200 * k- i * 20 * k, 200 * k - i * 20 * k);
            }
            //--круги
            List<PointF> points_N = new List<PointF>();
            for (int i = 0; i < a.Length; i++)
            {
                points_N.Add(new PointF((float)a[i]*k, (float)b[i]*k));
            }
            fullList.Add(points_N);
            g.RotateTransform(-90);
            g.DrawPolygon(new Pen(Color.Black,2), points_N.ToArray());
            g.FillPolygon(new SolidBrush(Color.FromArgb(125,Color.Yellow)), points_N.ToArray());
            List<double> len = new List<double>();
            for(int i = 0; i < a.Length; i++)
            {
                len.Add(Math.Sqrt(a[i]*k * a[i]*k + b[i]*k * b[i]*k));
            }
            for(int i = 0; i < angles.Length; i++)
            {
                g.RotateTransform((float)-angles[i]);
                g.DrawLine(new Pen(Color.Black), 0, 0, 0,100 * k);
                g.FillRectangle(new SolidBrush(Color.FromArgb(10,10+i+1,10)), 0, 100 * k, 2, 2);
                g.RotateTransform((float)angles[i]);
            }
            List<PointF> llpoints = new List<PointF>();
            for (int i = 0; i < angles.Length-1; i++)
            {
                g.RotateTransform((float)-(angles[i] + angles[i + 1]) / 2);
                g.DrawLine(new Pen(Color.Red), 0, 0, 0, (float)(len[i]+20));
                g.FillPolygon(new SolidBrush(Color.Red), new PointF[] { new PointF(0, (float)(len[i] + 20)), new PointF(5, (float)(len[i] + 15)), new PointF(-5, (float)(len[i] + 15)) });
                g.FillRectangle(new SolidBrush(Color.FromArgb(127,127 + i + 1, 127)), 0, (int)(len[i] + 21), 2, 2);
                g.RotateTransform((float)(angles[i] + angles[i + 1]) / 2);
            }
            g.RotateTransform(90);
            PointF[] array = new PointF[10];
            PointF[] array1 = new PointF[11];
            var gg = Graphics.FromImage(btm);
            for(int i = 0; i < 330; i++)
            {
                for(int j = 0; j < 330; j++)
                {
                    var tmp = btm.GetPixel(i, j);
                    if (tmp == null) continue;
                    for(int ki = 0; ki < 10; ki++)
                    {
                        if (tmp.G==128+ki)
                        {

                            if(tmp.R == 127 && tmp.B == 127)
                            {
                                array[ki] = new PointF(i, j);
                                break;
                            }
                        }
                        
                    }                   
                }
            }
            sfullList.Add(array);
            for (int i = 0; i < 330; i++)
            {
                for (int j = 0; j < 330; j++)
                {
                    var tmp = btm.GetPixel(i, j);
                    if (tmp == null) continue;
                    for (int ki = 0; ki <= 10; ki++)
                    {
                        if (tmp.G == 11 + ki)
                        {
                            if (tmp.R == 10 && tmp.B == 10)
                            {
                                array1[ki] = new PointF(i, j);
                                break;
                            }
                        }

                    }
                }
            }
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gg.DrawString((1).ToString(), new Font("arial", 8), new SolidBrush(Color.Black), array[0]);
            for (int i = 1; i < 10; i++)
            {
                gg.DrawString((i + 1).ToString(), new Font("arial",8), new SolidBrush(Color.Black), array[i]);
                gg.DrawLine(pen, array[i - 1], array[i]);
            }
            for(int i = 1; i <= 10; i++)
            {
                gg.DrawString(angles[i].ToString(), new Font("Times New Roman", 7), new SolidBrush(Color.Black), array1[i]);
            }
            gg.DrawLine(pen, array[0], array[9]);
            gg.TranslateTransform(110 * k, 110 * k);
            gg.DrawLine(p, -110 * k, 0, 110 * k, 0);
            gg.DrawLine(p, 0, -110 * k, 0, 110 * k);
            gg.FillPolygon(brush, new PointF[] { new PointF(0, -110 * k), new PointF(5, -110 * k + 5), new PointF(-5, -110 * k + 5) });
            gg.FillPolygon(brush, new PointF[] { new PointF(110 * k, 0), new PointF(110 * k - 5, 5), new PointF(110 * k - 5, -5) });

            return btm;
        }
        private void CreateDV(DataGridView dv, DataGridView dv1)
        {
            
            for(int i = 0; i < 10; i++)
            {
                dv.Rows.Add();
                dv1.Rows.Add();
                dv.Rows[i].Cells[0].Value = criterias[i];
                dv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            dv.Rows.Add();
            dv1.Rows.Add();
        }
        private void CalculateDV6()
        {
            double sum = 0.00;
            dataGridView6.Columns[1].HeaderText = double.Parse(dataGridView5.Rows[0].Cells[2].Value.ToString()).ToString("0.00");
            sum += double.Parse(dataGridView5.Rows[0].Cells[2].Value.ToString());
            dataGridView6.Columns[2].HeaderText = double.Parse(dataGridView5.Rows[1].Cells[2].Value.ToString()).ToString("0.00");
            sum += double.Parse(dataGridView5.Rows[1].Cells[2].Value.ToString());
            dataGridView6.Columns[3].HeaderText = double.Parse(dataGridView5.Rows[2].Cells[2].Value.ToString()).ToString("0.00");
            sum += double.Parse(dataGridView5.Rows[2].Cells[2].Value.ToString());
            dataGridView6.Columns[4].HeaderText = double.Parse(dataGridView5.Rows[3].Cells[2].Value.ToString()).ToString("0.00");
            sum += double.Parse(dataGridView5.Rows[3].Cells[2].Value.ToString());
            dataGridView6.Columns[5].HeaderText = (sum / 4).ToString("0.000");
            dataGridView6.Rows.Clear();
            dataGridView6plus.Rows.Clear();
            List<string> s = new List<string>(criterias);
            s.Add("Усереднені оцінки");
            s.Add("Оцінки з врахуванням вагомості експертів");
            for(int i = 0; i < s.Count; i++)
            {
                dataGridView6.Rows.Add();
                dataGridView6.Rows[i].Cells[0].Value = s[i];
                if (i < 10)
                {
                    dataGridView6.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    dataGridView6plus.Rows.Add();
                }
               
            }
            double[] summ = new double[4];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 1; j < 4; j++)
                {
                    dataGridView6.Rows[i].Cells[j].Value = (int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) * int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString())).ToString();
                    summ[j - 1] += (int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) * int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()));
                }
                dataGridView6.Rows[i].Cells[4].Value = (double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString())).ToString("0.00");
                summ[3] += (double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString()));
            }
            for(int i = 1; i < 5; i++)
            {
                dataGridView6.Rows[10].Cells[i].Value = (summ[i - 1] / double.Parse(dataGridView1.Rows[10].Cells[i].Value.ToString())).ToString("0.00");
            }
            for(int i = 1; i < 5; i++)
            {
                dataGridView6.Rows[11].Cells[i].Value = (double.Parse(dataGridView6.Rows[10].Cells[i].Value.ToString()) * double.Parse(dataGridView6.Columns[i].HeaderText)).ToString("0.00");
            }
            var zn = double.Parse(dataGridView5.Rows[4].Cells[2].Value.ToString());
            var fullSum = 0.0;
            for (int i = 0; i < 10; i++)
            {
                double summa = 0.0;
                for (int j = 1; j < 5; j++)
                {
                    summa += double.Parse(dataGridView6.Rows[i].Cells[j].Value.ToString()) * double.Parse(dataGridView6.Columns[j].HeaderText);
                }
                dataGridView6.Rows[i].Cells[5].Value = (summa / zn).ToString("0.00");
                fullSum += (summa / zn);
            }
            dataGridView6.Rows[10].Cells[5].Value = (fullSum/10/double.Parse(dataGridView1.Rows[10].Cells[6].Value.ToString())).ToString("0.00");
            fullSum = 0.0;
            for (int i = 0; i < 10; i++)
            {
                var tmp = double.Parse(dataGridView6.Rows[i].Cells[5].Value.ToString()) / double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                dataGridView6.Rows[i].Cells[6].Value = (tmp).ToString("0.00");
                fullSum += tmp;
            }
            dataGridView6.Rows[10].Cells[6].Value = (fullSum / 10).ToString("0.00");
            dataGridView6.Rows[11].Cells[5].Value = ((
                double.Parse(dataGridView6.Rows[10].Cells[1].Value.ToString()) + double.Parse(dataGridView6.Rows[10].Cells[2].Value.ToString()) + double.Parse(dataGridView6.Rows[10].Cells[3].Value.ToString()) + double.Parse(dataGridView6.Rows[10].Cells[4].Value.ToString())
            ) / 4).ToString("0.00");
            dataGridView6.Rows[11].Cells[6].Value = ((
                double.Parse(dataGridView6.Rows[11].Cells[1].Value.ToString()) + double.Parse(dataGridView6.Rows[11].Cells[2].Value.ToString()) + double.Parse(dataGridView6.Rows[11].Cells[3].Value.ToString()) + double.Parse(dataGridView6.Rows[11].Cells[4].Value.ToString())
            ) / zn).ToString("0.00");
            for(int i = 0; i < 10; i++) //row
            {
                var tmpsum = 0.0;
                for (int j = 1; j < 5; j++)
                {
                    tmpsum+=double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) * double.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()) * double.Parse(dataGridView6.Columns[j].HeaderText);
                }
                dataGridView6plus.Rows[i].Cells[0].Value = (tmpsum / zn).ToString("0.00");
            }
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0) return;
            string x = "";
            bool loop = false;
            while (!loop)
            {
                x = Interaction.InputBox("Введіть нове значення.", "Зміна значення");
                if (x.Equals("")) return;
                x = x.Replace('.', ',');
                if (!int.TryParse(x, out int val)) { MessageBox.Show("Невірно введено дані", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                if (val < 0 || val > 10) { MessageBox.Show("Недопустиме значення даної.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                loop = true;
            }
            ((DataGridView)(sender)).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = x;
            CalculateDV3();
            CalculateDV4();
            CalculateDV6();
            CalculateDV(dataGridView7, dataGridView1, dataGridView3, 1, dataGridView8, label12, label13, picture1);
            CalculateDV(dataGridView10, dataGridView1, dataGridView3, 2, dataGridView9, label15, label14, picture2);
            CalculateDV(dataGridView12, dataGridView1, dataGridView3, 3, dataGridView11, label17, label16, picture3);
            CalculateDV(dataGridView14, dataGridView1, dataGridView3, 4, dataGridView13, label19, label18, picture4);
            CalculateUZ();
            CalculateDV17();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex ==-1 && e.RowIndex==10) return;
            if (e.ColumnIndex <=0 || e.ColumnIndex>4) return;
            string x = "";
            bool loop = false;
            while (!loop)
            {
                x = Interaction.InputBox("Введіть нове значення.", "Зміна значення");
                if (x.Equals("")) return;
                x = x.Replace('.', ',');
                if (!int.TryParse(x, out int val)) { MessageBox.Show("Невірно введено дані", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                if (val < 0 || val > 10) { MessageBox.Show("Недопустиме значення даної.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                loop = true;
            }
            ((DataGridView)(sender)).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = x;
            CalculateDV1();
            CalculateDV4();
            CalculateDV6();
            CalculateDV(dataGridView7, dataGridView1, dataGridView3, 1, dataGridView8, label12, label13, picture1);
            CalculateDV(dataGridView10, dataGridView1, dataGridView3, 2, dataGridView9, label15, label14, picture2);
            CalculateDV(dataGridView12, dataGridView1, dataGridView3, 3, dataGridView11, label17, label16, picture3);
            CalculateDV(dataGridView14, dataGridView1, dataGridView3, 4, dataGridView13, label19, label18, picture4);
            CalculateUZ();
            CalculateDV17();

        }
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.RowIndex == 10) return;
            if (e.ColumnIndex <= 0 || e.ColumnIndex > 3) return;
            string x = "";
            bool loop = false;
            while (!loop)
            {
                x = Interaction.InputBox("Введіть нове значення.", "Зміна значення");
                if (x.Equals("")) return;
                x = x.Replace('.', ',');
                if (!int.TryParse(x, out int val)) { MessageBox.Show("Невірно введено дані", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                if (val < 0 || val > 10) { MessageBox.Show("Недопустиме значення даної.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                loop = true;
            }
            ((DataGridView)(sender)).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = x;
            CalculateDV3();
            CalculateDV4();
            CalculateDV6();
            CalculateDV(dataGridView7, dataGridView1, dataGridView3, 1, dataGridView8, label12, label13, picture1);
            CalculateDV(dataGridView10, dataGridView1, dataGridView3, 2, dataGridView9, label15, label14, picture2);
            CalculateDV(dataGridView12, dataGridView1, dataGridView3, 3, dataGridView11, label17, label16, picture3);
            CalculateDV(dataGridView14, dataGridView1, dataGridView3, 4, dataGridView13, label19, label18, picture4);
            CalculateUZ();
            CalculateDV17();
        }
        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 4 || e.RowIndex == -1) return;
            if (e.ColumnIndex == 0) return;
            string x = "";
            bool loop = false;
            while (!loop)
            {
                x = Interaction.InputBox("Введіть нове значення.", "Зміна значення");
                if (x.Equals("")) return;
                x = x.Replace('.', ',');
                if (e.ColumnIndex == 1)
                {
                    if (!int.TryParse(x, out int val)) { MessageBox.Show("Невірно введено дані", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                    if (val < 0 || val > 10) { MessageBox.Show("Недопустиме значення даної.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                    loop = true;
                    dataGridView5.Rows[e.RowIndex].Cells[1].Value = val.ToString();
                    dataGridView5.Rows[e.RowIndex].Cells[2].Value = ((double)val / 10).ToString("0.0");
                }
                else
                {
                    if (!double.TryParse(x, out double val)) { MessageBox.Show("Невірно введено дані", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                    if (val < 0 || val > 1) { MessageBox.Show("Недопустиме значення даної.", "Некоректний ввід", MessageBoxButtons.OK, MessageBoxIcon.Warning); continue; }
                    loop = true;
                    dataGridView5.Rows[e.RowIndex].Cells[1].Value = ((int)(val * 10)).ToString();
                    dataGridView5.Rows[e.RowIndex].Cells[2].Value = ((double)val).ToString("0.0");
                }
            }
            CalculateDV5();
            CalculateDV6();
            CalculateDV(dataGridView7, dataGridView1, dataGridView3, 1, dataGridView8, label12, label13, picture1);
            CalculateDV(dataGridView10, dataGridView1, dataGridView3, 2, dataGridView9, label15, label14, picture2);
            CalculateDV(dataGridView12, dataGridView1, dataGridView3, 3, dataGridView11, label17, label16, picture3);
            CalculateDV(dataGridView14, dataGridView1, dataGridView3, 4, dataGridView13, label19, label18, picture4);
            CalculateUZ();
            CalculateDV17();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                CalculateDV18();
            }
        }
        private void tabControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                CalculateDV18();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void picture3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }
    }
    
}
