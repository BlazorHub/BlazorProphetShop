using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Models
{
    public static class Payment
    {
        public const string INCASH = "Gotovina";
        public const string INSTALLMENT1X = "1x obroka";
        public const string INSTALLMENT2X = "2x obroka";
        public const string INSTALLMENT3X = "3x obroka";

        public static List<string> Values
        {
            get { return new List<string> { "Gotovina", "1x obroka", "2x obroka", "3x obroka" }; }
        }
    }
}
