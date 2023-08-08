﻿namespace FactCheck84.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int AuthorStatusId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public AuthorStatus AuthorStatus { get; set; }

        public Author()
        {
        }
    }
}
