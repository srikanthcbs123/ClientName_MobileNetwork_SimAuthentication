using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.DTOs;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces;
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
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
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
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
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
