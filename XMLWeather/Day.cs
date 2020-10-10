﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, currentTime, condition, conditionIcon, location, tempHigh, tempLow, feelTemp,
            windSpeed, windDirection, precipitation, visibility;

        public Day()
        {
            date = currentTemp = currentTime = condition = conditionIcon = location = tempHigh = tempLow = feelTemp
                = windSpeed = windDirection = precipitation = visibility = "";
        }
    }
}
