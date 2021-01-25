using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// ExtraToppingsOnItemCreateEditVM
    /// </summary>
    public class DefaultToppingCreateEditVM
    {
        /// <summary>
        /// ExtraToppingsOnItem
        /// </summary>
        public DefaultTopping DefaultTopping { get; set; } = default!;
      
        //public Topping Topping { get; set; } = default!;
        /// <summary>
        /// ToppingSelectList
        /// </summary>
        public SelectList? DefaultToppingSelectList { get; set; }

    }
}