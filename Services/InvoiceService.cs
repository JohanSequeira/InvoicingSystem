using InvoicingSystem.DTOs;
using InvoicingSystem.Models;
using Serilog;

namespace InvoicingSystem.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(IProductService productService, ICustomerService customerService, ILogger<InvoiceService> logger)
        {
            _productService = productService;
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<InvoiceDTO> GenerateInvoiceAsync(InvoiceRequestDTO request)
        {
            _logger.LogInformation("Generating invoice for customer ID {CustomerId}", request.CustomerId);

            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(request.CustomerId);
                if (customer == null)
                {
                    _logger.LogWarning("Customer with ID {CustomerId} not found", request.CustomerId);
                    throw new InvalidOperationException("Customer not found");
                }

                var items = new List<InvoiceItemDTO>();
                decimal subtotal = 0;

                foreach (var cartItem in request.Cart)
                {
                    var product = await _productService.GetProductByIdAsync(cartItem.ProductId);
                    if (product == null)
                    {
                        _logger.LogWarning("Product with ID {ProductId} not found", cartItem.ProductId);
                        throw new InvalidOperationException($"Product with ID {cartItem.ProductId} not found");
                    }
                    if (product.Quantity < cartItem.Quantity)
                    {
                        _logger.LogWarning("Insufficient stock for product {ProductName}", product.Name);
                        throw new InvalidOperationException($"Insufficient stock for product {product.Name}");
                    }

                    // Reduce product quantity
                    await _productService.ReduceProductQuantityAsync(product.Id, cartItem.Quantity);

                    var itemPrice = product.Price * cartItem.Quantity;
                    var itemDiscount = itemPrice * (product.DiscountPercentage / 100);

                    items.Add(new InvoiceItemDTO
                    {
                        ProductName = product.Name,
                        Quantity = cartItem.Quantity,
                        Price = product.Price,
                        Discount = itemDiscount
                    });

                    subtotal += itemPrice;
                }

                var totalDiscount = subtotal * (request.FlatDiscount / 100);
                var totalTax = subtotal * 0.1m; // Assuming 10% tax rate
                var total = subtotal - totalDiscount + totalTax;

                

                var invoiceDto = new InvoiceDTO
                {
                    CustomerId = customer.Id,
                    Items = items,
                    Subtotal = subtotal,
                    Discount = totalDiscount,
                    Tax = totalTax,
                    Total = total,
                    PaymentOption = request.PaymentOption,
                };

                _logger.LogInformation("Invoice generated successfully for customer ID {CustomerId}", request.CustomerId);
                return invoiceDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating invoice for customer ID {CustomerId}", request.CustomerId);
                throw;
            }
        }
    }


}
