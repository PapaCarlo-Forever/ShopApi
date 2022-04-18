﻿namespace ShopApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public Author Authors { get; set; }
    }
}
