using System.ComponentModel.DataAnnotations;

namespace WedAPI
{
    public class Buyer
    {
        [Key]
        public int BuyerID {get;set;}
        public string Name {get;set;}
        public string Payment {get;set;}
        public string part {get;set;}

        public int ShoesID {get;set;}
        public ShoesShop shoesShop {get;set;}

    }
}