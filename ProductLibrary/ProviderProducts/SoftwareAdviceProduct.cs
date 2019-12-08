using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.ProviderProducts
{

    public class Product : MainProduct
    {
        
        public List<string> Categories { get; set; }

        public string Title { get; set; }
    }

    public class RootObject
    {
        public List<Product> products { get; set; }
    }

}
