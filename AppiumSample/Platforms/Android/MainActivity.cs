using Android.App;
using Android.Content.PM;

namespace AppiumSample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, Name = "com.companyname.appiumsample.MainActivity",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}