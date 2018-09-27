using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Grouping;
using System.Collections;
using System.Collections.ObjectModel;

namespace GroupingTutorial
{
    public class ViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Data> listOfSummaryType = new ObservableCollection<Data>();
        ObservableCollection<Data> listOfSummaryMapping = new ObservableCollection<Data>();
        public ViewModel()
        {
            Load();
            BindSummaryType();
            BindSummaryMapping();
        }

        private void BindSummaryType()
        {
            listOfSummaryType.Add(new Data { SummaryType = "A" });                 
            listOfSummaryType.Add(new Data { SummaryType = "B"});
            listOfSummaryType.Add(new Data { SummaryType = "C"});
            listOfSummaryType.Add(new Data { SummaryType = "D" });
        }
        private void BindSummaryMapping()
         {
             //set up the summary combobox with enums..(leaving out custom)
             for (int i = 0; i < 11; ++i)
                 listOfSummaryMapping.Add(new Data { SummaryMapping = ((SummaryType)i).ToString() }); 
             //this.summaryType.SelectedItem = "Count";
        }
        private void Load()
        {
            //Data dat = new Data();

            //this.summaryMappingName.ItemsSource = dat.BindSmmaryType();
            //create a new grouping engine and assign it a IList datasource
            engine = new Engine();
            engine.SetSourceList(CreateADataSource());
            engine.RecordAsDisplayElements = true;

            //get a reference to the underlying grouping Table
            theTable = engine.Table;

           
        }

        //called recursively
        public void CollapseGroup(Group aGroup)
        {
            foreach (Group g in aGroup.Groups)
            {
                CollapseGroup(g);
                g.IsExpanded = false;
            }
        }

        public void Show(string title, IList list)
        {
            SetTitleLine(title);
            string indent = "";
            string text = "";
            foreach (Element o in list)
            {
                int indents = (o is CaptionSection) ? o.GroupLevel : o.GroupLevel + 1;
                indent = new string(indentChar, indents * indentSize);

                if (o is Record)
                {
                    Record r = o as Record;
                    text += string.Format("       \t {0}", r.GetData()) + Environment.NewLine;

                }
                else
                    text += string.Format("{1}{0}", o, indent) + Environment.NewLine;
            }
            this.TextBox1 += text;

        }

        #region Data Creation
        public IList CreateADataSource()
        {
            //create a datasource - an arraylist of MyObject's
            Random r = new Random();
            ArrayList dataSource = new ArrayList();
            for (int i = 0; i < nItems; ++i)
            {
                dataSource.Add(new MyObject(r.Next(100)));
            }

            return dataSource;
        }
        #endregion


        ListSortDirection lsd = ListSortDirection.Descending;
        public ListSortDirection GetSortDirection()
        {
            if (lsd == ListSortDirection.Descending)
                lsd = ListSortDirection.Ascending;
            else
                lsd = ListSortDirection.Descending;
            return lsd;
        }

        public void SetTitleLine(string title)
        {
            TextBox1 += new string('-', 40) + title + Environment.NewLine;
        }

        ArrayList ops = new ArrayList(new char[] { '=', '>', '^', '<', '%', '~', '!', '-' });
        string[] swapFrom = new string[] { ">=", "<=", "like", "match", "<>" };
        string[] swapTo = new string[] { "^", "%", "~", "!", "-" };

        public bool ParseFilter(string inputString, out string name, out FilterCompareOperator op, out string compareValue)
        {
            name = "";
            op = FilterCompareOperator.Custom;
            compareValue = "";
            string s = inputString.ToLower();

            bool b = true;
            try
            {
                for (int i = 0; i < swapFrom.GetLength(0); ++i)
                    s = s.Replace(swapFrom[i], swapTo[i]);

                int locOp = s.IndexOfAny((char[])ops.ToArray(typeof(char)));
                name = inputString.Substring(0, locOp).Trim();
                op = (FilterCompareOperator)(ops.IndexOf(s[locOp]) + 1);
                int len = s.Length - locOp - 1;
                int start = inputString.Length - len;
                compareValue = inputString.Substring(start).Trim();
            }
            catch
            {
                b = false;
            }
            return b;

        }

        //the initial number of objects in the IList datasource
        private int nItems = 10;

        //used for display indentation
        private int indentSize = 8;
        private char indentChar = ' ';

        private string filterString="D like d0*";

        //grouping support objects 
        private Syncfusion.Grouping.Table theTable;
        private Syncfusion.Grouping.Engine engine;

        private string textBox1;
        private int itemCount;
        private int selectedIndex;
        private string mappingName;
        public string MappingName
        {
            get { return mappingName; }
            set
            {
                mappingName = value;
                OnPropertyChanged("MappingName");
            }
        }
        public string TextBox1
        {
            get { return textBox1; }
            set
            {
                textBox1 = value;
                OnPropertyChanged("TextBox1");
            }
        }

        public int SelectedIndexVal
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexVal");
            }
        }

        public int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value;
            OnPropertyChanged("ItemCount");
            }
        }
        public string FilterString
        {
            get { return filterString; }
            set { filterString = value;
            OnPropertyChanged("FilterString");
            }
        }

        public int NItems
        {
            get { return nItems; }
            set
            {
                nItems = value;
                OnPropertyChanged("NItems");
            }
        }

        public int IndentSize
        {
            get { return indentSize; }
            set
            {
                indentSize = value;
                OnPropertyChanged("IndentSize");
            }
        }

        public Syncfusion.Grouping.Table TheTable
        {
            get { return theTable; }
            set
            {
                theTable = value;
                OnPropertyChanged("TheTable");
            }
        }

        public Syncfusion.Grouping.Engine Engine
        {
            get { return engine; }
            set
            {
                engine = value;
                OnPropertyChanged("Engine");
            }
        }

        public ObservableCollection<Data> ListOfSummaryType
        {
            get
            {
                return listOfSummaryType;
            }
            set
            {
                listOfSummaryType = value;                
            }
        }

        public ObservableCollection<Data> ListOfSummaryMapping
        {
            get
            {
                return listOfSummaryMapping;
            }
            set
            {
                listOfSummaryMapping = value;               
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    #region custom Comparer class
    public class BComparer : IComparer
    {
        #region Implementation of IComparer
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;
            else
            {
                int sx = 0;
                int sy = 0;
                try
                {
                    sx = int.Parse(x.ToString().Substring(1));
                    sy = int.Parse(y.ToString().Substring(1));
                    return sy - sx;
                }
                catch
                {
                    throw new ArgumentException("B must be in the form 'bnnnn'");
                }


            }
        }

        #endregion
    }
    #endregion

    #region the object class
    public class MyObject
    {
        private string aValue;
        private string bValue;
        private string cValue;
        private string dValue;

        public MyObject(int i)
        {
            aValue = string.Format("a{0}", i);
            bValue = string.Format("b{0}", i);
            cValue = string.Format("c{0}", i % 3);
            dValue = string.Format("d{0}", i % 2);
        }

        public string A
        {
            get { return aValue; }
            set { aValue = value; }
        }
        public string B
        {
            get { return bValue; }
            set { bValue = value; }
        }
        public string C
        {
            get { return cValue; }
            set { cValue = value; }
        }
        public string D
        {
            get { return dValue; }
            set { dValue = value; }
        }

        public override string ToString()
        {
            return A + "\t" + B + "\t" + C + "\t" + D;
        }
    }
    #endregion
}
