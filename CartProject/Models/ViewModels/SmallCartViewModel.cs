﻿namespace CartProject.Models.ViewModels
{
    public class SmallCartViewModel
    {
        public int NumberOfItems { get; set; }
        public decimal TotalAmount { get; set; } = 0;
    }
}