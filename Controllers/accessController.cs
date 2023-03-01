using IES_ADMIN_ACADEM_API.Config;
using IES_ADMIN_ACADEM_API.Entities;
using IES_ADMIN_ACADEM_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;

namespace IES_ADMIN_ACADEM_API.Controllers
{
    [ApiController]
    public class AccessController : ControllerBase
    {

        private readonly ILogger<AccessController> _logger;
        //Start custom auxiliar methods
        string[] dataDecoder(string cad)
        {
            string[] d = cad.Split('!');
            byte[] bA = System.Convert.FromBase64String(d[0]);
            byte[] bB = System.Convert.FromBase64String(d[1]);
            return new string[] { Encoding.Default.GetString(bA), Encoding.Default.GetString(bB) };
        }
        //End custom auxiliar methods

        public AccessController(ILogger<AccessController> logger)
        {
            _logger = logger;
        }

        private readonly accessServices Services = new accessServices();



        [Route(Routing.IES_USER_EXISTENCEPROOF)]
        [HttpGet]
        public IActionResult user_validate_existence(string username) //test
        {
            _logger.Log(LogLevel.Information, "-API --SERVICE --USERNAME VALIDATION REQUESTED ---\t@" + username);
            //Set as var the operation we need, remember that 'var' keyword lets save any object
            var toDo = Services.validateUsername(username);

            //Verify answer isn't null and have a TRUE as answer for this service
            if (toDo != null && toDo == true)
            {
                //Return object
                return Ok(toDo);
            }
            else
            {
                //Result doesn't comply with business rule 
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NO_EXISTS);
            }
            
        }

        [Route(Routing.IES_USERS_MATCH)]
        [HttpGet]
        public IActionResult user_validate_match(string data)
        {
            //Decode data
            string[] param = dataDecoder(data);
            _logger.Log(LogLevel.Information, "-API --SERVICE ---USER ACCESS VALIDATION BY MATCH ----\t@" + param[0]);
            //Set as var the operation we need, remember that 'var' keyword lets save any object
            var toDo = Services.validateAccess(param[0], param[1]);

            //Verify answer isn't null and have a TRUE as answer for this service
            if (toDo != null && toDo == true)
            {
                //Return object
                return Ok(toDo);
            }
            else
            {
                //Result doesn't comply with business rule 
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_MISSMATCH);
            }
        }

        [Route(Routing.IES_USERS_DESKAPP_ACCESS)]
        [HttpGet]
        public IActionResult user_validate_deskapp(string data)
        {
            //Decode data
            string[] param = dataDecoder(data);
            _logger.Log(LogLevel.Information, "-API --SERVICE ---USER DESKAPP ACCESS VALIDATION ----\t@" + param[0]);
            //Objects to treat
            bool matchSelector = false;
            bool usrPkg = false;
            //Set as var the operation we need, remember that 'var' keyword lets save any object type
            Services.validateDeskappAccess(param[0], param[1], out matchSelector, out usrPkg);

            //Verify answer isn't null and have a TRUE as answer for this service
            if (usrPkg && matchSelector)
            {
                //Return object
                return Ok(true);
            }
            else
            {
                //Result doesn't comply with business rule 
                //Match but doesn't have deskapp access
                if (usrPkg && !matchSelector)
                {
                    //No access to deskapp
                    return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_DESKAPP);
                }
                else if (!usrPkg && !matchSelector) { }
                {
                    //Doesn't match so doesn't have deskapp access
                    return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_MISSMATCH);
                }
            }
        }

        [Route(Routing.IES_USERS_SYSINFO_PERMISSIONS)]
        [HttpGet]
        public IActionResult user_getApps(string data)
        {
            //Decode data
            string[] param = dataDecoder(data);
            _logger.Log(LogLevel.Information, "-API --SERVICE ---USER PROFILE DATA ----\t@" + param[0]);
            //Objects to treat
            bool thereApps = true;
            bool userExistence = true;
            List<sisInfoUser> toReturn = null;
            //Set as var the operation we need, remember that 'var' keyword lets save any object type
            var pkg = Services.get_user_apps(param[0],out thereApps, out userExistence);
            

            if (userExistence) {
                //User exists
                if (!thereApps) { 
                    //No apps assigned
                    return StatusCode(412, BusinessErrorCodes.USER_GETAPPPERMISSIONS_NORECORDS);
                }
            }
            else
            {
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NO_EXISTS);
            }

            return Ok(pkg);
        }


        [Route(Routing.IES_USERS_GETPROFILE)]
        [HttpGet]
        public IActionResult user_getProfile(string data) {
            //Decode data
            string[] param = dataDecoder(data);
            _logger.Log(LogLevel.Information, "-API --SERVICE ---USER APPS AND PERMISSIONS ----\t@" + param[0]);
            //Objects to treat
            bool userExistence = true;
            //Set as var the operation we need, remember that 'var' keyword lets save any object type
            var pkg = Services.getProfileData(param[0], param[1], out userExistence);

            if (userExistence)
            {
                if(pkg == null)
                {
                    return StatusCode(412, BusinessErrorCodes.USER_GETPROFILE_DATA_EMPTY);
                }
            }
            else
            {
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NO_EXISTS) ;
            }

            return Ok(pkg);
        }

        [Route(Routing.IES_USERS_DESKAPP_RECORDACCESS)]
        [HttpGet]
        public IActionResult user_updateLastAccessRecord(string data) {
            //Decode data
            string[] param = dataDecoder(data);
            _logger.Log(LogLevel.Information, "-API --SERVICE ---UPDATE USER LAST ACCESS DATE ----\t@" + param[0]);
            //Object to send
            string newDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (Services.updUserLastAccessRecord(param[0], param[1], newDate)){
                return Ok(true);
            }
            else
            {
                return StatusCode(412, BusinessErrorCodes.USER_ATTRIBUTEUPDATE_FAILS) ;
            }
        }

    }
}
