using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CustomerBasketItemDto
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Range(1, double.MaxValue)]
        public long Price { get; set; }
        [Range(1, double.MaxValue)]
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string PictureUrl { get; set; }
    }
}