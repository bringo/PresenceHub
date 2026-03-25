using log4net;
using Microsoft.EntityFrameworkCore;
using PresenceHub.Application.DTO;
using PresenceHub.Application.InterfaceService;

using PresenceHub.Domain.Entity;
using PresenceHub.Domain.InterfaceRepo;
using System;
using System.Threading.Tasks;


namespace PresenceHub.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo auth;
        private readonly ITokenService _tokenService;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AuthService));

        

        public AuthService(IAuthRepo auth, ITokenService tokenService)
        {
            this.auth = auth;
            _tokenService = tokenService;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            try
            {
                _logger.Info($"Login attempt: {dto.UserName}");

                var user = await auth.getdata(dto.UserName);
                if (user == null)
                {
                    _logger.Warn("User not found");
                    return null;
                }

                if (     user.Username == dto.UserName &&
                        user.Password == dto.Password)
                {
                        _logger.Info("Credentials validated");
                    _logger.Info("Login successful");

                    return _tokenService.GenerateToken(user);
                }

                else
                {
                    _logger.Warn("Invalid credentials");
                    return null;
                }

               
            }
            catch (Exception ex)
            {
                _logger.Error("Error during login", ex);
                throw;
            }
        }
    }
}