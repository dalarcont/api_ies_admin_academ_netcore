using Abp.Extensions;
using AutoMapper.Internal.Mappers;
using BCrypt.Net;
using IES_ADMIN_ACADEM_API.Config;
using IES_ADMIN_ACADEM_API.Controllers;
using IES_ADMIN_ACADEM_API.Entities;
using IES_ADMIN_ACADEM_API.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Tls;
using System.Net;
using System.Runtime.Serialization;

namespace IES_ADMIN_ACADEM_API.Services
{
    /// <summary>
    /// Service processor that contains business logic procedures and rules to simplify endpoint controller<br />
    /// It's necessary to add inheritance of ControllerBase to perform value returning or 'throw' another status code different than 200(OK)<br/>
    /// IMPORTANT: All OK procedures that results in the answer to provide and finish the request MUST HAVE to be casted to IActionResult
    /// </summary>
    public class UserService : ControllerBase
    {
        //Logger 
        private readonly ILogger<UserService> EventLogger;

        //Object to handle repository services
        readonly UserRepository userRepository = new UserRepository();

        //Constructor of service
        public UserService(ILogger<UserService> logger)
        {
            EventLogger = logger;
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// GET ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Validates if a user exists using its username, it doesn't matter the user role.
        /// Provide validation to logins, existence before user addition or user actions related.
        /// Used for internal API username validations
        /// </summary>
        /// <param name="username">Username target</param>
        /// <returns>bool</returns>
        public bool UserValidateExistence(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----VALIDATE USER EXISTENCE\t-----@{0}", username);
            return userRepository.GetValidationUsername(username);         
        }

        /// <summary>
        /// Returns user basic profile data
        /// </summary>
        /// <param name="username"></param>
        /// <returns>User profile Object</returns>
        public IActionResult GetUserProfileData(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----USER PROFILE DATA\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                var _Object = userRepository.GetUserProfileData(username);
                if (_Object != null)
                {
                    return Ok(_Object);
                }
                else
                {
                    return StatusCode(412, BusinessErrorCodes.USER_GETPROFILE_DATA_EMPTY);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }

        /// <summary>
        /// Returns employee profile data
        /// </summary>
        /// <param name="username">Username of employee</param>
        /// <returns>Employee profile Object</returns>
        public IActionResult GetEmployeeProfile(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----EMPLOYEE PROFILE DATA\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                var _Object = userRepository.GetEmployeeProfile(username);
                if (_Object != null)
                {
                    return Ok(_Object);
                }
                else
                {
                    return StatusCode(412, BusinessErrorCodes.USER_GETPROFILE_DATA_EMPTY);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }

        /// <summary>
        /// Returns student profile data
        /// </summary>
        /// <param name="username">Username of student</param>
        /// <returns>Student profile Object</returns>
        public IActionResult GetStudentProfile(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----STUDENT PROFILE DATA\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                var _Object = userRepository.GetStudentProfile(username);
                if (_Object != null)
                {
                    return Ok(_Object);
                }
                else
                {
                    return StatusCode(412, BusinessErrorCodes.USER_GETPROFILE_DATA_EMPTY);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }

        /// <summary>
        /// Perform validation of access to Deskapp
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public IActionResult MatchLogin(string usr, string pwd)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----LOGIN ACCESS VALIDATION BY MATCH\t-----@{0}", usr);
            //Execution
            if (UserValidateExistence(usr))
            {
                if (userRepository.MatchLogin(usr, pwd))
                {
                    //Match!
                    return Ok(true);
                }
                else
                {
                    //Doesn't match
                    return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_MISSMATCH);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }

        }

        /// <summary>
        /// Service to validate an employee have access to system-info
        /// </summary>
        /// <param name="username">Username target</param>
        /// <returns>TRUE/FALSE</returns>
        public IActionResult ValidateDeskappAccess(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----DESKAPP ACCESS VALIDATION\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                if (userRepository.ValidateDeskappAccess(username))
                {
                    //Has access
                    return Ok(true);
                }
                else
                {
                    //Doesn't has access
                    return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_DESKAPP);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }

        }

        /// <summary>
        /// Service to validate a student have access to system-info
        /// </summary>
        /// <param name="username">Username target</param>
        /// <returns>TRUE/FALSE</returns>
        public IActionResult ValidateStudentAccess(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----STUDENT ACCESS VALIDATION\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                if (userRepository.ValidateStudentAccess(username))
                {
                    //Has access
                    return Ok(true);
                }
                else
                {
                    //Doesn't has access
                    return StatusCode(412, BusinessErrorCodes.USER_STD_ACCESS);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }

        /// <summary>
        /// Service to get and let system know apps that the user can afford
        /// </summary>
        /// <param name="username">Username target</param>
        /// <returns>List of apps info and permission objects</returns>
        public IActionResult UserGetAppsAndPermissions(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----USER APPS AND PERMISSIONS\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                //Object with app objects
                List<uf_sisinfo_AppsAndPermissions> userApps = userRepository.UserGetAppsAndPermissions(username);
                if (userApps != null)
                {
                    //Apps permissions found
                    return Ok(userApps);
                }
                else
                {
                    //Doesn't has apps related
                    return StatusCode(412, BusinessErrorCodes.USER_GETAPPPERMISSIONS_NORECORDS);
                }
            }
            else
            {
                //User doesn't exists so can't retrieve data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }

        }

        /// <summary>
        /// Service to know if there is a user associated to an specific Id
        /// </summary>
        /// <param name="id">User's id (NOT USERNAME)</param>
        /// <returns>TRUE/FALSE</returns>
        public IActionResult GetValidationUserById(string id) {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----VALIDATION OF EXISTENCE BY ID\t-----@{0}", id);
            //Execution
            return Ok(userRepository.GetValidationUserById(id));
        }

        /// <summary>
        /// Service to validate existence of user using the username
        /// This service was designed for user addition procedures
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns></returns>
        public IActionResult GetValidationSignupUsername(string username)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----VALIDATION OF EXISTENCE BY USERNAME ON USER ADDITION PROCEDURES\t-----@{0}", username);
            //Execution
            return Ok(userRepository.GetValidationUsername(username));
        }

        /// <summary>
        /// Service to know if there is a user associated to an specific personal email address
        /// </summary>
        /// <param name="email">User's personal email address</param>
        /// <returns></returns>
        public IActionResult GetValidationSignupEmail(string email)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----VALIDATION OF EXISTENCE BY EMAIL\t-----@{0}", email);
            //Execution
            return Ok(userRepository.GetValidationSignupEmail(email));
        }


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// POST ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Service to perform user addition to the system-info as a common user
        /// </summary>
        /// <param name="userprofile">User profile object with target user data</param>
        /// <returns></returns>
        public IActionResult AddUser(uf_personas userprofile)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---POST\t----ADD USER\t-----@{0} {1}", userprofile.prsn_APE, userprofile.prsn_NOM);
            //Execution
            //Perform password encryption
            /*
            *   DUE TO BUSINESS RULE, NO ONE, INCLUDED STAFF, CAN ASSIGN THE PASSWORD.
            *   FOR THE USER ADDITION PROCEDURE THE DEFAULT PASSWORD WILL BE USERNAME ASSIGNED + ID NUMBER OR IDENTIFICATION + CLOSES WITH '#'.
            */
            userprofile.prsn_PKEY = BCrypt.Net.BCrypt.HashPassword(userprofile.prsn_USUARIO + userprofile.prsn_ID + "#");
            if(!UserValidateExistence(userprofile.prsn_USUARIO))
            {
                //Can add the user
                if (userRepository.AddUser(userprofile))
                {
                    //Return profile created
                    userprofile             = userRepository.GetUserProfileData(userprofile.prsn_USUARIO);
                    IES_EmailModel emailPkg = new IES_EmailModel(
                                                IES_CONSTANTS.EMAIL_NAMES.INFO_REGISTRO , 
                                                IES_CONSTANTS.EMAIL_ADDRESS.NOREPLY     , 
                                                userprofile.prsn_EMAIL_PERSONAL         , 
                                                "Registro de usuario"                   , 
                                                IES_EmailTemplates.IES_DEV_WELCOME_NEW_USER(
                                                    new string[] {
                                                        "Registro de usuario",
                                                        userprofile.prsn_ID,
                                                        userprofile.prsn_USUARIO,
                                                        string.Concat(userprofile.prsn_NOM," ",userprofile.prsn_APE)
                                                    }), 
                                              true);
                    new EmailUtil(EventLogger).sendEmail_SMTP(emailPkg);
                    return Ok(userprofile);
                }
                else
                {
                    //There's something bad occurs with DDBB operation
                    return StatusCode(412, BusinessErrorCodes.USER_SIGNUP_QUERY_ERROR);
                }
            }
            else
            {
                //Can't add the user: duplicated username it means the user already exists
                return StatusCode(412, BusinessErrorCodes.USER_SIGNUP_DUPLICATED);
            }
        }

