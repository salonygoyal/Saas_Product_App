using ProductLibrary.ProviderProducts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace ProductLibrary.Providers
{
    public class Capterra 
    {
        public static List<CapterraProduct> ReadDataFromYAML(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    List<CapterraProduct> product = new List<CapterraProduct>();
                    string yamlString = reader.ReadToEnd();
                    var input = new StringReader(yamlString);
                    var yaml = new YamlStream();
                    yaml.Load(input);
                    var mapping =
                        (YamlSequenceNode)yaml.Documents[0].RootNode;
                    var items = mapping.Children;
                    foreach (YamlMappingNode item in items)
                    {
                        CapterraProduct tempProduct = new CapterraProduct();
                        tempProduct.name = Convert.ToString(item.Children[new YamlScalarNode("name")]);
                        tempProduct.tags = Convert.ToString(item.Children[new YamlScalarNode("tags")]);
                        tempProduct.twitter = Convert.ToString(item.Children[new YamlScalarNode("twitter")]);
                        product.Add(tempProduct);
                    }
                    return product;
                }
            }
            catch (Exception ex)
            {
                Helper.LogEvent("Error occurred in ReadDataFromYAML method due to " + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                throw ex;
            }
        }
        
    }
}
