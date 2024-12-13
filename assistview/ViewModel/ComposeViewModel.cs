#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Syncfusion.UI.Xaml.Chat;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Controls;

namespace syncfusion.assistviewdemo.wpf.ViewModel
{
    internal class ComposeViewModel : INotifyPropertyChanged
    {
        private Author currentUser;
        Booking service;

        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        private ObservableCollection<object> chats;
        public ObservableCollection<object> Chats
        {
            get
            {
                return this.chats;
            }
            set
            {
                this.chats = value;
                RaisePropertyChanged("Messages");
            }
        }

        private IEnumerable<string> suggestion;
        public IEnumerable<string> Suggestion
        {
            get
            {
                return this.suggestion;
            }
            set
            {
                this.suggestion = value;
                RaisePropertyChanged("Suggestion");
            }
        }

        public DataTemplate AIIcon { get; set; }

        private bool showTypingIndicator;
        public bool ShowTypingIndicator
        {
            get
            {
                return this.showTypingIndicator;
            }
            set
            {
                this.showTypingIndicator = value;
                RaisePropertyChanged("ShowTypingIndicator");
            }
        }
        private string aIGeneratedContent;

        public string AIGeneratedContent
        {
            get { return aIGeneratedContent; }
            set { aIGeneratedContent = value; RaisePropertyChanged(nameof(AIGeneratedContent)); }
        }
        public string Property { get; set; }

        public ComposeViewModel()
        {
            service = new Booking();
            this.Chats = new ObservableCollection<object>();
            this.Suggestion = new List<string>();
            this.CurrentUser = new Author { Name = "John" };
        }

        internal void InitAI()
        {
            Property = service.NextQuestion();
            this.Chats.Add(new TextMessage
            {
                Author = new Author { Name = "Bot", ContentTemplate = AIIcon },
                DateTime = DateTime.Now,
                Text = service.Question
            });
            this.Suggestion = new List<string>(service.Options);


            this.Chats.CollectionChanged += Chats_CollectionChanged1;
        }

        private void Chats_CollectionChanged1(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var item = e.NewItems?[0] as ITextMessage;
            if (item != null)
            {
                if (item.Author.Name == currentUser.Name)
                {
                    Suggestion = new List<string>();
                    Send(item.Text);
                }
            }
        }

