using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        CheckUser CheckUserName(string username);
        CheckUser CheckEmail(string email);
        int RegisterUser(User user);
    }
}
