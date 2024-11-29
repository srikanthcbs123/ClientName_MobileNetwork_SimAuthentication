using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.DTOs;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces
{
    public interface IUserRepository
    {
        Task<UserSignInResponse> UserSignIn(UserSignIn urdetail);
        Task<UserSignUpResponse> UserSignUp(UserSignUp urdetail);
    }
}
