using AutoMapper.Internal.Mappers;
using IES_ADMIN_ACADEM_API.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Tls;
using System.Data;

namespace IES_ADMIN_ACADEM_API.Repository
{
    /// <summary>
    /// Collection of methods that gather data from the DDBB
    /// </summary>
    public class UserRepository
    {
        //Object to handle DDBB connections and querys
        readonly daoManager daoMgr = new daoManager();

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// GET ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */
        
        /// <summary>
        /// Perform query to DDBB to get user basic profile data
        /// </summary>
        /// <param name="username">Username of target user</param>
        /// <returns>User profile object or NULL if there is no data</returns>
        public uf_personas GetUserProfileData(string username)
        {
            //Retrieve data as a datatable
            DataTable dt = daoMgr.retrieveDataObjects(string.Format(dbQueries.USER.GET_USER_BASIC_DATA_QUERY, username));
            //Get object data to map to class when dt have row count greater than 0
            var _Object = (dt.Rows.Count > 0) ? JArray.FromObject(dt).ToObject<List<uf_personas>>()[0] : null;
            //Return object casted to class
            return _Object;
        }

        /// <summary>
        /// Perform query to DDBB to get employee profile data
        /// </summary>
        /// <param name="username">Username of target user</param>
        /// <returns>Employee profile object or NULL if there is no data</returns>
        public uf_personas_empleado GetEmployeeProfile(string username)
        {
            //Retrieve data as datatable
            DataTable dt = daoMgr.retrieveDataObjects(string.Format(dbQueries.USER.GET_EMPLOYEE_PROFILE_QUERY, username));
            //Get object data to map to class when dt have row count greater than 0
            var _Object = (dt.Rows.Count > 0) ? JArray.FromObject(dt).ToObject<List<uf_personas_empleado>>()[0] : null;
            //Return object casted to class
            return _Object;
        }

        /// <summary>
        /// Perform query to DDBB to get student profile data
        /// </summary>
        /// <param name="username">Username of target user</param>
        /// <returns>Student profile object or NULL if there is no data</returns>
        public uf_personas_estudiante GetStudentProfile(string username)
        {
            //Retrieve data as datatable
            DataTable dt = daoMgr.retrieveDataObjects(string.Format(dbQueries.USER.GET_STUDENT_PROFILE_QUERY, username));
            //Get object data to map to class when dt have row count greater than 0
            var _Object = (dt.Rows.Count > 0) ? JArray.FromObject(dt).ToObject<List<uf_personas_estudiante>>()[0] : null;
            //Return object casted to class
            return _Object;

        }

        /// <summary>
        /// Perform validation between passwords, password provided by login procedure and the password stored in ddbb
        /// </summary>
        /// <param name="username">Username of user target</param>
        /// <param name="pwd">Password of user target</param>
        /// <returns>TRUE or FALSE</returns>
        public bool MatchLogin(string username,string pwd)
        {
            //Retrieve data as string
            string pwdHashed = (string)daoMgr.retrieveSingleValue(string.Format(dbQueries.USER.MATCH_LOGIN_QUERY, username));
            return  BCrypt.Net.BCrypt.Verify(pwd,pwdHashed);
        }

        /// <summary>
        /// Perform validation to get access to DESKAPP environment for an employee
        /// </summary>
        /// <param name="username">Employee's username</param>
        /// <returns>TRUE or FALSE</returns>
        public bool ValidateDeskappAccess(string username)
        {
            //Retrieve data as bool
            return Convert.ToBoolean(daoMgr.retrieveSingleValue(string.Format(dbQueries.USER.DESKAPP_ACCESS_QUERY, username)));
        }

        /// <summary>
        /// Perform validation to get access to student environmente
        /// </summary>
        /// <param name="username">Student's username</param>
        /// <returns>TRUE or FALSE</returns>
        public bool ValidateStudentAccess(string username)
        {
            //Retrieve data as bool
            return Convert.ToBoolean(daoMgr.retrieveSingleValue(string.Format(dbQueries.USER.STUDENT_ACCESS_QUERY, username)));
        }

        /// <summary>
        /// Perform query to get a list of the applications that a user is able to use
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of sysinfo_userapps</returns>
        public List<uf_sisinfo_AppsAndPermissions> UserGetAppsAndPermissions(string username)
        {
            //Retrieve data as datatable
            DataTable dt = daoMgr.retrieveDataObjects(string.Format(dbQueries.USER.SISINFO_APPS_PERMISSIONS_QUERY, username));
            //Get object data to map to class when dt have row count greater than 0
            var _Object = (dt.Rows.Count > 0) ? JArray.FromObject(dt).ToObject<List<uf_sisinfo_AppsAndPermissions>>() : null;
            //Return object casted to class
            return _Object;
        }

        /// <summary>
        /// Perform validation of user's existence by its id
        /// Used for sign-up procedures
        /// </summary>
        /// <param name="id">User's identification</param>
        /// <returns>TRUE/FALSE</returns>
        public bool GetValidationUserById(string id) {
            //Perform validation
            return Convert.ToBoolean(daoMgr.retrieveSingleValue(string.Format(dbQueries.USER.GET_VALIDATION_BY_ID, id)));
        }

        /// <summary>
        /// Perform validation of a username existence
        /// </summary>
        /// <param name="username">Wanted username for sign-up</param>
        /// <returns>TRUE/FALSE</returns>
        public bool GetValidationUsername(string username)
        {
            //Perform validation
            return Convert.ToBoolean(daoMgr.retrieveSingleValue(string.Format(dbQueries.USER.GET_USERNAME_AVAILABLE, username)));
        }

