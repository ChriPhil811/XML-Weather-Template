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

        //brushs for text boxes
        SolidBrush brush = new SolidBrush(Color.FromArgb(25, 25, 25));
        SolidBrush brush2 = new SolidBrush(Color.FromArgb(190, 190, 190));

        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            #region information printing

            dateOutput.Text = DateTime.Now.ToString("dddd, MMMM M");
            conditionOutput.Text = Form1.currentDay.condition;
            cityOutput.Text = Form1.currentDay.location;
            feelsOutput.Text = "Feels Like " + Form1.currentDay.feelTemp;
            tempLabel.Text = Form1.currentDay.currentTemp;
            minOutput.Text = Form1.days[0].tempLow;
            maxOutput.Text = Form1.days[0].tempHigh;

            #endregion information printing

            #region background drawing (and text color)

            string con = Form1.currentDay.conditionIcon;

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

            #endregion background drawing (and text color)
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

            //draw text boxes
            e.Graphics.FillRectangle(brush, 0, 435, 350, 65);

            //today and forcast text boxes
            e.Graphics.FillRectangle(brush2, 5, 5, 110, 56);
            e.Graphics.FillRectangle(brush, 10, 10, 100, 46);
            e.Graphics.FillRectangle(brush2, 235, 5, 110, 56);
            e.Graphics.FillRectangle(brush, 240, 10, 100, 46);

            //city text boxes
            e.Graphics.FillRectangle(brush2, 110, 102, 130, 46);
            e.Graphics.FillRectangle(brush, 115, 107, 120, 36);
        }

        #endregion paint method
    }
}
