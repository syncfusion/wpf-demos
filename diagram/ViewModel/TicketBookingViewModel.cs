using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Input;
using Application = System.Windows.Application;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class TicketBookingViewModel : INotifyPropertyChanged
    {

        #region Properties
        public ObservableCollection<SectionViewModel> Sections { get; } = new ObservableCollection<SectionViewModel>();
        public ObservableCollection<ShowTimeViewModel> ShowTimes { get; } = new ObservableCollection<ShowTimeViewModel>();
        public ObservableCollection<NodeViewModel> DiagramNodes { get; } = new ObservableCollection<NodeViewModel>();
        public ObservableCollection<ConnectorViewModel> DiagramConnectors { get; } = new ObservableCollection<ConnectorViewModel>();

        public DemoControl View;

        private ShowTimeViewModel _selectedShowTime;
        public ShowTimeViewModel SelectedShowTime
        {
            get => _selectedShowTime;
            set
            {
                if (_selectedShowTime != null) _selectedShowTime.IsSelected = false;
                _selectedShowTime = value;
                if (_selectedShowTime != null) _selectedShowTime.IsSelected = true;
                OnPropertyChanged();
                LoadSeatsForShowTime();
            }
        }

        public string MovieTitle => "F1: The Movie";
        public string ShowDate => $"{DateTime.Now:dddd, d MMM, hh:mm tt}  |  Velvet Aurora Cinematheque";
        public ICommand ProceedCommand { get; }
        #endregion

        private static readonly Dictionary<string, HashSet<string>> BookedSeatsByTiming =
            new Dictionary<string, HashSet<string>>
            {
                ["11:50 AM"] = new HashSet<string>
                {
                    "A8","A9","A10","A11",
                    "B8","B9","B10","B11",
                    "C8","C9","C10","C11",
                    "D7","D8","D9","D10","D11","D12",
                    "E7","E8","E9","E10",
                    "F6","F7","F8","F9","F10","F11","F12",
                    "G5","G6","G7","G8","G9","G10","G11",
                    "H5","H6","H7","H8","H9",
                    "I7","I8","I9","I10",
                    "J7","J8","J9","J10",
                    "K6","K7","K8","K9","K10","K11","K12",
                    "L5","L6","L7","L8","L9","L10",
                    "M4","M5","M6","M7","M8",
                    "N6","N7","N8","N9","N10",
                    "O6","O7","O8","O9","O10",
                    "P6","P7","P8","P9","P10"
                },
                ["02:25 PM"] = new HashSet<string>(),
                ["06:20 PM"] = new HashSet<string>
                {
                    "A1","A2","A3","A4","A5","A6","A7","A8","A9","A10","A11","A12",
                    "B1","B2","B3","B4","B5","B6","B7","B8","B9","B10","B11",
                    "C1","C2","C3","C4","C5","C6","C7","C8","C17",
                    "D1","D2","D3","D7","D8","D9","D10","D11","D12","D13","D14",
                    "E1","E2","E3","E4","E7","E8","E9","E10","E11","E12","E13",
                    "F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12","F13","F14","F15",
                    "G5","G7","G9","G12",
                    "H5",
                    "I1","I7","I8","I9","I10","I11",
                    "J7","J8","J9","J10","J11","J12",
                    "K6","K7","K8","K9","K10","K11","K12","K13",
                    "L5","L6","L7","L8","L9","L10","L11",
                    "M4","M5","M6","M7","M8","M9","M10","M11",
                    "N1","N2","N3","N4","N5","N6","N7","N8","N9","N10","N11",
                    "O1","O2","O3","O4","O5","O6","O7","O8","O9","O10",
                    "P1","P2","P3","P4","P5","P6","P7","P8","P9","P10","P11","P15"
                },
                ["09:15 PM"] = new HashSet<string>
                {
                    "A1","A2","B1","B2","C1","D1","E1","F1",
                    "G1","H1","I1","J1","K1","L1","M1","N1","O1","P1"
                }
            };

        public TicketBookingViewModel()
        {
            InitializeShowTimes();
            ProceedCommand = new RelayCommand(_ => Proceed(), _ => SelectedCount > 0);
            SelectedShowTime = ShowTimes.FirstOrDefault(st => st.Time == "11:50 AM");
        }

        #region Helper methods

        private void InitializeShowTimes()
        {
            ShowTimes.Add(new ShowTimeViewModel
            {
                Time = "11:50 AM",
                Format = "4K DOLBY ATMOS",
                IsAvailable = true,
                Status = "available",
                SelectShowCommand = new RelayCommand(_ => SelectedShowTime = ShowTimes[0])
            });
            ShowTimes.Add(new ShowTimeViewModel
            {
                Time = "02:25 PM",
                Format = "4K DOLBY ATMOS",
                IsAvailable = false,
                Status = "sold-out",
                SelectShowCommand = new RelayCommand(_ => { })
            });
            ShowTimes.Add(new ShowTimeViewModel
            {
                Time = "06:20 PM",
                Format = "4K DOLBY ATMOS",
                IsAvailable = true,
                Status = "filling-fast",
                SelectShowCommand = new RelayCommand(_ => SelectedShowTime = ShowTimes[2])
            });
            ShowTimes.Add(new ShowTimeViewModel
            {
                Time = "09:15 PM",
                Format = "4K DOLBY ATMOS",
                IsAvailable = true,
                Status = "available",
                SelectShowCommand = new RelayCommand(_ => SelectedShowTime = ShowTimes[3])
            });
        }

        private void LoadSeatsForShowTime()
        {
            if (SelectedShowTime == null) return;

            foreach (var seat in GetAllSeats())
                seat.PropertyChanged -= Seat_PropertyChanged;

            Sections.Clear();
            DiagramNodes.Clear();
            DiagramConnectors.Clear();

            CreateSection("Executive", 25m, new[]
            {
                ('A', 18), ('B', 18), ('C', 18), ('D', 18),
                ('E', 18), ('F', 18), ('G', 16), ('H', 14)
            });
            CreateSection("Corporate", 16m, new[]
            {
                ('I', 16), ('J', 16), ('K', 16), ('L', 14), ('M', 12)
            });
            CreateSection("Budget", 8m, new[]
            {
                ('N', 16), ('O', 16), ('P', 16)
            });

            var bookedSet = BookedSeatsByTiming.ContainsKey(SelectedShowTime.Time)
                ? BookedSeatsByTiming[SelectedShowTime.Time]
                : new HashSet<string>();

            foreach (var seat in GetAllSeats())
            {
                string key = $"{seat.Row}{seat.Number}";
                if (bookedSet.Contains(key))
                    seat.State = SeatState.Booked;
            }

            foreach (var seat in GetAllSeats())
                seat.PropertyChanged += Seat_PropertyChanged;

            if (this.View != null)
            {
                BuildDiagramNodes();
            }

            OnPropertyChanged(nameof(SelectedCount));
            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(TotalPriceText));
        }

        public void BuildDiagramNodes()
        {
            DiagramNodes.Clear();
            DiagramConnectors.Clear();

            double centerX = 560;
            double seatWidth = 32;
            double seatHeight = 32;
            double seatGap = 10;
            double seatStep = seatWidth + seatGap;
            double halfAisle = 41;
            double rowSpacing = 48;
            double labelX = 80;
            double startY = 50;
            double sectionHeaderGap = 28;
            double sectionSpacing = 60;

            var sectionDefs = new[]
            {
                new { Name="Executive", Price=25m, Rows=new[]{
                    ('A',18),('B',18),('C',18),('D',18),('E',18),('F',18),('G',16),('H',14)}},
                new { Name="Corporate", Price=16m, Rows=new[]{
                    ('I',16),('J',16),('K',16),('L',14),('M',12)}},
                new { Name="Budget",    Price=8m,  Rows=new[]{
                    ('N',16),('O',16),('P',16)}}
            };

            var allSeats = Sections
                .SelectMany(sec => sec.Rows.SelectMany(r => r.AllSeats))
                .ToDictionary(s => $"{s.Row}{s.Number}");

            double currentY = startY;

            // ---- Build tooltip template reference ----
            var tooltipTemplate = View.Resources["SeatTooltipContentTemplate"] as DataTemplate;
            var seatTemplate = View.Resources["SeatNodeContentTemplate"] as DataTemplate;
            var rowTemplate = View.Resources["RowLabelTemplate"] as DataTemplate;
            var secTemplate = View.Resources["SectionLabelTemplate"] as DataTemplate;
            var screenTemplate = View.Resources["ScreenTemplate"] as DataTemplate;

            foreach (var secDef in sectionDefs)
            {
                // Section label
                DiagramNodes.Add(new NodeViewModel
                {
                    OffsetX = centerX,
                    OffsetY = currentY,
                    UnitWidth = 300,
                    UnitHeight = 28,
                    Content = $"{secDef.Name} - ${secDef.Price}",
                    ContentTemplate = secTemplate,
                    // Constraints = NodeConstraints.None
                });

                currentY += sectionHeaderGap + seatHeight / 2;

                foreach (var (rowChar, count) in secDef.Rows)
                {
                    int leftCount = count / 2;
                    double leftFirstX = centerX - halfAisle
                        - (leftCount * seatWidth + (leftCount - 1) * seatGap)
                        + seatWidth / 2;
                    double rightFirstX = centerX + halfAisle + seatWidth / 2;

                    // Row label
                    DiagramNodes.Add(new NodeViewModel
                    {
                        OffsetX = labelX,
                        OffsetY = currentY,
                        UnitWidth = 30,
                        UnitHeight = 32,
                        Content = rowChar.ToString(),
                        ContentTemplate = rowTemplate,
                        //Constraints = NodeConstraints.None
                    });

                    // Left seats
                    for (int i = 1; i <= leftCount; i++)
                    {
                        string key = $"{rowChar}{i}";
                        if (!allSeats.ContainsKey(key)) continue;
                        var seat = allSeats[key];
                        DiagramNodes.Add(new NodeViewModel
                        {
                            OffsetX = leftFirstX + (i - 1) * seatStep,
                            OffsetY = currentY,
                            UnitWidth = seatWidth,
                            UnitHeight = seatHeight,
                            Content = seat,
                            ContentTemplate = seatTemplate,
                            //  // *** FIX: Set ToolTip directly on NodeViewModel ***
                            //  ToolTip = BuildTooltipBorder(seat, tooltipTemplate),
                            // Constraints = NodeConstraints.None 
                        });
                    }

                    // Right seats
                    for (int i = leftCount + 1; i <= count; i++)
                    {
                        string key = $"{rowChar}{i}";
                        if (!allSeats.ContainsKey(key)) continue;
                        var seat = allSeats[key];
                        DiagramNodes.Add(new NodeViewModel
                        {
                            OffsetX = rightFirstX + (i - leftCount - 1) * seatStep,
                            OffsetY = currentY,
                            UnitWidth = seatWidth,
                            UnitHeight = seatHeight,
                            Content = seat,
                            ContentTemplate = seatTemplate,
                            // *** FIX: Set ToolTip directly on NodeViewModel ***
                            //ToolTip = BuildTooltipBorder(seat, tooltipTemplate),
                            // Constraints = NodeConstraints.None 
                        });
                    }

                    currentY += rowSpacing;
                }

                currentY += sectionSpacing;
            }

            currentY += 20;
            DiagramNodes.Add(new NodeViewModel
            {
                OffsetX = centerX,
                OffsetY = currentY,
                UnitWidth = 520,
                UnitHeight = 68,   // canvas(46) + label(11) + margin(5) = 62 exact
                Content = "SCREEN",
                ContentTemplate = screenTemplate,
                Constraints = NodeConstraints.None
            });
        }


        private void Seat_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SeatViewModel.State))
            {
                OnPropertyChanged(nameof(SelectedCount));
                OnPropertyChanged(nameof(TotalPrice));
                OnPropertyChanged(nameof(TotalPriceText));
            }
        }

        public int SelectedCount => GetAllSeats().Count(s => s.State == SeatState.Selected);
        public decimal TotalPrice => GetAllSeats().Where(s => s.State == SeatState.Selected).Sum(s => s.Price);
        public string TotalPriceText => TotalPrice > 0 ? $"${TotalPrice}" : "$0";

        private List<SeatViewModel> GetAllSeats()
            => Sections.SelectMany(sec => sec.Rows.SelectMany(r => r.AllSeats)).ToList();

        private void Proceed()
        {
            var selected = GetAllSeats().Where(s => s.State == SeatState.Selected).ToList();
            if (!selected.Any()) return;
            var msg = $"Booking {selected.Count} seat(s) for ${TotalPrice}.\n\n" +
                      $"Show: {SelectedShowTime?.Time}\n" +
                      $"Seats: {string.Join(", ", selected.Select(s => $"{s.Row}{s.Number}"))}";
            MessageBox.Show(msg, "Confirm Booking", MessageBoxButton.OK, MessageBoxImage.Information);
            foreach (var seat in selected) seat.State = SeatState.Booked;
        }

        private void CreateSection(string name, decimal price, (char Row, int Count)[] rows)
        {
            var section = new SectionViewModel { Name = name, Price = price };
            foreach (var (rowChar, count) in rows)
            {
                var row = new RowViewModel { RowLabel = rowChar.ToString() };
                int leftCount = count / 2;
                for (int i = 1; i <= leftCount; i++)
                    row.LeftSeats.Add(new SeatViewModel
                    { Row = rowChar.ToString(), Number = i, Price = price, TierCategory = name });
                for (int i = leftCount + 1; i <= count; i++)
                    row.RightSeats.Add(new SeatViewModel
                    { Row = rowChar.ToString(), Number = i, Price = price, TierCategory = name });
                section.Rows.Add(row);
            }
            Sections.Add(section);
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public enum SeatState { Available, Selected, Booked }

    public class SeatViewModel : INotifyPropertyChanged
    {
        public string Row { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public string TierCategory { get; set; }

        private SeatState _state;
        public SeatState State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StateString));
                OnPropertyChanged(nameof(IsSelected));
                OnPropertyChanged(nameof(IsBooked));
                OnPropertyChanged(nameof(IsAvailable));
            }
        }

        // Explicit string for DataTrigger Value comparisons
        public string StateString => State.ToString();
        public bool IsSelected => State == SeatState.Selected;
        public bool IsBooked => State == SeatState.Booked;
        public bool IsAvailable => State == SeatState.Available;

        public ICommand ToggleCommand { get; }

        public SeatViewModel()
        {
            ToggleCommand = new RelayCommand(_ => Toggle());
            _state = SeatState.Available;
        }

        public void Toggle()
        {
            if (State == SeatState.Booked) return;
            State = State == SeatState.Selected ? SeatState.Available : SeatState.Selected;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RowViewModel
    {
        public string RowLabel { get; set; }
        public List<SeatViewModel> LeftSeats { get; set; } = new List<SeatViewModel>();
        public List<SeatViewModel> RightSeats { get; set; } = new List<SeatViewModel>();
        public List<SeatViewModel> AllSeats => LeftSeats.Concat(RightSeats).ToList();
    }

    public class SectionViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PriceText => $"${Price}";
        public ObservableCollection<RowViewModel> Rows { get; set; } = new ObservableCollection<RowViewModel>();
    }

    public class ShowTimeViewModel : INotifyPropertyChanged
    {
        public string Time { get; set; }
        public string Format { get; set; }
        public string Status { get; set; }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get => _isAvailable;
            set { _isAvailable = value; OnPropertyChanged(); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); }
        }

        public ICommand SelectShowCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => System.Windows.Input.CommandManager.RequerySuggested += value;
            remove => System.Windows.Input.CommandManager.RequerySuggested -= value;
        }
    }
}