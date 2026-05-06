using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiExamples.Examples.MVU.Models
{
    public record ProductsPageModel
    {
        public IReadOnlyList<SimpleProduct> Products { get; init; }

        public string SearchTerm { get; init; } = string.Empty;


        public IReadOnlyList<SimpleProduct> FilteredProducts =>
                string.IsNullOrWhiteSpace(SearchTerm)
                    ? Products   // no filter active - return everything
                    : Products
                        .Where(p => p.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                        .ToList();


        public static ProductsPageModel Initial() => new ProductsPageModel
        {
            Products = [],
            SearchTerm = string.Empty
        };
    }
}
