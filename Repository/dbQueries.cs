using Microsoft.Extensions.Primitives;
using System.Text;

namespace IES_ADMIN_ACADEM_API.Repository
{
    public static class dbQueries
    {
        public static class USER {

            public static readonly string GET_USER_BASIC_DATA_QUERY        = "CALL GET_USER_BASIC_DATA('{0}');";

            public static readonly string GET_EMPLOYEE_PROFILE_QUERY       = "CALL GET_EMPLOYEE_PROFILE('{0}');";

            public static readonly string GET_STUDENT_PROFILE_QUERY        = "CALL GET_STUDENT_PROFILE('{0}');";

            public static readonly string MATCH_LOGIN_QUERY                = "CALL GET_MATCH_LOGIN('{0}');";

            public static readonly string DESKAPP_ACCESS_QUERY             = "CALL GET_DESKAPP_ACCESS('{0}');";

            public static readonly string STUDENT_ACCESS_QUERY             = "CALL GET_STUDENT_ACCESS('{0}');";

            public static readonly string SISINFO_APPS_PERMISSIONS_QUERY   = "CALL GET_SISINFO_APPS_PERMISSIONS('{0}');";

            public static readonly string UPDATE_DESKAPP_LAST_ACCESS_QUERY = "CALL PATCH_UPDATE_DESKAPP_LAST_ACCESS('{0}','{1}');";

            public static readonly string UPDATE_STUDENT_LAST_ACCESS_QUERY = "CALL PATCH_UPDATE_STUDENT_LAST_ACCESS('{0}','{1}');";

            public static readonly string INSERT_PERSONA_QUERY             = "CALL POST_INSERT_PERSONA('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');";

            public static readonly string UPDATE_ITEM_PERSONA_QUERY        = "CALL PATCH_PUT_UPDATE_PERSONA('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}');";

            public static readonly string DELETE_SOLO_PERSONA_QUERY        = "CALL DELETE_PERSONA('{0}');";

            public static readonly string GET_VALIDATION_BY_ID             = "CALL GET_VALIDATION_BY_ID('{0}');";

            public static readonly string GET_USERNAME_AVAILABLE           = "CALL GET_USERNAME_AVAILABLE('{0}');";

            public static readonly string GET_VALIDATION_BY_EMAIL          = "CALL GET_VALIDATION_BY_EMAIL('{0}');";

            public static readonly string ADD_EVENT_LOG_WORK               = "CALL POST_ADD_EVENT_LOG_WORK('{0}','{1}','{2}');";

            public static readonly string ADD_EVENT_LOG_STDNT              = "CALL POST_ADD_EVENT_LOG_STDNT('{0}','{1}','{2}');";
        }

        public static class GENERAL { 
        
            public static readonly string GET_NAME_APP_CONVENTION_CODE_QUERY = "CALL GET_NAME_APP_CONVENTION_CODE('{0}');";

            public static readonly string GET_APP_STATE_QUERY                = "CALL GET_APP_STATE('{0}');";

        }
    }
}
