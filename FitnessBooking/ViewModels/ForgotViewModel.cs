﻿using System.ComponentModel.DataAnnotations;

namespace FitnessBooking.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}