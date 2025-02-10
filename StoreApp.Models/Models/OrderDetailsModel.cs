using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{

    public enum ShippingProvider
    {
        InPost,
        DHL,
        Fedex,
        DPD
    }

    public class OrderDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        
        public ShippingProvider ShippingProvider { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Apartament { get; set; }
        public string PostalCode { get; set; }

        public string CardNumber { get; set; }
        public string ExpirationDate {  get; set; }
        public string SecurityCode { get; set; }

        public OrderDetailsModel()
        {

        }

        public OrderDetailsModel(Dictionary<string, StringValues> formResponse)
        {
            Email = formResponse["email"];
            FirstName = formResponse["name"];
            LastName = formResponse["surname"];
            
            Address = formResponse["street"];
            City = formResponse["city"];
            Apartament = formResponse["apartament"];
            PostalCode = formResponse["zipCode"];

            CardNumber = formResponse["cardNo"];
            ExpirationDate = formResponse["expirationDate"];
            SecurityCode = formResponse["cnn"];

            switch (formResponse["provider"])
            {
                case "inpost":
                    ShippingProvider = ShippingProvider.InPost;
                    break;
                case "dhl":
                    ShippingProvider = ShippingProvider.DHL;
                    break;
                case "dpd":
                    ShippingProvider = ShippingProvider.DPD;
                    break;
                case "fedex":
                    ShippingProvider = ShippingProvider.Fedex;
                    break;
            }
        }
    }
}
