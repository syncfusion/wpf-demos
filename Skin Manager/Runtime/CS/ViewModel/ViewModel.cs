#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace SkinManagerDemo_2008
{
    class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the visibility for firstTab.
        /// </summary>
        private Visibility firstTabVisibility;

        /// <summary>
        /// Maintains the visibility for secondTab.
        /// </summary>
        private Visibility secondTabVisibility;

        /// <summary>
        /// Maintains the command for openCommand;
        /// </summary>
        private ICommand openCommand;

        /// <summary>
        /// Maintains the command for pageSetUpCommand;
        /// </summary>
        private ICommand pageSetUpCommand;

        /// <summary>
        /// Maintains the command for printCommand;
        /// </summary>
        private ICommand printCommand;

        /// <summary>
        /// Maintains the command for selectAllCommand;
        /// </summary>
        private ICommand selectAllCommand;

        /// <summary>
        /// Maintains the command for cutCommand;
        /// </summary>
        private ICommand cutCommand;

        /// <summary>
        /// Maintains the command for copyCommand;
        /// </summary>
        private ICommand copyCommand;

        /// <summary>
        /// Maintains the command for helpCommand;
        /// </summary>
        private ICommand helpCommand;

        /// <summary>
        /// Maintains the command for homeCommand;
        /// </summary>
        private ICommand homeCommand;

        /// <summary>
        /// Maintains the command for exitCommand;
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Maintains the command for pasteCommand;
        /// </summary>
        private ICommand pasteCommand;

        /// <summary>
        /// Maintains the command for saveCommand;
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// Maintains the command for contactUsCommand;
        /// </summary>
        private ICommand contactUsCommand;

        /// <summary>
        /// Maintains the command for aboutUsCommand;
        /// </summary>
        private ICommand aboutUsCommand;

        /// <summary>
        /// Maintains the vacancy command.
        /// </summary>
        private ICommand vacancyCommand;

        /// <summary>
        /// Maintains the vacancy command.
        /// </summary>
        private ICommand interviewCommand;

        /// <summary>
        /// Private Members 
        /// </summary>
        public static ObservableCollection<Model> InterviewDetails =
        new ObservableCollection<Model>();

        /// <summary>
        /// Gets the game collection.
        /// </summary>
        /// <value>The game collection.</value>
        public ObservableCollection<Model> JobInformation
        { get { return InterviewDetails; } }

        /// <summary>
        /// Initializes the new instance of <see cref="ViewModel"/> class
        /// </summary>
        public ViewModel()
        {
            GameCollections();
            vacancyCommand = new DelegateCommand<object>(ExecuteVacancyCommand);
            interviewCommand = new DelegateCommand<object>(ExecuteInterviewCommand);
            openCommand = new DelegateCommand<object>(ExecuteOpenCommand);
            cutCommand = new DelegateCommand<object>(ExecuteCutCommand);
            copyCommand = new DelegateCommand<object>(ExecuteCopyCommand);
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            homeCommand = new DelegateCommand<object>(ExecuteHomeCommand);
            pasteCommand = new DelegateCommand<object>(ExecutePasteCommand);
            saveCommand = new DelegateCommand<object>(ExecuteSaveCommand);
            pageSetUpCommand = new DelegateCommand<object>(ExecutePageSetUpCommand);
            printCommand = new DelegateCommand<object>(ExecutePrintCommand);
            selectAllCommand = new DelegateCommand<object>(ExecuteSelectAllCommand);
            contactUsCommand = new DelegateCommand<object>(ExecuteContactUsCommand);
            aboutUsCommand = new DelegateCommand<object>(ExecuteAboutUsCommand);
            SecondTabVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Gets or sets the visibility for first TabControl <see cref="ViewModel"/> class.
        /// </summary>
        public Visibility FirstTabVisibility
        {
            get
            {
                return firstTabVisibility;
            }
            set
            {
                firstTabVisibility = value;
                RaisePropertyChanged("FirstTabVisibility");
            }
        }

        /// <summary>
        /// Gets or sets the visibility for second TabControl <see cref="ViewModel"/> class.
        /// </summary>
        public Visibility SecondTabVisibility
        {
            get
            {
                return secondTabVisibility;
            }
            set
            {
                secondTabVisibility = value;
                RaisePropertyChanged("SecondTabVisibility");
            }
        }

        /// <summary>
        /// Gets or sets the command for vacancy radio button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand VacancyCommand
        {
            get
            {
                return vacancyCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for exit <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for contact us menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand ContactUsCommand
        {
            get
            {
                return contactUsCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for about us menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand AboutUsCommand
        {
            get
            {
                return aboutUsCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for interview radio button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InterviewCommand
        {
            get
            {
                return interviewCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for header open button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand OpenCommand
        {
            get
            {
                return openCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command print menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand PrintCommand
        {
            get
            {
                return printCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command selectAll menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand SelectAllCommand
        {
            get
            {
                return selectAllCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command pageSetUp menu item <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand PageSetUpCommand
        {
            get
            {
                return pageSetUpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for  header home button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HomeCommand
        {
            get
            {
                return homeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for header save button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for header cut button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand CutCommand
        {
            get
            {
                return cutCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for header copy button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand CopyCommand
        {
            get
            {
                return copyCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for header help button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for header paste button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand PasteCommand
        {
            get
            {
                return pasteCommand;
            }
        }

        /// <summary>
        /// Games the collections.
        /// </summary>
        public static void GameCollections()
        {
            InterviewDetails.Add(new Model
            {
                JobID = "101",
                CompanyName = "Photon InfoTech",
                CompanyID = "1001",
                JobDescription = "Software Developer",
                Vacancy = "10",
                Date = "10.10.08 to 10.12.08",
                Branch = "Photon Infotech",
                Interview = "Software Developer",
                SecondJobID = "101a",
                SecondCompanyName = "World Of Warcraft",
                SecondCompanyID = "1001a",
                SecondJobDescription = "Hardware Technician",
                SecondVacancy = "5",
                SecondDate = "09.25.08 to 09.26.08",
                SecondBranch = "World Of Warcraft",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "101b",
                ThirdCompanyName = "Polaris",
                ThirdCompanyID = "1001b",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.25.08 to 09.26.08",
                ThirdBranch = "Q3 Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "101c",
                FourthCompanyName = "Cosmosoft Solution",
                FourthCompanyID = "1001c",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "09.27.08",
                FourthBranch = "Polaris",
                FourthInterview = "BPO",
                FifthJobID = "101d",
                FifthCompanyName = "ACTE Group of Education",
                FifthCompanyID = "1001d",
                FifthJobDescription = "Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ACTE Group of Education",
                FifthInterview = "Lecturer",
                SixthJobID = "101e",
                SixthCompanyName = "ACTE Group of Education",
                SixthCompanyID = "1001e",
                SixthJobDescription = "Cashier",
                SixthVacancy = "4",
                SixthDate = "09.25.08 to 09.26.08",
                SixthBranch = "ACTE Group of Education",
                SixthInterview = "Cashier"

            });
            InterviewDetails.Add(new Model
            {
                JobID = "102",
                CompanyName = "World Of Warcraft",
                CompanyID = "1002",
                JobDescription = "Project Developer",
                Vacancy = "5",
                Date = "09.25.08 to 09.26.08",
                Branch = "World Of Warcraft",
                Interview = "Software Developer",
                SecondJobID = "102a",
                SecondCompanyName = "Q3 Technology",
                SecondCompanyID = "1002a",
                SecondJobDescription = "Hardware Trainee",
                SecondVacancy = "3",
                SecondDate = "09.28.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Trainee",
                ThirdJobID = "102b",
                ThirdCompanyName = "World Of Warcraft",
                ThirdCompanyID = "1002b",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "2.10.08 to 5.10.08",
                ThirdBranch = "World Of Warcraft",
                ThirdInterview = "Call Center",
                FourthJobID = "102c",
                FourthCompanyName = "SkyWare Technology",
                FourthCompanyID = "1002c",
                FourthJobDescription = "BPO",
                FourthVacancy = "7",
                FourthDate = "7.10.08 to 10.10.08",
                FourthBranch = "SkyWare Technology",
                FourthInterview = "BPO",
                FifthJobID = "102d",
                FifthCompanyName = "CSC Computer",
                FifthCompanyID = "1002d",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "1.10.08",
                FifthBranch = "CSC Computer",
                FifthInterview = "Trainee",
                SixthJobID = "102e",
                SixthCompanyName = "ZepTo Tech",
                SixthCompanyID = "1002e",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "2.10.08",
                SixthBranch = "ZeptoTech",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                JobID = "103",
                CompanyName = "Polaris",
                CompanyID = "1003",
                JobDescription = ".NET Developer",
                Vacancy = "15",
                Date = "09.25.08 to 09.26.08",
                Branch = "Q3 Technology",
                Interview = "Team Leader",
                SecondJobID = "103a",
                SecondCompanyName = "Krupto Tech",
                SecondCompanyID = "1003a",
                SecondJobDescription = "HardWare Technician",
                SecondVacancy = "2",
                SecondDate = "2.10.08 to 5.10.08",
                SecondBranch = "Krupto Tech",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "103b",
                ThirdCompanyName = "Hexogan Technology",
                ThirdCompanyID = "1003b",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "5.10.08",
                ThirdBranch = "Hexogan Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "103c",
                FourthCompanyName = "World Of Warcraft",
                FourthCompanyID = "1003c",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "2.10.08 to 5.10.08",
                FourthBranch = "World Of Warcraft",
                FourthInterview = "BPO",
                FifthJobID = "103d",
                FifthCompanyName = "MIT Trainee Center",
                FifthCompanyID = "1003d",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "2.10.08",
                FifthBranch = "MIT Trainee Center",
                FifthInterview = "Trainee",

                SixthJobID = "103e",
                SixthCompanyName = "MIT Trainee Center",
                SixthCompanyID = "1003e",
                SixthJobDescription = "Senior Accountant",
                SixthVacancy = "1",
                SixthDate = "09.29.08",
                SixthBranch = "MIT Trainee Center",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                JobID = "104",
                CompanyName = "Cosmosoft Solution",
                CompanyID = "1004",
                JobDescription = "Project coordinator",
                Vacancy = "5",
                Date = "09.27.08",
                Branch = "Polaris",
                Interview = ".NET Developer",
                SecondJobID = "104a",
                SecondCompanyID = "1004a",
                SecondCompanyName = "Accenture",
                SecondJobDescription = "Technician",
                SecondVacancy = "5",
                SecondDate = "09.27.08",
                SecondBranch = "Accenture",
                SecondInterview = "Technician",
                ThirdJobID = "104b",
                ThirdCompanyID = "1004b",
                ThirdCompanyName = "IconTech",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.25.08 to 09.26.08",
                ThirdBranch = "IconTech",
                ThirdInterview = "Call Center",
                FourthJobID = "104c",
                FourthCompanyID = "1004c",
                FourthCompanyName = "Spam Tech",
                FourthJobDescription = "BPO",
                FourthVacancy = "10",
                FourthDate = "1.10.08 to 2.10.08",
                FourthBranch = "Spam Tech",
                FourthInterview = "BPO",
                FifthJobID = "104d",
                FifthCompanyID = "1004d",
                FifthCompanyName = "APCOS College",
                FifthJobDescription = "Guest Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.25.08 to 09.26.08",
                FifthBranch = "APCOS College",
                FifthInterview = "Guest Lecturer",
                SixthJobID = "104e",
                SixthCompanyID = "1004e",
                SixthCompanyName = "APCOS College",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "09.28.08",
                SixthBranch = "APCOS College",
                SixthInterview = "Accountant"
            });
            InterviewDetails.Add(new Model
            {
                JobID = "105",
                CompanyID = "1005",
                CompanyName = "Zeptoware Technology",
                JobDescription = "Team leader",
                Vacancy = "2",
                Date = "09.27.08",
                Branch = "Cosmosoft Solution",
                Interview = "Project Developer",
                SecondJobID = "105a",
                SecondCompanyID = "1005a",
                SecondCompanyName = "World of WarCraft",
                SecondJobDescription = "Hardware Tester",
                SecondVacancy = "10",
                SecondDate = "09.28.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Technician",
                ThirdJobID = "105b",
                ThirdCompanyID = "1005b",
                ThirdCompanyName = "TCS",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.25.08 to 09.26.08",
                ThirdBranch = "TCS",
                ThirdInterview = "Call Center",
                FourthJobID = "105c",
                FourthCompanyID = "1005c",
                FourthCompanyName = "CTS",
                FourthJobDescription = "BPO",
                FourthVacancy = "20",
                FourthDate = "09.25.08 to 09.26.08",
                FourthBranch = "CTS",
                FourthInterview = "BPO",
                FifthJobID = "105d",
                FifthCompanyID = "1005d",
                FifthCompanyName = "ASMWC College",
                FifthJobDescription = "Senior Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ASMWC College",
                FifthInterview = "Senior Lecturer",
                SixthJobID = "105e",
                SixthCompanyID = "1005e",
                SixthCompanyName = "DenMark Pri. Ltd",
                SixthJobDescription = "Clerk",
                SixthVacancy = "2",
                SixthDate = "09.26.08",
                SixthBranch = "DenMark Pri. Ltd",
                SixthInterview = "Clerk"
            });
            InterviewDetails.Add(new Model
            {
                JobID = "101",
                CompanyID = "1001",
                CompanyName = "Photon InfoTech",
                JobDescription = "Software Developer",
                Vacancy = "10",
                Date = "10.10.08 to 10.12.08",
                Branch = "Photon Infotech",
                Interview = "Software Developer",
                SecondJobID = "101a",
                SecondCompanyID = "1001a",
                SecondCompanyName = "World Of Warcraft",
                SecondJobDescription = "Hardware Technician",
                SecondVacancy = "5",
                SecondDate = "09.25.08 to 09.26.08",
                SecondBranch = "World Of Warcraft",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "101b",
                ThirdCompanyName = "Polaris",
                ThirdCompanyID = "1001b",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.25.08 to 09.26.08",
                ThirdBranch = "Q3 Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "101c",
                FourthCompanyName = "Cosmosoft Solution",
                FourthCompanyID = "1001c",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "09.27.08",
                FourthBranch = "Polaris",
                FourthInterview = "BPO",
                FifthJobID = "101d",
                FifthCompanyID = "1001d",
                FifthCompanyName = "ACTE Group of Education",
                FifthJobDescription = "Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ACTE Group of Education",
                FifthInterview = "Lecturer",
                SixthJobID = "101e",
                SixthCompanyID = "1001e",
                SixthCompanyName = "ACTE Group of Education",
                SixthJobDescription = "Cashier",
                SixthVacancy = "4",
                SixthDate = "09.27.08 to 09.29.08",
                SixthBranch = "ACTE Group of Education",
                SixthInterview = "Cashier"

            });
            InterviewDetails.Add(new Model
            {
                JobID = "102",
                CompanyID = "1002",
                CompanyName = "World Of Warcraft",
                JobDescription = "Project Developer",
                Vacancy = "5",
                Date = "25.09.08 to 09.26.08",
                Branch = "World Of Warcraft",
                Interview = "Software Developer",
                SecondJobID = "102a",
                SecondCompanyID = "1002a",
                SecondCompanyName = "Q3 Technology",
                SecondJobDescription = "Hardware Trainee",
                SecondVacancy = "3",
                SecondDate = "09.29.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Trainee",
                ThirdJobID = "102b",
                ThirdCompanyID = "1002b",
                ThirdCompanyName = "World Of Warcraft",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "2.10.08 to 5.10.08",
                ThirdBranch = "World Of Warcraft",
                ThirdInterview = "Call Center",
                FourthJobID = "102c",
                FourthCompanyName = "SkyWare Technology",
                FourthCompanyID = "1002c",
                FourthJobDescription = "BPO",
                FourthVacancy = "7",
                FourthDate = "7.10.08 to 10.10.08",
                FourthBranch = "SkyWare Technology",
                FourthInterview = "BPO",
                FifthJobID = "102d",
                FifthCompanyName = "CSC Computer",
                FifthCompanyID = "1002d",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "1.10.08",
                FifthBranch = "CSC Computer",
                FifthInterview = "Trainee",
                SixthJobID = "102e",
                SixthCompanyName = "ZepTo Tech",
                SixthCompanyID = "1002e",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "2.10.08",
                SixthBranch = "ZeptoTech",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1003a",
                ThirdCompanyID = "1003b",
                FourthCompanyID = "1003c",
                FifthCompanyID = "1003d",
                SixthCompanyID = "1003e",
                CompanyID = "1003",
                JobID = "103",
                CompanyName = "Polaris",
                JobDescription = ".NET Developer",
                Vacancy = "15",
                Date = "25.09.08 to 09.26.08",
                Branch = "Q3 Technology",
                Interview = "Team Leader",
                SecondJobID = "103a",
                SecondCompanyName = "Krupto Tech",
                SecondJobDescription = "HardWare Technician",
                SecondVacancy = "2",
                SecondDate = "2.10.08 to 5.10.08",
                SecondBranch = "Krupto Tech",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "103b",
                ThirdCompanyName = "Hexogan Technology",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "5.10.08",
                ThirdBranch = "Hexogan Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "103c",
                FourthCompanyName = "World Of Warcraft",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "2.10.08 to 5.10.08",
                FourthBranch = "World Of Warcraft",
                FourthInterview = "BPO",
                FifthJobID = "103d",
                FifthCompanyName = "MIT Trainee Center",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "2.10.08",
                FifthBranch = "MIT Trainee Center",
                FifthInterview = "Trainee",

                SixthJobID = "103e",
                SixthCompanyName = "MIT Trainee Center",
                SixthJobDescription = "Senior Accountant",
                SixthVacancy = "1",
                SixthDate = "09.29.08",
                SixthBranch = "MIT Trainee Center",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1004a",
                ThirdCompanyID = "1004b",
                FourthCompanyID = "1004c",
                FifthCompanyID = "1004d",
                SixthCompanyID = "1004e",
                CompanyID = "1004",
                JobID = "104",
                CompanyName = "Cosmosoft Solution",
                JobDescription = "Project coordinator",
                Vacancy = "5",
                Date = "09.27.08",
                Branch = "Polaris",
                Interview = ".NET Developer",
                SecondJobID = "104a",
                SecondCompanyName = "Accenture",
                SecondJobDescription = "Technician",
                SecondVacancy = "5",
                SecondDate = "09.27.08",
                SecondBranch = "Accenture",
                SecondInterview = "Technician",
                ThirdJobID = "104b",
                ThirdCompanyName = "IconTech",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.29.08 to 09.30.08",
                ThirdBranch = "IconTech",
                ThirdInterview = "Call Center",
                FourthJobID = "104c",
                FourthCompanyName = "Spam Tech",
                FourthJobDescription = "BPO",
                FourthVacancy = "10",
                FourthDate = "1.10.08 to 2.10.08",
                FourthBranch = "Spam Tech",
                FourthInterview = "BPO",
                FifthJobID = "104d",
                FifthCompanyName = "APCOS College",
                FifthJobDescription = "Guest Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.29.08 to 09.30.08",
                FifthBranch = "APCOS College",
                FifthInterview = "Guest Lecturer",
                SixthJobID = "104e",
                SixthCompanyName = "APCOS College",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "09.28.08",
                SixthBranch = "APCOS College",
                SixthInterview = "Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1005a",
                ThirdCompanyID = "1005b",
                FourthCompanyID = "1005c",
                FifthCompanyID = "1005d",
                SixthCompanyID = "1005e",
                CompanyID = "1005",
                JobID = "105",
                CompanyName = "Zeptoware Technology",
                JobDescription = "Team leader",
                Vacancy = "2",
                Date = "09.28.08",
                Branch = "Cosmosoft Solution",
                Interview = "Project Developer",
                SecondJobID = "105a",
                SecondCompanyName = "World of WarCraft",
                SecondJobDescription = "Hardware Tester",
                SecondVacancy = "10",
                SecondDate = "09.28.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Technician",
                ThirdJobID = "105b",
                ThirdCompanyName = "TCS",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.28.08 to 09.29.08",
                ThirdBranch = "TCS",
                ThirdInterview = "Call Center",
                FourthJobID = "105c",
                FourthCompanyName = "CTS",
                FourthJobDescription = "BPO",
                FourthVacancy = "20",
                FourthDate = "09.26.08 to 09.27.08",
                FourthBranch = "CTS",
                FourthInterview = "BPO",
                FifthJobID = "105d",
                FifthCompanyName = "ASMWC College",
                FifthJobDescription = "Senior Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ASMWC College",
                FifthInterview = "Senior Lecturer",
                SixthJobID = "105e",
                SixthCompanyName = "DenMark Pri. Ltd",
                SixthJobDescription = "Clerk",
                SixthVacancy = "2",
                SixthDate = "09.26.08",
                SixthBranch = "DenMark Pri. Ltd",
                SixthInterview = "Clerk"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1001a",
                ThirdCompanyID = "1001b",
                FourthCompanyID = "1001c",
                FifthCompanyID = "1001d",
                SixthCompanyID = "1001e",
                CompanyID = "1001",
                JobID = "101",
                CompanyName = "Photon InfoTech",
                JobDescription = "Software Developer",
                Vacancy = "10",
                Date = "10.10.08 to 12.10.08",
                Branch = "Photon Infotech",
                Interview = "Software Developer",
                SecondJobID = "101a",
                SecondCompanyName = "World Of Warcraft",
                SecondJobDescription = "Hardware Technician",
                SecondVacancy = "5",
                SecondDate = "25.09.08 to 09.26.08",
                SecondBranch = "World Of Warcraft",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "101b",
                ThirdCompanyName = "Polaris",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "25.09.08 to 09.26.08",
                ThirdBranch = "Q3 Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "101c",
                FourthCompanyName = "Cosmosoft Solution",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "09.27.08",
                FourthBranch = "Polaris",
                FourthInterview = "BPO",
                FifthJobID = "101d",
                FifthCompanyName = "ACTE Group of Education",
                FifthJobDescription = "Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ACTE Group of Education",
                FifthInterview = "Lecturer",
                SixthJobID = "101e",
                SixthCompanyName = "ACTE Group of Education",
                SixthJobDescription = "Cashier",
                SixthVacancy = "4",
                SixthDate = "09.27.08 to 09.29.08",
                SixthBranch = "ACTE Group of Education",
                SixthInterview = "Cashier"

            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1002a",
                ThirdCompanyID = "1002b",
                FourthCompanyID = "1002c",
                FifthCompanyID = "1002d",
                SixthCompanyID = "1002e",
                CompanyID = "1002",
                JobID = "102",
                CompanyName = "World Of Warcraft",
                JobDescription = "Project Developer",
                Vacancy = "5",
                Date = "09.25.08 to 26.09.08",
                Branch = "World Of Warcraft",
                Interview = "Software Developer",
                SecondJobID = "102a",
                SecondCompanyName = "Q3 Technology",
                SecondJobDescription = "Hardware Trainee",
                SecondVacancy = "3",
                SecondDate = "09.29.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Trainee",
                ThirdJobID = "102b",
                ThirdCompanyName = "World Of Warcraft",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "2.10.08 to 5.10.08",
                ThirdBranch = "World Of Warcraft",
                ThirdInterview = "Call Center",
                FourthJobID = "102c",
                FourthCompanyName = "SkyWare Technology",
                FourthJobDescription = "BPO",
                FourthVacancy = "7",
                FourthDate = "7.10.08 to 10.10.08",
                FourthBranch = "SkyWare Technology",
                FourthInterview = "BPO",
                FifthJobID = "102d",
                FifthCompanyName = "CSC Computer",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "1.10.08",
                FifthBranch = "CSC Computer",
                FifthInterview = "Trainee",
                SixthJobID = "102e",
                SixthCompanyName = "ZepTo Tech",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "2.10.08",
                SixthBranch = "ZeptoTech",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1003a",
                ThirdCompanyID = "1003b",
                FourthCompanyID = "1003c",
                FifthCompanyID = "1003d",
                SixthCompanyID = "1003e",
                CompanyID = "1003",
                JobID = "103",
                CompanyName = "Polaris",
                JobDescription = ".NET Developer",
                Vacancy = "15",
                Date = "25.09.08 to 09.26.08",
                Branch = "Q3 Technology",
                Interview = "Team Leader",
                SecondJobID = "103a",
                SecondCompanyName = "Krupto Tech",
                SecondJobDescription = "HardWare Technician",
                SecondVacancy = "2",
                SecondDate = "2.10.08 to 5.10.08",
                SecondBranch = "Krupto Tech",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "103b",
                ThirdCompanyName = "Hexogan Technology",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "5.10.08",
                ThirdBranch = "Hexogan Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "103c",
                FourthCompanyName = "World Of Warcraft",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "2.10.08 to 5.10.08",
                FourthBranch = "World Of Warcraft",
                FourthInterview = "BPO",
                FifthJobID = "103d",
                FifthCompanyName = "MIT Trainee Center",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "2.10.08",
                FifthBranch = "MIT Trainee Center",
                FifthInterview = "Trainee",

                SixthJobID = "103e",
                SixthCompanyName = "MIT Trainee Center",
                SixthJobDescription = "Senior Accountant",
                SixthVacancy = "1",
                SixthDate = "09.29.08",
                SixthBranch = "MIT Trainee Center",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1004a",
                ThirdCompanyID = "1004b",
                FourthCompanyID = "1004c",
                FifthCompanyID = "1004d",
                SixthCompanyID = "1004e",
                CompanyID = "1004",
                JobID = "104",
                CompanyName = "Cosmosoft Solution",
                JobDescription = "Project coordinator",
                Vacancy = "5",
                Date = "09.27.08",
                Branch = "Polaris",
                Interview = ".NET Developer",
                SecondJobID = "104a",
                SecondCompanyName = "Accenture",
                SecondJobDescription = "Technician",
                SecondVacancy = "5",
                SecondDate = "09.27.08",
                SecondBranch = "Accenture",
                SecondInterview = "Technician",
                ThirdJobID = "104b",
                ThirdCompanyName = "IconTech",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.29.08 to 09.30.08",
                ThirdBranch = "IconTech",
                ThirdInterview = "Call Center",
                FourthJobID = "104c",
                FourthCompanyName = "Spam Tech",
                FourthJobDescription = "BPO",
                FourthVacancy = "10",
                FourthDate = "1.10.08 to 2.10.08",
                FourthBranch = "Spam Tech",
                FourthInterview = "BPO",
                FifthJobID = "104d",
                FifthCompanyName = "APCOS College",
                FifthJobDescription = "Guest Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.29.08 to 09.30.08",
                FifthBranch = "APCOS College",
                FifthInterview = "Guest Lecturer",
                SixthJobID = "104e",
                SixthCompanyName = "APCOS College",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "09.28.08",
                SixthBranch = "APCOS College",
                SixthInterview = "Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1005a",
                ThirdCompanyID = "1005b",
                FourthCompanyID = "1005c",
                FifthCompanyID = "1005d",
                SixthCompanyID = "1005e",
                CompanyID = "1005",
                JobID = "105",
                CompanyName = "Zeptoware Technology",
                JobDescription = "Team leader",
                Vacancy = "2",
                Date = "09.28.08",
                Branch = "Cosmosoft Solution",
                Interview = "Project Developer",
                SecondJobID = "105a",
                SecondCompanyName = "World of WarCraft",
                SecondJobDescription = "Hardware Tester",
                SecondVacancy = "10",
                SecondDate = "09.28.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Technician",
                ThirdJobID = "105b",
                ThirdCompanyName = "TCS",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.28.08 to 09.29.08",
                ThirdBranch = "TCS",
                ThirdInterview = "Call Center",
                FourthJobID = "105c",
                FourthCompanyName = "CTS",
                FourthJobDescription = "BPO",
                FourthVacancy = "20",
                FourthDate = "09.26.08 to 09.27.08",
                FourthBranch = "CTS",
                FourthInterview = "BPO",
                FifthJobID = "105d",
                FifthCompanyName = "ASMWC College",
                FifthJobDescription = "Senior Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ASMWC College",
                FifthInterview = "Senior Lecturer",
                SixthJobID = "105e",
                SixthCompanyName = "DenMark Pri. Ltd",
                SixthJobDescription = "Clerk",
                SixthVacancy = "2",
                SixthDate = "09.26.08",
                SixthBranch = "DenMark Pri. Ltd",
                SixthInterview = "Clerk"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1001a",
                ThirdCompanyID = "1001b",
                FourthCompanyID = "1001c",
                FifthCompanyID = "1001d",
                SixthCompanyID = "1001e",
                CompanyID = "1001",
                JobID = "101",
                CompanyName = "Photon InfoTech",
                JobDescription = "Software Developer",
                Vacancy = "10",
                Date = "10.10.08 to 12.10.08",
                Branch = "Photon Infotech",
                Interview = "Software Developer",
                SecondJobID = "101a",
                SecondCompanyName = "World Of Warcraft",
                SecondJobDescription = "Hardware Technician",
                SecondVacancy = "5",
                SecondDate = "25.09.08 to 09.26.08",
                SecondBranch = "World Of Warcraft",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "101b",
                ThirdCompanyName = "Polaris",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "25.09.08 to 09.26.08",
                ThirdBranch = "Q3 Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "101c",
                FourthCompanyName = "Cosmosoft Solution",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "09.27.08",
                FourthBranch = "Polaris",
                FourthInterview = "BPO",
                FifthJobID = "101d",
                FifthCompanyName = "ACTE Group of Education",
                FifthJobDescription = "Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ACTE Group of Education",
                FifthInterview = "Lecturer",
                SixthJobID = "101e",
                SixthCompanyName = "ACTE Group of Education",
                SixthJobDescription = "Cashier",
                SixthVacancy = "4",
                SixthDate = "09.27.08 to 09.29.08",
                SixthBranch = "ACTE Group of Education",
                SixthInterview = "Cashier"

            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1002a",
                ThirdCompanyID = "1002b",
                FourthCompanyID = "1002c",
                FifthCompanyID = "1002d",
                SixthCompanyID = "1002e",
                CompanyID = "1002",
                JobID = "102",
                CompanyName = "World Of Warcraft",
                JobDescription = "Project Developer",
                Vacancy = "5",
                Date = "25.09.08 to 09.26.08",
                Branch = "World Of Warcraft",
                Interview = "Software Developer",
                SecondJobID = "102a",
                SecondCompanyName = "Q3 Technology",
                SecondJobDescription = "Hardware Trainee",
                SecondVacancy = "3",
                SecondDate = "09.29.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Trainee",
                ThirdJobID = "102b",
                ThirdCompanyName = "World Of Warcraft",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "2.10.08 to 5.10.08",
                ThirdBranch = "World Of Warcraft",
                ThirdInterview = "Call Center",
                FourthJobID = "102c",
                FourthCompanyName = "SkyWare Technology",
                FourthJobDescription = "BPO",
                FourthVacancy = "7",
                FourthDate = "7.10.08 to 10.10.08",
                FourthBranch = "SkyWare Technology",
                FourthInterview = "BPO",
                FifthJobID = "102d",
                FifthCompanyName = "CSC Computer",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "1.10.08",
                FifthBranch = "CSC Computer",
                FifthInterview = "Trainee",
                SixthJobID = "102e",
                SixthCompanyName = "ZepTo Tech",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "2.10.08",
                SixthBranch = "ZeptoTech",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1003a",
                ThirdCompanyID = "1003b",
                FourthCompanyID = "1003c",
                FifthCompanyID = "1003d",
                SixthCompanyID = "1003e",
                CompanyID = "1003",
                JobID = "103",
                CompanyName = "Polaris",
                JobDescription = ".NET Developer",
                Vacancy = "15",
                Date = "25.09.08 to 09.26.08",
                Branch = "Q3 Technology",
                Interview = "Team Leader",
                SecondJobID = "103a",
                SecondCompanyName = "Krupto Tech",
                SecondJobDescription = "HardWare Technician",
                SecondVacancy = "2",
                SecondDate = "2.10.08 to 5.10.08",
                SecondBranch = "Krupto Tech",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "103b",
                ThirdCompanyName = "Hexogan Technology",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "5.10.08",
                ThirdBranch = "Hexogan Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "103c",
                FourthCompanyName = "World Of Warcraft",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "2.10.08 to 5.10.08",
                FourthBranch = "World Of Warcraft",
                FourthInterview = "BPO",
                FifthJobID = "103d",
                FifthCompanyName = "MIT Trainee Center",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "2.10.08",
                FifthBranch = "MIT Trainee Center",
                FifthInterview = "Trainee",

                SixthJobID = "103e",
                SixthCompanyName = "MIT Trainee Center",
                SixthJobDescription = "Senior Accountant",
                SixthVacancy = "1",
                SixthDate = "09.29.08",
                SixthBranch = "MIT Trainee Center",
                SixthInterview = "Senior Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1004a",
                ThirdCompanyID = "1004b",
                FourthCompanyID = "1004c",
                FifthCompanyID = "1004d",
                SixthCompanyID = "1004e",
                CompanyID = "1004",
                JobID = "104",
                CompanyName = "Cosmosoft Solution",
                JobDescription = "Project coordinator",
                Vacancy = "5",
                Date = "09.27.08",
                Branch = "Polaris",
                Interview = ".NET Developer",
                SecondJobID = "104a",
                SecondCompanyName = "Accenture",
                SecondJobDescription = "Technician",
                SecondVacancy = "5",
                SecondDate = "09.27.08",
                SecondBranch = "Accenture",
                SecondInterview = "Technician",
                ThirdJobID = "104b",
                ThirdCompanyName = "IconTech",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.29.08 to 09.30.08",
                ThirdBranch = "IconTech",
                ThirdInterview = "Call Center",
                FourthJobID = "104c",
                FourthCompanyName = "Spam Tech",
                FourthJobDescription = "BPO",
                FourthVacancy = "10",
                FourthDate = "1.10.08 to 2.10.08",
                FourthBranch = "Spam Tech",
                FourthInterview = "BPO",
                FifthJobID = "104d",
                FifthCompanyName = "APCOS College",
                FifthJobDescription = "Guest Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.29.08 to 09.30.08",
                FifthBranch = "APCOS College",
                FifthInterview = "Guest Lecturer",
                SixthJobID = "104e",
                SixthCompanyName = "APCOS College",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "09.28.08",
                SixthBranch = "APCOS College",
                SixthInterview = "Accountant"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1005a",
                ThirdCompanyID = "1005b",
                FourthCompanyID = "1005c",
                FifthCompanyID = "1005d",
                SixthCompanyID = "1005e",
                CompanyID = "1005",
                JobID = "105",
                CompanyName = "Zeptoware Technology",
                JobDescription = "Team leader",
                Vacancy = "2",
                Date = "09.28.08",
                Branch = "Cosmosoft Solution",
                Interview = "Project Developer",
                SecondJobID = "105a",
                SecondCompanyName = "World of WarCraft",
                SecondJobDescription = "Hardware Tester",
                SecondVacancy = "10",
                SecondDate = "09.28.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Technician",
                ThirdJobID = "105b",
                ThirdCompanyName = "TCS",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "09.28.08 to 09.29.08",
                ThirdBranch = "TCS",
                ThirdInterview = "Call Center",
                FourthJobID = "105c",
                FourthCompanyName = "CTS",
                FourthJobDescription = "BPO",
                FourthVacancy = "20",
                FourthDate = "09.26.08 to 09.27.08",
                FourthBranch = "CTS",
                FourthInterview = "BPO",
                FifthJobID = "105d",
                FifthCompanyName = "ASMWC College",
                FifthJobDescription = "Senior Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ASMWC College",
                FifthInterview = "Senior Lecturer",
                SixthJobID = "105e",
                SixthCompanyName = "DenMark Pri. Ltd",
                SixthJobDescription = "Clerk",
                SixthVacancy = "2",
                SixthDate = "09.26.08",
                SixthBranch = "DenMark Pri. Ltd",
                SixthInterview = "Clerk"
            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1001a",
                ThirdCompanyID = "1001b",
                FourthCompanyID = "1001c",
                FifthCompanyID = "1001d",
                SixthCompanyID = "1001e",
                CompanyID = "1001",
                JobID = "101",
                CompanyName = "Photon InfoTech",
                JobDescription = "Software Developer",
                Vacancy = "10",
                Date = "10.10.08 to 12.10.08",
                Branch = "Photon Infotech",
                Interview = "Software Developer",
                SecondJobID = "101a",
                SecondCompanyName = "World Of Warcraft",
                SecondJobDescription = "Hardware Technician",
                SecondVacancy = "5",
                SecondDate = "25.09.08 to 09.26.08",
                SecondBranch = "World Of Warcraft",
                SecondInterview = "HardWare Technician",
                ThirdJobID = "101b",
                ThirdCompanyName = "Polaris",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "15",
                ThirdDate = "25.09.08 to 09.26.08",
                ThirdBranch = "Q3 Technology",
                ThirdInterview = "Call Center",
                FourthJobID = "101c",
                FourthCompanyName = "Cosmosoft Solution",
                FourthJobDescription = "BPO",
                FourthVacancy = "5",
                FourthDate = "09.27.08",
                FourthBranch = "Polaris",
                FourthInterview = "BPO",
                FifthJobID = "101d",
                FifthCompanyName = "ACTE Group of Education",
                FifthJobDescription = "Lecturer",
                FifthVacancy = "2",
                FifthDate = "09.28.08",
                FifthBranch = "ACTE Group of Education",
                FifthInterview = "Lecturer",
                SixthJobID = "101e",
                SixthCompanyName = "ACTE Group of Education",
                SixthJobDescription = "Cashier",
                SixthVacancy = "4",
                SixthDate = "09.27.08 to 09.29.08",
                SixthBranch = "ACTE Group of Education",
                SixthInterview = "Cashier"

            });
            InterviewDetails.Add(new Model
            {
                SecondCompanyID = "1002a",
                ThirdCompanyID = "1002b",
                FourthCompanyID = "1002c",
                FifthCompanyID = "1002d",
                SixthCompanyID = "1002e",
                CompanyID = "1002",
                JobID = "102",
                CompanyName = "World Of Warcraft",
                JobDescription = "Project Developer",
                Vacancy = "5",
                Date = "25.09.08 to 09.26.08",
                Branch = "World Of Warcraft",
                Interview = "Software Developer",
                SecondJobID = "102a",
                SecondCompanyName = "Q3 Technology",
                SecondJobDescription = "Hardware Trainee",
                SecondVacancy = "3",
                SecondDate = "09.29.08",
                SecondBranch = "Q3 Technology",
                SecondInterview = "Hardware Trainee",
                ThirdJobID = "102b",
                ThirdCompanyName = "World Of Warcraft",
                ThirdJobDescription = "Call Center",
                ThirdVacancy = "5",
                ThirdDate = "2.10.08 to 5.10.08",
                ThirdBranch = "World Of Warcraft",
                ThirdInterview = "Call Center",
                FourthJobID = "102c",
                FourthCompanyName = "SkyWare Technology",
                FourthJobDescription = "BPO",
                FourthVacancy = "7",
                FourthDate = "7.10.08 to 10.10.08",
                FourthBranch = "SkyWare Technology",
                FourthInterview = "BPO",
                FifthJobID = "102d",
                FifthCompanyName = "CSC Computer",
                FifthJobDescription = "Trainee",
                FifthVacancy = "2",
                FifthDate = "1.10.08",
                FifthBranch = "CSC Computer",
                FifthInterview = "Trainee",
                SixthJobID = "102e",
                SixthCompanyName = "ZepTo Tech",
                SixthJobDescription = "Accountant",
                SixthVacancy = "1",
                SixthDate = "2.10.08",
                SixthBranch = "ZeptoTech",
                SixthInterview = "Senior Accountant"
            });
        }

        /// <summary>
        /// Method used to execute the vacancy command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteVacancyCommand(object parameter)
        {
            FirstTabVisibility = Visibility.Visible;
            SecondTabVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Method used to execute the interview command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteInterviewCommand(object parameter)
        {
            FirstTabVisibility = Visibility.Collapsed;
            SecondTabVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Method used to execute the open command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteOpenCommand(object parameter)
        {
            MessageBox.Show("Open is executed");
        }

        /// <summary>
        /// Method used to execute the savecommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteSaveCommand(object parameter)
        {
            MessageBox.Show("Save is executed");
        }

        /// <summary>
        /// Method used to execute the helpcommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteHelpCommand(object parameter)
        {
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/chromlesswindow/getting-started");
        }

        /// <summary>
        /// Method used to execute the contactUscommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteContactUsCommand(object parameter)
        {
            System.Diagnostics.Process.Start("https://www.syncfusion.com/company/contact-us");
        }

        /// <summary>
        /// Method used to execute the aboutUscommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteAboutUsCommand(object parameter)
        {
            System.Diagnostics.Process.Start("https://www.syncfusion.com/company/about-us");
        }

        /// <summary>
        /// Method used to execute the cutcommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteCutCommand(object parameter)
        {
            MessageBox.Show("Cut is executed");
        }

        /// <summary>
        /// Method used to execute the copycommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteCopyCommand(object parameter)
        {
            MessageBox.Show("Copy is executed");
        }

        /// <summary>
        /// Method used to execute the pastecommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecutePasteCommand(object parameter)
        {
            MessageBox.Show("Paste is executed");
        }

        /// <summary>
        /// Method used to execute the homecommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteHomeCommand(object parameter)
        {
            MessageBox.Show("Home is executed");
        }

        /// <summary>
        /// Method used to execute the printcommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecutePrintCommand(object parameter)
        {
            MessageBox.Show("Print is executed");
        }

        /// <summary>
        /// Method used to execute the pageSetUpcommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecutePageSetUpCommand(object parameter)
        {
            MessageBox.Show("Page SetUp is executed");
        }

        /// <summary>
        /// Method used to execute the selectAllcommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteSelectAllCommand(object parameter)
        {
            MessageBox.Show("SelectAll is executed");
        }

        /// <summary>
        /// Method used to execute the exitcommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteExitCommand(object parameter)
        {
            Application.Current.Shutdown();
        }
    }

    /// <summary>
    /// This converter targets a column header,in order to take its width to zero when it should be hidden
    /// </summary>
    public class ColumnWidthConverter: IValueConverter
    {
        /// <summary>
        /// Converts to visibility.
        /// </summary>
        /// <param name="value">Specifies the value.</param>
        /// <param name="targetType">Specifies the target type.</param>
        /// <param name="parameter">Specifies the parameter.</param>
        /// <param name="culture">Specifies the culture.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isVisible = (bool)value;
            var width = double.Parse(parameter as string);
            return isVisible ? width : 0.0;
        }

        /// <summary>
        /// ConvertBack method.
        /// </summary>
        /// <param name="value">Specifies the value.</param>
        /// <param name="targetType">Specifies the target type.</param>
        /// <param name="parameter">Specifies the parameter</param>
        /// <param name="culture">Specifies the culture.</param>
        /// <returns></returns>
        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
