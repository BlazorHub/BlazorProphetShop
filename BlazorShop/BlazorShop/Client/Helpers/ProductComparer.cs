using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.ViewModels;

namespace BlazorShop.Client.Helpers
{
    public class ProductComparer
    {
        public const string DEFAULT = "Preporučeno";
        public const string PRICE_ASCENDING = "Cijena - od najniže";
        public const string PRICE_DESCENDING = "Cijena - od najviše";

        public Func<ProductViewModel, ProductViewModel, int> GetComparer(string type)
        {
            return type switch
            {
                PRICE_ASCENDING => SortValueAscendingHelper,
                PRICE_DESCENDING => SortValueDescendingHelper,
                DEFAULT => SortDefault,
                _ => SortDefault,
            };
        }

        public Func<ProductViewModel, ProductViewModel, int> SortDefault = (p1, p2) =>
        {
            return 0;
        };

        public Func<ProductViewModel, ProductViewModel, int> SortValueDescendingHelper = (p1, p2) =>
        {
            if (p1.Value < p2.Value)
                return 1;

            if (p1.Value > p2.Value)
                return -1;

            else
                return 0;
        };

        public Func<ProductViewModel, ProductViewModel, int> SortValueAscendingHelper = (p1, p2) =>
        {
            if (p1.Value > p2.Value)
                return 1;

            if (p1.Value < p2.Value)
                return -1;

            else
                return 0;
        }; 
    }
}
