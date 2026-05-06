using MauiExamples.Examples.MVU.Models;

namespace MauiExamples.Services;

public interface ISimpleProductService
{
  IEnumerable<SimpleProduct> GetAll();
}


