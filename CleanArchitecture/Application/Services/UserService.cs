using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class UserService:IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public CheckUser CheckUserName(string username)
        {
            bool nameNotValid = _userRepository.IsExistUserName(username);
            return nameNotValid ? CheckUser.NotValid : CheckUser.Ok;
        }

        public CheckUser CheckEmail(string email)
        {
            bool emailNotValid = _userRepository.IsExistEmail(email);
            return emailNotValid ? CheckUser.NotValid : CheckUser.Ok;
        }

        public int RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.Save();
            return user.Id;
        }
    }
}
