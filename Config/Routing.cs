namespace IES_ADMIN_ACADEM_API.Config
{
    public class Routing
    {
        private const string ROOT = "api/ies";


        //Root of API Path for User related apps
        private const string IES_USERS = ROOT + "/users";
        //Get validation/existence proof of an user by its username and password
        public const string IES_USER_EXISTENCEPROOF = IES_USERS + "/{username}";
        //Get validation of SIS_INFO access for that user
        public const string IES_USERS_MATCH = IES_USERS + "/{data}/match";
        //Get validation if the user have access to DESKAPP
        public const string IES_USERS_DESKAPP_ACCESS = IES_USERS + "/{data}/sysinfoaccess";
        //Get list of app permissions enabled for an user
        public const string IES_USERS_SYSINFO_PERMISSIONS = IES_USERS + "/{data}/sysinfopermissions";
        //Get user personal and work profile data
        public const string IES_USERS_GETPROFILE = IES_USERS + "/{data}/profiledata";
        //Set user's last access to DESKAPP
        public const string IES_USERS_DESKAPP_RECORDACCESS = IES_USERS + "/{data}/recordaccess";
    }
}
