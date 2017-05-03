---
uid: scriptBootstrapping.md
title: Bootstrapping Your Plugin Script
---

# Bootstrapping Your Plugin Script

## Overview
If you are looking to supercharge your *plugins* with ESAPIX, you need to do a few things to get it properly wired up. You need to:

1. Create a **Script.cs** file in your project.
2. Install the latest ESAPIX via NuGet
3. In your *Script.cs* file, include the following:

```cs
namespace VMS.TPS
{
    public class Script : XScriptBase
    {
        public Script() : base() { }


        public override void XExecute(PluginContext ctx, DispatcherFrame frame)
        {
            try
            {
                //When hooked up to bootstrapper (comment out otherwise)
                FacadeInitializer.Initialize();
                //Standard setup (assuming the view you want to show is called "MainView")
                var bs = new ScriptBootstrapper<MainView>(ctx, frame);
                bs.Run(() => Splasher.GetSplash(this.GetType().Assembly));
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, there was a problem launching this script.\n Emailing ....\n Please try again.");
		//Log crash
            }
        }
    }
}
```
4. Run the app. You are supercharged.

## What Is Happening In This Code
We are highjacking the traditional Script call from Varian and adding some spice along the way. Make sure the class is named **Script.cs** and that the namespace is **VMS.TPS**. Those are required for the call to work. Here are the other details.

### XScriptBase
We are inheriting from *XScriptBase* because this class has some plumbing to transform Varian's *ScriptContext* into ESAPIX's IScriptContext interface. For plugins, the concrete class used is **PluginContext** which you can see in our "XExecute" method. The PluginContext implements [facade access](facades.md), holds the thread which we can access Varian objects, and implements IScriptContext so we can test our apps in standalone mode. 
XScriptBase will also handle the window object (hides it) that is passed from Varian. This window contains the [Dispatcher object](https://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher(v=vs.110).aspx) which lets ESAPIX know how to communicate with VMS. If you move outside of that thread...bad things will happen. Don't worry, ESAPIX will hold your hand. XScriptBase will also close the window when the app is done running (your app will actually run in a different window).Lastly, the XScriptBase will keep the app from closing prematurely, which it would do when you didn't use that window.
* VMS ScriptContext => ESAPIX PluginContext (IScriptContext)
* Gets Window Information then Hides Window
* Keeps App From Closing Until Finished

### XExecute
This method is to let you know that Varian is not calling this method. ESAPIX is. This is where **YOU** will wire up your bootstrapper. The above example code should show the basics. There are only three lines required:
```cs
 	FacadeInitializer.Initialize();
        var bs = new ScriptBootstrapper<MainView>(ctx, frame);
        bs.Run(() => Splasher.GetSplash(this.GetType().Assembly));
```

The **ScriptBootstrapper** needs the type of the first Window you want to show to the user. In this example, *MainView.xaml* is the window we will show. The Splasher.GetSplash just splashes the default splash included with ESAPIX.

