using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace AppiumSample.UITests;

public class MainPageTests
{
    AppiumDriver<AppiumWebElement> driver;

    AppiumOptions options;

    const TargetPlatform Platform = TargetPlatform.Android;

    [SetUp]
    public void Setup()
    {
        switch (Platform)
        {
            case TargetPlatform.Apple:
                options = AppleOptions();
                driver = new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), options,
                    TimeSpan.FromSeconds(180));
                break;
            case TargetPlatform.Android:
                options = AndroidOptions();
                driver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), options,
                    TimeSpan.FromSeconds(10));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }


    [Test]
    public void ClickCounterTest()
    {
        var element = driver.FindElementById("CounterBtn");
        element.Click();
        Thread.Sleep(2000);
        driver.TakeScreenshot().SaveAsFile(nameof(ClickCounterTest), ScreenshotImageFormat.Png);
        Assert.That(element.Text, Is.EqualTo("Clicked 1 time"));
    }

    [Test]
    public void AlertTest()
    {
        var element = driver.FindElementById("AlertBtn");
        element.Click();

        var source = driver.PageSource;
        Assert.DoesNotThrow(() =>
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(_ => driver.SwitchTo().Alert().Text);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(_ =>
            {
                driver.TakeScreenshot().SaveAsFile(nameof(AlertTest), ScreenshotImageFormat.Png);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(2000);
                return string.Empty;
            });
        });
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    static AppiumOptions AndroidOptions()
    {
        /*** adjust the values as needed ***/

        var androidOptions = new AppiumOptions();
        androidOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
        androidOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.appiumsample");
        // comment out if providing path to .app/.ipa file on the next line
        androidOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity,
            "com.companyname.appiumsample.MainActivity");
        //_options.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc64a85506f2de248d26.MainActivity");

        // if the app is not installed, provide path to the .apk file here and uncomment
        //options.AddAdditionalCapability(MobileCapabilityType.App, "pathTo.apk");

        // optional capabilities
        androidOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
        /*_options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12");
        _options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");*/
        return androidOptions;
    }

    static AppiumOptions AppleOptions()
    {
        /*** adjust the values as needed ***/

        var appleOptions = new AppiumOptions();
        appleOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
        appleOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "15.4");
        appleOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
        appleOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone 11");
        // comment out if providing path to .app/.ipa file on the next line
        appleOptions.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, "com.companyname.appiumsample");
        // if the app is not installed, provide path to the .app/.ipa file here and uncomment
        // options.AddAdditionalCapability(MobileCapabilityType.App, "pathTo.app or pathTo.ipa");
        return appleOptions;
    }

    enum TargetPlatform
    {
        Apple,
        Android
    }
}