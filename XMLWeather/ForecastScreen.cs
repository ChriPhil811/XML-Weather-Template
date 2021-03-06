﻿using System;
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
        //image for background
        Image background;

        //brushs for text boxes
        SolidBrush brush = new SolidBrush(Color.FromArgb(25, 25, 25));
        SolidBrush brush2 = new SolidBrush(Color.FromArgb(190, 190, 190));

        //list for weather icons
        List<Image> icons = new List<Image>();

        //variable for positioning the weather icons
        int imageY = 85;

        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            #region information printing

            //print info for day 1
            day1.Text = DateTime.Now.ToString("dddd");
            lowDay1.Text = Form1.days[0].tempLow;
            highDay1.Text = Form1.days[0].tempHigh;
            conditionDay1.Text = "(" + Form1.days[0].condition + ")";

            //print info for day 2
            day2.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            lowDay2.Text = Form1.days[1].tempLow;
            highDay2.Text = Form1.days[1].tempHigh;
            conditionDay2.Text = "(" + Form1.days[1].condition + ")";

            //print info for day 3
            day3.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();
            lowDay3.Text = Form1.days[2].tempLow;
            highDay3.Text = Form1.days[2].tempHigh;
            conditionDay3.Text = "(" + Form1.days[2].condition + ")";

            //print info for day 4
            day4.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();
            lowDay4.Text = Form1.days[3].tempLow;
            highDay4.Text = Form1.days[3].tempHigh;
            conditionDay4.Text = "(" + Form1.days[3].condition + ")";

            //print info for day 5
            day5.Text = DateTime.Now.AddDays(4).DayOfWeek.ToString();
            lowDay5.Text = Form1.days[4].tempLow;
            highDay5.Text = Form1.days[4].tempHigh;
            conditionDay5.Text = "(" + Form1.days[4].condition + ")";

            //print info for day 6
            day6.Text = DateTime.Now.AddDays(5).DayOfWeek.ToString();
            lowDay6.Text = Form1.days[5].tempLow;
            highDay6.Text = Form1.days[5].tempHigh;
            conditionDay6.Text = "(" + Form1.days[5].condition + ")";

            //print info for day 7
            day7.Text = DateTime.Now.AddDays(6).DayOfWeek.ToString();
            lowDay7.Text = Form1.days[6].tempLow;
            highDay7.Text = Form1.days[6].tempHigh;
            conditionDay7.Text = "(" + Form1.days[6].condition + ")";

            #endregion information printing

            #region icon and background drawing

            //for each day in the days list, create an image and set it to the appropriate weather icon for the day's condition.
            foreach (Day d in Form1.days)
            {
                Image image = Properties.Resources._01d;

                if (d.conditionIcon == "01d") { image = Properties.Resources._01d; }
                if (d.conditionIcon == "01n") { image = Properties.Resources._01n; }
                if (d.conditionIcon == "02d") { image = Properties.Resources._02d; }
                if (d.conditionIcon == "02n") { image = Properties.Resources._02n; }
                if (d.conditionIcon == "03d") { image = Properties.Resources._03d; }
                if (d.conditionIcon == "04d") { image = Properties.Resources._04d; }
                if (d.conditionIcon == "09d") { image = Properties.Resources._09d; }
                if (d.conditionIcon == "10d") { image = Properties.Resources._10d; }
                if (d.conditionIcon == "10n") { image = Properties.Resources._10n; }
                if (d.conditionIcon == "11d") { image = Properties.Resources._11d; }
                if (d.conditionIcon == "13d") { image = Properties.Resources._13d; }

                icons.Add(image);
            }

            string con = Form1.currentDay.conditionIcon;

            //change the background image based on time of day
            if (con == "01d" || con == "02d" || con == "03d" || con == "04d" || con == "09d" || con == "10d" || con == "11d" || con == "13d") 
            { 
                background = Properties.Resources.dayForcast; 
            }
            if (con == "01n" || con == "02n" || con == "03n" || con == "04n" || con == "09n" || con == "10n" || con == "11n" || con == "13n") 
            { 
                background = Properties.Resources.nightForcast; 
            }

            //refresh the screen graphics
            Refresh();

            #endregion icon and background drawing
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        #region paint method

        private void ForecastScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw the background
            e.Graphics.DrawImage(background, 0, 0);

            foreach (Image i in icons)
            {
                //draw the appropriate weather icon
                e.Graphics.DrawImage(i, 4, imageY); 

                //add 60 to the next image's y coordinate
                imageY += 60;
            }

            //reset imageY to 85
            imageY = 85;

            //today and forcast text boxes
            e.Graphics.FillRectangle(brush2, 5, 5, 110, 56);
            e.Graphics.FillRectangle(brush, 10, 10, 100, 46);
            e.Graphics.FillRectangle(brush2, 235, 5, 110, 56);
            e.Graphics.FillRectangle(brush, 240, 10, 100, 46);
        }

        #endregion paint method
    }
}
