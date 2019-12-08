using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductLibrary.ProviderProducts;
using ProductLibrary.Providers;

namespace SaaSProductUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ReadDataFromJSONTestMethod1()
        {
            List<Product> softAdviceProd = new List<Product>();
            Assert.AreNotEqual(SoftwareAdvice.ReadDataFromJSON("./../../../feed-products/softwareadvice.json"), softAdviceProd);
        }

        
        [TestMethod]
        public void ReadDataFromJSONTestMethod2()
        {
            List<Product> softAdviceProd = new List<Product>();

            Product softAdviceProd1 = new Product();
            softAdviceProd1.Category = "Customer Service ,Call Center";
            softAdviceProd1.Twitter = "@freshdesk";
            softAdviceProd1.Title = "Freshdesk";
            softAdviceProd1.ProviderName = "SoftwareAdvice";
            softAdviceProd.Add(softAdviceProd1);
        
            Product softAdviceProd2 = new Product();
            softAdviceProd2.Category = "CRM,Sales Management";
            softAdviceProd2.Twitter = null;
            softAdviceProd2.Title = "Zoho";
            softAdviceProd2.ProviderName = "SoftwareAdvice";
            softAdviceProd.Add(softAdviceProd2);

            Assert.AreNotEqual(SoftwareAdvice.ReadDataFromJSON("./../../../feed-products/softwareadvice.json"), softAdviceProd);
        }

        [TestMethod]
        public void ReadDataFromYAMLTestMethod2()
        {
            List<CapterraProduct> capterraProd = new List<CapterraProduct>();
            Assert.AreNotEqual(Capterra.ReadDataFromYAML("./../../../feed-products/capterra.yaml"), capterraProd);
        }

        [TestMethod]
        public void ReadDataFromYAMLTestMethod1()
        {
            List<CapterraProduct> capterraProd = new List<CapterraProduct>();
            CapterraProduct prod1 = new CapterraProduct();
            prod1.ProviderName = "Capterra";
            prod1.Category = "Bugs & Issue Tracking,Development Tools";
            prod1.Name = "GitGHub";
            prod1.Twitter = "github";
            capterraProd.Add(prod1);

            CapterraProduct prod2 = new CapterraProduct();
            prod2.ProviderName = "Capterra";
            prod2.Category = "Instant Messaging & Chat,Web Collaboration,Productivity";
            prod2.Name = "Slack";
            prod2.Twitter = "slackhq";
            capterraProd.Add(prod2);

            CapterraProduct prod3 = new CapterraProduct();
            prod3.ProviderName = "Capterra";
            prod3.Category = "Project Management,Project Collaboration,Development Tools";
            prod3.Name = "JIRA Software";
            prod3.Twitter = "jira";
            capterraProd.Add(prod3);

            Assert.AreNotEqual(Capterra.ReadDataFromYAML("./../../../feed-products/capterra.yaml"), capterraProd);
        }

    }
}
