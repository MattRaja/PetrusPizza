using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// OrderRowCreateEditVM
    /// </summary>
    public class OrderRowCreateEditVM
    {
        /// <summary>
        /// OrderRow
        /// </summary>
        public OrderRow OrderRow { get; set; } = default!;
        
        /// <summary>
        /// ExtraToppingsOnItem
        /// </summary>
        public ExtraToppingsOnItem? ExtraToppingsOnItem { get; set; }
        /// <summary>
        /// ExtraToppingsOnItemSelectList
        /// </summary>
        public SelectList? ExtraToppingsOnItemSelectList { get; set; }

        /// <summary>
        /// ItemRow
        /// </summary>
        public ItemRow ItemRow { get; set; } = default!;
        /// <summary>
        /// ItemRowSelectList
        /// </summary>
        public SelectList ItemRowSelectList { get; set; } = default!;

        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; set; } = default!;
        /// <summary>
        /// OrderSelectList
        /// </summary>
        public SelectList OrderSelectList { get; set; } = default!;
    }
}