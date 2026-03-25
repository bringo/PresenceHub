using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Domain.InterfaceRepo
{
    public interface IAuthRepo
    {
        Task<User> getdata(string username);
    }
}
