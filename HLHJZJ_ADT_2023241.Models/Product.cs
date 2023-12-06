using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HLHJZJ_ADT_2023241.Models
{
	public class Product
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string VendorCode { get; set; }
        public int Cost { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Topic? Topic { get; set; }

        [ForeignKey(nameof(Topic))]
        public int Topic_id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Interest? Interest { get; set; }
        [ForeignKey(nameof(Interest))]
        public int Interest_id { get; set; }

        public Product()
		{
		}
	}
}

