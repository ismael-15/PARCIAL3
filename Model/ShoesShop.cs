using System.ComponentModel.DataAnnotations;

namespace WedAPI
{
    public class ShoesShop
    {
        [Key]

        public int ShoesID {get;set;}
        public string Color {get;set;}
        public string Mark {get;set;}
        public string price {get;set;}
        public int Amount {get;set;}

    }
}