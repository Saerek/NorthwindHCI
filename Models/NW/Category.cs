using System;
using System.Collections.Generic;

namespace NorthwindHCI.Models.NW;

using System.ComponentModel.DataAnnotations;


public partial class Category
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    [StringLength(40, ErrorMessage = "Category name cannot be longer than 40 characters")]
    public string CategoryName { get; set; } = null!;

    [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
