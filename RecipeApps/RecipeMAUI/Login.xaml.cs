using RecipeSystem;

namespace RecipeMAUI;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            MessageLbl.Text = "";
            DBManager.SetConnectionString(App.ConnStringSetting, true, UserNameTxt.Text, PasswordTxt.Text);
            App.LoggedIn = true;
            await Navigation.PopModalAsync();
        }
        catch (Exception ex)
        {
            MessageLbl.Text = ex.Message;
        }
    }

    private void CancelBtn_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}