using System.Collections;
using System.Collections.Generic;
using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemRowCreateEditVM
    {
        /// <summary>
        /// ItemRow
        /// </summary>
        public ItemRow ItemRow { get; set; } = default!;
        /// <summary>
        /// PizzaOrder
        /// </summary>
        public PizzaOrder PizzaOrder { get; set; } = default!;
       
        //public SelectList PizzaOrderSelectList { get; set; } = default!;
    }
}