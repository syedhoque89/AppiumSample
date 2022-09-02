namespace AppiumSample;

public partial class MainPage
{
    int count;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        CounterBtn.Text = count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnAlertClicked(object sender, EventArgs e)
    {
        await Application.Current!.MainPage!.DisplayAlert("Alert", "This is an alert", "Ok");
    }
}