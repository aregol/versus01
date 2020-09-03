using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication;
using Aplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IService _service;
        private readonly TestData _data;

        public DemoController(IService service, TestData data)
        {
            _service = service;
            _data = data;
        }

        [HttpGet]
        public async Task<ActionResult<Tabla>> Single()
        {
            var single = _data.Single();
            var row = await _service.Add(single);

            return row;
        }

        [HttpGet("Many")]
        public async Task<ActionResult> Many()
        {
            var many = _data.Many();
            await _service.AddMany(many);

            return NoContent();
        }
    }
}