        /// <summary>
        /// Servie to perform addition of a work event log
        /// Established for work applications
        /// </summary>
        /// <param name="workLog">Work event log object</param>
        /// <returns></returns>
        public IActionResult AddEmployeeActivityLog(uf_registro_ejecutivo workLog) { 
            if(UserValidateExistence(workLog.cod_EMPLEADO))
            {
                //Employee profile exists
                //Perform data insertion
                if (userRepository.AddEmployeeActivityLog(workLog))
                {
                    //Worklog added
                    return Ok(true);
                }
                else
                {
                    //Worklog not added
                    return StatusCode(412, BusinessErrorCodes.USER_EVENTLOG_WORK_FAILS);
                }
            }
            else
            {
                //Target user doesn't exists
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }

        /// <summary>
        /// Servie to perform addition of a student event log
        /// Established for student applications
        /// </summary>
        /// <param name="stdLog">Student event log object</param>
        /// <returns></returns>
        public IActionResult AddStudentActivityLog(uf_estudiantes_registro_ejecutivo stdLog)
        {
            if (UserValidateExistence(stdLog.cod_ESTUDIANTE))
            {
                //Student profile exists
                //Perform data insertion
                if (userRepository.AddStudentActivityLog(stdLog))
                {
                    //Student event log added
                    return Ok(true);
                }
                else
                {
                    //Worklog not added
                    return StatusCode(412, BusinessErrorCodes.USER_EVENTLOG_STDNT_FAILS);
                }
            }
            else
            {
                //Target user doesn't exists
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// PATCH //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Service to perform partially attribute updates of user profile
        /// </summary>
        /// <param name="username">Username target</param>
        /// <param name="patch">JSON incoming data patched as object</param>
        /// <returns>uf_personas Object</returns>
        public IActionResult PatchUser(string username,JsonPatchDocument patch)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---PATCH\t----UPDATE USER ITEM\t-----@{0}", username);
            /**
             * IMPORTANT: Due to business rule, no one can change the signup date of a user.
             * This procedure will not touch that data field even if someone modify this procedure to treat it.
             */
            if (UserValidateExistence(username))
            {
                //Get current data
                uf_personas currentProfile = userRepository.GetUserProfileData(username);
                uf_personas newUser = new uf_personas();
                //Password change request validation previous password store
                //Patch jsonPatch object to class and data loaded in prev var
                patch.ApplyTo(newUser);
                //Password validation
                if (!newUser.prsn_PKEY.IsNullOrEmpty())
                {
                    //Requires new password
                    //Path to current data
                    patch.ApplyTo(currentProfile);
                    currentProfile.prsn_PKEY = BCrypt.Net.BCrypt.HashPassword(newUser.prsn_PKEY);
                }
                else
                {
                    patch.ApplyTo(currentProfile);
                }
                //Set upper and lower case rules
                currentProfile.prsn_NOM.ToUpper();
                currentProfile.prsn_APE.ToUpper();
                currentProfile.prsn_USUARIO.ToLower();
                currentProfile.prsn_EMAIL_PERSONAL.ToLower();
                currentProfile.prsn_EMAIL_LABORAL.ToLower();
                currentProfile.prsn_ORIGEN_CIUDAD.ToUpper();
                currentProfile.prsn_RESIDE_CIUDAD.ToUpper();
                //Perform update
                var _Object = userRepository.GeneralUpdateUserProfile(currentProfile);
                if(_Object != false) {
                    //Profile/profile items updated successful
                    //Get new profile object and return as a response
                    //Return it without validations, on this statement its clear that the user exists and the updates were applied.
                    return Ok(userRepository.GetUserProfileData(username));
                }
                else
                {
                    //Can't update
                    return StatusCode(412, BusinessErrorCodes.USER_ATTRIBUTEUPDATE_FAILS);
                }
            }
            else
            {
                //User doesn't exists
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }

        /// <summary>
        /// Service to set a new date to provide system information about when was the last access of a user
        /// </summary>
        /// <param name="username">Username target</param>
        /// <param name="newdate">New date format YYYY-MM-DD HH:mm:ss</param>
        /// <returns>TRUE/FALSE</returns>
        public IActionResult SetUserLastAccessDeskapp(string username, string newdate)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----UPDATE USER LAST ACCESS DATE ON DESKAPP\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                if (userRepository.SetUserLastAccessDeskapp(username, newdate))
                {
                    //Update done
                    return Ok(true);
                }
                else
                {
                    //Can't update
                    return StatusCode(412, BusinessErrorCodes.USER_ATTRIBUTEUPDATE_FAILS);
                }
            }
            else
            {
                //User doesn't exists so can't update data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }

        }

        /// <summary>
        /// Service to set a new date to provide system information about when was the last access of a user
        /// </summary>
        /// <param name="username">Username target</param>
        /// <param name="newdate">New date format YYYY-MM-DD HH:mm:ss</param>
        /// <returns>TRUE/FALSE</returns>
        public IActionResult SetStudentLastAccessDeskapp(string username, string newdate)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----UPDATE USER LAST ACCESS DATE ON STUDENT APPS\t-----@{0}", username);
            //Execution
            if (UserValidateExistence(username))
            {
                if (userRepository.SetStudentLastAccessDeskapp(username, newdate))
                {
                    //Update done
                    return Ok(true);
                }
                else
                {
                    //Can't update
                    return StatusCode(412, BusinessErrorCodes.USER_ATTRIBUTEUPDATE_FAILS);
                }
            }
            else
            {
                //User doesn't exists so can't update data
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }

        }


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// PUT ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Service to set a new date to provide system information when was the last access of a user
        /// </summary>
        /// <param name="username">Username target</param>
        /// <param name="newdate">New date format YYYY-MM-DD HH:mm:ss</param>
        /// <returns>TRUE/FALSE</returns>
        public IActionResult PutUser(string username, uf_personas putObj)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---PUT\t----UPDATE USER PROFILE\t-----@{0}", username);
            if (UserValidateExistence(username))
            {
                //Password validation
                if (putObj.prsn_PKEY.IsNullOrEmpty())
                {
                    //Set default password by business rule
                    putObj.prsn_PKEY = BCrypt.Net.BCrypt.HashPassword(putObj.prsn_USUARIO + putObj.prsn_ID + "#");
                }
                else
                {
                    //It comes with a custom password value
                    putObj.prsn_PKEY = BCrypt.Net.BCrypt.HashPassword(putObj.prsn_PKEY);
                }
                putObj.prsn_NOM.ToUpper();
                putObj.prsn_APE.ToUpper();
                putObj.prsn_USUARIO.ToLower();
                putObj.prsn_EMAIL_PERSONAL.ToLower();
                putObj.prsn_EMAIL_LABORAL.ToLower();
                putObj.prsn_ORIGEN_CIUDAD.ToUpper();
                putObj.prsn_RESIDE_CIUDAD.ToUpper();
                //Perform update
                var _Object = userRepository.GeneralUpdateUserProfile(putObj);
                if (_Object != null)
                {
                    //Update successful
                    //Get new profile object and return as a response
                    //Return it without validations, on this statement its clear that the user exists and the updates were applied.
                    return Ok(userRepository.GetUserProfileData(username));
                }
                else
                {
                    //Can't update
                    return StatusCode(412, BusinessErrorCodes.USER_PROFILE_UPDATE_FAILS);
                }
            }
            else
            {
                //User doesn't exists
                return StatusCode(412, BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// DELETE /////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */
        
        public IActionResult DeleteUser(string username)
        {
            if(UserValidateExistence(username))
            {
                //Target user exists
                if (userRepository.DeleteUser(username))
                {
                    //Success remotion
                    return Ok(true);
                }
                else
                {
                    //Can't delete
                    return StatusCode(412, BusinessErrorCodes.USER_REMOTION_FAILS);
                }
            }
            else
            {
                return StatusCode(412,BusinessErrorCodes.USER_VALIDATION_USER_NOEXISTS);
            }
        }
    }
}
