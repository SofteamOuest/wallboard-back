using System;
using System.ComponentModel.DataAnnotations;

namespace WallboardBack.Models
{
    public class Widget
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Uri { get; set; }
    }
}