using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts
{
    internal class Parts
    {

        public string Type { get; set; }
        public string CarBrand { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int Unit { get; set; }


        public override string  ToString()
        {
             string c = $"Type: {Type} | \b, Car Brand: {CarBrand} | \b, Quantity: {Quantity} | \b, Unit Price: {UnitPrice} | \b , Unit: {Unit} |";
            return c ;
        }
        




    }
}
