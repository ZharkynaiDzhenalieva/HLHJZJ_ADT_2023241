﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HLHJZJ_ADT_2023241.Models
{
    public class Topic
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

        public Topic()
        {
            Products = new HashSet<Product>();
        }
    }
}

