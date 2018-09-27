using System.Windows.Interactivity;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using Syncfusion.Grouping;
using System;

namespace GroupingTutorial
{
    public class ButtonAction : TargetedTriggerAction<ChromelessWindow>
    {

        protected override void Invoke(object parameter)
        {

            switch (((parameter as System.Windows.RoutedEventArgs).Source as System.Windows.Controls.Button).Name)
            {
                case "button1":
                    ListSortDirection dir = (this.Target.DataContext as ViewModel).GetSortDirection();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.SortedColumns.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.SortedColumns.Add("B", dir);
                    (this.Target.DataContext as ViewModel).SetTitleLine("Sorted On B using default " + dir.ToString());
                    break;
                case "button2":
                    //listSortedOnBcomparer

                    (this.Target.DataContext as ViewModel).SetTitleLine("Sorted On B using custom Comparer");

                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.SortedColumns.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.SortedColumns.Add("B");
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.SortedColumns["B"].Comparer = new BComparer();
                    break;
                case "button3":
                    //groupByC
                    (this.Target.DataContext as ViewModel).SetTitleLine("GroupBy C");
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.GroupedColumns.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.GroupedColumns.Add("C", (this.Target.DataContext as ViewModel).GetSortDirection());
                    break;
                case "button4":
                    //groupByC
                    (this.Target.DataContext as ViewModel).SetTitleLine("GroupBy CD");

                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.GroupedColumns.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.GroupedColumns.Add("C", (this.Target.DataContext as ViewModel).GetSortDirection());
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.GroupedColumns.Add("D", (this.Target.DataContext as ViewModel).GetSortDirection());

                    // ShowGrouping();
                    break;
                case "button5":
                    //Filter
                    string s = (this.Target.DataContext as ViewModel).FilterString;
                    FilterCompareOperator op;
                    string name;
                    string compareValue;
                    if ((this.Target.DataContext as ViewModel).ParseFilter(s, out name, out op, out compareValue))
                    {
                        (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.RecordFilters.Clear();
                        (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.RecordFilters.Add(name, op, compareValue);
                        (this.Target.DataContext as ViewModel).SetTitleLine("Filter by: " + name + " " + op.ToString() + " " + compareValue.ToString());
                    }
                    break;
                case "button6":
                    string mappingName = (this.Target.DataContext as ViewModel).MappingName;
                    string name1 = mappingName;
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.Summaries.Add(name1, mappingName, (SummaryType)((this.Target.DataContext as ViewModel).SelectedIndexVal));
                    break;
                case "button7":
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.Summaries.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.GroupedColumns.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.SortedColumns.Clear();
                    (this.Target.DataContext as ViewModel).TheTable.TableDescriptor.RecordFilters.Clear();
                    break;
                case "button8":
                    (this.Target.DataContext as ViewModel).TextBox1 = string.Empty;
                    break;
                case "button9":
                    //rawList

                    (this.Target.DataContext as ViewModel).SetTitleLine("Raw List");

                    //A.commented code shows particular property
                    //PropertyDescriptorCollection pdc = theTable.GetItemProperties();
                    //PropertyDescriptor pd = pdc["B"];

                    int i = 0;
                    foreach (Record r in (this.Target.DataContext as ViewModel).TheTable.UnsortedRecords)
                    {
                        //this.textBox1.Text += string.Format("[{0}]  \t {1}", i, r.GetData()) + Environment.NewLine;
                        (this.Target.DataContext as ViewModel).TextBox1 += string.Format("       \t {1}", i, r.GetData()) + Environment.NewLine;

                        //B.commented code shows particular property
                        //this.textBox1.Text += pd.GetValue(r.Data).ToString() + Environment.NewLine;
                        ++i;
                    }

                    break;
                case "button10":
                    (this.Target.DataContext as ViewModel).NItems = (int)(this.Target.DataContext as ViewModel).ItemCount;
                    (this.Target.DataContext as ViewModel).Engine.SetSourceList((this.Target.DataContext as ViewModel).CreateADataSource());
                    (this.Target.DataContext as ViewModel).TheTable = (this.Target.DataContext as ViewModel).Engine.Table;
                    break;
                case "button11":
                    (this.Target.DataContext as ViewModel).Show("DisplayElements", (this.Target.DataContext as ViewModel).TheTable.DisplayElements);
                    break;
                case "button12":
                    (this.Target.DataContext as ViewModel).Show("Elements", (this.Target.DataContext as ViewModel).TheTable.Elements);
                    break;
                case "button13":
                    (this.Target.DataContext as ViewModel).Show("FilteredRecords", (this.Target.DataContext as ViewModel).TheTable.FilteredRecords);
                    break;
                case "button14":
                    (this.Target.DataContext as ViewModel).Show("SortedRecords", (this.Target.DataContext as ViewModel).TheTable.Records);
                    break;
                case "button15":
                    (this.Target.DataContext as ViewModel).TheTable.ExpandAllGroups();
                    (this.Target.DataContext as ViewModel).SetTitleLine("ExpandAllGroups");
                    break;
                case "button16":
                    (this.Target.DataContext as ViewModel).CollapseGroup((this.Target.DataContext as ViewModel).TheTable.TopLevelGroup);
                    (this.Target.DataContext as ViewModel).SetTitleLine("CollapseAllGroups");
                    break;
            }
        }
    }
}
