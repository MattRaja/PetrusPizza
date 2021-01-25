using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    /// <summary>
    /// BalanceCreateEditVM
    /// </summary>
    public class BalanceCreateEditVM
    {

        /// <summary>
        /// Balance
        /// </summary>
        public Balance Balance { get; set; } = default!;
        /// <summary>
        /// Payment
        /// </summary>
        public Payment Payment { get; set; } = default!;
        /// <summary>
        /// Person
        /// </summary>
        public Person Person { get; set; } = default!;
        /// <summary>
        /// AppUser
        /// </summary>
        public AppUser? AppUser { get; set; }
        /// <summary>
        /// PaymentSelectList
        /// </summary>
        public SelectList? PaymentSelectList { get; set; }
        /// <summary>
        /// PersonSelectList
        /// </summary>
        public SelectList? PersonSelectList { get; set; }
        /// <summary>
        /// AppUserSelectList
        /// </summary>
        public SelectList? AppUserSelectList { get; set; }

    }
}