        /// <summary>
        /// Perform validation of user's existence by its personal email address
        /// Used for sign-up procedures
        /// </summary>
        /// <param name="email">User's personal email address</param>
        /// <returns>TRUE/FALSE</returns>
        public bool GetValidationSignupEmail(string email)
        {
            //Perform validation
            return Convert.ToBoolean(daoMgr.retrieveSingleValue(string.Format(dbQueries.USER.GET_VALIDATION_BY_EMAIL, email)));
        }


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// POST ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Perform addition of a new user profile data
        /// </summary>
        /// <param name="userprofile">User profile object</param>
        /// <returns>TRUE or FALSE</returns>
        public bool AddUser(uf_personas userprofile)
        {
            //Perfom addition
            return daoMgr.updateData(string.Format(dbQueries.USER.INSERT_PERSONA_QUERY,
                userprofile.prsn_ID,
                userprofile.prsn_NOM,
                userprofile.prsn_APE,
                userprofile.prsn_USUARIO,
                userprofile.prsn_GEN,
                userprofile.prsn_EMAIL_PERSONAL,
                userprofile.prsn_EMAIL_LABORAL,
                userprofile.prsn_ORIGEN_PAIS,
                userprofile.prsn_ORIGEN_CIUDAD,
                userprofile.prsn_RESIDE_PAIS,
                userprofile.prsn_RESIDE_CIUDAD,
                userprofile.prsn_ESCOLARIDAD,
                userprofile.prsn_PKEY
                )) == 1;
        }

        /// <summary>
        /// Perform insertion of a work event log
        /// </summary>
        /// <param name="workEventLog">Object with data to insert</param>
        /// <returns>TRUE for correct insertion / FALSE for insertion execution error</returns>
        public bool AddEmployeeActivityLog(uf_registro_ejecutivo workEventLog)
        {
            return daoMgr.updateData(string.Format(dbQueries.USER.ADD_EVENT_LOG_WORK,
                                                    workEventLog.cod_EMPLEADO,
                                                    workEventLog.reg_APPSET,
                                                    workEventLog.reg_ACTION_DESCR)) == 1;
        }

        /// <summary>
        /// Perform insertion of a student event log
        /// </summary>
        /// <param name="stdEventLog">Object with data to insert</param>
        /// <returns>TRUE for correct insertion / FALSE for insertion execution error</returns>
        public bool AddStudentActivityLog(uf_estudiantes_registro_ejecutivo stdEventLog)
        {
            return daoMgr.updateData(string.Format(dbQueries.USER.ADD_EVENT_LOG_STDNT,
                                                    stdEventLog.cod_ESTUDIANTE,
                                                    stdEventLog.reg_APPSET,
                                                    stdEventLog.reg_ACTION_DESCR)) == 1;
        }

        


        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// PATCH //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Perform update of one or more attributes of a user
        /// Used by full object update service too
        /// </summary>
        /// <param name="usr">Username target</param>
        /// <returns>Can return uf_personas object or NULL instead.</returns>
        public bool GeneralUpdateUserProfile(uf_personas usr){
            /**
             * IMPORTANT: Due to business rule, no one can change the signup date of a user.
             * This procedure has an SQL query that doesn't touch that, just can update the fields showed.
             */
            if (
                daoMgr.updateData(string.Format(dbQueries.USER.UPDATE_ITEM_PERSONA_QUERY,
                                                usr.prsn_ID,
                                                usr.prsn_NOM,
                                                usr.prsn_APE,
                                                usr.prsn_GEN,
                                                usr.prsn_EMAIL_PERSONAL,
                                                usr.prsn_EMAIL_LABORAL,
                                                usr.prsn_ORIGEN_PAIS,
                                                usr.prsn_ORIGEN_CIUDAD,
                                                usr.prsn_RESIDE_PAIS,
                                                usr.prsn_RESIDE_CIUDAD,
                                                usr.prsn_ESCOLARIDAD,
                                                usr.prsn_PKEY,
                                                usr.prsn_RECOVERY_QUEST,
                                                usr.prsn_RECOVERY_ANS,
                                                usr.prsn_USUARIO)
                ) == 1
                ) {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Perform employee's last access date update
        /// </summary>
        /// <param name="username">Employee's username</param>
        /// <param name="newdate">Last date of access (Generated by system on realtime)</param>
        /// <returns>TRUE or FALSE</returns>
        public bool SetUserLastAccessDeskapp(string username, string newdate)
        {
            //Perform update
            return (daoMgr.updateData(string.Format(dbQueries.USER.UPDATE_DESKAPP_LAST_ACCESS_QUERY, username, newdate)) == 1);
        }

        /// <summary>
        /// Perform student's last access date update
        /// </summary>
        /// <param name="username">Student's username</param>
        /// <param name="newdate">Last date of access (Generated by system on realtime)</param>
        /// <returns>TRUE or FALSE</returns>
        public bool SetStudentLastAccessDeskapp(string username, string newdate)
        {
            //Perform update
            return (daoMgr.updateData(string.Format(dbQueries.USER.UPDATE_STUDENT_LAST_ACCESS_QUERY, username, newdate)) == 1);
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// PUT ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// DELETE /////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Delete user profile
        /// [ON DEVELOPMENT]
        /// Just delete the record on uf_personas table
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteUser(string username)
        {
            //Perform remotion
            return (daoMgr.updateData(string.Format(dbQueries.USER.DELETE_SOLO_PERSONA_QUERY, username)) == 1);
        }
    }
}
