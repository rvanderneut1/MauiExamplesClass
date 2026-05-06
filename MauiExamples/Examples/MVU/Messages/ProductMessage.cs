using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiExamples.Examples.MVU.Messages
{

    public sealed record LoadProductsMessage(string SearchTerm);
}
