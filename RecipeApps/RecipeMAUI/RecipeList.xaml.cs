using RecipeSystem;
using System.Data;
namespace RecipeMAUI;

public partial class RecipeList : ContentPage
{
	public RecipeList()
	{
		InitializeComponent();
		LoadData();
	}

	private void LoadData()
	{
        DataTable dt = Recipe.GetDataList("Recipe", false);
        RecipeLst.ItemsSource = dt.Rows;
	}
}