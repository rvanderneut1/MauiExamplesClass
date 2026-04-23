using MauiExamples.Examples.MVU.Models;

namespace MauiExamples.Examples.MVU;

public partial class ProductsPages : ContentPage
{
	private ProductsPageModel _model = ProductsPageModel.Initial();
	public ProductsPages()
	{
		InitializeComponent();
	}

}