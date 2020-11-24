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
        private int numYears = DateTime.Now.Year;
        private Axis xAxis;
        private double currentDTMinValue, currentDTMaxValue;
        private long minValue, maxValue;
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
                Title = "Revenue"
            };
            cartSeries = new ColumnSeries
            {
                ScalesYAt = 0,
                Values = new ChartValues<DateModel>(),
                Title = "Cart Size",
                MaxColumnWidth = 8
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

            summaryChart.Series = new SeriesCollection(dayConfig);
            summaryChart.LegendLocation = LegendLocation.Bottom;
            summaryChart.Pan = PanningOptions.X;

            summaryChart.AxisX.Add(xAxis);
            summaryChart.AxisY.Add(new Axis
            {
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.Blue,
                LabelFormatter = value => value + " GB"
            });
            summaryChart.AxisY.Add(new Axis
            {
                Position = AxisPosition.LeftBottom,
                Foreground = System.Windows.Media.Brushes.Red,
                LabelFormatter = value => value + " ETB",
                MinValue = 0,
                Separator = new Separator { StrokeThickness = 0 }
            }) ;
            

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

            mediaAmountChart.Series.Add(new ColumnSeries
            {
                Title = "Movies",
                Values = new ChartValues<int> { movieCatalogue.Count }
            });

            mediaAmountChart.Series.Add(new ColumnSeries
            {
                Title = "Music",
                Values = new ChartValues<int> { musicCatalogue.Count }
            });

            mediaAmountChart.Series.Add(new ColumnSeries {
                Title = "Series",
                Values = new ChartValues<int> { seriesCatalogue.Count }
            });

            mediaSentLabel.Text = "Total No of Media Sent  " + (moviesSent + musicSent + seriesSent);
            cartSentLabel.Text = "Carts Sent  " + cartsSent;
            panel1.Refresh();
            GC.Collect();

            while (numYears <= DateTime.Now.Year)
                yearComboBox.Items.Add(numYears++);

            yearComboBox.Text = DateTime.Now.Year.ToString();
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
        }

        private void zoomInButton1_Click(object sender, EventArgs e)
        {
            DateTime zoomMinDate = new DateTime(minValue);
            DateTime zoomMaxDate = new DateTime(maxValue);


            if (zoomMaxDate.Day - zoomMinDate.Day > 2)
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

        private void monthComboBox_TextChanged(object sender, EventArgs e)
        {
            DateTime changedMonth;

            if (monthComboBox.Text == "January")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 1, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "February")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 2, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "March")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 3, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "April")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 4, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "May")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 5, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "June")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 6, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "July")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 7, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "August")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 8, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "September")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 9, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "October")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 10, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "November")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 11, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
            else if (monthComboBox.Text == "December")
            {
                changedMonth = new DateTime(int.Parse(yearComboBox.Text), 12, 1);

                xAxis.MinValue = changedMonth.Ticks / TimeSpan.TicksPerDay;
                xAxis.MaxValue = changedMonth.AddDays(30).Ticks / TimeSpan.TicksPerDay;
            }
        }
    }
}
