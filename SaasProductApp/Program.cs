using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary.Providers;
using ProductLibrary.ProviderProducts;
using ProductLibrary;

namespace SaasProductApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Do you want to import product from /feed-products. Press 'Y' or 'N'");
                if (Convert.ToString(Console.ReadLine()).ToUpper() == "Y")
                {
                    Console.WriteLine("Please enter provider");
                    string provider = Convert.ToString(Console.ReadLine());
                    switch (provider.ToLower())
                    {
                        case "capterra": List<CapterraProduct> lstCapProducts = Capterra.ReadDataFromYAML(ConfigurationDetails.GetConfiguration("YamlFilePath"));
                            DisplayCapterraProducts(lstCapProducts);
                            break;

                        case "softwareadvice":  List<Product> lstSoftProducts = SoftwareAdvice.ReadDataFromJSON(ConfigurationDetails.GetConfiguration("JsonFilePath"));
                            DisplaySoftAdviceProducts(lstSoftProducts);
                            break;

                        default:
                            Console.WriteLine("Other providers are currently unavailable");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter csv output online url for importing products");
                    //TO DO
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        /*
         * This method is used to display imported software advice products.
         * @params softwareProduct List<Product>
         * */

        private static void DisplaySoftAdviceProducts(List<Product> softwareProduct)
        {
            foreach(Product prod in softwareProduct)
            {
                Console.WriteLine("importing : Title : {0}, Categories : {1} , twitter : {2}", prod.Title, prod.Category, prod.Twitter);
            }
        }

        /*
         * This method is used to display imported capterra products.
         * @params capterraProduct List<CapterraProduct>
         * */

        private static void DisplayCapterraProducts(List<CapterraProduct> capterraProduct)
        {
            foreach (CapterraProduct prod in capterraProduct)
            {
                Console.WriteLine(
                             "importing : name: {0}, tags: {1} ,twitter: {2}",
                             prod.Name , prod.Category , prod.Twitter
                         );
            }
        }
    }
}
