#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace syncfusion.patientmonitor.wpf
{
    public class PatientDetails
    {
        #region Properties
        public string Name { get; set; }
        public int ID { get; set; }
        public string ImageName { get; set; }
        public int HeartRate { get; set; }
        public int RespirationRate { get; set; }
        public string Block { get; set; }
        public string RoomNo { get; set; }
        public int Temperature { get; set; }
        public int Saturation { get; set; }
        public string Sex { get; set; }
        public int BloodPressure { get; set; }
        public int BloodPressure2 { get; set; }
        public Brush TileColor { get; set; }
        public TimeSpan TileIntreval { get; set; }

        #endregion

        #region Methods
        public static List<PatientDetails> GetPatientDetails()
        {
            List<PatientDetails> patientDetails = new List<PatientDetails>();
            patientDetails.Add(new PatientDetails() { Name = "Jessie Mcferron", ID = 1, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image1.jpg", Sex = "Male", Block = "A", RoomNo = "1" });
            patientDetails.Add(new PatientDetails() { Name = "Erik Edgemon", ID = 2, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image2.jpg", Sex = "Female", Block = "A", RoomNo = "2" });
            patientDetails.Add(new PatientDetails() { Name = "Christian Tilson", ID = 3, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image3.jpg", Sex = "Male", Block = "A", RoomNo = "3" });
            patientDetails.Add(new PatientDetails() { Name = "Jessie Badgley", ID = 4, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image4.jpg", Sex = "Male", Block = "A", RoomNo = "4" });
            patientDetails.Add(new PatientDetails() { Name = "Ted Zinke", ID = 5, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image5.jpg", Sex = "Male", Block = "A", RoomNo = "5" });
            patientDetails.Add(new PatientDetails() { Name = "Julio Ice", ID = 6, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image6.jpg", Sex = "Female", Block = "A", RoomNo = "6" });
            patientDetails.Add(new PatientDetails() { Name = "Clayton Lillibridge", ID = 7, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image7.jpg", Sex = "Male", Block = "A", RoomNo = "7" });
            patientDetails.Add(new PatientDetails() { Name = "Mathew Lechler", ID = 8, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image8.jpg", Sex = "Male", Block = "A", RoomNo = "8" });
            patientDetails.Add(new PatientDetails() { Name = "Cody Paskett", ID = 9, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image13.jpg", Sex = "Female", Block = "A", RoomNo = "9" });
            patientDetails.Add(new PatientDetails() { Name = "Nelson Donnellan", ID = 10, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image10.jpg", Sex = "Male", Block = "A", RoomNo = "10" });
            patientDetails.Add(new PatientDetails() { Name = "Alejandra Mescher", ID = 11, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image11.jpg", Sex = "Male", Block = "A", RoomNo = "11" });


            patientDetails.Add(new PatientDetails() { Name = "Zazueta", ID = 1, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image4.jpg", Sex = "Female", Block = "B", RoomNo = "1" });
            patientDetails.Add(new PatientDetails() { Name = "Clayton Lebaron", ID = 2, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image8.jpg", Sex = "Male", Block = "B", RoomNo = "2" });
            patientDetails.Add(new PatientDetails() { Name = "JKarina Ziolkowski", ID = 3, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image1.jpg", Sex = "Female", Block = "B", RoomNo = "3" });
            patientDetails.Add(new PatientDetails() { Name = "Javier Vanleuven", ID = 4, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image9.jpg", Sex = "Male", Block = "B", RoomNo = "4" });
            patientDetails.Add(new PatientDetails() { Name = "Kelly Barga", ID = 5, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image10.jpg", Sex = "Male", Block = "B", RoomNo = "5" });
            patientDetails.Add(new PatientDetails() { Name = "Allan Quarterman", ID = 6, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image14.jpg", Sex = "Male", Block = "B", RoomNo = "6" });
            patientDetails.Add(new PatientDetails() { Name = "Tameka Douse", ID = 7, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image6.jpg", Sex = "Female", Block = "B", RoomNo = "7" });
            patientDetails.Add(new PatientDetails() { Name = "Tyrone Hadfield", ID = 8, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image3.jpg", Sex = "Male", Block = "B", RoomNo = "8" });
            patientDetails.Add(new PatientDetails() { Name = "Darcy Mascio", ID = 9, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image7.jpg", Sex = "Female", Block = "B", RoomNo = "9" });
            patientDetails.Add(new PatientDetails() { Name = "Gay Roeser", ID = 10, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image4.jpg", Sex = "Female", Block = "B", RoomNo = "10" });
            patientDetails.Add(new PatientDetails() { Name = "Lance Piotrowski", ID = 11, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image11.jpg", Sex = "Male", Block = "B", RoomNo = "11" });



            patientDetails.Add(new PatientDetails() { Name = "Louisa Fargo", ID = 1, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image7.jpg", Sex = "Female", Block = "C", RoomNo = "1" });
            patientDetails.Add(new PatientDetails() { Name = "Laconte", ID = 2, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image1.jpg", Sex = "Female", Block = "C", RoomNo = "2" });
            patientDetails.Add(new PatientDetails() { Name = "Alana Barranco", ID = 3, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image6.jpg", Sex = "Female", Block = "C", RoomNo = "3" });
            patientDetails.Add(new PatientDetails() { Name = "Tyrone Hadfield", ID = 4, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image3.jpg", Sex = "Male", Block = "C", RoomNo = "4" });
            patientDetails.Add(new PatientDetails() { Name = "Allan Hoefler", ID = 5, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image5.jpg", Sex = "Male", Block = "C", RoomNo = "5" });
            patientDetails.Add(new PatientDetails() { Name = "Clayton Lokey", ID = 6, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image8.jpg", Sex = "Male", Block = "C", RoomNo = "6" });
            patientDetails.Add(new PatientDetails() { Name = "Darryl Saunier", ID = 7, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image10.jpg", Sex = "Male", Block = "C", RoomNo = "7" });
            patientDetails.Add(new PatientDetails() { Name = "Karina Ziolkowski", ID = 8, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image12.jpg", Sex = "Female", Block = "C", RoomNo = "8" });
            patientDetails.Add(new PatientDetails() { Name = "Tameka Douse", ID = 9, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image14.jpg", Sex = "Female", Block = "C", RoomNo = "9" });
            patientDetails.Add(new PatientDetails() { Name = "Fernando Kirschbaum", ID = 10, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image4.jpg", Sex = "Male", Block = "C", RoomNo = "10" });
            patientDetails.Add(new PatientDetails() { Name = "Fernando Kirschbaum", ID = 11, ImageName = "ms-appx:///Chart/ShowCase/HospitalDemo/Assets/Image5.jpg", Sex = "Male", Block = "C", RoomNo = "10" });


            Random rand = new Random();
            foreach (PatientDetails patient in patientDetails)
            {
                patient.BloodPressure = rand.Next(80, 190);
                patient.BloodPressure2 = rand.Next(60, 120);
                if (patient.BloodPressure > 160)
                    patient.TileColor = new SolidColorBrush(Color.FromArgb(255, 177, 16, 16));
                else
                    patient.TileColor = new SolidColorBrush(Color.FromArgb(255, 12, 144, 192));
                patient.TileIntreval = new TimeSpan(0, 0, 0, rand.Next(2, 15));
                patient.Saturation = rand.Next(80, 99);
                patient.RespirationRate = rand.Next(16, 20);
                patient.HeartRate = rand.Next(75, 150);
                patient.Temperature = rand.Next(97, 106);
            }

            List<PatientDetails> temp = patientDetails.Where(p => p.BloodPressure > 160).ToList<PatientDetails>();
            return patientDetails;
        }

        public PersonDetails ToPersonDetails()
        {
            return new PersonDetails()
            {
                Name = Name,
                Description = "Room No: " + Block + RoomNo
            };
        }

        #endregion
    }

    public class PatientHealthDetails
    {
        public IList<HealthData> GenerateData()
        {
            IList<HealthData> datas = new List<HealthData>();

            DateTime time = new DateTime(2011, 01, 01, 3, 30, 20);
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                HealthData data = new HealthData();
                data.DateTime = time;
                data.RR = random.Next(60, 80);
                data.HR = random.Next(140, 160);
                data.Sat = random.Next(20, 30);
                data.Temp = random.Next(55, 80);
                datas.Add(data);
                time = time.Add(TimeSpan.FromHours(3));
            }
            return datas;
        }
    }

    public class PersonDetails
    {
        public string ImageName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}