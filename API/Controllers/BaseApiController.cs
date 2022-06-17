using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // [controller] is a placeholder and gets replaced by the first part of the controller name
    public class BaseApiController : ControllerBase 
    {

    }
}