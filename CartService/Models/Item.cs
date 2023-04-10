﻿namespace CartService.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAltText { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}