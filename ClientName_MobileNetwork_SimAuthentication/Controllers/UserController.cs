using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.DTOs;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces;
using System.Text;
namespace ClientName_MobileNetwork_SimAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("UserSignIn")]
        public async Task<IActionResult> UserSignIn([FromBody] UserSignInDto userSignInDto)
        {
            try
            {

               //dont use multiple string  concadination purpose below process.
               //use stringbuilder concept beacuse it reduces the object creation.
                string a = "hello";//it will create object
                string b = "hai";//it will create object
                string c = "hyderabad";//it will create object
                string result = a + b + c;//it will create object

                // Initialize a StringBuilder to store validation messages
                StringBuilder validationMessages = new StringBuilder();//it will create only one object

                // Validate input fields
                if (string.IsNullOrWhiteSpace(userSignInDto.UserName) || string.IsNullOrEmpty(userSignInDto.UserName))
                {
                    validationMessages.AppendLine("UserName is required.");//in that object we are appending the data
                }

                if (string.IsNullOrWhiteSpace(userSignInDto.Password) || string.IsNullOrEmpty(userSignInDto.Password))
                {
                    validationMessages.AppendLine("Password is required.");//in that object we are appending the data
                }
                if (validationMessages.Length>0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, Convert.ToString(validationMessages));
                }
                //if (!ModelState.IsValid)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                //}
                else
                {
                    var res = await _userService.UserSignIn(userSignInDto);
                    return Ok(res);
                    // return StatusCode(StatusCodes.Status200OK, { "result": res.Error_Message });
                    // return StatusCode(Convert.ToInt32(res."sucess"), res.Error_Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("UserSignUp")]
        public async Task<IActionResult> UserSignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            try
            {
                
                //use stringbuilder concept beacuse it reduces the object creation.
                // Initialize a StringBuilder to store validation messages
                StringBuilder validationMessages = new StringBuilder();//it will create only one object

                // Validate input fields
                if (string.IsNullOrWhiteSpace(userSignUpDto.Username) || string.IsNullOrEmpty(userSignUpDto.Username))
                {
                    validationMessages.AppendLine("UserName is required.");//in that object we are appending the data
                }

                if (string.IsNullOrWhiteSpace(userSignUpDto.Password) || string.IsNullOrEmpty(userSignUpDto.Password))
                {
                    validationMessages.AppendLine("Password is required.");//in that object we are appending the data
                }
                if (string.IsNullOrWhiteSpace(userSignUpDto.FullName) || string.IsNullOrEmpty(userSignUpDto.FullName))
                {
                    validationMessages.AppendLine("FullName is required.");//in that object we are appending the data
                }

                if (string.IsNullOrWhiteSpace(userSignUpDto.Email) || string.IsNullOrEmpty(userSignUpDto.Email))
                {
                    validationMessages.AppendLine("Email is required.");//in that object we are appending the data
                }
                if (validationMessages.Length > 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, Convert.ToString(validationMessages));
                }
                //if (!ModelState.IsValid)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                //}
                else
                {
                    var res = await _userService.UserSignUp(userSignUpDto);
                    return Ok(res);
                    //return StatusCode(StatusCodes.Status200OK, res.Error_Message);
                    // return StatusCode(Convert.ToInt32(res.Error_Code), res.Error_Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
