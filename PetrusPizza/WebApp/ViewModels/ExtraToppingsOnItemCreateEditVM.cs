using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// ExtraToppingsOnItemCreateEditVM
    /// </summary>
    public class ExtraToppingsOnItemCreateEditVM
    {
        /// <summary>
        /// ExtraToppingsOnItem
        /// </summary>
        public ExtraToppingsOnItem ExtraToppingsOnItem { get; set; } = default!;
        /// <summary>
        /// ItemRow
        /// </summary>
        public ItemRow ItemRow { get; set; } = default!;
        /// <summary>
        /// Topping
        /// </summary>
        public Topping Topping { get; set; } = default!;
        /// <summary>
        /// ItemRowSelectList
        /// </summary>
        public SelectList? ItemRowSelectList { get; set; }
        /// <summary>
        /// ToppingSelectList
        /// </summary>
        public SelectList? ToppingSelectList { get; set; }

    }
}