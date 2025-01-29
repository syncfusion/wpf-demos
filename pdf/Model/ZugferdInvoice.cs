#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Syncfusion.Zugferd
{
    /// <summary>
    /// zugferd Invoice
    /// </summary>
    public class ZugferdInvoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public CurrencyCodes Currency { get; set; }
        public InvoiceType Type { get; set; }

        public UserDetails Buyer { get; set; }
        public UserDetails Seller { get; set; }

        public ZugferdProfile Profile { get; set; }
       
        public float TotalAmount { get; set; }

        List<Product> products = new List<Product>();

        public void AddProduct(string productID, string productName,float price, float quantity, float totalPrice)
        {
            Product product = new Product()
            {
                ProductID = productID,
                productName = productName,
                Price = price,
                Quantity = quantity,
                Total = totalPrice
            };

            products.Add(product);
        }

        public ZugferdInvoice(string invoiceNumber, DateTime invoiceDate, CurrencyCodes currency)
        {            
            InvoiceNumber= invoiceNumber;
            InvoiceDate = invoiceDate;            
            Currency = currency;
                  
        }
     
        public Stream Save(Stream stream)
        {            
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();

            #region Header
            writer.WriteStartElement("rsm:CrossIndustryDocument");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "rsm", null, "urn:ferd:CrossIndustryDocument:invoice:1p0");
            writer.WriteAttributeString("xmlns", "ram", null, "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:12");
            writer.WriteAttributeString("xmlns", "udt", null, "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:15");
            #endregion

            #region SpecifiedExchangedDocumentContext
            writer.WriteStartElement("rsm:SpecifiedExchangedDocumentContext");
            writer.WriteStartElement("ram:TestIndicator");
            writer.WriteElementString("udt:Indicator", "true");
            writer.WriteEndElement();
            writer.WriteStartElement("ram:GuidelineSpecifiedDocumentContextParameter");
            writer.WriteElementString("ram:ID", "urn:ferd:CrossIndustryDocument:invoice:1p0:" + Profile.ToString().ToLower());
            writer.WriteEndElement();
            writer.WriteEndElement();

            #endregion

            WriteHeaderExchangeDocument(writer);

            writer.WriteStartElement("rsm:SpecifiedSupplyChainTradeTransaction");

            writer.WriteStartElement("ram:ApplicableSupplyChainTradeAgreement");
           
            //Seller details.
            WriteUserDetails(writer, "ram:SellerTradeParty", Seller);

            //Buyer details
            WriteUserDetails(writer, "ram:BuyerTradeParty", Buyer);
            
            //End of ApplicableSupplyChainTradeAgreement
            writer.WriteEndElement();           

            writer.WriteStartElement("ram:ApplicableSupplyChainTradeSettlement");            

            writer.WriteElementString("ram:InvoiceCurrencyCode", Currency.ToString("g"));                        

            writer.WriteStartElement("ram:SpecifiedTradeSettlementMonetarySummation");
          
            WriteOptionalAmount(writer, "ram:GrandTotalAmount", TotalAmount);
            
            writer.WriteEndElement();  

            writer.WriteEndElement();

            AddTradeLineItems(writer);

            writer.WriteEndDocument();
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void AddTradeLineItems(XmlTextWriter writer)
        {
            foreach (Product product in this.products)
            {
                writer.WriteStartElement("ram:IncludedSupplyChainTradeLineItem");


                if (Profile != ZugferdProfile.Basic)
                {
                    writer.WriteStartElement("ram:SpecifiedSupplyChainTradeAgreement");
                    writer.WriteStartElement("ram:GrossPriceProductTradePrice");

                    WriteAttribute(writer, "ram:BasisQuantity", "unitCode", "KGM", product.Quantity.ToString());

                    writer.WriteEndElement();

                    writer.WriteEndElement();  
                }

                writer.WriteStartElement("ram:SpecifiedSupplyChainTradeDelivery");
                WriteAttribute(writer, "ram:BilledQuantity", "unitCode", "KGM", product.Quantity.ToString());

                writer.WriteEndElement();  


                writer.WriteStartElement("ram:SpecifiedSupplyChainTradeSettlement");

                writer.WriteStartElement("ram:SpecifiedTradeSettlementMonetarySummation");

                WriteAttribute(writer, "ram:LineTotalAmount", "currencyID", this.Currency.ToString("g"), FormatValue(product.Total));
                writer.WriteEndElement();  
                writer.WriteEndElement(); 

                writer.WriteStartElement("ram:SpecifiedTradeProduct");
              
                WriteOptionalElement(writer, "ram:Name", product.productName);            

                writer.WriteEndElement();  
                writer.WriteEndElement();  
            }  

        }
 
        private void WriteAttribute(XmlTextWriter writer, string tagName, string attributeName, string attributeValue, string nodeValue)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString(attributeName, attributeValue);
            writer.WriteValue(nodeValue);
            writer.WriteEndElement(); 
        }

      

        private void WriteOptionalElement(XmlTextWriter writer, string tagName, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                writer.WriteElementString(tagName, value);
            }
        }
        private void WriteOptionalAmount(XmlTextWriter writer, string tagName, float value, int numDecimals = 2)
        {
            if (value !=float.MinValue)
            {
                writer.WriteStartElement(tagName);
                writer.WriteAttributeString("currencyID", Currency.ToString("g"));
                writer.WriteValue(FormatValue(value, numDecimals));
                writer.WriteEndElement();
            }
        }

 
        private void WriteUserDetails(XmlTextWriter writer, string customerTag, UserDetails user)
        {
            if (user != null)
            {
                writer.WriteStartElement(customerTag);

                if (!String.IsNullOrEmpty(user.ID))
                {
                    writer.WriteElementString("ram:ID", user.ID);
                }
              
                if (!String.IsNullOrEmpty(user.Name))
                {
                    writer.WriteElementString("ram:Name", user.Name);
                }

                writer.WriteStartElement("ram:PostalTradeAddress");
                writer.WriteElementString("ram:PostcodeCode", user.Postcode);
                writer.WriteElementString("ram:LineOne", string.IsNullOrEmpty(user.ContactName) ? user.Street : user.ContactName);
                if (!string.IsNullOrEmpty(user.ContactName))
                    writer.WriteElementString("ram:LineTwo", user.Street);
                writer.WriteElementString("ram:CityName", user.City);
                writer.WriteElementString("ram:CountryID", user.Country.ToString("g"));
                writer.WriteEndElement();

               
                writer.WriteEndElement();
            }
        }


      
        private void WriteHeaderExchangeDocument(XmlTextWriter writer)
        {
            #region HeaderExchangedDocument
            writer.WriteStartElement("rsm:HeaderExchangedDocument");
            writer.WriteElementString("ram:ID", InvoiceNumber);
            writer.WriteElementString("ram:Name", GetInvoiceTypeName(Type));
            writer.WriteElementString("ram:TypeCode", String.Format("{0}", GetInvoiceTypeCode(Type)));


            writer.WriteStartElement("ram:IssueDateTime");
            writer.WriteStartElement("udt:DateTimeString");
            writer.WriteAttributeString("format", "102");
            writer.WriteValue(ConvertDateFormat(InvoiceDate, "102"));
            writer.WriteEndElement();
            writer.WriteEndElement();

            // AddNotes(writer, Notes);

            writer.WriteEndElement();

            #endregion
        }

       


        private string ConvertDateFormat(DateTime date, String format = "102")
        {
            if (format.Equals("102"))
            {
                return date.ToString("yyyymmdd");
            }
            else
            {
                return date.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        private string GetInvoiceTypeName(InvoiceType type)
        {
            switch (type)
            {
                case InvoiceType.Invoice: return "RECHNUNG";
                case InvoiceType.Correction: return "KORREKTURRECHNUNG";
                case InvoiceType.CreditNote: return "GUTSCHRIFT";
                case InvoiceType.DebitNote: return "";
                case InvoiceType.SelfBilledInvoice: return "";
                default: return "";
            }
        }
        private int GetInvoiceTypeCode(InvoiceType type)
        {
            if ((int)type > 1000)
            {
                type -= 1000;
            }

            return (int)type;
        }

        private string FormatValue(float value, int numDecimals = 2)
        {
            string formatString = "0.";
            for (int i = 0; i < numDecimals; i++)
            {
                formatString += "0";
            }
            return value.ToString(formatString).Replace(",", ".");
        }
      
    }
}