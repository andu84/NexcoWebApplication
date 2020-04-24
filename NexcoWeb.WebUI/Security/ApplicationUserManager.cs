using Microsoft.AspNet.Identity;
using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexcoWeb.WebUI.Security
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore)
            : base(userStore)
        {
        }
    }
}