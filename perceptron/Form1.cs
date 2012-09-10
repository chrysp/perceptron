using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Text.RegularExpressions;

namespace perceptron
{
    public partial class Form1 : Form
    {
        private Series class1, class2, boundary;
        private double w1, w2, wbias;
        int bias = 1;
        bool dataFromBoxes = true, displayEachIteration = true;

        public Form1()
        {
            InitializeComponent();
            InitializeChartSeries();
        }

        private void InitializeChartSeries()
        {
            class1 = chart1.Series.Add("Class 1");
            class1.ChartType = SeriesChartType.Point;
            //class1.MarkerSize = 10;

            class2 = chart1.Series.Add("Class 2");
            class2.ChartType = SeriesChartType.Point;
            //class2.MarkerSize = 10;

            boundary = chart1.Series.Add("Decision Boundary");
            boundary.ChartType = SeriesChartType.Line;
        }

        private void DrawBoundaryLine(double xmin, double xmax)
        {
            boundary.Points.Clear();

            boundary.Points.Add(new DataPoint(xmin, ((w1 / -w2) * xmin) + (wbias / -w2)));
            boundary.Points.Add(new DataPoint(xmax, ((w1 / -w2) * xmax) + (wbias / -w2)));

            if (displayEachIteration)
                chart1.Update();
        }

