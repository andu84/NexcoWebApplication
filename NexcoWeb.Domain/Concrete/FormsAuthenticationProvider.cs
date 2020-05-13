﻿using NexcoWeb.Domain.Abstract;
using System;
using System.Data.Entity;

namespace NexcoWeb.Domain.Concrete
{
    public class FormsAuthenticationProvider : IAuthentication
    {
        private readonly EFDbContext context = new EFDbContext();

        public bool Authenticate(string username, string password)
        {
            var result = context.Users.FirstOrDefaultAsync(u => u.UserId == username &&
                                                            u.Password == password);
            if (result == null)
                return false;
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
