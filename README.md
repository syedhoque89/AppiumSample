## To get started please follow the steps below:

- Download and install latest `VS` with `.NET MAUI` workload.
- Ensure target `Android SDK` is installed.
- Download and install latest `XCode` (for iOS). Also ensure command line tools are installed by running `xcode-select --install` in the terminal.
- Download and install the desktop version of `Appium Server GUI` from here https://github.com/appium/appium-desktop/releases. You can use the `CLI` if you prefer.
- Open `Appium Server GUI` => Edit configuration => Set `ANDROID_HOME` and `JAVA_HOME` path. Save and restart the `Appium Server GUI`.
- Start `Appium Server GUI`, take note of `localhost` and `port` settings
- Build a and deploy `AppiumSample` app to your target of choice (i.e. Android)
- Stop debugging/ running the app.
- Navigate to `AppiumSample.UITests` => `MainPageTests` => Set `Platform` property to target platform (i.e.`TargetPlatform.Android`)
- Adjust the parameters as needed in the file
- Run the tests!
