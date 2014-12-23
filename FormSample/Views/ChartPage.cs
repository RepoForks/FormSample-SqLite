namespace FormSample
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using OxyPlot.XamarinForms;

    using Xamarin.Forms;

    public class ChartPage : ContentPage
    {
        public ChartPage()
        {
            // var layout= GenerateChart();
            // Content = layout;
            this.Content = this.GeneratePieChart();
        }

        public ScrollView GeneratePieChart()
        {
            var pieChart = new OxyPlotView()
                        {
                            Model = CreatePieChart(),
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalOptions = LayoutOptions.Fill,
                        };

            var pieChart2 = new OxyPlotView()
            {
                Model = CreatePieChart2(),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
            };
            var nameLayout = new ScrollView()
                                 {
                                     Content = new StackLayout()
                                                   {
                                                       // WidthRequest = 320,
                                                       Padding = new Thickness(0, 20, 0, 0),
                                                       HorizontalOptions = LayoutOptions.Start,
                                                       VerticalOptions = LayoutOptions.Fill,
                                                       Orientation = StackOrientation.Vertical,
                                                       Children = { pieChart, pieChart2 },
                                                       BackgroundColor = Color.Gray
                                                   },
                                 };

            return nameLayout;
        }

        private static PlotModel CreatePieChart()
        {
            var model = new PlotModel { Title = "World population by continent" };

            var ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Asia", 4157));
            ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            model.Series.Add(ps);
            return model;
        }

        private static PlotModel CreatePieChart2()
        {
            var model = new PlotModel { Title = "Cricket world cup" };

            var ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            ps.Slices.Add(new PieSlice("India", 1030) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Aus", 929) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Srilanka", 4157));
            ps.Slices.Add(new PieSlice("England", 739) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Pakistan", 35) { IsExploded = true });

            model.Series.Add(ps);
            return model;
        }
    }

    public class WeatherChartDemo : ContentPage
    {
        private DataModelNew dataModel;

        public WeatherChartDemo()
        {
            dataModel = new DataModelNew();
            this.SetData();

            //Initializing chart
            SfChart chart = new SfChart();
            chart.Title = new ChartTitle() { Text = "Weather Analysis" };

            //Initializing Primary Axis
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Title = new ChartAxisTitle() { Text = "Month" };

            chart.PrimaryAxis = primaryAxis;

            ////////Initializing Secondary Axis
            //NumericalAxis secondaryAxis = new NumericalAxis();
            //secondaryAxis.Title = new ChartAxisTitle() { Text = "Temperature" };

            //chart.SecondaryAxis = secondaryAxis;




            //Adding ColumnSeries to the chart for percipitation
            chart.Series.Add(new ColumnSeries()
            {
                ItemsSource = dataModel.column2,
                Label = "c1",
                YAxis = new NumericalAxis() { IsVisible = false },
                DataMarker = new ChartDataMarker() { ShowLabel = true }


            });


            //Adding the SplineSeries to the chart for high temperature
            chart.Series.Add(new ColumnSeries()
            {
                ItemsSource = dataModel.column3,
                Label = "c2",
                YAxis = new NumericalAxis()
                {
                    OpposedPosition = false,
                    ShowMajorGridLines = false
                },
                DataMarker = new ChartDataMarker() { ShowLabel = true }
            });

            ////Adding the SplineSeries to the chart for low temperature
            //chart.Series.Add(new SplineSeries()
            //{
            //    ItemsSource = dataModel.column3,
            //    Label = "Low"
            //});

            //Adding Chart Legend for the Chart
            chart.Legend = new ChartLegend() { IsVisible = true };

            this.Content = chart;
        }

        private void SetData()
        {
            var dataList = new List<SampleTable>();

            for (int i = 100; i <= 500; i += 50)
            {
                var w = 50;
                var g = i * 5;
                var npl = g - w;
                var npu = 12 * g - 15;

                dataList.Add(new SampleTable()
                {
                    c1 = i,
                    c2 = npl,
                    c3 = npu
                });


                dataModel.SetCol2Data(i.ToString(), npl);
                dataModel.SetCol3Data(i.ToString(), npu);
            }

        }
    }

    public class DataModelNew
    {
        public ObservableCollection<ChartDataPoint> column1;

        public ObservableCollection<ChartDataPoint> column2;

        public ObservableCollection<ChartDataPoint> column3;

        public DataModelNew()
        {
            //column1 = new ObservableCollection<ChartDataPoint>();

            //column1.Add(new ChartDataPoint("100", 100));
            //column1.Add(new ChartDataPoint("150", 150));
            //column1.Add(new ChartDataPoint("200", 200));
            //column1.Add(new ChartDataPoint("250", 250));


            column2 = new ObservableCollection<ChartDataPoint>();

            //column2.Add(new ChartDataPoint("100", 270));
            //column2.Add(new ChartDataPoint("150", 358));
            //column2.Add(new ChartDataPoint("200", 450));
            //column2.Add(new ChartDataPoint("250", 350));


            column3 = new ObservableCollection<ChartDataPoint>();

            //column3.Add(new ChartDataPoint("100", 50));
            //column3.Add(new ChartDataPoint("150", 100));
            //column3.Add(new ChartDataPoint("200", 900));
            //column3.Add(new ChartDataPoint("250", 1500));

        }

        public void SetCol1Data(string title, double value)
        {
            column1.Add(new ChartDataPoint(title, value));
        }

        public void SetCol2Data(string title, double value)
        {
            column2.Add(new ChartDataPoint(title, value));
        }
        public void SetCol3Data(string title, double value)
        {
            column3.Add(new ChartDataPoint(title, value));
        }
    }

    public class SampleTable
    {
        public double c1 { get; set; }
        public double c2 { get; set; }
        public double c3 { get; set; }
    }
}