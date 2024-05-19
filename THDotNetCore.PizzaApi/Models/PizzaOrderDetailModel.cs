using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THDotNetCore.PizzaApi.Models
{
    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
    }


    public class PizzaOrderHeadModel
    {
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public int PizzaId { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
    }

    public class PizzaOrderInvoiceDetailModel
    {
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }
    }

    public class PizzaOrderInvoiceResponse
    {
        public PizzaOrderHeadModel Order { get; set; }
        public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
    }
}
