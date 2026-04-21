#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONGenerator
{
    public class JSONGenerator
    {
        static Dictionary<string, DayDataDTO[]> DayData_Gen = new Dictionary<string, DayDataDTO[]>();

        static void LoadWeatherData()
        {
            #region Day Data
            var files = Directory.GetFiles("DataStore", @"*-Day.json");
            foreach (var file in files)
            {
                var city = Path.GetFileName(file);
                try
                {
                    using (StreamReader fileReader = File.OpenText(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        DayDataDTO[] weatherDataArray = (DayDataDTO[])serializer.Deserialize(fileReader, typeof(DayDataDTO[]));
                        DayData_Gen[city] = weatherDataArray;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            #endregion
        }
        
        internal static void GenerateExcel(string cityName)
        {
            if(DayData_Gen.Count == 0)
            LoadWeatherData();
            var dayFromData = DayData_Gen.
                FirstOrDefault(cn => cn.Key.Contains(cityName)).
                Value.FirstOrDefault(w => w.Datetime.Month == DateTime.Now.Month && w.Datetime.Day == DateTime.Now.Day);

            string[] headers = new string[] { "Condition", "Temperature_Min",
  "Temperature_Max",
  "Dew_Min",
  "Dew_Max",
  "Feelslike_Min",
  "Feelslike_Max",
  "Snow_Min",
  "Snow_Max",
  "Humidity_Min",
  "Humidity_Max",
  "Precip_Min",
  "Precip_Max",
  "PrecipProb_Min",
  "PrecipProb_Max",
  "Pressure_Min",
  "Pressure_Max",
  "UVIndex_Min",
  "UVIndex_Max",
  "Visibility_Min",
  "Visibility_Max",
  "WindSpeed_Min",
  "WindSpeed_Max",
  "WindDirection_Min",
  "WindDirection_Max",
  "Sunrise_Max",
  "Sunrise_Min",
  "Sunset_Max",
  "Sunset_Min",
  "Moonrise_Max",
  "Moonrise_Min",
  "Moonset_Max",
  "Moonset_Min" };

            var months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            for (int i = 0; i < 12; i++)
            {
                var monthwise_datas = DayData_Gen.FirstOrDefault(cn => cn.Key.Contains(cityName)).Value.Where(we => we.Datetime.Month == i+1).
                    Select(w => new { w.TempMax, w.TempMin, w.Conditions, w.Description, w.Dew, w.Feelslike, w.Snow, w.Sunset, w.Sunrise, w.Humidity, w.Moonrise, w.Moonset, w.Precip, w.Precipprob, w.Sealevelpressure, w.UVindex, w.Visibility, w.Windspeed, w.Winddir }).GroupBy(x => x.Conditions).ToDictionary(x => x.Key, x => x.ToList());
                string csvName = cityName + "_"+ months[i];

                using (var writer = new StreamWriter(csvName + ".csv"))
                {
                    foreach (string condition in GetWeatherConditionArray(monthwise_datas.Select(c => c.Key).ToList()).Distinct().ToList())
                    {
                        var conditionBased = monthwise_datas.SelectMany(c => c.Value).Where(co => co.Conditions.Contains(condition));
                        if (conditionBased.Any())
                        {
                            var min_Temp = conditionBased.Select(w => w.TempMin).Distinct().Min();
                            var max_Temp = conditionBased.Select(w => w.TempMax).Distinct().ToList().Max();

                            var min_dew = conditionBased.Select(w => w.Dew).Distinct().ToList().Min();
                            var max_dew = conditionBased.Select(w => w.Dew).Distinct().ToList().Max();

                            var min_feel = conditionBased.Select(w => w.Feelslike).Distinct().ToList().Min();
                            var max_feel = conditionBased.Select(w => w.Feelslike).Distinct().ToList().Max();

                            var min_snow = conditionBased.Select(w => w.Snow).Distinct().ToList().Min();
                            var max_snow = conditionBased.Select(w => w.Snow).Distinct().ToList().Max();

                            var min_humi = conditionBased.Select(w => w.Humidity).Distinct().ToList().Min();
                            var max_humi = conditionBased.Select(w => w.Humidity).Distinct().ToList().Max();

                            var min_prec = conditionBased.Select(w => w.Precip).Distinct().ToList().Min();
                            var max_prec = conditionBased.Select(w => w.Precip).Distinct().ToList().Max();

                            var min_precipprob = conditionBased.Select(w => w.Precipprob).Distinct().ToList().Min();
                            var max_precipprob = conditionBased.Select(w => w.Precipprob).Distinct().ToList().Max();

                            var min_pressure = conditionBased.Select(w => w.Sealevelpressure).Distinct().ToList().Min();
                            var max_pressure = conditionBased.Select(w => w.Sealevelpressure).Distinct().ToList().Max();

                            var min_uvindex = conditionBased.Select(w => w.UVindex).Distinct().ToList().Min();
                            var max_uvindex = conditionBased.Select(w => w.UVindex).Distinct().ToList().Max();

                            var min_visibility = conditionBased.Select(w => w.Visibility).Distinct().ToList().Min();
                            var max_visibility = conditionBased.Select(w => w.Visibility).Distinct().ToList().Max();

                            var min_windspeed = conditionBased.Select(w => w.Windspeed).Distinct().ToList().Min();
                            var max_windspeed = conditionBased.Select(w => w.Windspeed).Distinct().ToList().Max();

                            var min_winddir = conditionBased.Select(w => w.Winddir).Distinct().ToList().Min();
                            var max_winddir = conditionBased.Select(w => w.Winddir).Distinct().ToList().Max();

                            var description = conditionBased.Select(w => w.Description).Distinct().ToList();
                            var single_des = string.Join(",", description);

                            var sunRise_Min = conditionBased.Select(w => w.Sunrise.TimeOfDay).Distinct().ToList().Min();
                            var sunSet_Min = conditionBased.Select(w => w.Sunset.TimeOfDay).Distinct().ToList().Min();

                            var sunRise_Max = conditionBased.Select(w => w.Sunrise.TimeOfDay).Distinct().ToList().Max();
                            var sunSet_Max = conditionBased.Select(w => w.Sunset.TimeOfDay).Distinct().ToList().Max();

                            var moonRise_Min = conditionBased.Where(co => co.Moonrise != null && !string.IsNullOrEmpty(co.Moonrise.ToString()) && !string.IsNullOrWhiteSpace(co.Moonrise.ToString())).Select(w => DateTime.Parse(w.Moonrise.ToString()).TimeOfDay).Distinct().ToList().Min();
                            var moonSet_Min = conditionBased.Where(co => co.Moonset != null && !string.IsNullOrEmpty(co.Moonset.ToString()) && !string.IsNullOrWhiteSpace(co.Moonset.ToString())).Select(w => DateTime.Parse(w.Moonset.ToString()).TimeOfDay).Distinct().ToList().Min();

                            var moonRise_Max = conditionBased.Where(co => co.Moonrise != null && !string.IsNullOrEmpty(co.Moonrise.ToString()) && !string.IsNullOrWhiteSpace(co.Moonrise.ToString())).Select(w => DateTime.Parse(w.Moonrise.ToString()).TimeOfDay).Distinct().ToList().Max();
                            var moonSet_Max = conditionBased.Where(co => co.Moonset != null && !string.IsNullOrEmpty(co.Moonset.ToString()) && !string.IsNullOrWhiteSpace(co.Moonset.ToString())).Select(w => DateTime.Parse(w.Moonset.ToString()).TimeOfDay).Distinct().ToList().Max();
                            {
                                Console.SetOut(writer);
                                Console.WriteLine($"{condition}, {min_Temp}, {max_Temp},{min_dew},{max_dew},{min_feel},{max_feel},{min_snow},{max_snow},{min_humi},{max_humi},{min_prec},{max_prec},{min_precipprob},{max_precipprob},{min_pressure},{max_pressure},{min_uvindex}, {max_uvindex}, {min_visibility},{max_visibility},{min_windspeed},{max_windspeed},{min_winddir},{max_winddir}, {sunRise_Min},{sunRise_Max},{sunSet_Min},{sunSet_Max},{moonRise_Min},{moonRise_Max},{moonSet_Min},{moonSet_Max}");
                                //Console.WriteLine($"{condition}, {sunRise_Max},{sunRise_Min},{sunSet_Max},{sunSet_Min},{moonRise_Max},{moonRise_Min},{moonSet_Max},{moonSet_Min}");
                                //Console.WriteLine($"{condition},{moonRise_Max},{moonRise_Min},{moonSet_Max},{moonSet_Min}");
                            }

                        }
                        //return;
                    }
                }
            }

            // Path to the Excel file to be created
            string excelFilePath = cityName+".xlsx";
            string[] csvFilePath = new string[12] /*{ cityName+"_jan.csv", cityName + "_feb.csv", cityName + "_mar.csv", cityName + "_apr.csv", cityName + "_may.csv", cityName + "_jun.csv", cityName + "_jul.csv", cityName + "_Aug.csv", cityName + "_Sep.csv", cityName + "_Oct.csv", cityName + "_nov.csv", cityName + "_dec.csv" }*/;
            for (int i = 0; i < months.Count(); i++)
            {
                csvFilePath[i] = cityName + "_" + months[i] +".csv";
            }
            // Create a new Excel package
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                // Create a new worksheet
                foreach (var filePath in csvFilePath)
                {
                   
                    string monthHeader = filePath.Split('_').Last();
                    string trimmedString = monthHeader.Remove(3, monthHeader.Count() - 3);
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(trimmedString);

                    // Read the CSV file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        int row = 2;
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Split the line by comma to get the values
                            string[] values = line.Split(',');

                            // Write the values to the Excel worksheet
                            for (int col = 1; col <= values.Length; col++)
                            {
                                worksheet.Cells[1, col].Value = headers[col - 1];
                                worksheet.Cells[row, col].Value = values[col - 1];
                            }

                            row++;
                        }
                    }

                    // Save the Excel package to a file
                    FileInfo excelFile = new FileInfo(excelFilePath);
                    excelPackage.SaveAs(excelFile);
                }
            }
            GenerateJSON(excelFilePath, @"WeatherData-" + cityName + ".json");
        }

        public static void GenerateJSON(string excelFilePath, string jsonFilePath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Set the license context if using EPPlus free version
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                Dictionary<string, DataTable> sheetData = new Dictionary<string, DataTable>();

                // Read each sheet and add the data to Dictionary<SheetName, DataTable>
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    if (worksheet.Dimension == null)
                        continue; // Skip empty worksheets

                    DataTable dataTable;
                    if (!sheetData.TryGetValue(worksheet.Name, out dataTable))
                    {
                        dataTable = new DataTable();
                        sheetData.Add(worksheet.Name, dataTable);
                    }

                    for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        if (row == 1)
                        {
                            // Add columns based on the first row of each sheet
                            foreach (var firstRowCell in worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column])
                            {
                                string columnName = $"{firstRowCell.Text}";
                                if (!dataTable.Columns.Contains(columnName))
                                    dataTable.Columns.Add(columnName);
                            }
                        }
                        else
                        {
                            var newRow = dataTable.NewRow();
                            for (var col = 1; col <= worksheet.Dimension.End.Column; col++)
                            {
                                string columnName = $"{worksheet.Cells[1, col].Value}";
                                newRow[columnName] = worksheet.Cells[row, col].Value;
                            }
                            dataTable.Rows.Add(newRow);
                        }
                    }
                }

                // Convert Dictionary<SheetName, DataTable> to JSON
                string json = JsonConvert.SerializeObject(sheetData, Formatting.Indented);
                string currentDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory).Parent;
                string folderPath = Path.Combine(parentDirectory.FullName, "JSON Datas");
                
                if (!Directory.Exists(folderPath))
                {
                    // Create the folder
                    Directory.CreateDirectory(folderPath);
                }
                jsonFilePath = Path.Combine(folderPath, jsonFilePath);
                // Save the JSON to a file
                File.WriteAllText(jsonFilePath, json);
            }
        }

        static List<string> GetWeatherConditionArray(List<string> con_arr)
        {
            List<string> list_cond = new List<string>();
            foreach (var item in con_arr)
            {
                if (item.Contains(","))
                {
                    string[] words = item.Split(',');
                    foreach (string wor in words)
                    {
                        string trimmedWord = wor.Trim();
                        list_cond.Add(trimmedWord);
                    }
                }
                else
                    list_cond.Add(item);
            }

            return list_cond;
        }


    }

    public class DayDataDTO
    {
        public string Name { get; set; }
        public DateTime Datetime { get; set; }
        public float TempMax { get; set; }
        public float TempMin { get; set; }
        public float Temp { get; set; }
        public float Feelslike { get; set; }
        public float Dew { get; set; }
        public float Humidity { get; set; }
        public float Precip { get; set; }
        public float Precipprob { get; set; }
        public float Precipcover { get; set; }
        public object Preciptype { get; set; }
        public float Snow { get; set; }
        public float Snowdepth { get; set; }
        public float Windspeed { get; set; }
        public float Windspeedmax { get; set; }
        public float Windspeedmean { get; set; }
        public float Windspeedmin { get; set; }
        public float Winddir { get; set; }
        public float Sealevelpressure { get; set; }
        public float Visibility { get; set; }
        public float? UVindex { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public float MoonPhase { get; set; }
        public string Conditions { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public object Moonrise { get; set; }
        public object Moonset { get; set; }
        public float DayTemp { get; set; }
        public float NightTemp { get; set; }
    }
}
