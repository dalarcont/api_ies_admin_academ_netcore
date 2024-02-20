using Abp.Extensions;
using IES_ADMIN_ACADEM_API.Config;
using IES_ADMIN_ACADEM_API.Entities;
using IES_ADMIN_ACADEM_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IES_ADMIN_ACADEM_API.Services
{
    /// <summary>
    /// Service processor that contains business logic procedures and rules to simplify endpoint controller<br />
    /// It's necessary to add inheritance of ControllerBase to perform value returning or 'throw' another status code different than 200(OK)<br/>
    /// IMPORTANT: All OK procedures that results in the answer to provide and finish the request MUST HAVE to be casted to IActionResult
    /// </summary>
    public class GeneralService : ControllerBase
    {
        //Logger
        private readonly ILogger<GeneralService> EventLogger;

        //Object to handle repository services
        readonly GeneralRepository generalRepository = new GeneralRepository();

        //Constructor of service
        public GeneralService(ILogger<GeneralService> logger)
        {
            EventLogger = logger;
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// GET ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Get name or detail of an app convention code
        /// </summary>
        /// <param name="codConv">Convention code</param>
        /// <returns>Convention name</returns>
        public IActionResult GetConventionName(string codConv)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----GET CONVENTION NAME\t-----@{0}", codConv);
            string? _Object = null;
                //Validate convention code is given
                if(!codConv.IsNullOrEmpty())
                {
                    string tmp = generalRepository.GetConventionName(codConv);
                    if (!tmp.Contains("NULL"))
                    {
                        //There is a result
                        _Object = tmp;
                    }else{
                        //Given convention code doesn't exists
                        return StatusCode(412, BusinessErrorCodes.GENERAL_CONVENTION_CODE_NOEXISTS);
                    }
                }
                else
                {
                    //Convention code not given
                    return StatusCode(412, BusinessErrorCodes.GENERAL_CONVENTION_CODE_NOTGIVEN);
                }

            return Ok(_Object);
        }

        /// <summary>
        /// Get the operation availability of an application by its appcode
        /// </summary>
        /// <param name="appcode">Application code</param>
        /// <returns>Object with status and details</returns>
        public IActionResult GetAppStatus(string appcode)
        {
            EventLogger.Log(LogLevel.Information, "-API\t--SERVICE\t---GET\t----GET APP STATUS OBJECT\t-----@{0}", appcode);
            uf_appstates? _Object = null;
            if(!appcode.IsNullOrEmpty())
            {
                //App code was given
                _Object = generalRepository.GetAppStatus(appcode);
                if(_Object == null)
                {
                    //Object return null from repository, so the appcode was given but is incorrect or doesn't exist
                    return StatusCode(412, BusinessErrorCodes.GENERAL_APPCODE_NOEXISTS);
                }
            }
            else
            {
                //App code was not given
                return StatusCode(412, BusinessErrorCodes.GENERAL_APPCODE_NOTGIVEN);
            }
            return Ok(_Object);
        }
    }
}
