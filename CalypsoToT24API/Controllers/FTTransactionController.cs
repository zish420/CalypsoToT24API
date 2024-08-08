using CalypsoToT24API.Helper;
using CalypsoToT24API.Infrastructure.Models;
using CalypsoToT24API.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace CalypsoToT24API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FTTransactionController : ControllerBase
    {
        private readonly IFTTransactionService _service;
        private readonly IMemoryCache _cache;

        public FTTransactionController(IFTTransactionService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        [HttpPost]
        [Consumes("application/xml")]
        public async Task<IActionResult> CreateFTTransaction()
        {
            string xmlContent;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                xmlContent = await reader.ReadToEndAsync();
            }

            var calypsoEvent = XmlParser.ParseXml(xmlContent);
            if (calypsoEvent == null)
            {
                return BadRequest("Invalid XML");
            }

            try
            {
                bool isSaved = await _service.SaveFTTransaction(calypsoEvent);

                if (isSaved)
                {
                    return Ok("Transaction saved successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to save transaction.");
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