        private async void Send(string message)
        {
            ShowTypingIndicator = true;
            string response = string.Empty;
            await Task.Delay(2000);
            try
            {
                string error;
                if (service.TrySetValue(Property, message, out error))
                {
                    Property = service.NextQuestion();
                    response = service.Question;
                }
                else
                {
                    response = error;
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            Suggestion = new List<string>(service.Options);
            Chats.Add(new TextMessage
            {
                Author = new Author { Name = "Bot", ContentTemplate = AIIcon },
                DateTime = DateTime.Now,
                Text = response
            });

            ShowTypingIndicator = false;
        }

        public static string GenerateJsonSchema(Type type)
        {
            var store =
@"{
  ""type"": ""object"",
  ""properties"": {
    ""Title"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""Tone"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""Format"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""Length"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""Article"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""AIResponse"": {
      ""type"": ""string""
    },
    ""Suggestions"": {
      ""type"": ""array"",
      ""items"": {
        ""type"": [
          ""string"",
          ""null""
        ]
      }
    }
  },
  ""required"": [
    ""AIResponse"",
    ""Suggestions""
  ]
}";
            return store;
        }

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        internal async void MenuItemClicked(MenuItemClickedEventArgs e)
        {
            ShowTypingIndicator = true;
            if (e.MenuType == MenuItemType.Regenerate)
            {
                await Task.Delay(2000);
            }
            ShowTypingIndicator = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// Represents the response from AI. AI gets input from the user to write about, tone, format, length, and generates AI-generated content in markdown format.
    /// </summary>
    public class ArticleResponse : Response
    {
        /// <summary>
        /// Gets or sets the topic the user wants to write about.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the tone of the generated content. Examples: Professional, Casual, Enthusiastic, Informational, Funny, Succinct.
        /// </summary>
        public string Tone { get; set; }

        /// <summary>
        /// Gets or sets the format of the generated content. Examples: Paragraph, Email, Bullet Points, LinkedIn Post, Summary, Report.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the length of the generated content. Examples: Short, Medium, Long.
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the Article content in markdown format.
        /// </summary>
        public string Article { get; set; }

    }


    public enum Class
    {
        Economy,
        Business,
        First
    }

    public enum Airline
    {
        Emirates,
        Qatar,
        Singapore,
        Lufthansa,
        BritishAirways,
        AirFrance,
        AmericanAirlines,
        Delta,
        UnitedAirlines,
        CathayPacific
    }

    public class GetInput
    {
        public string Question { get; set; }
        public List<string> Suggestions { get; set; }
    }

    public class Booking
    {
        CountryName selectedCountry;
        City selectedCity;
        Hotel selectedHotel;

        public List<CountryName> Countries { get; set; }
        public List<City> Cities { get; set; }
        public List<Hotel> Hotels { get; set; }

        public string Name { get; set; } = "John";
        public DateTimeEdit Departure { get; set; }
        public int? NumberOfDays { get; set; }
        public bool? Return { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public Class? Class { get; set; }
        public Airline? Airline { get; set; }

        public string Question { get; set; }
        public List<string> Options { get; set; }

        public CountryName CountryName
        {
            get
            {
                return selectedCountry;
            }
            set
            {
                selectedCountry = value;
                OnSelectedCountryChanged();
            }
        }

        public City City
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnSelectedCityChanged();
            }
        }

        public Hotel Hotel
        {
            get { return selectedHotel; }
            set
            {
                selectedHotel = value;
            }
        }

        public Booking()
        {
            Countries = new List<CountryName>()
            {
                new CountryName() {
                    Name = "Australia",
                    Image = new Uri("ms-appx:///ChatDemos/Assets/Australia.png"),
                    Cities = new List<City>
                    {
                        new City{
                            Name = "Sydney",
                            Image = "ms-appx:///ChatDemos/Assets/Sydney.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Langham", Address = "89-113 Kent St, Sydney NSW 2000", Phone = "+61 2 9256 2222", Rating = "5", Price = "$200", Description = "The Langham, Sydney is a luxurious 5-star hotel that offers an indoor pool, a day spa and award-winning dining options. All rooms offer a flat-screen TV and free WiFi. The Langham Sydney is located in the historic Rocks district. The Sydney Opera House and the Sydney Harbor Bridge are within a 15-minute walk." },
                                new Hotel{ Name = "Four Seasons Hotel", Address = "199 George St, Sydney NSW 2000", Phone = "+61 2 9250 3100", Rating = "5", Price = "$250", Description = "Overlooking Sydney's historic Rocks area, Four Seasons Hotel offers free WiFi, a bar, restaurant, fitness center and swimming pool. Situated in Sydney CBD (Central Business District), it features luxurious rooms with panoramic views over the iconic Sydney Opera House and Circular Quay." },
                                new Hotel{ Name = "Shangri-La Hotel", Address = "176 Cumberland St, The Rocks NSW 2000", Phone = "+61 2 9250 6000", Rating = "5", Price = "$220", Description = "Wake up to breathtaking views of the iconic Sydney Opera House, the Harbor Bridge or Darling Harbor each morning. You will be spoiled for choice at the Shangri-La Hotel, with a day spa, fitness center and indoor pool at your disposal." }
                            }
                        },
                        new City{
                            Name = "Melbourne",
                            Image = "ms-appx:///ChatDemos/Assets/Melbourne.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Crown Towers", Address = "8 Whiteman St, Southbank VIC 3006", Phone = "+61 3 9292 6868", Rating = "5", Price = "$180", Description = "Rising above Melbourne’s vibrant Southbank precinct, Crown Towers offers spacious luxury rooms with views of the city or Port Phillip Bay. Each room features original artworks and marble bathrooms." },
                                new Hotel{ Name = "The Langham", Address = "1 Southgate Ave, Southbank VIC 3006", Phone = "+61 3 8696 8888", Rating = "5", Price = "$200", Description = "Situated on the banks of the Yarra River, The Langham, Melbourne features an indoor swimming pool with views across the city. The elegant interior includes a grand marble staircase, cascading fountains and magnificent chandeliers." },
                                new Hotel{ Name = "Grand Hyatt", Address = "123 Collins St, Melbourne VIC 3000", Phone = "+61 3 9657 1234", Rating = "5", Price = "$190", Description = "Located on Collins Street, perfectly positioned in the heart of Melbourne's shopping, dining and theater center, Grand Hyatt Melbourne comprises of luxurious guest rooms, and premium suites, all boasting contemporary living and spectacular Melbourne city skyline or picturesque Yarra River views." }
                            }
                        },
                        new City{
                            Name = "Perth",
                            Image = "ms-appx:///ChatDemos/Assets/Perth.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Crown Metropol", Address = "Great Eastern Hwy, Burswood WA 6100", Phone = "+61 8 9362 8888", Rating = "5", Price = "$150", Description = "Crown Metropol Perth offers modern and stylish accommodations within a 15 minutes’ drive from Perth’s International and Domestic Airports. Perth city center is a 5-minute drive away." },
                                new Hotel{ Name = "Pan Pacific", Address = "207 Adelaide Terrace, Perth WA 6000", Phone = "+61 8 9224 7777", Rating = "5", Price = "$160", Description = "Overlooking the Swan River and riverfront parklands, Pan Pacific Perth features a state-of-the-art fitness center, a choice of 2 restaurants and 2 bars." },
                                new Hotel{ Name = "Hyatt Regency", Address = "99 Adelaide Terrace, Perth WA 6000", Phone = "+61 8 9225 1234", Rating = "5", Price = "$140", Description = "Located in Perth CBD (Central Business District), the 5-star Duxton Hotel Perth offers luxury rooms in a great location. Facilities include a restaurant, bar, fitness center and outdoor swimming pool." }
                            }
                        },
                        new City{
                            Name = "Brisbane",
                            Image = "ms-appx:///ChatDemos/Assets/Brisbane.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "W Brisbane", Address = "81 North Quay, Brisbane QLD 4000", Phone = "+61 7 3556 8888", Rating = "5", Price = "$170", Description = "W Brisbane is located on North Quay with views of the Brisbane River. Offering 312 spacious guest rooms, W Brisbane boasts three restaurants and bars, a spa and fitness center." },
                                new Hotel{ Name = "Emporium Hotel", Address = "1000 Ann St, Fortitude Valley QLD 4006", Phone = "+61 7 3253 6999", Rating = "5", Price = "$180", Description = "Emporium Hotel South Bank is located in the heart of South Bank, adjacent to Brisbane Convention & Exhibition Center. The hotel features 143 luxuriously appointed​ ​suites with all the comforts you could ask for." },
                                new Hotel{ Name = "Hilton Brisbane", Address = "190 Elizabeth St, Brisbane City QLD 4000", Phone = "+61 7 3234 2000", Rating = "5", Price = "$160", Description = "Located in the heart of Brisbane city, Hilton Brisbane is a 30-minute drive from the Gold Coast's theme parks. The hotel features stunning city views, an indoor pool, a fitness center and a tennis court." }
                            }
                        }
                    }
                },
                new CountryName() { Name = "Canada", Image = new Uri("ms-appx:///ChatDemos/Assets/Canada.png"),
                Cities = new List<City>
                    {
                        new City{
                            Name = "Toronto",
                            Image = "ms-appx:///ChatDemos/Assets/Toronto.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Ritz-Carlton", Address = "181 Wellington St W, Toronto, ON M5V 3G7", Phone = "+1 416-585-2500", Rating = "5", Price = "$250", Description = "Located in the center of downtown Toronto, this 5-star hotel is across the street from the CN Tower and steps away from the Air Canada Center and other attractions." },
                                new Hotel{ Name = "Four Seasons Hotel", Address = "60 Yorkville Ave, Toronto, ON M4W 0A4", Phone = "+1 416-964-0411", Rating = "5", Price = "$230", Description = "Located in the Yorkville, in the heart of Toronto's most fashionable shopping, dining and entertainment district, the new Four Seasons Hotel Toronto offers 259 spacious guest rooms." },
                                new Hotel{ Name = "The Hazelton Hotel", Address = "118 Yorkville Ave, Toronto, ON M5R 1C2", Phone = "+1 416-963-6300", Rating = "5", Price = "$220", Description = "This hotel is located in the upscale district of Yorkville and is near a number of Toronto's finest restaurants. A full service spa, boasting world class spa treatments is available." }
                            }
                        },
                        new City{
                            Name = "Vancouver",
                            Image = "ms-appx:///ChatDemos/Assets/Vancouver.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Fairmont Pacific Rim", Address = "1038 Canada Pl, Vancouver, BC V6C 0B9", Phone = "+1 604-695-5300", Rating = "5", Price = "$240", Description = "This hotel is located in the financial district of Vancouver city center and offers on-site dining and a bar. A spa and fitness center are available. Stanley Park is 1.5 mi away." },
                                new Hotel{ Name = "Shangri-La Hotel", Address = "1128 W Georgia St, Vancouver, BC V6E 0A8", Phone = "+1 604-689-1120", Rating = "5", Price = "$230", Description = "Featuring a full service spa, Shangri-La Hotel offers easy access to luxury shopping, art installations and trendy restaurants and bars. Guests can enjoy views of Vancouver city center." },
                                new Hotel{ Name = "The Sutton Place Hotel", Address = "845 Burrard St, Vancouver, BC V6Z 2K6", Phone = "+1 604-682-5511", Rating = "5", Price = "$220", Description = "This hotel is located in the heart of downtown Vancouver and is 5 minutes’ walk from Coal Harbor and Vancouver Convention Center. An indoor pool and hot tub are featured." }
                            }
                        },
                        new City{
                            Name = "Montreal",
                            Image = "ms-appx:///ChatDemos/Assets/Montreal.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Ritz-Carlton Montreal", Address = "1228 Sherbrooke St W, Montreal, QC H3G 1H6", Phone = "+1 514-842-4212", Rating = "5", Price = "$220", Description = "Located in the Golden Square Mile, this luxury hotel is 2 minutes' walk from the Montreal Museum of Fine Arts. The hotel offers a full-service spa, a gourmet restaurant and a modern gym." },
                                new Hotel{ Name = "Hotel Birks Montreal", Address = "1240 Phillips Square, Montreal, QC H3B 3H4", Phone = "+1 514-954-1111", Rating = "5", Price = "$210", Description = "Located in Downtown Montreal, this elegant hotel and spa is 5 minutes' walk from the Bell Center. It features a saltwater pool and free WiFi." },
                                new Hotel{ Name = "Hotel Le St-James", Address = "355 Saint-Jacques St, Montreal, QC H2Y 1N9", Phone = "+1 514-841-3111", Rating = "5", Price = "$200", Description = "Located in Old Montreal, only steps from many attractions, this historic hotel offers European elegance, along with first-class services and an extensive selection of on-site dining options." }
                            }
                        },
                        new City{
                            Name = "Calgary",
                            Image = "ms-appx:///ChatDemos/Assets/Calgary.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Fairmont Palliser", Address = "133 9 Ave SW, Calgary, AB T2P 2M3", Phone = "+1 403-262-1234", Rating = "5", Price = "$200", Description = "Featuring a large indoor pool and hot tub, this luxurious hotel is connected to the Calgary Telus Convention Center by skywalk. Several on-site dining options are available. Guest rooms feature cable TV with pay per view and a work desk." },
                                new Hotel{ Name = "Hyatt Regency", Address = "700 Centre St S, Calgary, AB T2G 5P6", Phone = "+1 403-717-1234", Rating = "5", Price = "$190", Description = "Featuring an outdoor seasonal pool and on-site restaurant, Hyatt Regency Calgary is located in the city center of Calgary. A fitness center and sauna are available for guest use. Free WiFi is provided." },
                                new Hotel{ Name = "Hotel Arts", Address = "119 12 Ave SW, Calgary, AB T2R 0G8", Phone = "+1 403-266-4611", Rating = "5", Price = "$180", Description = "Offering an outdoor pool and bar with city views, Hotel Arts is located in Calgary city center. Free WiFi is provided throughout the property. A flat-screen TV features in each room. " }
                            }
                        }
                    }
                },
                new CountryName() {
                    Name = "France",
                    Image = new Uri("ms-appx:///ChatDemos/Assets/France.png"),
                    Cities = new List<City>
                    {
                        new City{
                            Name = "Paris",
                            Image = "ms-appx:///ChatDemos/Assets/Paris.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Four Seasons Hotel", Address = "3 Rue du Faubourg Saint-Honoré, 75008 Paris", Phone = "+33 1 49 52 70 00", Rating = "5", Price = "$250", Description = "Le Meurice is a hotel palace located in central Paris. It offers a 2-star Michelin restaurant as well as a spa and a fitness center with massage treatments. Decorated in a 18th century style, with Louis XVI furniture, a flat-screen TV with international channels and DVD player are provided in the air-conditioned rooms." },
                                new Hotel{ Name = "Shangri-La Hotel", Address = "10 Avenue d'Iéna, 75116 Paris", Phone = "+33 1 53 67 19 98", Rating = "5", Price = "$230", Description = "A former residence of Prince Roland Bonaparte and listed in the French “Monuments Historiques”, Shangri-La Hotel, Paris is a hotel palace located across the Seine and facing the Eiffel Tower. It reflects both Asian hospitality and French art de vivre." },
                                new Hotel{ Name = "The Peninsula", Address = "19 Avenue Kléber, 75116 Paris", Phone = "+33 1 58 12 28 88", Rating = "5", Price = "$220", Description = "The Peninsula sits in the heart of Paris and is within walking distance of famous monuments, museums, and luxury shopping. The hotel features a rooftop restaurant, a bar, a spa, and a 50-foot indoor pool." }
                            }
                        },
                        new City{
                            Name = "Nice",
                            Image = "ms-appx:///ChatDemos/Assets/Nice.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Hyatt Regency", Address = "13 Promenade des Anglais, 06000 Nice", Phone = "+33 4 93 27 12 34", Rating = "5", Price = "$180", Description = "Located on the Promenade des Anglais, Hyatt Regency Nice Palais de la Méditerranée is an art-deco style hotel featuring an on-site casino, an indoor and outdoor swimming pool, a hammam, a sauna, a fitness center and a private beach." },
                                new Hotel{ Name = "Le Negresco", Address = "37 Prom. des Anglais, 06000 Nice", Phone = "+33 4 93 16 64 00", Rating = "5", Price = "$170", Description = "The famous Hotel Negresco, dating from the beginning of the 20th century, overlooks the beach and the Promenade des Anglais in Nice. From Louis XIII style to modern art, 5 centuries of history are exhibited throughout the hotel." },
                                new Hotel{ Name = "Hotel Le Royal", Address = "23 Prom. des Anglais, 06000 Nice", Phone = "+33 4 97 03 44 44", Rating = "5", Price = "$160", Description = "Located on the Promenade des Anglais, Radisson Blu Hotel Nice features a private beach and a rooftop swimming pool offering panoramic views of the Mediterranean Sea. Free WiFi is available throughout the entire property." }
                            }
                        },
                        new City{
                            Name = "Lyon",
                            Image = "ms-appx:///ChatDemos/Assets/Lyon.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Villa Maïa", Address = "8 Rue du Professeur Pierre Marion, 69005 Lyon", Phone = "+33 4 78 16 01 01", Rating = "5", Price = "$160", Description = "Located in Lyon, 1.1 mi from the Museum of Fine Arts of Lyon, Villa Maïa features a fitness center and sauna. Free WiFi is available." },
                                new Hotel{ Name = "Cour des Loges", Address = "6 Rue du Bœuf, 69005 Lyon", Phone = "+33 4 72 77 44 44", Rating = "5", Price = "$150", Description = "Located in Old Lyon, Cour des Loges comprises 4 restored Renaissance buildings set around a glass-roofed courtyard. It features 2 restaurants and a wine cellar. Free WiFi is available throughout the hotel." },
                                new Hotel{ Name = "Sofitel Lyon Bellecour", Address = "20 Quai Gailleton, 69002 Lyon", Phone = "+33 4 72 41 20 20", Rating = "5", Price = "$140", Description = "Located in the heart of Lyon, this 5-star hotel is located a 6-minute walk from Place Bellecour. Free WiFi is available throughout the property." }
                            }
                        },
                        new City{
                            Name = "Marseille",
                            Image = "ms-appx:///ChatDemos/Assets/Marseille.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "InterContinental", Address = "1 Place Daviel, 13002 Marseille", Phone = "+33 4 13 42 42 42", Rating = "5", Price = "$150", Description = "Located in Marseille overlooking the Vieux Port, Radisson Blu Hotel Marseille Vieux Port is a 4-star hotel. It offers an outdoor swimming pool overlooking Fort Saint-Nicholas and a fitness room with a panoramic view of the main monuments of the city." },
                                new Hotel{ Name = "Sofitel Marseille", Address = "36 Boulevard Charles Livon, 13007 Marseille", Phone = "+33 4 91 15 59 00", Rating = "5", Price = "$140", Description = "Sofitel Marseille Vieux-Port offers a fitness center, a spa with a hot tub, and a terrace overlooking the Marseille Old Port. Some air-conditioned guest rooms have a terrace with harbor views." },
                                new Hotel{ Name = "Hotel C2", Address = "48 Rue Roux de Brignoles, 13006 Marseille", Phone = "+33 4 95 05 13 13", Rating = "5", Price = "$130", Description = "Featuring a grand piano, HOTEL C2, located in the Pierre Puget courtyard in Marseille, is a 19th-century private mansion converted into a hotel. It features the original marble and parquet floors, columns, bas-relief sculptures, frescoes and bronze banisters, whilst offering a minimalist, contemporary twist." }
                            }
                        }
                    }
                },
                new CountryName() {
                    Name = "Germany",
                    Image = new Uri("ms-appx:///ChatDemos/Assets/Germany.png"),
                    Cities = new List<City>
                    {
                        new City{
                            Name = "Berlin",
                            Image = "ms-appx:///ChatDemos/Assets/Berlin.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Hotel Adlon Kempinski", Address = "Unter den Linden 77, 10117 Berlin", Phone = "+49 30 22610", Rating = "5", Price = "$200", Description = "The quintessence of luxury lodging, the Adlon is a legendary 5-star hotel situated in Berlin’s Mitte, beside the Brandenburg Gate. State-of-the-art facilities include a double Michelin-star restaurant and a shopping arcade." },
                                new Hotel{ Name = "The Ritz-Carlton", Address = "Potsdamer Platz 3, 10785 Berlin", Phone = "+49 30 337777", Rating = "5", Price = "$190", Description = "This 5-star hotel at Berlin’s Potsdamer Platz Square features a luxury spa with pool. Its elegant rooms have touch-screen controls and marble bathrooms. The Ritz-Carlton, Berlin offers a grill restaurant and a sushi restaurant." },
                                new Hotel{ Name = "Regent Berlin", Address = "Charlottenstraße 49, 10117 Berlin", Phone = "+49 30 2033630", Rating = "5", Price = "$180", Description = "Ideally located on Berlin's Gendarmenmarkt Square, this classic-style, 5-star hotel offers a casual dining at the Charlotte & Fritz restaurant, exclusive spa facilities, and free WiFi." }
                            }
                        },
                        new City{
                            Name = "Munich",
                            Image = "ms-appx:///ChatDemos/Assets/Munich.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Hotel Bayerischer Hof", Address = "Promenadeplatz 2-6, 80333 Munich", Phone = "+49 89 21200", Rating = "5", Price = "$180", Description = "Offering 5 gourmet restaurants, 6 bars, and an exclusive spa with rooftop pool, this historic 5-star hotel is located directly in Munich’s fashionable shopping district." },
                                new Hotel{ Name = "Sofitel Munich Bayerpost", Address = "Bayerstraße 12, 80335 Munich", Phone = "+49 89 599480", Rating = "5", Price = "$170", Description = "This 5-star hotel with free Wi-Fi and design interiors is just 328 feet from Munich Main Station. Spa facilities at the Sofitel Munich include an indoor swimming pool, sauna and modern fitness studio." },
                                new Hotel{ Name = "Mandarin Oriental", Address = "Neuturmstraße 1, 80331 Munich", Phone = "+49 89 290980", Rating = "5", Price = "$160", Description = "Luxurious rooms, and the famous Matsuhisa, Munich restaurant are featured at this 5-star hotel in the heart of Munich's Old Town. It is located in a historic building offers a stylish spa with indoor pool, and free Wi-Fi." }
                            }
                        },
                        new City{
                            Name = "Hamburg",
                            Image = "ms-appx:///ChatDemos/Assets/Hamburg.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Fairmont Hotel Vier Jahreszeiten", Address = "Neuer Jungfernstieg 9-14, 20354 Hamburg", Phone = "+49 40 34940", Rating = "5", Price = "$170", Description = "Overlooking Außenalster Lake, this classic 5-star hotel offers free Wi-Fi, an elegant spa with indoor pool, a private cinema, and a gourmet restaurant. Hamburg Central Station is 500 meters away." },
                                new Hotel{ Name = "Park Hyatt", Address = "Bugenhagenstraße 8, 20095 Hamburg", Phone = "+49 40 33321234", Rating = "5", Price = "$160", Description = "Spacious rooms with Bang & Olufsen flat-screen TVs and a free spa with indoor pool are featured at this hotel in the Mönckebergstraße shopping street. The hotel has a private underground car park." },
                                new Hotel{ Name = "The Westin", Address = "Elbchaussee 401-403, 22609 Hamburg", Phone = "+49 40 897280", Rating = "5", Price = "$150", Description = "This hotel in Hamburg’s St. Georg district offers free Wi-Fi, a sauna, gym, and a private garden. The Alster Lake and Jungfernstieg shopping street are a 7-minute walk away." }
                            }
                        },
                    }
                },
                new CountryName() {
                    Name = "India",
                    Image = new Uri("ms-appx:///ChatDemos/Assets/India.png"),
                    Cities = new List<City>
                    {
                        new City{
                            Name = "Delhi",
                            Image = "ms-appx:///ChatDemos/Assets/Delhi.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Leela Palace", Address = "Diplomatic Enclave, Chanakyapuri, New Delhi, Delhi 110023", Phone = "+91 11 3933 1234", Rating = "5", Price = "$200", Description = "Located in New Delhi's Diplomatic Enclave, The Leela Palace New Delhi is a blend of Lutyen's architecture and the royal Indian culture. A pampering spa, 4 dining options and free parking are available." },
                                new Hotel{ Name = "The Oberoi", Address = "Dr Zakir Hussain Marg, New Delhi, Delhi 110003", Phone = "+91 11 2436 3030", Rating = "5", Price = "$190", Description = "The Lodhi – A member of The Leading Hotels Of The World is located in New Delhi. The property is centered around a courtyard with a large swimming pool." },
                                new Hotel{ Name = "The Taj Mahal", Address = "Number One Mansingh Road, New Delhi, Delhi 110011", Phone = "+91 11 6656 6162", Rating = "5", Price = "$180", Description = "Located in the heart of Lutyen’s Delhi, Taj Mahal Hotel New Delhi offers luxurious accommodations located amid 6 acres of landscaped grounds. Featuring 7 dining options, 5-star facilities include a state-of-the-art fitness center, an outdoor pool and spa." }
                            }
                        },
                        new City{
                            Name = "Mumbai",
                            Image = "ms-appx:///ChatDemos/Assets/Mumbai.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Oberoi", Address = "Nariman Point, Mumbai, Maharashtra 400021", Phone = "+91 22 6632 5757", Rating = "5", Price = "$190", Description = "Centrally located in Mumbai's business district, close to South Mumbai's shopping and entertainment areas, The Oberoi offers luxury and convenience with its outdoor heated pool, 24-hour spa, fitness and concierge service." },
                                new Hotel{ Name = "The Taj Mahal Palace", Address = "Apollo Bunder, Mumbai, Maharashtra 400001", Phone = "+91 22 6665 3366", Rating = "5", Price = "$180", Description = "Built in 1973, the iconic The Taj Mahal Tower Mumbai stands majestically across from the Gateway of India, overlooking the Arabian Sea. The Tower stands in harmonious contrast to The Taj Mahal Palace." },
                                new Hotel{ Name = "The St. Regis", Address = "462, Senapati Bapat Marg, Lower Parel, Mumbai, Maharashtra 400013", Phone = "+91 22 6162 8000", Rating = "5", Price = "$170", Description = "Situated in Mumbai's Worli area, The St. Regis Mumbai is a 5-minute drive away from Lower Parel, the city's premier commercial and entertainment hub. It is 8 km from the famous Siddhivinayak Temple and 15 km from Shivaji Park." }
                            }
                        },
                        new City{
                            Name = "Chennai",
                            Image = "ms-appx:///ChatDemos/Assets/Chennai.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Leela Palace", Address = "Adyar Seaface, MRC Nagar, Chennai, Tamil Nadu 600028", Phone = "+91 44 3366 1234", Rating = "5", Price = "$180", Description = "The luxurious Leela Palace Chennai is located on the Adyar Seaface and offers a sea-facing city retreat. It has an outdoor pool, a spa, and 4 dining options. Adyar Seaface is 1.2 mi and Ramee Mall is 2.7 mi." },
                                new Hotel{ Name = "ITC Grand Chola", Address = "63, Mount Road, Guindy, Chennai, Tamil Nadu 600032", Phone = "+91 44 2220 0000", Rating = "5", Price = "$170", Description = "ITC Grand Chola is a 10-minute drive from the Chennai International Airport and the Tidel Park. It features 10 dining options and an outdoor swimming pool and a fitness center." },
                                new Hotel{ Name = "The Park", Address = "601, Anna Salai, Near US Embassy, Chennai, Tamil Nadu 600006", Phone = "+91 44 4267 6000", Rating = "5", Price = "$160", Description = "The luxurious Raintree Anna Salai Hotel is located a 20-minute drive from Chennai International Airport. It provides well-appointed rooms and 5-star facilities like a pool, a spa and a sauna." }
                            }
                        },
                    }
                },
                new CountryName() {
                    Name = "Italy",
                    Image = new Uri("ms-appx:///ChatDemos/Assets/Italy.png"),
                    Cities = new List<City>
                    {
                        new City{
                            Name = "Rome",
                            Image = "ms-appx:///ChatDemos/Assets/Rome.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Hotel Hassler", Address = "Piazza Trinità dei Monti, 6, 00187 Roma RM, Italy", Phone = "+39 06 699340", Rating = "5", Price = "$250", Description = "Set at the top of the Spanish Steps, Hassler Roma is one of the city's most famous hotels. It offers elegant rooms and suites with high-speed free WiFi, and free wellness facilities including a sauna, Turkish bath and gym." },
                                new Hotel{ Name = "The St. Regis", Address = "Via Vittorio E. Orlando, 3, 00185 Roma RM, Italy", Phone = "+39 06 47091", Rating = "5", Price = "$240", Description = "Boasting a stunning location just above the Spanish Steps, Rocco Forte Hotel De La Ville offers 3 restaurants, a spa, and elegant rooms with free WiFi and city views. The Trevi Fountain is a 5-minute walk away." },
                                new Hotel{ Name = "The Westin", Address = "Via Giuseppe Zanardelli, 14, 00186 Roma RM, Italy", Phone = "+39 06 6889 1", Rating = "5", Price = "$230", Description = "Set in a 19th-century building, The Westin Excelsior is located in Rome’s fashionable Via Veneto. It features a wellness center with a large indoor pool and a well-equipped gym." }
                            }
                        },
                        new City{
                            Name = "Venice",
                            Image = "ms-appx:///ChatDemos/Assets/Venice.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Gritti Palace", Address = "Campo Santa Maria del Giglio, 2467, 30124 Venezia VE, Italy", Phone = "+39 041 794611", Rating = "5", Price = "$240", Description = "The Gritti Palace is an exclusive hotel where history and culture meet with renewed Venetian style. A place of exceptional art and elegance, the restored Gritti Palace retains its reassuringly intimate and familiar feel." },
                                new Hotel{ Name = "Hotel Danieli", Address = "Riva degli Schiavoni, 4196, 30122 Venezia VE, Italy", Phone = "+39 041 5226480", Rating = "5", Price = "$230", Description = "Overlooking Venice Lagoon, Hotel Danieli is a legendary hotel 200 yards from St. Mark's Square. Each room is spacious and finely furnished. The staff provides an unmatchable service." },
                                new Hotel{ Name = "The St. Regis", Address = "San Marco 2159, 30124 Venezia VE, Italy", Phone = "+39 041 2400001", Rating = "5", Price = "$220", Description = "The St. Regis Venice features wonderful views of the Grand Canal. It features a panoramic restaurant and bar, and Venetian-style decor. The hotel has marble interiors with lavish and design furniture." }
                            }
                        },
                        new City{
                            Name = "Milan",
                            Image = "ms-appx:///ChatDemos/Assets/Milan.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "Park Hyatt", Address = "Via Tommaso Grossi, 1, 20121 Milano MI, Italy", Phone = "+39 02 8821 1234", Rating = "5", Price = "$230", Description = "Facing the entrance of the Galleria Vittorio Emanuele, Park Hyatt Milano is set in the heart of the fashion district, 200 yards from the Cathedral and La Scala Theater. The hotel features free WiFi, a spa and gym." },
                                new Hotel{ Name = "Bulgari Hotel", Address = "Via Privata Fratelli Gabba, 7b, 20121 Milano MI, Italy", Phone = "+39 02 805 8051", Rating = "5", Price = "$220", Description = "Bulgari Hotel Milano is probably the most refined and exclusive establishment in Milan, a boutique property adjacent to the most important shopping street, Via Montenapoleone." },
                                new Hotel{ Name = "Armani Hotel", Address = "Via Alessandro Manzoni, 31, 20121 Milano MI, Italy", Phone = "+39 02 8883 8888", Rating = "5", Price = "$210", Description = "Just 150 yards from Montenapoleone Metro Station, Four Seasons Hotel Milano offers luxurious rooms in Milan’s shopping district. The Cathedral is a 10-minute walk away and Wi-Fi is free throughout." }
                            }
                        }
                    }
                },
                new CountryName() {
                    Name = "Japan",
                    Image = new Uri("ms-appx:///ChatDemos/Assets/Japan.png"),
                    Cities = new List<City>
                    {
                        new City{
                            Name = "Tokyo",
                            Image = "ms-appx:///ChatDemos/Assets/Tokyo.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Peninsula", Address = "1-8-1 Yurakucho, Chiyoda-ku, Tokyo 100-0006", Phone = "+81 3 6270 2888", Rating = "5", Price = "$250", Description = "Offering high-floor views of the city and Tokyo Bay, 5-star room at The Peninsula Tokyo feature a large plasma-screen TV. A dressing room, mood lighting and a large private bathroom with a bathtub are included." },
                                new Hotel{ Name = "The Ritz-Carlton", Address = "9-7-1 Akasaka, Minato-ku, Tokyo 107-6245", Phone = "+81 3 3423 8000", Rating = "5", Price = "$240", Description = "Located at the heart of the downtown Roppongi area in Tokyo's tallest building, the 53rd-story Ritz-Carlton offers elegant luxury high above Tokyo’s busy streets. It features an indoor pool and 8 dining options." },
                                new Hotel{ Name = "Mandarin Oriental", Address = "2-1-1 Nihonbashi Muromachi, Chuo-ku, Tokyo 103-8328", Phone = "+81 3 3270 8800", Rating = "5", Price = "$230", Description = "Mandarin Oriental Tokyo offers an award-winning luxury experience with 3 Michelin-star dining, a spa and wellness center and the spacious guest rooms and suites offer the chic décor and modern conveniences." }
                            }
                        },
                        new City{
                            Name = "Kyoto",
                            Image = "ms-appx:///ChatDemos/Assets/Kyoto.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Ritz-Carlton", Address = "Kamogawa Nijo-Ohashi Hotori, Nakagyo-ku, Kyoto 604-0902", Phone = "+81 75 746 5555", Rating = "5", Price = "$240", Description = "The Ritz-Carlton, Kyoto features a peaceful setting within the Kamogawa River facing the Higashiyama Mountains. The hotel includes a spa, indoor pool, fitness center, and various dining options." },
                                new Hotel{ Name = "Four Seasons Hotel", Address = "445-3 Myohoin Maekawacho, Higashiyama-ku, Kyoto 605-0932", Phone = "+81 75 541 8288", Rating = "5", Price = "$230", Description = "Awarded the TripAdvisor Certificate of Excellence in 2013, 2014, 2015, 2016, 2017, 2018 and 2019, Four Seasons Hotel Kyoto features a modern embodiment of the traditional Japanese garden." },
                                new Hotel{ Name = "Hyatt Regency", Address = "644-2 Sanjusangendo-mawari, Higashiyama-ku, Kyoto 605-0941", Phone = "+81 75 541 1234", Rating = "5", Price = "$220", Description = "Located just a 5-minute walk from the iconic Sanjusangendo Temple, Hyatt Regency Kyoto offers a spa, 3 restaurants and a bar. The elegant rooms are spacious and come with a flat-screen TV, DVD player and an en suite bathroom." }
                            }
                        },
                        new City{
                            Name = "Osaka",
                            Image = "ms-appx:///ChatDemos/Assets/Osaka.png",
                            Hotels = new List<Hotel>
                            {
                                new Hotel{ Name = "The Ritz-Carlton", Address = "2-5-25 Umeda, Kita-ku, Osaka 530-0001", Phone = "+81 6 6343 7000", Rating = "5", Price = "$230", Description = "Located in the heart of Osaka city, the Ritz-Carlton Osaka offers luxurious rooms with panoramic city views, a 24-hour fitness center, and a spa with a sauna, a hot tub and a plunge pool." },
                                new Hotel{ Name = "InterContinental", Address = "3-60 Ofuka-cho, Kita-ku, Osaka 530-0011", Phone = "+81 6 6374 5700", Rating = "5", Price = "$220", Description = "Located in the heart of Osaka, InterContinental Osaka offers rooms with city views and free WiFi. The hotel features 5 dining options, a 24-hour fitness center and a spa with massage services." },
                                new Hotel{ Name = "The St. Regis", Address = "3-6-12 Honmachi, Chuo-ku, Osaka 541-0053", Phone = "+81 6 6258 3333", Rating = "5", Price = "$210", Description = "The St. Regis Osaka is located on the Honmachi street, a 5-minute walk from Shinsaibashi Station. The hotel features a 24-hour fitness center, 3 dining options and rooms with 24-hour room service." }
                            }
                        }
                    }
                },
            };
            Cities = new List<City>();
            Hotels = new List<Hotel>();
            //     Departure = new DateTimeEdit();
            Questions = new Dictionary<string, GetInput>()
            {
                { nameof(Name), new GetInput
                    {
                        Question = "What's your name?",
                        Suggestions = new List<string> { "A", "B" }
                    }
                },
                {
                    nameof(Departure), new GetInput {
                        Question = "When are you planning to depart?",
                        Suggestions = new List<string> {typeof(DateTime).ToString()}
                    }
                },
                { nameof(NumberOfDays), new GetInput
                    {
                        Question = "How many days would you like to stay?",
                        Suggestions = new List<string> {"2", "4", "8", "16", typeof(int).ToString() }
                    }
                },
                { nameof(Adults), new GetInput
                    {
                        Question = "How many adults are traveling?",
                        Suggestions = new List<string> {"1", "2", "3", typeof(int).ToString() }
                    }
                },
                { nameof(Children), new GetInput
                    {
                        Question = "How many children are traveling?",
                        Suggestions = new List<string> {"1", "2", "3", typeof(int).ToString() }
                    }
                },
                { nameof(Class), new GetInput
                    {
                        Question = "What class would you like to travel in?",
                        Suggestions = new List<string> {typeof(Class).ToString()}
                    }
                },
                { nameof(Airline), new GetInput
                    {
                        Question = "Do you have a preferred airline?",
                        Suggestions = new List<string> { typeof(Airline).ToString() }
                    }
                },
                { nameof(Return), new GetInput
                    {
                        Question = "Will this be a round-trip booking?",
                        Suggestions = new List<string> { "Yes", "No" }
                    }
                },
                { nameof(CountryName), new GetInput
                    {
                        Question = $"Welcome {Name}! Where would you like to go?",
                        Suggestions = Countries
                .Where(country => country != null)  // Ensure the country is not null (optional check)
                .Select(country => country.Name)    // Select the Name property of each CountryName
                .ToList()
                       // Ensure Countries is properly defined
                    }
                },
                { nameof(City), new GetInput
                    {
                        Question = $"Which city would you like to visit?",
                        Suggestions = new List<string>()
                    }
                },
                { nameof(Hotel), new GetInput
                    {
                        Question = $"Please select a hotel.",
                        Suggestions = new List<string>()
                    }
                },
            };
        }

        private void OnSelectedCountryChanged()
        {
            if (CountryName != null)
            {
                Cities = CountryName.Cities;
                Questions[nameof(City)].Suggestions = Cities
                .Where(country => country != null)  // Ensure the country is not null (optional check)
                .Select(country => country.Name)    // Select the Name property of each CountryName
                .ToList();
            }
            else
            {
                Cities = new List<City>();
                Questions[nameof(City)].Suggestions = new List<string>();
                City = null;
            }
        }

        private void OnSelectedCityChanged()
        {
            if (City != null)
            {
                Hotels = City.Hotels;
                Questions[nameof(Hotel)].Suggestions = Hotels
                .Where(hotel => hotel != null)  // Ensure the country is not null (optional check)
                .Select(hotel => hotel.Name)    // Select the Name property of each CountryName
                .ToList();
            }
            else
            {
                Hotels = new List<Hotel>();
                Questions[nameof(Hotel)].Suggestions = new List<string>();
                Hotel = null;
            }
        }

        private Dictionary<string, GetInput> Questions { get; set; }

        public string NextQuestion()
        {
            string nextInput = Name == null ?
                nameof(Name) :
                CountryName == null ?
                nameof(CountryName) :
                City == null ?
                nameof(City) :
                Hotel == null ?
                nameof(Hotel) :
                Departure == null ?
                nameof(Departure) :
                NumberOfDays == null ?
                nameof(NumberOfDays) :
                Return == null ?
                nameof(Return) :
                Adults == null ?
                nameof(Adults) :
                Children == null ?
                nameof(Children) :
                Class == null ?
                nameof(Class) :
                Airline == null ?
                nameof(Airline) :
                null;

            if (nextInput == null)
            {
                Question = "Thank you for providing the information. Your trip details are as follows: \n\n" +
                    $"NAME: {Name}\n\n" +
                    $"DEPARTURE: {Departure.DateTime.ToDateTime().ToString("d")}\n\n" +
                    $"NUMBER OF DAYS: {NumberOfDays}\n\n" +
                    $"ADULTS: {Adults}\n\n" +
                    $"CHILDREN: {Children}\n\n" +
                    $"CLASS: {Class}\n\n";
                Options = new List<string>();
            }
            else
            {
                var q = Questions[nextInput];
                Question = q.Question;
                Options = q.Suggestions;
            }
            return nextInput;
        }

        public bool TrySetValue(string prop, string value, out string error)
        {
            DateTime departure;
            int days;
            int adults;
            int children;
            Class travelClass;
            Airline airline;

            switch (prop)
            {
                case nameof(Name):
                    Name = value;
                    break;
                case nameof(Departure):
                    if (DateTime.TryParse(value, out departure))
                    {
                        if (departure < DateTime.Now)
                        {
                            error = "Invalid date. Please enter a valid date.";
                            return false;
                        }
                        Departure = new DateTimeEdit();
                        Departure.DateTime = departure;
                    }
                    else
                    {
                        error = "Invalid date format. Please enter a valid date.";
                        return false;
                    }
                    break;
                case nameof(NumberOfDays):
                    if ((int.TryParse(value, out days)))
                    {
                        if (days < 1)
                        {
                            error = "Invalid number of days. Please enter a valid number.";
                            return false;
                        }
                        NumberOfDays = days;
                    }
                    else
                    {
                        error = "Invalid number of days. Please enter a valid number.";
                        return false;
                    }
                    break;
                case nameof(Adults):
                    if ((int.TryParse(value, out adults)))
                    {
                        if (adults < 1)
                        {
                            error = "Invalid number of adults. Please enter a valid number.";
                            return false;
                        }
                        Adults = adults;
                    }
                    else
                    {
                        error = "Invalid number of adults. Please enter a valid number.";
                        return false;
                    }
                    break;
                case nameof(Children):
                    if ((int.TryParse(value, out children)))
                    {
                        if (children < 0)
                        {
                            error = "Invalid number of children. Please enter a valid number.";
                            return false;
                        }
                        Children = children;
                    }
                    else
                    {
                        error = "Invalid number of children. Please enter a valid number.";
                        return false;
                    }
                    break;
                case nameof(Class):
                    if (Enum.TryParse<Class>(value, out travelClass))
                    {
                        Class = travelClass;
                    }
                    else
                    {
                        error = "Invalid travel class. Please select a valid travel class.";
                        return false;
                    }
                    break;
                case nameof(Airline):
                    if ((Enum.TryParse<Airline>(value, out airline)))
                    {
                        Airline = airline;
                    }
                    else
                    {
                        error = "Invalid airline. Please select a valid airline.";
                        return false;
                    }
                    break;
                case nameof(Return):
                    Return = value == "Yes";
                    break;
                case nameof(CountryName):
                    CountryName = Countries.FirstOrDefault(c => c.Name.ToLower() == value.ToLower());
                    break;
                case nameof(City):
                    City = Cities.FirstOrDefault(c => c.Name.ToLower() == value.ToLower());
                    break;
                case nameof(Hotel):
                    Hotel = Hotels.FirstOrDefault(h => h.Name.ToLower() == value.ToLower());
                    break;
            }
            error = null;
            return true;
        }
    }

    public class CountryName
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public List<City> Cities { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Hotel> Hotels { get; set; }
    }

    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Rating { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class SuggestionUISelector : SuggestionTemplateSelector
    {
        public SuggestionUISelector()
        {

        }

        public DataTemplate DateOnlyTemplate { get; set; }
        public DataTemplate ComboBoxTemplate { get; set; }
        public DataTemplate CarouselTemplate { get; set; }
        public DataTemplate NumericTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string template = item.ToString();

            if (item is string)
            {
                if (template == "System.DateTime")
                {
                    return DateOnlyTemplate;
                }
                else if (template == typeof(Class).ToString())
                {
                    return ComboBoxTemplate;
                }
                else if (template == typeof(Airline).ToString())
                {
                    return ComboBoxTemplate;
                }
                else if (template == typeof(int).ToString())
                {
                    return NumericTemplate;
                }
            }
            else if (item is IList)
            {
                return CarouselTemplate;
            }


            return base.SelectTemplate(item, container);
        }
    }


    public class SelectionBehavior : ISuggestionSelectionBehavior
    {
        public SelectionBehavior()
        {

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object newValue = e.AddedItems[0].ToString();
            CountryName country = new CountryName();
            City city = new City();
            Hotel hotel = new Hotel();

            if (newValue == country)
            {
                newValue = country.Name;
            }
            else if (newValue == city)
            {
                newValue = city.Name;
            }
            else if (newValue == hotel)
            {
                newValue = hotel.Name;
            }
            var args = new SuggestionClickedEventArgs(newValue, sender as UIElement);
            RaiseEvent(sender, args);
        }

        private void RaiseEvent(object sender, SuggestionClickedEventArgs args)
        {
            if (Selected != null)
            {
                Selected.Invoke(sender, args);
            }
        }

        public void Attach(object obj)
        {
            DateTimeEdit dp = new Syncfusion.Windows.Shared.DateTimeEdit();
            ComboBox cb = new ComboBox();
            ListBox lb = new ListBox();
            IntegerTextBox nb = new IntegerTextBox();

            if (obj.GetType() == dp.GetType())
            {
                DateTimeEdit date = obj as DateTimeEdit;
                date.DateTimeChanged += Dp_DateTimeChanged; ;
            }
            else if (obj.GetType() == cb.GetType())
            {
                ComboBox combo = obj as ComboBox;
                var type = Type.GetType(combo.DataContext as string);
                combo.ItemsSource = Enum.GetValues(type).Cast<object>().ToList();
                //cb.PlaceholderText = "Select";
                combo.SelectionChanged += ComboBox_SelectionChanged;
            }
            else if (obj.GetType() == lb.GetType())
            {
                lb.ItemsSource = (IEnumerable)lb.DataContext;
                lb.SelectionChanged += ComboBox_SelectionChanged;
            }
            else if (obj.GetType() == nb.GetType())
            {
                IntegerTextBox nb1 = obj as IntegerTextBox;
                nb1.PreviewKeyDown += Nb1_PreviewKeyDown; 
            }
        }

        private void Nb1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var args = new SuggestionClickedEventArgs((sender as IntegerTextBox).Text, sender as UIElement);
                RaiseEvent(sender, args);
            }
        }

        private void Dp_DateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var args = new SuggestionClickedEventArgs(string.Format("{0:d}", e.NewValue), d as UIElement);
            RaiseEvent(d, args);
        }

        private void Nb_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var args = new SuggestionClickedEventArgs(e.NewValue, d as UIElement);
            RaiseEvent(d, args);
        }

        public void Detach(object obj)
        {
            DateTimeEdit dp = new DateTimeEdit();
            ComboBox cb = new ComboBox();
            ListBox lb = new ListBox();
            IntegerTextBox nb = new IntegerTextBox();

            if (obj == dp)
            {
                dp.DateTimeChanged -= Dp_DateTimeChanged;
            }
            else if (obj == cb)
            {
                cb.SelectionChanged -= ComboBox_SelectionChanged;
            }
            else if (obj == lb)
            {
                lb.SelectionChanged -= ComboBox_SelectionChanged;
            }
            else if (obj == nb)
            {
                nb.Value = 2;
                nb.ValueChanged -= Nb_ValueChanged;
            }
        }

        public event EventHandler<SuggestionClickedEventArgs> Selected;
    }
}
