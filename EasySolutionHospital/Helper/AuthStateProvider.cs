using Blazored.SessionStorage;
using EasySolutionHospital.Shared.ResponseModel;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace EasySolutionHospital.Helper
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        public AuthStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var authUser = await _sessionStorage.GetItemAsync<string>("auth");
                var user = JsonSerializer.Deserialize<LoginResponse>(authUser);
                if (user != null)
                {
                    identity = new ClaimsIdentity(new[]
                    {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                            new Claim(ClaimTypes.SerialNumber, user.TotalPurchases.ToString())
                        }, "Authentication");

                }
                var state = new AuthenticationState(new ClaimsPrincipal(identity));
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }
            catch
            {
                var state = new AuthenticationState(new ClaimsPrincipal(identity));
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }
        }

        public async Task SetStateAsync(string authUser)
        {
            await _sessionStorage.SetItemAsync("auth", authUser);

            var state = await GetAuthenticationStateAsync();

            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        public async Task ClearStateAsync()
        {
            await _sessionStorage.RemoveItemAsync("auth");

            var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        public async Task SetProfileAmountAync(int? amount = 0)
        {
            await _sessionStorage.SetItemAsync("amount", amount);
        }
    }
}
