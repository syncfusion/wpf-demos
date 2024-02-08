#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.weatheranalysis.wpf
{
    public class DataGenerator
    {
        public const string TEMP = "Temperature";
        public const string HUM = "Humidity";
        public const string DEW = "Dew";
        public const string FEELSLIKE = "Feelslike";
        public const string SNOWNAME = "Snow";
        public const string PRECIP = "Precip";
        public const string PRECIPPROB = "PrecipProb";
        public const string PRESSURE = "Pressure";
        public const string UVINDEX = "UVIndex";
        public const string VISIBILITY = "Visibility";
        public const string WINDDIR = "WindDirection";
        public const string WINDSPEED = "WindSpeed";
        public const string SUNSET = "Sunset";
        public const string SUNRISE = "Sunrise";
        public const string MOONSET = "Moonset";
        public const string MOONRISE = "Moonrise";

        private static readonly Random Random;

        static DataGenerator()
        {
            Random = new Random();
            CoordinatesData.Add("New York", new Tuple<double, double>(42.3601, -71.0589));
            CoordinatesData.Add("Los Angeles", new Tuple<double, double>(34.0522, 118.2437));
            CoordinatesData.Add("San Francisco", new Tuple<double, double>(37.7749, 122.4194));
            CoordinatesData.Add("Seattle", new Tuple<double, double>(47.6062, 122.3321));
            CoordinatesData.Add("Washington, D.C", new Tuple<double, double>(38.9072, 77.0369));
        }

        #region Load Weather Data

        private static readonly string[] Months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        private static Dictionary<string, Tuple<double, double>> CoordinatesData = new Dictionary<string, Tuple<double, double>>();

        public static List<DayDataDTO> GenerateWeatherData(string selectedCity)
        {
            List<DateTime> allDates = new List<DateTime>();
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                allDates.Add(date);
            }

            if (DateTime.Now.Month == 12) // Adding next year's Jan month to collection to avoid data shortage
            {
                int upcomingYear = DateTime.Now.AddYears(1).Year;
                startDate = new DateTime(upcomingYear, 1, 1);
                endDate = new DateTime(upcomingYear, 1, 31);
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    allDates.Add(date);
                }
            }

            List<DayDataDTO> dayDataCollection = new List<DayDataDTO>();
            for (int i = 0; i < allDates.Count; i++)
            {
                DayDataDTO dayDataDTO = new DayDataDTO();
                dayDataDTO.Datetime = allDates[i];
                string month = Months[allDates[i].Month - 1];
                int monthInt = allDates[i].Month;
                dayDataDTO.Name = selectedCity;
                dayDataDTO.Conditions = DataGenerator.GetWeather(month, selectedCity);
                dayDataDTO.Dew = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.DEW);
                dayDataDTO.Temp = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.TEMP);
                dayDataDTO.UVindex = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.UVINDEX);
                dayDataDTO.Windspeed = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.WINDSPEED);
                dayDataDTO.Precip = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.PRECIP);
                dayDataDTO.Feelslike = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.FEELSLIKE);
                dayDataDTO.Precipprob = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.PRECIPPROB);
                dayDataDTO.Snow = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.SNOWNAME);
                dayDataDTO.Visibility = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.VISIBILITY);
                dayDataDTO.Sealevelpressure = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.PRESSURE);
                dayDataDTO.Winddir = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.WINDDIR);
                dayDataDTO.Humidity = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.HUM);
                var tempMax = dayDataDTO.Temp + Random.Next(1, 5);
                var tempMin = dayDataDTO.Temp - Random.Next(1, 5);
                var dewMax = dayDataDTO.Dew + Random.Next(1, 5);
                var dewMin = dayDataDTO.Dew - Random.Next(1, 5);
                var uvIndexMax = dayDataDTO.UVindex + Random.Next(1, 5);
                var uvIndexMin = dayDataDTO.UVindex - Random.Next(1, 5);
                var windSpeedMax = dayDataDTO.Windspeed + Random.Next(1, 5);
                var windSpeedMin = dayDataDTO.Windspeed - Random.Next(1, 5);
                var pressureMax = dayDataDTO.Sealevelpressure + Random.Next(1, 5);
                var pressureMin = dayDataDTO.Sealevelpressure - Random.Next(1, 5);
                var humitidyMax = dayDataDTO.Humidity + Random.Next(1, 5);
                var humitidyMin = dayDataDTO.Humidity - Random.Next(1, 5);
                var feelsLikeMax = dayDataDTO.Feelslike + Random.Next(1, 5);
                var feelsLikeMin = dayDataDTO.Feelslike - Random.Next(1, 5);
                var visibilityMax = dayDataDTO.Visibility + Random.Next(1, 5);
                var visibilityMin = dayDataDTO.Visibility - Random.Next(1, 5);
                List<TimeSpan> hourOfDay = GenerateHourList();
                List<HourlyDTO> hoursArray = new List<HourlyDTO>();
                TimeSpan startOfDay = TimeSpan.Parse("06:00:00");
                TimeSpan endOfDay = TimeSpan.Parse("18:00:00");

                var tempList = SpreadHeatWave(tempMin, tempMax);
                var dewList = SpreadHeatWave(dewMin, dewMax);
                var uvindexList = SpreadHeatWave(uvIndexMin.Value, uvIndexMax.Value);
                var windspeedList = SpreadHeatWave(windSpeedMin, windSpeedMax);
                var pressureList = SpreadHeatWave(pressureMin, pressureMax);
                var humitidyList = SpreadHeatWave(humitidyMin, humitidyMax);
                var feelslikeList = SpreadHeatWave(feelsLikeMin, feelsLikeMax);
                var visibilityList = SpreadHeatWave(visibilityMin, visibilityMax);

                int iTemp = 0;
                foreach (var hourItem in hourOfDay)
                {
                    HourlyDTO hourDTO = new HourlyDTO();
                    hourDTO.Datetime = dayDataDTO.Datetime.Add(hourItem);
                    hourDTO.Conditions = DataGenerator.GetWeather(month, selectedCity);
                    hourDTO.Dew = dewList[iTemp];
                    hourDTO.Temp = tempList[iTemp];
                    hourDTO.UVindex = uvindexList[iTemp];
                    hourDTO.Windspeed = windspeedList[iTemp];
                    hourDTO.Pressure = pressureList[iTemp];
                    hourDTO.Humidity = humitidyList[iTemp];
                    hourDTO.Feelslike = feelslikeList[iTemp];
                    hourDTO.Visibility = visibilityList[iTemp];
                    hourDTO.Precip = DataGenerator.GetRandomValue(month, dayDataDTO.Conditions, selectedCity, DataGenerator.PRECIP);

                    if (hourDTO.Datetime.TimeOfDay >= startOfDay && hourDTO.Datetime.TimeOfDay <= endOfDay)
                    {
                        dayDataDTO.DayTemp = Math.Max(dayDataDTO.DayTemp, hourDTO.Temp);
                    }
                    else
                    {
                        dayDataDTO.NightTemp = Math.Max(dayDataDTO.NightTemp, hourDTO.Temp);
                    }

                    hoursArray.Add(hourDTO);
                    iTemp++;
                }

                dayDataDTO.TempMax = hoursArray.Select(ho => ho.Temp).Max();
                dayDataDTO.TempMin = hoursArray.Select(ho => ho.Temp).Min();
                dayDataDTO.HoulyDataCollection = hoursArray.ToArray();
                dayDataDTO.Sunrise = DataGenerator.GetRandomTime(month, dayDataDTO.Conditions, selectedCity, DataGenerator.SUNRISE, dayDataDTO.Datetime);
                dayDataDTO.Sunset = DataGenerator.GetRandomTime(month, dayDataDTO.Conditions, selectedCity, DataGenerator.SUNSET, dayDataDTO.Datetime);
                dayDataDTO.Moonrise = DataGenerator.GetRandomTime(month, dayDataDTO.Conditions, selectedCity, DataGenerator.MOONRISE, dayDataDTO.Datetime);
                dayDataDTO.Moonset = dayDataDTO.Moonrise.AddHours(Random.Next(8, 14)).AddMinutes(Random.Next(2, 55));

                // Calculate the moon phase
                dayDataDTO.MoonPhase = MoonPhaseCalculator.CalculateMoonPhase(dayDataDTO.Datetime, CoordinatesData[selectedCity].Item1, CoordinatesData[selectedCity].Item2);
                dayDataCollection.Add(dayDataDTO);
            }

            return dayDataCollection;
        }

        public static float[] SpreadHeatWave(float minHeat, float maxHeat)
        {
            int numberOfHours = 24; // Total number of hours in a day
            float[] heatLevels = new float[numberOfHours];

            // Calculate the amplitude of the sine wave based on the min and max heat values
            double amplitude = (maxHeat - minHeat) / 2;

            // Calculate the phase shift to ensure maximum heat occurs at 12 PM
            double phaseShift = Math.PI / 2;

            // Calculate the angular frequency
            double angularFrequency = 2 * Math.PI / numberOfHours;

            // Generate heat values for each hour of the day using a sine function with oscillation
            Random random = new Random();
            for (int hour = 0; hour < numberOfHours; hour++)
            {
                double heatLevel = minHeat + (amplitude * Math.Sin((angularFrequency * hour) - phaseShift));
                heatLevel += /*random.NextDouble() **/ (amplitude / 2); // Add randomness to introduce oscillation
                heatLevels[hour] = Convert.ToSingle(heatLevel);
            }

            return heatLevels;
        }

        public static string GetWeather(string month, string selectedCity)
        {
            string[] weather_Collection = DataStore.WeatherConditions[selectedCity][month].ToArray();
            int randomIndex = Random.Next(0, weather_Collection.Count() - 1);
            return weather_Collection[randomIndex];
        }

        internal static List<TimeSpan> GenerateHourList()
        {
            List<TimeSpan> hoursOfDay = new List<TimeSpan>();

            for (int hour = 0; hour < 24; hour++)
            {
                TimeSpan time = TimeSpan.FromHours(hour);
                hoursOfDay.Add(time);
            }

            return hoursOfDay;
        }

        public static DateTime GenerateTime(string min, string max, DateTime dateTime)
        {
            TimeSpan minTime = TimeSpan.Parse(min); // Minimum time
            TimeSpan maxTime = TimeSpan.Parse(max); // Maximum time

            TimeSpan randomTime = TimeSpan.FromTicks((long)(Random.NextDouble() * (maxTime - minTime).Ticks) + minTime.Ticks);

            DateTime randomDateTime = dateTime.Add(randomTime);

            return randomDateTime;
        }

        public static DateTime GetRandomTime(string month, string weather, string selectedCity, string required, DateTime dateTime)
        {
            var minMax = DataStore.CityData[selectedCity][month][weather][required];
            return GenerateTime(minMax.Item1, minMax.Item2, dateTime);
        }

        public static float GetRandomValue(string month, string weather, string selectedCity, string required)
        {
            var minMax = DataStore.CityData[selectedCity][month][weather][required];
            var min = minMax.Item1;
            var max = minMax.Item2;
            double range = double.Parse(max) - double.Parse(min);
            double sample = Random.NextDouble();
            double scaled = (sample * range) + double.Parse(min);
            float roundedValue = (float)Math.Round(scaled, 2);
            return roundedValue;
        }

        #endregion
    }
}
