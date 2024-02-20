using IES_ADMIN_ACADEM_API.Entities;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Data;

namespace IES_ADMIN_ACADEM_API.Repository
{
    /// <summary>
    /// Collections of methos that gather data from the DDBB for general environment purposes
    /// </summary>
    public class GeneralRepository
    {
        //Object to handle DDBB connections and querys
        readonly daoManager daoMgr = new daoManager();

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// GET ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Get name or detail of an app convention code
        /// </summary>
        /// <param name="codConv">Convention code</param>
        /// <returns>Convention name</returns>
        public string GetConventionName(string codConv)
        {
            //Retrieve data as astring 
            return (string)daoMgr.retrieveSingleValue(string.Format(dbQueries.GENERAL.GET_NAME_APP_CONVENTION_CODE_QUERY,codConv));
        }

        /// <summary>
        /// Get the operation availability of an application by its appcode
        /// </summary>
        /// <param name="appcode">Application code</param>
        /// <returns>Object with status and details</returns>
        public uf_appstates GetAppStatus(string appcode)
        {
            //Retrieve data as datatable
            DataTable dt = daoMgr.retrieveDataObjects(string.Format(dbQueries.GENERAL.GET_APP_STATE_QUERY,appcode));
            //Get object data to map to class when dt have row count greater than 0
            var _Object = (dt.Rows.Count > 0) ? JArray.FromObject(dt).ToObject<List<uf_appstates>>()[0] : null;
            //Return object casted to class
            return _Object;
        }
    }
}
