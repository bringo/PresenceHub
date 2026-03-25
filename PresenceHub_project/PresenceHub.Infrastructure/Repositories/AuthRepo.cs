using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using PresenceHub.Infrastructure.DB_Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Infrastructure.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly HubDBcontext context;

        public AuthRepo(HubDBcontext context)
        {
            this.context = context;
        }
        public async Task<User> getdata(string username)
        {
            return await context.User.FindAsync(username);
        }
    }
}
