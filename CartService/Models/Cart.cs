using System.Collections;
using System.Collections.Generic;

namespace CartService.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}