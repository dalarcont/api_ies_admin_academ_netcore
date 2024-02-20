using IES_ADMIN_ACADEM_API.Config;
using IES_ADMIN_ACADEM_API.Entities;
using IES_ADMIN_ACADEM_API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Text;

namespace IES_ADMIN_ACADEM_API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        //Logger
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<UserController> _logger;

        //Business service logic processor
        private readonly UserService userServiceGeneral;

        //Declare custom auxiliar methods
        string[] dataDecoder(string cad)
        {
            string[] d   = cad.Split('!');
            byte[] bA    = System.Convert.FromBase64String(d[0]);
            byte[] bB    = System.Convert.FromBase64String(d[1]);
            return new string[] { Encoding.Default.GetString(bA), Encoding.Default.GetString(bB) };
        }
        //End custom auxiliar methods

        //Constructor
        public UserController(ILogger<UserController> logger,IServiceProvider serviceProvider)
        {
            //Following operations are for a logger instance passing between classes.
            _logger             = logger;
            _serviceProvider    = serviceProvider; 
            var LoggerThread    = _serviceProvider.GetService(typeof(ILogger<UserService>)) as ILogger<UserService>;
            userServiceGeneral  = new UserService(LoggerThread);
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// GET ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Validate existence of a user by its username
        /// </summary>
        /// <param name="username">username of target user</param>
        /// <returns>TRUE or FALSE</returns>
        [Route(Routes.GET.USERS.EXISTENCEPROOF)]
        [HttpGet]
        public IActionResult UserValidateExistence(string username)
        {
            return Ok(userServiceGeneral.UserValidateExistence(username));
        }

        /// <summary>
        /// Get user basic profile data
        /// </summary>
        /// <param name="username">username of target user</param>
        /// <returns>User profile object</returns>
        [Route(Routes.GET.USERS.GET_USER_PROFILE)]
        [HttpGet]
        public IActionResult GetUserProfileData(string username)
        {
            return userServiceGeneral.GetUserProfileData(username);
        }

        /// <summary>
        /// Get employee profile data
        /// </summary>
        /// <param name="username">username of target user</param>
        /// <returns>Employee profile object</returns>
        [Route(Routes.GET.USERS.GET_EMPLOYEE_PROFILE)]
        [HttpGet]
        public IActionResult GetEmployeeProfile(string username)
        {
            return userServiceGeneral.GetEmployeeProfile(username);
        }

        /// <summary>
        /// Get student profile data
        /// </summary>
        /// <param name="username">username of target user</param>
        /// <returns>Student profile object</returns>
        [Route(Routes.GET.USERS.GET_STUDENT_PROFILE)]
        [HttpGet]
        public IActionResult GetStudentProfile(string username)
        {
            return userServiceGeneral.GetStudentProfile(username);
        }

        /// <summary>
        /// Validate match between the credentials of a user
        /// </summary>
        /// <param name="data">Encoded credentials on single string</param>
        /// <returns></returns>
        [Route(Routes.GET.USERS.MATCH_LOGIN)]
        [HttpGet]
        public IActionResult MatchLogin(string data)
        {
            return userServiceGeneral.MatchLogin(dataDecoder(data)[0],dataDecoder(data)[1]);
        }

        /// <summary>
        /// Validate deskapp access
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.GET.USERS.DESKAPP_ACCESS)]
        [HttpGet]
        public IActionResult ValidateDeskappAccess(string data)
        {
            return userServiceGeneral.ValidateDeskappAccess(data);
        }

        /// <summary>
        /// Validate student access
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.GET.USERS.STUDENT_ACCESS)]
        [HttpGet]
        public IActionResult ValidateStudentAccess(string data)
        {
            return userServiceGeneral.ValidateStudentAccess(data);
        }

        /// <summary>
        /// Get app info and permissions for a deskapp user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.GET.USERS.SYSINFO_PERMISSIONS)]
        [HttpGet]
        public IActionResult UserGetAppsAndPermissions(string data)
        {
            return userServiceGeneral.UserGetAppsAndPermissions(dataDecoder(data)[0]);
        }

        /// <summary>
        /// Validate existence of a username by its identification number/serial for sign-up statements
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.GET.USERS.EXISTENCEPROOF_BYID)]
        [HttpGet]
        public IActionResult GetValidationByID(string data)
        {
            return userServiceGeneral.GetValidationUserById(data);
        }

        /// <summary>
        /// Validate existence of a user by email for sign-up statements
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.GET.USERS.USR_ADD_VAL_EMAIL)]
        [HttpGet]
        public IActionResult GetValidationSignupEmail(string data)
        {
            return userServiceGeneral.GetValidationSignupEmail(data);
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// POST ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Add user profile
        /// </summary>
        /// <param name="userprofile"></param>
        /// <returns></returns>
        [Route(Routes.USERS_ENDPOINT_PUBLIC)]
        [HttpPost]
        public IActionResult AddUser([FromBody]uf_personas userprofile)
        {
            if (userprofile == null)
            {
                return BadRequest();
            }
            else
            {
                return userServiceGeneral.AddUser(userprofile);
            }
        }

        /// <summary>
        /// Add event log for work environment actions by the employees
        /// </summary>
        /// <param name="worklog"></param>
        /// <returns></returns>
        [Route(Routes.POST.USERS.ADD_EVENT_WORKLOG)]
        [HttpPost]
        public IActionResult AddEmployeeActivityLog([FromBody]uf_registro_ejecutivo worklog)
        {
            return userServiceGeneral.AddEmployeeActivityLog(worklog);
        }

        /// <summary>
        /// Add event log for student environment actions by the students
        /// </summary>
        /// <param name="stdLog">Object with event specs</param>
        /// <returns></returns>
        [Route(Routes.POST.USERS.ADD_EVENT_STDNTLOG)]
        [HttpPost]
        public IActionResult AddStudentActivityLog([FromBody] uf_estudiantes_registro_ejecutivo stdLog)
        {
            return userServiceGeneral.AddStudentActivityLog(stdLog);
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// PATCH //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Update item of userprofile
        /// </summary>
        /// <param name="data"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [Route(Routes.USERS_ENDPOINT_PUBLIC+Routes.BODY)]
        [HttpPatch]
        public IActionResult PatchUser(string data, [FromBody]JsonPatchDocument patchDocument)
        {
            if(patchDocument != null)
            {
                return userServiceGeneral.PatchUser(data, patchDocument);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update last access date of a user inside deskapp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.PATCH.USERS.SYSTEM_DESKAPP_RECORDACCESS)]
        [HttpPatch]
        public IActionResult SetUserLastAccessDeskapp(string data)
        {
            string newdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return userServiceGeneral.SetUserLastAccessDeskapp(dataDecoder(data)[0], newdate);
        }

        /// <summary>
        /// Update last access date of a student on its portal 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route(Routes.PATCH.USERS.SYSTEM_STD_RECORDACCESS)]
        [HttpPatch]
        public IActionResult SetStudentLastAccessDeskapp(string data)
        {
            string newdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return userServiceGeneral.SetStudentLastAccessDeskapp(dataDecoder(data)[0], newdate);
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// PUT ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Update user profile
        /// </summary>
        /// <param name="username">Target username</param>
        /// <param name="userprofile">uf_personas Object with new data</param>
        /// <returns></returns>
        [Route(Routes.PUT.USERS.UPDATE_USER_PROFILE)]
        [HttpPut]
        public IActionResult PutUSer(string username, [FromBody]uf_personas userprofile)
        {
            if(userprofile != null)
            {
                return userServiceGeneral.PutUser(username, userprofile);
            }
            else
            {
                return BadRequest();
            }
        }


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// DELETE /////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Performs remotion of user's record on table uf_personas
        /// [ON DEVELOPMENT]
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Route(Routes.DELETE.USERS.DELETE_USER)]
        [HttpDelete]
        public IActionResult DeleteUser(string username)
        {
            return userServiceGeneral.DeleteUser(username);
        }
    }
}
