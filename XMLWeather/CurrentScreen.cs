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
    public partial class CurrentScreen : UserControl
    {
        //image for background
        Image background;

        //brush for bottom box
        SolidBrush brush = new SolidBrush(Color.FromArgb(25, 25, 25));

        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            #region information printing

            dateOutput.Text = DateTime.Now.ToString("dddd, MMMM M");
            conditionOutput.Text = Form1.days[0].condition;
            cityOutput.Text = Form1.days[0].location;
            feelsOutput.Text = "Feels Like " + Form1.days[0].feelTemp;
            tempLabel.Text = Form1.days[0].currentTemp;
            minOutput.Text = Form1.days[0].tempLow;
            maxOutput.Text = Form1.days[0].tempHigh;

            #endregion information printing

            #region background drawing

            string con = Form1.days[0].conditionIcon;

            //change the background image based on time of day and weather conditions
            if (con == "01d") { background = Properties.Resources.dayClear; }
            if (con == "01n") { background = Properties.Resources.nightClear; }
            if (con == "02d" || con == "03d") { background = Properties.Resources.dayCloudy; }
            if (con == "02n" || con == "03n") { background = Properties.Resources.nightCloudy; }
            if (con == "04d" || con == "04n") { background = Properties.Resources.veryCloudy; }
            if (con == "09d") { background = Properties.Resources.dayDrizzle; }
            if (con == "09n") { background = Properties.Resources.nightDrizzle; }
            if (con == "10d" || con == "10n") { background = Properties.Resources.rain; }
            if (con == "11d" || con == "11n") { background = Properties.Resources.thunderStorm; }
            if (con == "13d" || con == "13n") { background = Properties.Resources.snow; }

            #endregion background drawing
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        #region paint method

        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw the background
            e.Graphics.DrawImage(background, 0, 0);

            //draw the bottom box
            e.Graphics.FillRectangle(brush, 0, 435, 350, 65);
        }

        #endregion paint method
    }
}
