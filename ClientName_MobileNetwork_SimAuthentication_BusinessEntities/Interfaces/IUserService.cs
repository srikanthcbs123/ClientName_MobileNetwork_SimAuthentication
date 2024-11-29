using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces
{
    public interface IUserService
    {
        Task<UserSignInResponse> UserSignIn(UserSignInDto userDetailDto);
        Task<UserSignUpResponse> UserSignUp(UserSignUpDto userDetailDto);
    }
}
