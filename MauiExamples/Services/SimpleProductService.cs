using MauiExamples.Examples.MVU.Models;
using MauiExamples.Services;

public class SimpleProductService : ISimpleProductService
{
  private static readonly IReadOnlyList<SimpleProduct> _products =
  [
      new() { Id = 1, Name = "Coffee Beans", Price = 8.99m, InStock = true },
        new() { Id = 2, Name = "Tea Box", Price = 5.49m, InStock = true },
        new() { Id = 3, Name = "Chocolate Bar", Price = 2.25m, InStock = false },
        new() { Id = 4, Name = "Notebook", Price = 3.99m, InStock = true },
        new() { Id = 5, Name = "Pen Set", Price = 6.75m, InStock = true },
        new() { Id = 6, Name = "Water Bottle", Price = 12.00m, InStock = false },
        new() { Id = 7, Name = "Backpack", Price = 39.95m, InStock = true },
        new() { Id = 8, Name = "Headphones", Price = 59.99m, InStock = true },
        new() { Id = 9, Name = "USB Cable", Price = 4.50m, InStock = true },
        new() { Id = 10, Name = "Keyboard", Price = 29.90m, InStock = false },
        new() { Id = 11, Name = "Mouse", Price = 19.99m, InStock = true },
        new() { Id = 12, Name = "Monitor Stand", Price = 24.00m, InStock = true },
        new() { Id = 13, Name = "Desk Lamp", Price = 18.75m, InStock = true },
        new() { Id = 14, Name = "Phone Charger", Price = 14.99m, InStock = false },
        new() { Id = 15, Name = "Webcam", Price = 44.95m, InStock = true },
    ];

  public IEnumerable<SimpleProduct> GetAll() => _products;
}