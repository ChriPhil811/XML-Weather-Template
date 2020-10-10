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
        Image background = Properties.Resources.dayClear;

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

            //TODO draw the background image based on time of day and weather conditions

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
            e.Graphics.DrawImage(background, 0, 0);
        }

        #endregion paint method
    }
}
