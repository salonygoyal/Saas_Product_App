using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.ProviderProducts
{

    public class Product
    {
        public List<string> Categories { get; set; }
        public string Twitter { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
    }

    public class RootObject
    {
        public List<Product> products { get; set; }
    }

}
