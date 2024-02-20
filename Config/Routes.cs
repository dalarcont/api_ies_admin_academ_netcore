using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;

namespace IES_ADMIN_ACADEM_API.Config
{
    /// <summary>
    /// Endpoint general directory
    /// </summary>
    public static class Routes
    {
        //General paths
        const string API_PATH = "api/ies";
        //Endpoints base
        const string USERS_ENDPOINT     = "/users";
        const string GENERAL_ENDPOINT   = "/general";
        public const string BODY        = "/{data}";
        //Endpoints path
        public const string USERS_ENDPOINT_PUBLIC   = API_PATH + USERS_ENDPOINT;
        public const string GENERAL_ENDPOINT_PUBLIC = API_PATH + GENERAL_ENDPOINT;


        // ENDPOINTS Showed as a tree Method type>Environment>Endpoint (e.g., GET>USERS>Endpoint)

        //GET
        public static class GET {

            //Routes for USERS endpoint controller
            public static class USERS
            {
                //Get validation/existence proof of a user by its username and password
                public const string EXISTENCEPROOF          = (USERS_ENDPOINT_PUBLIC + "/{username}");
                //Get validation of SIS_INFO access for anyone
                public const string MATCH_LOGIN             = (USERS_ENDPOINT_PUBLIC + "/{data}/matchlogin");
                //Get user profile data
                public const string GET_USER_PROFILE        = (USERS_ENDPOINT_PUBLIC + "/{username}/profiledata");
                //Get employee work profile data
                public const string GET_EMPLOYEE_PROFILE    = (USERS_ENDPOINT_PUBLIC + "/{username}/employeeprofile");
                //Get student profile data
                public const string GET_STUDENT_PROFILE     = (USERS_ENDPOINT_PUBLIC + "/{username}/studentprofile");
                //Get validation if the user have access to DESKAPP
                public const string DESKAPP_ACCESS          = (USERS_ENDPOINT_PUBLIC + "/{data}/dskaccess");
                //Get validation if the student have access to its portal
                public const string STUDENT_ACCESS          = (USERS_ENDPOINT_PUBLIC + "/{data}/stdaccess");
                //Get list of app permissions enabled for a user
                public const string SYSINFO_PERMISSIONS     = (USERS_ENDPOINT_PUBLIC + "/{data}/sysinfopermissions");
                //Validation of existence of a username by its identificacion
                public const string EXISTENCEPROOF_BYID     = (USERS_ENDPOINT_PUBLIC + "/valbyid/{data}");
                //Validation of existence of a user by email
                public const string USR_ADD_VAL_EMAIL       = (USERS_ENDPOINT_PUBLIC + "/valaddemail/{data}");
            }

            //Routes for GENERAL endpoint controller
            public static class GENERAL
            {
                //Get name of a convention of something inside an app (e.g., send 'COL' and got back 'Colombia')
                public const string CONVENTION_NAME = (GENERAL_ENDPOINT_PUBLIC + "/convention/{data}");
                //Get status of availability of an app by its appcode
                public const string APP_STATUS      = (GENERAL_ENDPOINT_PUBLIC + "/appstatus/{data}");
            }

        }

        //PATCH ENDPOINTS
        public static class PATCH
        {

            //Routes for USERS endpoint controller
            public static class USERS
            {
                //Set employee's last access date to DESKAPP
                public const string SYSTEM_DESKAPP_RECORDACCESS = (USERS_ENDPOINT_PUBLIC + "/{data}/dsklastaccess");
                //Set student last access date
                public const string SYSTEM_STD_RECORDACCESS     = (USERS_ENDPOINT_PUBLIC + "/{data}/stdlastaccess");
            }
        }

        //POST ENDPOINTS
        public static class POST
        {
            //Routes for USERS endpoint controller
            public static class USERS
            {
                //Add event log inside work environment -> Requires request body (see documentation)
                public const string ADD_EVENT_WORKLOG    = (USERS_ENDPOINT_PUBLIC + "/worklog");
                //Add event log inside student environment -> Requires request body (see documentation)
                public const string ADD_EVENT_STDNTLOG   = (USERS_ENDPOINT_PUBLIC + "/stdntlog");
            }
        }

        //PUT ENDPOINTS
        public static class PUT
        {
            //Routes for USERS endpoint controller
            public static class USERS
            {
                //Reeplace user profile information -> Requires request body (see documentation)
                public const string UPDATE_USER_PROFILE = (USERS_ENDPOINT_PUBLIC + "/{username}");
            }
        }

        //DELETE ENDPOINTS
        public static class DELETE
        {
            //Routes for USERS endpoint controller
            public static class USERS
            {
                //ON DEVELOPMENT:
                //PENDING DECISION ABOUT A REQUEST TO CONSIDER ON THE NEXT MASS FILE AND RECORDS DELETING (Each month data deleting)
                //OR DIRECT DELETE (Find user profile and delete)
                //OR ALL RELATED DATA TO USER DELETION (Find user records on all DDBB and delete)
                //Delete user profile
                public const string DELETE_USER = (USERS_ENDPOINT_PUBLIC + "/{username}");
            }
        }

    }
}
