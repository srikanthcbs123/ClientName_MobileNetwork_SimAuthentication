using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.DTOs;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Entities;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientName_MobileNetwork_SimAuthentication_ServiceLayer
{
    public class UserServices : IUserService
    {
       private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async  Task<UserSignInResponse> UserSignIn(UserSignInDto userDetailDto)
        {
            UserSignIn usi = new UserSignIn();
            usi.UserName = userDetailDto.UserName;
            usi.Password = userDetailDto.Password;
            var res = await _userRepository.UserSignIn(usi);
            return res;
        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUpDto userDetailDto)
        {
            UserSignUp usi = new UserSignUp();
            usi.FullName = userDetailDto.FullName;
            usi.Username = userDetailDto.Username;
            usi.Email = userDetailDto.Email;
            usi.Password = userDetailDto.Password;
            var res = await _userRepository.UserSignUp(usi);
            return res;
        }
    }
}
