﻿using System.ComponentModel.DataAnnotations;

namespace ProductManager.Blazor.Models.Forms
{
    public class AjoutProduitForm
    {
        [Required]
        public string Nom { get; set; } = default!;

        [Required]
        [Range(0, double.MaxValue)]
        public double Prix { get; set; }
    }
}
