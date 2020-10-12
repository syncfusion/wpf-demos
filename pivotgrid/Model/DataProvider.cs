#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.ComponentModel;

    public static class DataProvider<T> where T : new()
    {
        static readonly Random r = new Random(12312);

        public static ObservableCollection<T> GetData()
        {
            string fileName = "";
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries"))
            {
                fileName = System.IO.Path.GetFullPath(@"..\..\pivotgrid\Data\pivotgrid\data.csv");
            }
            else
            {
                fileName = System.IO.Path.GetFullPath(@"..\..\..\pivotgrid\Data\pivotgrid\data.csv");
            }
            List<string> lines = new List<string>();

            using (StreamReader reader = File.OpenText(fileName))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            var dataSource = new ObservableCollection<T>();
            SetFileData(lines, dataSource);
            return dataSource;
        }


        private static void SetFileData(List<string> lines, ObservableCollection<T> dataSource)
        {
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 1; i < lines.Count;
                ++i)
            {
                string[] cols = lines[i].Split(new char[] { ',' });
                T bo = new T();
                int k = 0;

                foreach (PropertyDescriptor pd in pdc)
                {
                    if (pd.Name == "PID_CLR_SIZ")
                    {
                        continue; //skip this on as it is a composite column
                    }
                    if (!pd.Name.StartsWith("Test")) //skip added test fields that are not in the data
                        ProcessLine(bo, cols[k++], pd);
                    else if (bo is BO)
                    {

                        switch (pd.Name)
                        {
                            case "TestInt":
                                pd.SetValue(bo, (bo as BO).Color);
                                break;
                            case "TestStr":
                                pd.SetValue(bo, "S" + (bo as BO).Color);
                                break;
                            case "TestDouble":
                                // Console.WriteLine(1d + r.NextDouble() / 5d);
                                pd.SetValue(bo, 1d + r.NextDouble() / 5d);
                                //  pd.SetValue(bo,(double) ((bo as BO).Color) );
                                break;
                            case "TestSortA":
                                // Console.WriteLine(1d + r.NextDouble() / 5d);
                                pd.SetValue(bo, r.Next(2));
                                //  pd.SetValue(bo,(double) ((bo as BO).Color) );
                                break;
                            case "TestSortB":
                                // Console.WriteLine(1d + r.NextDouble() / 5d);
                                pd.SetValue(bo, r.Next(3));
                                //  pd.SetValue(bo,(double) ((bo as BO).Color) );
                                break;
                            case "TestSortC":
                                // Console.WriteLine(1d + r.NextDouble() / 5d);
                                pd.SetValue(bo, r.Next(4));
                                //  pd.SetValue(bo,(double) ((bo as BO).Color) );
                                break;
                        }
                    }
                }
                dataSource.Add(bo);
            }
        }

        private static void ProcessLine(T bo, string val, PropertyDescriptor pd)
        {

            if (pd.PropertyType == typeof(int))
            {
                if (val == string.Empty)
                {
                    //don't set it
                }
                else
                {
                    pd.SetValue(bo, int.Parse(val));
                }
            }
            else if (pd.PropertyType == typeof(double))
            {
                if (val.TrimEnd().EndsWith("%"))
                {
                    pd.SetValue(bo, double.Parse(val.Replace("%", "")) / 100d);
                }
                else if (val != string.Empty)
                {
                    pd.SetValue(bo, double.Parse(val));
                }
            }
            else if (pd.PropertyType == typeof(DateTime))
            {
                pd.SetValue(bo, DateTime.Parse(val));
            }
            else
            {
                pd.SetValue(bo, val);
            }
        }
    }
}
