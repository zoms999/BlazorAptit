using BlazorAptit.Models;
using BlazorAptit.Models.Account;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAptit.Services
{
    public interface IAccountService
    {
        User User { get; }
        Task Login(Login model);
        Task Logins(Login model);
        Task Register(AddUser model);

    }

    public class AccountService : IAccountService
    {
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public User User { get; private set; }

        public AccountService(
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Login(Login model)
        {
            //User = await _httpService.Post<User>("/users/authenticate", model);
            await _localStorageService.SetItem(_userKey, model);
        }

        public async Task Logins(Login model)
        {
            //User = await _httpService.Post<User>("/users/authenticate", model);
            await _localStorageService.SetItem(_userKey, model);
        }
        public async Task Register(AddUser model)
        {
            //await _httpService.Post("/users/register", model);
        }

    }
}