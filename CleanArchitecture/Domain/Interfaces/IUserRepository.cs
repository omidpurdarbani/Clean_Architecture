using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        void Save();

    }
}
