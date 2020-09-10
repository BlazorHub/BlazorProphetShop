using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Models
{
    public class Cities
    {
        public static List<string> GetValues()
        {
            return new List<string>
            {
                "Osijek",
                "Zagreb",
                "Varaždin",
                "Split",
                "Rijeka",
                "Pula",
                "Zadar",
                "Vinkovci"
            };
        }
    }
}
