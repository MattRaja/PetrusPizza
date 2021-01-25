using ee.itcollege.mrajam.Contracts.DAL.Base;
using Microsoft.AspNetCore.Http;

namespace WebApp.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserNameProvider : IUserNameProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public UserNameProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CurrentUserName  => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "-";
    }
}