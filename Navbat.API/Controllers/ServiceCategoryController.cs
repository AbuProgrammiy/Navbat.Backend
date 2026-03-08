using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Navbat.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        [HttpGet]
        public bool GetAll()
        {
            return true;
        }

        [HttpGet]
        public bool GetById()
        {
            return true;
        }

        [HttpPost]
        public bool Create()
        {
            return true;
        }

        [HttpPut]
        public bool Update()
        {
            return true;
        }

        [HttpDelete]
        public bool Delete()
        {
            return true;
        }
    }
}
