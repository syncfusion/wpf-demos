#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMapDrillDown
{
    public class Continents : ObservableCollection<SubDivision>
    {
        public Continents()
        {
            this.Add(new SubDivision() { Name = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600, Area = 1076395, Density = 12 });
            this.Add(new SubDivision() { Name = "Mexico", Continent = "North America", Country = "Mexico", Population = 15174272, Area = 21355, Density = 711 });
            this.Add(new SubDivision() { Name = "California", Continent = "North America", Country = "United States", Population = 37253956, Area = 423970, Density = 88 });
            this.Add(new SubDivision() { Name = "Texas", Continent = "North America", Country = "United States", Population = 25145561, Area = 696241, Density = 36 });
            this.Add(new SubDivision() { Name = "New York", Continent = "North America", Country = "United States", Population = 19378102, Area = 141299, Density = 137 });
            this.Add(new SubDivision() { Name = "Florida", Continent = "North America", Country = "United States", Population = 18801310, Area = 170304, Density = 110 });
            this.Add(new SubDivision() { Name = "Illinois", Continent = "North America", Country = "United States", Population = 12830632, Area = 140998, Density = 91 });
            this.Add(new SubDivision() { Name = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379, Area = 119283, Density = 106 });
            this.Add(new SubDivision() { Name = "Ohio", Continent = "North America", Country = "United States", Population = 11536504, Area = 116096, Density = 99 });
            this.Add(new SubDivision() { Name = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428, Area = 307571, Density = 51 });
            this.Add(new SubDivision() { Name = "Sao Paulo", Continent = "South America", Country = "Brazil", Population = 43663672, Area = 248209, Density = 166 });
            this.Add(new SubDivision() { Name = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366, Area = 586528, Density = 33 });
            this.Add(new SubDivision() { Name = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178, Area = 43696, Density = 366 });
            this.Add(new SubDivision() { Name = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127, Area = 564692, Density = 25 });
            this.Add(new SubDivision() { Name = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050, Area = 281748, Density = 38 });
            this.Add(new SubDivision() { Name = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462, Area = 199315, Density = 52 });
            this.Add(new SubDivision() { Name = "Dhaka", Continent = "Asia", Country = "Bangladesh", Population = 46729000, Area = 31120, Density = 1502 });
            this.Add(new SubDivision() { Name = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000, Area = 33771, Density = 831 });
            this.Add(new SubDivision() { Name = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000, Area = 18197, Density = 1007 });
            this.Add(new SubDivision() { Name = "Rangpur", Continent = "Asia", Country = "Bangladesh", Population = 15665000, Area = 16317, Density = 960 });
            this.Add(new SubDivision() { Name = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000, Area = 22272, Density = 699 });
            this.Add(new SubDivision() { Name = "Guangdong", Continent = "Asia", Country = "China", Population = 104303132, Area = 177900, Density = 618 });
            this.Add(new SubDivision() { Name = "Shandong", Continent = "Asia", Country = "China", Population = 95793065, Area = 156700, Density = 598 });
            this.Add(new SubDivision() { Name = "Henan", Continent = "Asia", Country = "China", Population = 94023567, Area = 167000, Density = 560 });
            this.Add(new SubDivision() { Name = "Sichuan", Continent = "Asia", Country = "China", Population = 80418200, Area = 485000, Density = 181 });
            this.Add(new SubDivision() { Name = "Jiangsu", Continent = "Asia", Country = "China", Population = 78659903, Area = 102600, Density = 743 });
            this.Add(new SubDivision() { Name = "Hebei", Continent = "Asia", Country = "China", Population = 71854202, Area = 187700, Density = 370 });
            this.Add(new SubDivision() { Name = "Hunan", Continent = "Asia", Country = "China", Population = 65683722, Area = 211800, Density = 323 });
            this.Add(new SubDivision() { Name = "Anhui", Continent = "Asia", Country = "China", Population = 59500510, Area = 139400, Density = 498 });
            this.Add(new SubDivision() { Name = "Hubei", Continent = "Asia", Country = "China", Population = 57237740, Area = 185900, Density = 332 });
            this.Add(new SubDivision() { Name = "Zhejiang", Continent = "Asia", Country = "China", Population = 54426891, Area = 101800, Density = 509 });
            this.Add(new SubDivision() { Name = "Guangxi", Continent = "Asia", Country = "China", Population = 46026629, Area = 236700, Density = 211 });
            this.Add(new SubDivision() { Name = "Yunnan", Continent = "Asia", Country = "China", Population = 45966239, Area = 394100, Density = 107 });
            this.Add(new SubDivision() { Name = "Jiangxi", Continent = "Asia", Country = "China", Population = 44567475, Area = 166900, Density = 257 });
            this.Add(new SubDivision() { Name = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323, Area = 145900, Density = 295 });
            this.Add(new SubDivision() { Name = "Heilongjiang", Continent = "Asia", Country = "China", Population = 38312224, Area = 460000, Density = 83 });
            this.Add(new SubDivision() { Name = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378, Area = 205800, Density = 180 });
            this.Add(new SubDivision() { Name = "Fujian", Continent = "Asia", Country = "China", Population = 36894216, Area = 121400, Density = 283 });
            this.Add(new SubDivision() { Name = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111, Area = 156800, Density = 214 });
            this.Add(new SubDivision() { Name = "Guizhou", Continent = "Asia", Country = "China", Population = 34746468, Area = 176100, Density = 214 });
            this.Add(new SubDivision() { Name = "Chongqing", Continent = "Asia", Country = "China", Population = 28846170, Area = 82300, Density = 393 });
            this.Add(new SubDivision() { Name = "Jilin", Continent = "Asia", Country = "China", Population = 27462297, Area = 187400, Density = 146 });
            this.Add(new SubDivision() { Name = "Gansu", Continent = "Asia", Country = "China", Population = 25575254, Area = 454000, Density = 58 });
            this.Add(new SubDivision() { Name = "Inner Mongolia", Continent = "Asia", Country = "China", Population = 24706321, Area = 1183000, Density = 21 });
            this.Add(new SubDivision() { Name = "Shanghai", Continent = "Asia", Country = "China", Population = 23019148, Area = 7037, Density = 2730 });
            this.Add(new SubDivision() { Name = "Xinjiang", Continent = "Asia", Country = "China", Population = 21813334, Area = 1660001, Density = 13 });
            this.Add(new SubDivision() { Name = "Beijing", Continent = "Asia", Country = "China", Population = 19612368, Area = 16801, Density = 1309 });
            this.Add(new SubDivision() { Name = "Tianjin", Continent = "Asia", Country = "China", Population = 12938224, Area = 11760, Density = 1044 });
            this.Add(new SubDivision() { Name = "Uttar Pradesh", Continent = "Asia", Country = "India", Population = 200581477, Area = 240928, Density = 828 });
            this.Add(new SubDivision() { Name = "Maharashtra", Continent = "Asia", Country = "India", Population = 112372972, Area = 307713, Density = 365 });
            this.Add(new SubDivision() { Name = "Bihar", Continent = "Asia", Country = "India", Population = 103804637, Area = 94163, Density = 1102 });
            this.Add(new SubDivision() { Name = "West Bengal", Continent = "Asia", Country = "India", Population = 91347736, Area = 88752, Density = 1029 });
            this.Add(new SubDivision() { Name = "Andhra Pradesh", Continent = "Asia", Country = "India", Population = 84665533, Area = 275045, Density = 308 });
            this.Add(new SubDivision() { Name = "Madhya Pradesh", Continent = "Asia", Country = "India", Population = 72597565, Area = 308245, Density = 236 });
            this.Add(new SubDivision() { Name = "Tamil Nadu", Continent = "Asia", Country = "India", Population = 72138958, Area = 130058, Density = 555 });
            this.Add(new SubDivision() { Name = "Rajasthan", Continent = "Asia", Country = "India", Population = 68621012, Area = 342239, Density = 201 });
            this.Add(new SubDivision() { Name = "Karnataka", Continent = "Asia", Country = "India", Population = 61130704, Area = 191791, Density = 319 });
            this.Add(new SubDivision() { Name = "Gujarat", Continent = "Asia", Country = "India", Population = 60383628, Area = 196024, Density = 308 });
            this.Add(new SubDivision() { Name = "Odisha", Continent = "Asia", Country = "India", Population = 41947358, Area = 155820, Density = 269 });
            this.Add(new SubDivision() { Name = "Kerala", Continent = "Asia", Country = "India", Population = 33387677, Area = 38863, Density = 859 });
            this.Add(new SubDivision() { Name = "Jharkhand", Continent = "Asia", Country = "India", Population = 32966238, Area = 74677, Density = 414 });
            this.Add(new SubDivision() { Name = "Assam", Continent = "Asia", Country = "India", Population = 31169272, Area = 78550, Density = 397 });
            this.Add(new SubDivision() { Name = "Punjab", Continent = "Asia", Country = "India", Population = 27704236, Area = 50362, Density = 550 });
            this.Add(new SubDivision() { Name = "Chattisgarh", Continent = "Asia", Country = "India", Population = 25540196, Area = 135194, Density = 189 });
            this.Add(new SubDivision() { Name = "Haryana", Continent = "Asia", Country = "India", Population = 25353081, Area = 44212, Density = 573 });
            this.Add(new SubDivision() { Name = "Delhi", Continent = "Asia", Country = "India", Population = 16753235, Area = 1483, Density = 11297 });
            this.Add(new SubDivision() { Name = "Jammu", Continent = "Asia", Country = "India", Population = 12548926, Area = 222236, Density = 56 });
            this.Add(new SubDivision() { Name = "Uttarakhand", Continent = "Asia", Country = "India", Population = 10116752, Area = 53483, Density = 189 });
            this.Add(new SubDivision() { Name = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826, Area = 348161, Density = 1236 });
            this.Add(new SubDivision() { Name = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011, Area = 47922, Density = 782 });
            this.Add(new SubDivision() { Name = "Central Java", Continent = "Asia", Country = "Indonesia", Population = 32380687, Area = 32548, Density = 995 });
            this.Add(new SubDivision() { Name = "North Sumatra", Continent = "Asia", Country = "Indonesia", Population = 12985075, Area = 71680, Density = 181 });
            this.Add(new SubDivision() { Name = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030, Area = 9161, Density = 1162 });
            this.Add(new SubDivision() { Name = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595, Area = 74028, Density = 15342 });
            this.Add(new SubDivision() { Name = "Tehran", Continent = "Asia", Country = "Iran", Population = 14795116, Area = 18814, Density = 786 });
            this.Add(new SubDivision() { Name = "Tokyo", Continent = "Asia", Country = "Japan", Population = 13010279, Area = 2187, Density = 5949 });
            this.Add(new SubDivision() { Name = "Punjab", Continent = "Asia", Country = "Pakistan", Population = 101000000, Area = 205344, Density = 490 });
            this.Add(new SubDivision() { Name = "Sindh", Continent = "Asia", Country = "Pakistan", Population = 34968800, Area = 140914, Density = 248 });
            this.Add(new SubDivision() { Name = "Khyber Pakhtunkhwa", Continent = "Asia", Country = "Pakistan", Population = 20468700, Area = 34084, Density = 601 });
            this.Add(new SubDivision() { Name = "Calarbarzon", Continent = "Asia", Country = "Philippines", Population = 12609803, Area = 16229, Density = 777 });
            this.Add(new SubDivision() { Name = "Metro", Continent = "Asia", Country = "Philippines", Population = 11553427, Area = 639, Density = 186415 });
            this.Add(new SubDivision() { Name = "Central Luzon", Continent = "Asia", Country = "Philippines", Population = 10137737, Area = 21740, Density = 4722 });
            this.Add(new SubDivision() { Name = "Moscow", Continent = "Asia", Country = "Russia", Population = 11503501, Area = 1081, Density = 9772 });
            this.Add(new SubDivision() { Name = "Gyeonggi", Continent = "Asia", Country = "South Korea", Population = 11571684, Area = 10131, Density = 1142 });
            this.Add(new SubDivision() { Name = "Seoul", Continent = "Asia", Country = "South Korea", Population = 10208302, Area = 605, Density = 16873 });
            this.Add(new SubDivision() { Name = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531, Area = 112343, Density = 234 });
            this.Add(new SubDivision() { Name = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805, Area = 182413, Density = 55 });
            this.Add(new SubDivision() { Name = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805, Area = 182413, Density = 55 });
            this.Add(new SubDivision() { Name = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805, Area = 182413, Density = 55 });
            this.Add(new SubDivision() { Name = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400, Area = 16548, Density = 632 });
            this.Add(new SubDivision() { Name = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900, Area = 94361, Density = 109 });
            this.Add(new SubDivision() { Name = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000, Area = 12012, Density = 974 });
            this.Add(new SubDivision() { Name = "Lombardy", Continent = "Europe", Country = "Italy", Population = 10006710, Area = 23861, Density = 414 });
            this.Add(new SubDivision() { Name = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863, Area = 34084, Density = 524 });
            this.Add(new SubDivision() { Name = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331, Area = 70549, Density = 177 });
            this.Add(new SubDivision() { Name = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479, Area = 35752, Density = 301 });
            this.Add(new SubDivision() { Name = "Istanbul", Continent = "Europe", Country = "Turkey", Population = 12915158, Area = 5196, Density = 2486 });
            this.Add(new SubDivision() { Name = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600, Area = 130395, Density = 395 });
            this.Add(new SubDivision() { Name = "New South Wales", Continent = "Oceania", Country = "Australia", Population = 7303700, Area = 809444, Density = 9 });
            this.Add(new SubDivision() { Name = "Victoria", Continent = "Oceania", Country = "Australia", Population = 5679600, Area = 237629, Density = 25 });
            this.Add(new SubDivision() { Name = "Queensland", Continent = "Oceania", Country = "Australia", Population = 4610900, Area = 1852642, Density = 3 });
        }
    }

    public class SubDivision
    {
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
        public int Density { get; set; }
    }
}
