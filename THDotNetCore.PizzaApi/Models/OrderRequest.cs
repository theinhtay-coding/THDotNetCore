namespace THDotNetCore.PizzaApi.Models
{
    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] Extras { get; set; }
    }

    public class OrderResponse
    {
        public string Message { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
