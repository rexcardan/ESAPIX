ESAPIX
===================

ESAPIX is an open source extension library for the Varian Eclipse Scripting API that contains extra methods, and bootstrapping frameworks to quickly develop applications for research and clinical use. It has no affiliation with Varian Medical Systems. It provides implementations for multithreading, asynchronous calls, debugging plugins, dependency injection, and view model "auto finding" through the Prism 6 library 

To dive deeper, check out [more examples and API documentation](https://rexcardan.github.io/ESAPIX/).

----------

Getting Started
-------------

> **Quickstart:**
> - Create a new WPF project and set its build to x64
> - Reference with VMS.TPS.Common.Model.API and VMS.TPS.Common.Model.Types dlls
> - Use NuGet to download ESAPIX and dependencies
> - Add a folder called "Views"
> - Add a folder called "ViewModels"
> - Add a new Window in the Views folder called "Main"
> - Add a new class to the ViewModels folder called "MainViewModel.cs"
> - Remove the "StartupUri="MainWindow.xaml" from the App.xaml file

#### <i class="icon-pencil"></i> Modify the App.cs file
Launching your app in default multithreaded mode is easy. Just override the OnStartup method and you are set!
```csharp
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var sa = new ESAPIX.AppKit.AppBootstrapper<Main>(null, null, false);
            sa.Run();
        }
    }
```
