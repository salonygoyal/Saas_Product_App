using Newtonsoft.Json;
using ProductLibrary.ProviderProducts;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProductLibrary.Providers
{
    public class SoftwareAdvice
    {

        public static List<Product> ReadDataFromJSON(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    List<Product> importedProducts = new List<Product>();
                    string json = reader.ReadToEnd();
                    JsonSerializer serializer = new JsonSerializer();
                    RootObject root =  JsonConvert.DeserializeObject<RootObject>(json);
                    foreach(Product prod in root.products)
                    {
                        int index = 0;
                        string category = "";
                        foreach (var cat in prod.Categories)
                        {
                            index++;
                            category += cat;
                            if (index != prod.Categories.Count)
                                category += ",";
                        }
                        prod.Category = category;
                        importedProducts.Add(prod);
                    }
                    return importedProducts;
                }
            }
            catch(Exception ex)
            {
                Helper.LogEvent("Error occurred in ReadDataFromJSON method due to " + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                throw ex;
            }
        }
    }
}
