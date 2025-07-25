﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public Product Product { get; set; }

    }
}
