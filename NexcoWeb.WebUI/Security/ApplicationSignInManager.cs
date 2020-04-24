using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexcoWeb.WebUI.Security
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}