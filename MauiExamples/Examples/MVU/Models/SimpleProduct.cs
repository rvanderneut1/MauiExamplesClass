using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiExamples.Examples.MVU.Models
{
    public record SimpleProduct
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public bool InStock { get; init; }
    }
}
