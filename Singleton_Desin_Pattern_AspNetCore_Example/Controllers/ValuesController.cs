using Microsoft.AspNetCore.Mvc;
using Singleton_Desin_Pattern_AspNetCore_Example.Services;

namespace Singleton_Desin_Pattern_AspNetCore_Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult X()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Conncetion();
            databaseService.Disconncetion();
            return Ok(databaseService.Count);
        }

        [HttpGet("[action]")]
        public IActionResult Y()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Conncetion();
            databaseService.Disconncetion();
            return Ok(databaseService.Count);
        }
    }
}
