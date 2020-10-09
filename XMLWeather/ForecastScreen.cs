using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            //print info for day 1
            day1.Text = DateTime.Now.ToString("dddd");
            lowDay1.Text = Form1.days[0].tempLow;
            highDay1.Text = Form1.days[0].tempHigh;

            //print info for day 2
            day2.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            lowDay2.Text = Form1.days[1].tempLow;
            highDay2.Text = Form1.days[1].tempHigh;

            //print info for day 3
            day3.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();

            //print info for day 4
            day4.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();

            //print info for day 5
            day5.Text = DateTime.Now.AddDays(4).DayOfWeek.ToString();

            //print info for day 6
            day6.Text = DateTime.Now.AddDays(5).DayOfWeek.ToString();

            //print info for day 7
            day7.Text = DateTime.Now.AddDays(6).DayOfWeek.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
