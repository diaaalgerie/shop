using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(250)]

        public string Title { get; set; }       

        public double? Rate { get; set; }

        [MaxLength(2500)]
        public string? Descreption { get; set; }

        public byte[] Poster { get; set; }

        public int CategoryId  { get; set; }

        public Category Category { get; set; }
    }
}
