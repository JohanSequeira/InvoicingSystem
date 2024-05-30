using InvoicingSystem.DTOs;
using InvoicingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpPost("generate")]
        [ProducesResponseType(typeof(InvoiceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateInvoice(InvoiceRequestDTO request)
        {
            try
            {
                var invoiceDto = await _invoiceService.GenerateInvoiceAsync(request);
                return Ok(invoiceDto);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Validation error while generating invoice");
                return BadRequest(new ErrorResponseDTO
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    Details = "Validation error while generating invoice"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating invoice");
                return StatusCode(500, new ErrorResponseDTO
                {
                    StatusCode = 500,
                    Message = "An internal server error occurred",
                    Details = ex.Message
                });
            }

        }
    }


}
