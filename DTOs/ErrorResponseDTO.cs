namespace InvoicingSystem.DTOs
{
    public class ErrorResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }

    public class ValidationErrorDTO
    {
        public string Field { get; set; }
        public string Error { get; set; }
    }
}