        private void AddPointsFromBoxes()
        {
            double tempDoubleX = 0, tempDoubleY = 0;

            class1.Points.Clear();
            class2.Points.Clear();

            //class1
            //point 1
            if ((textBox1.Text == "" && textBox2.Text != "") || (textBox1.Text != "" && textBox2.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (!double.TryParse(textBox1.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox1.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox2.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox2.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class1.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 2
            if ((textBox3.Text == "" && textBox4.Text != "") || (textBox3.Text != "" && textBox4.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                if (!double.TryParse(textBox3.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox3.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox4.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox4.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class1.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 3
            if ((textBox5.Text == "" && textBox6.Text != "") || (textBox5.Text != "" && textBox6.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                if (!double.TryParse(textBox5.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox5.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox6.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox6.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class1.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 4
            if ((textBox7.Text == "" && textBox8.Text != "") || (textBox7.Text != "" && textBox8.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                if (!double.TryParse(textBox7.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox7.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox8.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox8.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class1.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 5
            if ((textBox9.Text == "" && textBox10.Text != "") || (textBox9.Text != "" && textBox10.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox9.Text != "" && textBox10.Text != "")
            {
                if (!double.TryParse(textBox9.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox9.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox10.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox10.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class1.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }


            //class2
            //point 1
            if ((textBox11.Text == "" && textBox12.Text != "") || (textBox11.Text != "" && textBox12.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox11.Text != "" && textBox12.Text != "")
            {
                if (!double.TryParse(textBox11.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox11.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox12.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox12.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class2.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 2
            if ((textBox13.Text == "" && textBox14.Text != "") || (textBox13.Text != "" && textBox14.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox13.Text != "" && textBox14.Text != "")
            {
                if (!double.TryParse(textBox13.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox13.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox14.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox14.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class2.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 3
            if ((textBox15.Text == "" && textBox16.Text != "") || (textBox15.Text != "" && textBox16.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox15.Text != "" && textBox16.Text != "")
            {
                if (!double.TryParse(textBox15.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox15.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox16.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox16.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class2.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 4
            if ((textBox17.Text == "" && textBox18.Text != "") || (textBox17.Text != "" && textBox18.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox17.Text != "" && textBox18.Text != "")
            {
                if (!double.TryParse(textBox17.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox17.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox18.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox18.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class2.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }

            //point 5
            if ((textBox19.Text == "" && textBox20.Text != "") || (textBox19.Text != "" && textBox20.Text == ""))
            {
                MessageBox.Show("You must include both the X and Y values for each data point you enter.");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }
            if (textBox19.Text != "" && textBox20.Text != "")
            {
                if (!double.TryParse(textBox19.Text, out tempDoubleX))
                {
                    MessageBox.Show("The input of \"" + textBox19.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                if (!double.TryParse(textBox20.Text, out tempDoubleY))
                {
                    MessageBox.Show("The input of \"" + textBox20.Text + "\" is not recognized");
                    class1.Points.Clear();
                    class2.Points.Clear();
                    return;
                }
                class2.Points.Add(new DataPoint(tempDoubleX, tempDoubleY));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataFromBoxes == true)
                AddPointsFromBoxes();

            //Set chart axis sizes
            double xmin, xmax, c1, c2;
            c1 = class1.Points.FindMinByValue().YValues.First();
            c2 = class2.Points.FindMinByValue().YValues.First();
            xmin = Math.Min(c1, c2);
            xmin -= 6;
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            c1 = class1.Points.FindMaxByValue().YValues.First();
            c2 = class2.Points.FindMaxByValue().YValues.First();
            xmax = Math.Max(c1, c2);
            xmax += 6;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;

            //train
            //variables
            double alpha; //learningRate
            if (!double.TryParse(textBox21.Text, out alpha))
            {
                MessageBox.Show("The input of \"" + textBox21.Text + "\" is not valid input for the Learning Rate");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }

            int maxIterations;
            if (!int.TryParse(textBox22.Text, out maxIterations))
            {
                MessageBox.Show("The input of \"" + textBox22.Text + "\" is not valid input for Max Iterations");
                class1.Points.Clear();
                class2.Points.Clear();
                return;
            }

            bool misclassified = false;
            int i = 0, iteration = 0;
            int numberOfPoints = class1.Points.Count + class2.Points.Count;

            //create and initialize two-dimensional array of X and Y point values for all points of both classes
            double[,] p = new double[numberOfPoints, 2];
            for (int j = 0; j < class1.Points.Count; j++)
            {
                p[j, 0] = class1.Points.ElementAt(j).XValue;
                p[j, 1] = class1.Points.ElementAt(j).YValues.First();
            }
            for (int j = class1.Points.Count; j < numberOfPoints; j++)
            {
                p[j, 0] = class2.Points.ElementAt(j - class1.Points.Count).XValue;
                p[j, 1] = class2.Points.ElementAt(j - class1.Points.Count).YValues.First();
            }

            double summation;
            int calculatedClass;
            int correctClass;

            //create and initialize weights
            Random rn = new Random();
            w1 = rn.Next(-100, 101);
            w2 = rn.Next(-100, 101);
            wbias = rn.Next(-100, 101);

            //training loop
            do
            {
                misclassified = false;
                i = 0;
                while (i < numberOfPoints)
                {
                    if (i < class1.Points.Count)
                        correctClass = 1;
                    else
                        correctClass = -1;

                    summation = w1 * p[i, 0] + w2 * p[i, 1] + wbias * bias;

                    if (summation > 0)
                        calculatedClass = 1;
                    else
                        calculatedClass = -1;

                    if (calculatedClass != correctClass)
                    {
                        w1 = w1 + alpha * (correctClass - calculatedClass) * p[i, 0];
                        w2 = w2 + alpha * (correctClass - calculatedClass) * p[i, 1];
                        wbias = wbias + alpha * (correctClass - calculatedClass) * bias;
                        misclassified = true;
                    }
                    i++;
                }
                if (displayEachIteration)
                    Thread.Sleep(50);
                DrawBoundaryLine(xmin, xmax);
                iteration++;
            }
            while (misclassified && (iteration <= maxIterations));

            label22.Text = (iteration - 1).ToString();

            if (misclassified)
                label23.Text = "NO";
            else
                label23.Text = "YES";

            StringBuilder db, lg;
            db = new StringBuilder(w1.ToString());
            db.Append(" x1 + ");
            db.Append(w2.ToString());
            db.Append(" x2 + ");
            db.Append(wbias.ToString());
            db.Append(" = 0");
            label26.Text = db.ToString();

            lg = new StringBuilder("x2 = (");
            lg.Append(w1.ToString());
            lg.Append(" / ");
            lg.Append((-w2).ToString());
            lg.Append(") x1 + (");
            lg.Append(wbias.ToString());
            lg.Append(" / ");
            lg.Append((-w2).ToString());
            lg.Append(")");
            label27.Text = lg.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            class1.Points.Clear();
            class2.Points.Clear();

            DialogResult result = openFileDialog1.ShowDialog();
            string input = "";
            double x, y, c;

            if (result == DialogResult.Cancel)
                return;

            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    input = System.IO.File.ReadAllText(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The file could not be opened. /n/n" + ex.Message);
                }
            }

            Regex re = new Regex("[ ]|[\n]|[\t]+");
            string[] data = re.Split(input);


            for (int i = 0; i < data.Length; i += 3)
            {
                x = double.Parse(data[i]);
                y = double.Parse(data[i + 1]);
                c = double.Parse(data[i + 2]);

                if (c == 1)
                    class1.Points.Add(new DataPoint(x, y));
                if (c == 2)
                    class2.Points.Add(new DataPoint(x, y));
            }

            dataFromBoxes = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            displayEachIteration = !displayEachIteration;
        }
    }
}
