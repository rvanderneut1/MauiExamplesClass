using MauiExamples.Examples.MVU.Messages;
using MauiExamples.Examples.MVU.Models;
using MauiExamples.Services;

namespace MauiExamples.Examples.MVU;

public partial class ProductsPages : ContentPage
{
	private readonly ISimpleProductService _productService;
	private ProductsPageModel _model = ProductsPageModel.Initial();
	public ProductsPages(ISimpleProductService productService)
	{

		_productService = productService;
		InitializeComponent();
		BindingContext = this;
	}

	private void Dispatch(object message)
	{
		_model = Update(_model, message);
		Render(_model);
	}

	private static ProductsPageModel Update(ProductsPageModel model, object message)
	{
		return message switch
		{
			LoadProductsMessage msg => model with { SearchTerm = msg.SearchTerm },
			_ => model
		};
	}

	private void Render(ProductsPageModel model)
	{
		// Bind the filtered list to the CollectionView.
		// FilteredProducts is already filtered by SearchText on the model.
		ProductList.ItemsSource = model.FilteredProducts;

		// Keep the search bar text in sync (important if Reset clears it programmatically).
		if (SearchBar.Text != model.SearchTerm)
			SearchBar.Text = model.SearchTerm;
	}

	private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
	{
		Dispatch(new LoadProductsMessage(e.NewTextValue ?? string.Empty));
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// Load products when the page appears.
		var products = _productService.GetAll();
		_model = _model with { Products = products.ToList() };
		Render(_model);
	}

}