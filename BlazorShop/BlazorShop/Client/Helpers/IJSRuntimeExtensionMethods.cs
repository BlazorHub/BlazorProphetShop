using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Helpers
{
    /**
     * Pomoćna klasa koja služi za enkapsuliranje metoda Javascript runtime-a.
     **/
    public static class IJSRuntimeExtensionMethods
    {
        /// <summary>
        /// Metoda koja služi za pozivanje localStorage.setItem() metode Javascript API-a koja pohranjuje objekt u lokalne pohrane web preglednika.
        /// </summary>
        /// <param name="js">Objekt koji nam služi kao sučelje prema JS runtime-u i omogućuje pozivanje raznih Javascript API-a</param>
        /// <param name="key">Ključ pod kojem želimo spremiti objekt u lokalnoj pohrani</param>
        /// <param name="content">Sadržaj koji želimo spremiti u lokalnu pohranu</param>
        /// <returns></returns>
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);

        /// <summary>
        /// Metoda koja služi za pozivanje localStorage.getItem() metode Javascript API-a koja dohvaća objekt iz lokalne pohrane web preglednika.
        /// </summary>
        /// <param name="js">Objekt koji nam služi kao sučelje prema JS runtime-u i omogućuje pozivanje raznih Javascript API-a</param>
        /// <param name="key">Ključ pod kojim je objekt spremljen u lokalnoj pohrani</param>
        /// <returns></returns>
        public static ValueTask<string> GetFromLocalStorage (this IJSRuntime js, string key)
            => js.InvokeAsync<string>("localStorage.getItem", key);

        /// <summary>
        /// Metoda koja služi za pozivanje localStorage.removeItem() metode Javascript API-a koja briše objekt iz lokalne pohrane web preglednika.
        /// </summary>
        /// <param name="js">Objekt koji nam služi kao sučelje prema JS runtime-u i omogućuje pozivanje raznih Javascript API-a</param>
        /// <param name="key">Ključ pod kojim je objekt spremljen u lokalnoj pohrani</param>
        /// <returns></returns>
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("localStorage.removeItem", key);
    }
}
