using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// UserOrderCreateEditVM
    /// </summary>
    public class UserOrderCreateEditVM
    {
        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; set; } = default!;
        /// <summary>
        /// AppUser
        /// </summary>
        public AppUser AppUser { get; set; } = default!;
        /// <summary>
        /// UserOrderSelectList
        /// </summary>
        public SelectList UserOrderSelectList { get; set; } = default!;
    }
}