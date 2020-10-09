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
            day1.Text = DateTime.Now.ToString("dddd");

            day2.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();

            day3.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();

            day4.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();

            day5.Text = DateTime.Now.AddDays(4).DayOfWeek.ToString();

            day6.Text = DateTime.Now.AddDays(5).DayOfWeek.ToString();

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
