using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please write the name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1.00, 100.00, ErrorMessage = "Please enter a value between 1.00 and 100.00")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please choose a supplier")]
        [DisplayName("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
