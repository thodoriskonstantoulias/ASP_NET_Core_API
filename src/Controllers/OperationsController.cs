using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;

        public OperationsController(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpOptions("reloadconfig")] 
        public ActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot)configuration;
                root.Reload();
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
   
        }
    }
}