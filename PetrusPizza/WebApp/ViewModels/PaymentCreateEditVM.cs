using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
            
    /// <summary>
    /// PaymentCreateEditVM
    /// </summary>
    public class PaymentCreateEditVM
    {

        /// <summary>
        /// Payment
        /// </summary>
        public Payment Payment { get; set; } = default!;
        
        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; set; } = default!;
        /// <summary>
        /// OrderSelectList
        /// </summary>
        public SelectList OrderSelectList { get; set; } = default!;

        /// <summary>
        /// PaymentMethod
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; } = default!;
        /// <summary>
        /// PaymentMethodSelectList
        /// </summary>
        public SelectList PaymentMethodSelectList { get; set; } = default!;

        /// <summary>
        /// AppUser
        /// </summary>
        public AppUser AppUser { get; set; } = default!;
        /// <summary>
        /// AppUserSelectList
        /// </summary>
        public SelectList AppUserSelectList { get; set; } = default!;
    }
}