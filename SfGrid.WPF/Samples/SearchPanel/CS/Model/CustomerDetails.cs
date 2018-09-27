using System.Collections.Generic;

namespace SearchPanel
{
    public class Customers : List<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customers"/> class.
        /// </summary>
        public Customers()
        {
            var model = new OrderInfoRepository();
            this.AddRange(model.Customers);
        }
    }
}