using IES_ADMIN_ACADEM_API.Entities;
using IES_ADMIN_ACADEM_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IES_ADMIN_ACADEM_API.Services
{
    public class accessServices
    {
        //Object to handle repository services
        readonly accessRepository accessRepo = new accessRepository();

        /// <summary>
        /// Validate if a user exists by its username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public bool validateUsername(string username)
        {
            bool r = false;
            List<portalLaboral> resultTemp = accessRepo.validateUsername(username);


            if (resultTemp != null && resultTemp.Count > 0)
            {
                if (resultTemp.ElementAt(0).Username.Equals(username))
                {
                    //Match! User exists
                    r = true;
                }
            }
            //Return service result
            return r;
        }
        

        /// <summary>
        /// Validate if user's username and passwords match and exists
        /// </summary>
        /// <param name="username">decoded username</param>
        /// <param name="pwd">decoded password</param>
        /// <returns>bool</returns>
        public bool validateAccess(string username, string pwd)
        {
            bool r = false;
            List<portalLaboral> resultTemp = accessRepo.validateAccess(username, pwd);


            if (resultTemp != null && resultTemp.Count > 0)
            {
                if (resultTemp.ElementAt(0).Username.Equals(username))
                {
                    //Match! User exists
                    r = true;
                }
            }
            //Return service result
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">decoded username</param>
        /// <param name="pwd">decoded password</param>
        /// <param name="matchSelector">OUT -> indicates permission</param>
        /// <param name="userDataExists">OUT -> indicates user data package existence</param>
        public void validateDeskappAccess(string username, string pwd, out bool matchSelector, out bool userDataExists)
        {
            List<portalLaboral> resultTemp = accessRepo.validateAccess(username, pwd);
            matchSelector = false; //Initialize
            userDataExists = false; //Initialize

            //There is a package then check isn't null and have at least 1 record
            if (resultTemp != null && resultTemp.Count > 0)
            {
                //Validate match
                if (
                    resultTemp.ElementAt(0).Username.Equals(username) && resultTemp.ElementAt(0).Password.Equals(pwd)
                    )
                {
                    //Match! User exists, validate deskapp access
                    userDataExists = true;
                    matchSelector = resultTemp.ElementAt(0).Deskapp_access == 1 ? true : false;
                }
                //Missmatch
                else
                {
                    userDataExists = false;
                }
            }
            else
            {
                //There is no data
                userDataExists = false;
            }

            //return resultTemp;
        }

        public List<sisInfoUser> get_user_apps(string username, out bool thereApps, out bool userExistence) {

            List<sisInfoUser> resultTemp = accessRepo.getApps(username);
            thereApps = false;
            userExistence = false;

            //Validate if user exists or has changes during the access and the operation of this method
            //Remember that this method verify app list and access for an user, but the user can be removed from the IES's employers list.
            //Could happen that an user still having access but the IES's doesn't let use any app, while they remove the user from employers list.
            if(validateUsername(username))
            {
                //Validation successful, record exists on employers list.
                userExistence = true;
                //Validation of at least 1 app assigned
                //IMPORTANT: There are 'apps' that isn't apps really, its just to give frontend root app levels information due to the design of dynamic app tree view
                // So we have to count how much apps are assigned than the 'null' apps.
                if (new List<sisInfoUser>(resultTemp).Where(x => x.User.Equals(username)).Count() > 0)
                {
                    thereApps = true;
                }
            }

            return resultTemp;
        }

        public List<userProfile> getProfileData(string username, string pwd, out bool userExistence) {

            List<userProfile> resultTemp = accessRepo.getProfileData(username, pwd);
            userExistence = false;

            if(validateUsername(username))
            {
                userExistence = true;
            }

            return resultTemp;
        }

        public bool updUserLastAccessRecord(string usr, string pwd, string newdate)
        {
            return accessRepo.setLastAccessRecord(usr, pwd, newdate);
        }
    }
}
