using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// PizzaOrderCreateEditVM
    /// </summary>
    public class PizzaOrderCreateEditVM
    {
        /// <summary>
        /// PizzaOrder
        /// </summary>
        public PizzaOrder PizzaOrder { get; set; } = default!;
        
        /// <summary>
        /// PizzaName
        /// </summary>
        public PizzaName PizzaName { get; set; } = default!;
        /// <summary>
        /// PizzaNameSelectList
        /// </summary>
        public SelectList PizzaNameSelectList { get; set; } = default!;
        /// <summary>
        /// PizzaSize
        /// </summary>
        public PizzaSize PizzaSize { get; set; } = default!;
        /// <summary>
        /// PizzaSizeSelectList
        /// </summary>
        public SelectList PizzaSizeSelectList { get; set; } = default!;
        /// <summary>
        /// PizzaType
        /// </summary>
        public PizzaType PizzaType { get; set; } = default!;
        /// <summary>
        /// PizzaTypeSelectList
        /// </summary>
        public SelectList PizzaTypeSelectList { get; set; } = default!;
            
    }
}