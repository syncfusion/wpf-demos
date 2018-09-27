using System.Collections.Generic;

namespace SearchPanel
{
    public class ShipCountries : List<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCountries"/> class.
        /// </summary>
        public ShipCountries()
        {
            var model = new OrderInfoRepository();
            this.AddRange(model.ShipCountries);
        }
    }
}
