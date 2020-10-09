using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        //create list to hold day objects
        public static List<Day> days = new List<Day>();

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                //create a day object
                Day day = new Day();

                //fill day object with required data
                reader.ReadToFollowing("time");
                day.date = reader.GetAttribute("day");

                reader.ReadToFollowing("temperature");
                day.tempLow = Math.Round(Convert.ToDouble(reader.GetAttribute("min")) + "°";
                day.tempHigh = reader.GetAttribute("max");

                //if day object not null add to the days list
                days.Add(day);
            }
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //find the city and add to currect day in the list
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            //find the current temp and round it, then add to currect day in the list
            reader.ReadToFollowing("temperature");
            days[0].currentTemp = Math.Round(Convert.ToDouble(reader.GetAttribute("value"))) + "°";

            //find the feels like temperature and round it, then add to currect day in the list
            reader.ReadToFollowing("feels_like");
            days[0].feelTemp = Math.Round(Convert.ToDouble(reader.GetAttribute("value"))) + "°";

            //find the low and high temp and round them, then add to currect day in the list
            days[0].tempLow = Math.Round(Convert.ToDouble(days[0].tempLow)) + "°";
            days[0].tempHigh = Math.Round(Convert.ToDouble(days[0].tempHigh)) + "°";

            //find the outdoor conditions and add to currect day in the list
            reader.ReadToFollowing("weather");
            days[0].condition = reader.GetAttribute("value");
        }
    }
}
