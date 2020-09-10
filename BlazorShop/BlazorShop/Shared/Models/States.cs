using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Models
{
    public class States
    {
        public static List<string> GetValues()
        {
            return new List<string>
            {
                "ZAGREBAČKA",
                "KRAPINSKO-ZAGORSKA",
                "SISAČKO-MOSLAVAČKA",
                "KARLOVAČKA",
                "VARAŽDINSKA",
                "KOPRIVNIČKO-KRIŽEVAČKA",
                "BJELOVARSKO-BILOGORSKA",
                "PRIMORSKO-GORANSKA",
                "LIČKO-SENJSKA",
                "VIROVITIČKO-PODRAVSKA",
                "POŽEŠKO-SLAVONSKA",
                "BRODSKO-POSAVSKA",
                "ZADARSKA",
                "OSJEČKO-BARANJSKA",
                "ŠIBENSKO-KNINSKA",
                "VUKOVARSKO-SRIJEMSKA",
                "SPLITSKO-DALMATINSKA",
                "ISTARSKA",
                "DUBROVAČKO-NERETVANSKA",
                "MEĐIMURSKA",
                "GRAD ZAGREB"
            };
        }
    }
}
