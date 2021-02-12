using System;
using System.IO;
using static System.IO.Path;
using static System.Environment;
using static Mobile_Service_Distribution.LibraryManager;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace Mobile_Service_Distribution.Forms
{
    public partial class StatsForm : Form
    {
        private static string statsFileURL = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Stats Record.txt");
        private string[] statsFile = File.ReadAllLines(statsFileURL);
        public int moviesSent = 0, musicSent = 0, seriesSent = 0, cartsSent = 0;
        private int numYears = DateTime.Now.Year, minYear;
        private Axis xAxis;
        private double currentDTMinValue, currentDTMaxValue;
        private long minValue, maxValue, MINVALUE, MAXVALUE;
        private string yearCombo, monthCombo;
        public class DateModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }
            public int MoSent { get; set; }
            public int MuSent { get; set; }
            public int SeSent { get; set; }
            public double Price { get; set; }
        }

        public LineSeries priceSeries;
        public ColumnSeries cartSeries;

        public StatsForm()
        {
            InitializeComponent();

            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
                .Y(dayModel => dayModel.Value);

            priceSeries = new LineSeries
            {
                ScalesYAt = 1,
                Values = new ChartValues<DateModel>(),
                Title = "Revenue",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };
            cartSeries = new ColumnSeries
            {
                ScalesYAt = 0,
                Values = new ChartValues<DateModel>(),
                Title = "Cart Size",
                MaxColumnWidth = 8,
                Fill = System.Windows.Media.Brushes.DodgerBlue
            };
            xAxis = new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("dd MMM"),
                MaxRange = DateTime.MaxValue.Subtract(TimeSpan.FromDays(146400)).Year,
                MinValue = DateTime.Now.Subtract(TimeSpan.FromDays(4)).Ticks / TimeSpan.TicksPerDay,
                MaxValue = DateTime.Now.AddDays(3).Ticks / TimeSpan.TicksPerDay
            };

            currentDTMinValue = xAxis.MinValue;
            currentDTMaxValue = xAxis.MaxValue;
            minValue = DateTime.Now.Subtract(TimeSpan.FromDays(4)).Ticks;
            maxValue = DateTime.Now.AddDays(3).Ticks;
            MINVALUE = minValue;
            MAXVALUE = maxValue;

            summaryChart.Series = new SeriesCollection(dayConfig);
            summaryChart.LegendLocation = LegendLocation.Bottom;
            summaryChart.Pan = PanningOptions.X;

            summaryChart.AxisX.Add(xAxis);
            summaryChart.AxisY.Add(new Axis
            {
                MinValue = 0,
                Foreground = cartSeries.Fill,
                LabelFormatter = value => value + " GB"
            });
            summaryChart.AxisY.Add(new Axis
            {
                Position = AxisPosition.LeftBottom,
                Foreground = priceSeries.Stroke,
                LabelFormatter = value => value + " ETB",
                MinValue = 0,
                Separator = new Separator { StrokeThickness = 0 }
            });
            
            for(int i = 0; i < statsFile.Length - 1; i += 7)
            {
                DateTime date = DateTime.Parse(statsFile.ElementAt(i).Substring(11));
                double price = double.Parse(statsFile.ElementAt(i + 5).Substring(14));

                if (numYears > date.Year)
                    numYears = date.Year;

                cartSeries.Values.Add(new DateModel
                {
                    DateTime = date,
                    Value = double.Parse(statsFile.ElementAt(i + 1).Substring(6)),
                    MoSent = int.Parse(statsFile.ElementAt(i + 2).Substring(11)),
                    MuSent = int.Parse(statsFile.ElementAt(i + 3).Substring(11)),
                    SeSent = int.Parse(statsFile.ElementAt(i + 4).Substring(12)),
                    Price = price
                }) ;

                priceSeries.Values.Add(new DateModel
                {
                    DateTime = date,
                    Value = price,
                }) ;

                moviesSent += int.Parse(statsFile.ElementAt(i + 2).Substring(11));
                musicSent += int.Parse(statsFile.ElementAt(i + 3).Substring(11));
                seriesSent += int.Parse(statsFile.ElementAt(i + 4).Substring(12));
                cartsSent++;
            }

            minYear = numYears;
            
            summaryChart.Series.Add(cartSeries);
            summaryChart.Series.Add(priceSeries);
            
            summaryPieChart.LegendLocation = LegendLocation.Right;
            summaryPieChart.Size = new Size(175, 125);
            summaryPieChart.Location = new Point(17, 50);
            
            summaryPieChart.Series.Add(new PieSeries
            {
                Values = new ChartValues<int> { moviesSent },
                Title = "Movies Sent"
            });
            summaryPieChart.Series.Add(new PieSeries
            {
                Values = new ChartValues<int> { musicSent},
                Title = "Music Sent"
            });
            summaryPieChart.Series.Add(new PieSeries
            {
                Values = new ChartValues<int> { seriesSent },
                Title = "Series Sent"
            });

            mediaAmountChart.LegendLocation = LegendLocation.Bottom;
            mediaAmountChart.AxisX.Add(new Axis
            {
                Labels = new[] { " " },
                Separator = new Separator{ StrokeThickness = 0 }
            });

            mediaSentExt.Text = (moviesSent + musicSent + seriesSent).ToString();
            cartSentExt.Text = cartsSent.ToString();
            panel1.Refresh();
            GC.Collect();

            while (numYears <= DateTime.Now.Year)
                yearComboBox.Items.Add(numYears++);

            yearCombo = DateTime.Now.Year.ToString();
            yearComboBox.Text = yearCombo;
            monthCombo = monthComboBox.Text;
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            DateModel values = (DateModel)chartPoint.Instance;
            cartMoviesExt.Text = values.MoSent.ToString();
            cartMusicExt.Text = values.MuSent.ToString();
            cartSeriesExt.Text = values.SeSent.ToString();
            cartDateExt.Text = values.DateTime.ToString("MMM dd H:mm tt");
            cartPaidExt.Text = $"{values.Price} ETB";
        }

        private void nxtButton_Click(object sender, EventArgs e)
        {
            DateTime zoomMinDate = new DateTime(minValue);
            DateTime zoomMaxDate = new DateTime(maxValue);

            if (zoomMaxDate.Day - zoomMinDate.Day < 6)
            {
                xAxis.MinValue += TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue += TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;
            }
            else
            {
                xAxis.MinValue += TimeSpan.FromDays(4).Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue += TimeSpan.FromDays(3).Ticks / TimeSpan.TicksPerDay;
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            DateTime zoomMinDate = new DateTime(minValue);
            DateTime zoomMaxDate = new DateTime(maxValue);

            if (zoomMaxDate.Day - zoomMinDate.Day < 6)
            {
                xAxis.MinValue -= TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue -= TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;
            }
            else
            {
                xAxis.MinValue -= TimeSpan.FromDays(4).Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue -= TimeSpan.FromDays(3).Ticks / TimeSpan.TicksPerDay;
            }
        }

        private void resetChartButton_Click(object sender, EventArgs e)
        {
            xAxis.MinValue = currentDTMinValue;
            xAxis.MaxValue = currentDTMaxValue;

            minValue = MINVALUE;
            maxValue = MAXVALUE;
        }

        private void zoomInButton1_Click(object sender, EventArgs e)
        {
            DateTime zoomMinDate = new DateTime(minValue);
            DateTime zoomMaxDate = new DateTime(maxValue);

            if (zoomMaxDate.Ticks - zoomMinDate.Ticks > 2500000000000)
            {
                xAxis.MinValue += TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue -= TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;

                minValue += TimeSpan.FromDays(1).Ticks;
                maxValue -= TimeSpan.FromDays(1).Ticks;
            }
        }

        private void zoomOutButton1_Click(object sender, EventArgs e)
        {
            xAxis.MinValue -= TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;
            xAxis.MaxValue += TimeSpan.FromDays(1).Ticks / TimeSpan.TicksPerDay;

            minValue -= TimeSpan.FromDays(1).Ticks;
            maxValue += TimeSpan.FromDays(1).Ticks;
        }

        private void yearComboBox_TextChanged(object sender, EventArgs e)
        {
            DateTime changedYear;
            int intYear;

            if (yearComboBox.Text != "")
                intYear = int.Parse(yearComboBox.Text);
            else
                intYear = 0;

            if (intYear >= minYear && intYear <= DateTime.Now.Year)
            {
                if (monthComboBox.Text == "January")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 1, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "February")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 2, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "March")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 3, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "April")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 4, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "May")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 5, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "June")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 6, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "July")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 7, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "August")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 8, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "September")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 9, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "October")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 10, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "November")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 11, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if (monthComboBox.Text == "December")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), 12, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
                else if(monthComboBox.Text == "Pick a month")
                {
                    changedYear = new DateTime(int.Parse(yearComboBox.Text), DateTime.Now.Month, 1);

                    xAxis.MinValue = changedYear.Ticks / TimeSpan.TicksPerDay;
                    xAxis.MaxValue = changedYear.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                    minValue = changedYear.Ticks;
                    maxValue = changedYear.AddDays(30).Ticks;

                    yearCombo = yearComboBox.Text;
                }
            }
            else
            {
                if (yearCombo != yearComboBox.Text && yearComboBox.Text.Length > 3)
                    yearComboBox.Text = yearCombo;
            }
        }

        private void monthComboBox_TextChanged(object sender, EventArgs e)
        {
            DateTime changedMonth;

            if (monthComboBox.Text == "January")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 1, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "February")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 2, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "March")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 3, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "April")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 4, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "May")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 5, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "June")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 6, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "July")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 7, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "August")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 8, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "September")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 9, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "October")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 10, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "November")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 11, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else if (monthComboBox.Text == "December")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 12, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;

                minValue = changedMonth.Ticks;
                maxValue = changedMonth.AddDays(30).Ticks;

                monthCombo = monthComboBox.Text;
            }
            else
            {
                if(monthCombo != monthComboBox.Text)
                    monthComboBox.Text = monthCombo;
            }
        }
    }
}
