using IES_ADMIN_ACADEM_API.Config;
using IES_ADMIN_ACADEM_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IES_ADMIN_ACADEM_API.Controllers
{
    [ApiController]
    public class GeneralController
    {
        //Logger
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<GeneralController> _logger;

        //Business service logic processor
        private readonly GeneralService generalService;

        //Declare custom auxiliar methods
        
        //End custom auxiliar methods

        //Constructor
        public GeneralController(ILogger<GeneralController> logger,IServiceProvider serviceProvider) {
            //Following operations are for a logger instance passing between classes.
            _logger          = logger;
            _serviceProvider = serviceProvider;
            var LoggerThread = _serviceProvider.GetService(typeof(ILogger<GeneralService>)) as ILogger<GeneralService>;
            generalService   = new GeneralService(LoggerThread);
        }

        /* /////////////////////////////////////////////////////////////////////////////////////////////////
        /// GET ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////// */

        /// <summary>
        /// Get name or detail of an app convention code
        /// </summary>
        /// <returns>Convention name</returns>
        [Route(Routes.GET.GENERAL.CONVENTION_NAME)]
        [HttpGet]
        public IActionResult GetConventionName(string data) {
            return generalService.GetConventionName(data);
        }

        /// <summary>
        /// Get the operation availability of an application by its appcode
        /// </summary>
        /// <returns>Object with status and details</returns>
        [Route(Routes.GET.GENERAL.APP_STATUS)]
        [HttpGet]
        public IActionResult GetAppStatus(string data)
        {
            return generalService.GetAppStatus(data.Replace('!', '/'));
        }
    }
}
