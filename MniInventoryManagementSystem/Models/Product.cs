﻿using System.ComponentModel.DataAnnotations;

namespace MiniInventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

       
        public int Stock { get; set; }
    }
}
