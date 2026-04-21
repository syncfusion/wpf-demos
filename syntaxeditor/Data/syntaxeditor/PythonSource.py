import clr
clr.AddReference("WindowsBase")
clr.AddReference("PresentationCore")
clr.AddReference("PresentationFramework")
from System.Collections.Generic import *
from System import *
from System.ComponentModel import *
from System.Collections.ObjectModel import *
from System.Windows.Threading import *
from System.Text import *

# NotifyPropertyChangedBase class implements INotifyPropertyChanged interface

class NotifyPropertyChangedBase(INotifyPropertyChanged):
    """http://sdlsdk.codeplex.com/Thread/View.aspx?ThreadId=30322"""
    PropertyChanged = None
    def __init__(self):
        (self.PropertyChanged, self._propertyChangedCaller) = make_event()

    def add_PropertyChanged(self, value):
        self.PropertyChanged += value

    def remove_PropertyChanged(self, value):
        self.PropertyChanged -= value

    def OnPropertyChanged(self, propertyName):
        self._propertyChangedCaller(self, PropertyChangedEventArgs(propertyName))

class StockData(NotifyPropertyChangedBase):
    """
        Implementing business object StockData
    """
    def Symbol(self, value):
        self.Symbol = value
        self.OnPropertyChanged("Symbol")
    
    def Account(self, value):
        self.Account = value
        self.OnPropertyChanged("Account")

    def LastTrade(self, value):
        self.LastTrade = value
        self.OnPropertyChanged("LastTrade")
    
    def Change(self, value):
        self.Change = value
        self.OnPropertyChanged("Change")
    
    def PreviousClose(self, value):
        self.PreviousClose = value
        self.OnPropertyChanged("PreviousClose")
    
    def Open(self, value):
        self.Open = value
        self.OnPropertyChanged("Open")
    
    def Volume(self, value):
        self.Volume = value
        self.OnPropertyChanged("Volume")
    
    def InitializeOn(self, other):
        self.Symbol = other.Symbol
        self.LastTrade = other.LastTrade
        self.Change = other.Change
        self.PrevoiusChange = other.PreviousChange
        self.Open = other.Open
        self.Volume = other.Volume

class StocksViewModel(object):
    def __init__(self):
        self.r = Random()
        self.data = ObservableCollection[StockData]()
        self.AddRows(10)
        self.timer = DispatcherTimer()
        self.timer.Interval = TimeSpan.FromMilliseconds(500)
        self.timer.Tick += self.OnTimerTick
        self.StartTimer()
    
    @property
    def Stocks(self):
        return self.data
    
    """ Timer related code """
    def StartTimer(self):
        if not self.timer.IsEnabled:
            self.timer.Start()
    
    def StopTimer(self):
        self.timer.Stop()
    
    def OnTimerTick(self, sender, eventargs):
        self.AddRows(self.r.Next(5))
        self.ChangeRows(self.r.Next(20))
        self.DeleteRows(self.r.Next(5))
    
    def AddRows(self, count):
        for i in range(0, count):
            newRec = StockData()
            newRec.Symbol = self.ChangeSymbol()
            newRec.Account = self.ChangeAccount()
            newRec.Open = Math.Round(self.r.NextDouble() * 30, 2)
            newRec.LastTrade = Math.Round(1 + self.r.NextDouble() * 50)
            d = self.r.NextDouble()
            if d < 0.5:
                newRec.Change = Math.Round(d, 2)
            else:
                newRec.Change = Math.Round(d, 2) * -1
            newRec.PreviousClose = Math.Round(self.r.NextDouble() * 30, 2)
            newRec.Volume = self.r.Next()
            self.data.Add(newRec)
    
    def ChangeSymbol(self):
        builder = StringBuilder()
        random = Random()
        for i in range(0, 3):
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)))
            builder.Append(ch)
        return builder.ToString()
    
    def ChangeAccount(self):
        random = Random()
        next = random.Next(1, 5)
        if next == 1:
            return "American Funds"
        elif next == 2:
            return "ChildrenCollegeSavings"
        elif next == 3:
            return "DayTrading"
        elif next == 4:
            return "RetirementSavings"
        else:
            return "FidelityFunds"
    
    def DeleteRows(self, count):
        if count < self.data.Count:
            for i in range(0, count):
                row  = self.r.Next(self.data.Count)
                self.data.RemoveAt(row)
    
    def ChangeRows(self, count):
        if count < self.data.Count:
            for i in range(0, count):
                recNo = self.r.Next(self.data.Count)
                recRow = self.data[recNo]
                recRow.LastTrade = Math.Round((1 + self.r.NextDouble() * 50))
                d = self.r.NextDouble()
                if d < 0.5:
                    recRow.Change = Math.Round(d, 2)
                else:
                    recRow.Change = Math.Round(d, 2) * -1
                recRow.PreviousClose = Math.Round(self.r.NextDouble() * 30, 2)
                recRow.Volume = self.r.Next()

s = StocksViewModel()
grid = Application.FindName('dataGrid')
grid.ItemsSource = s.Stocks