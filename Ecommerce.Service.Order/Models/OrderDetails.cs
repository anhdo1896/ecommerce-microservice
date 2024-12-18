﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Service.Order.Dtos;

namespace Ecommerce.Service.Order.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public OrderHeader? OrderHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
    }
}
