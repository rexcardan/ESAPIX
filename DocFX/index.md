<center>![Logo](images/esapixLogo.jpg "ESAPIX Logo")</center>

Welcome to the [ESAPIX library](https://github.com/rexcardan/ESAPIX/) homepage. Kick start your Eclipse Scripting with a powerful, open source library. It provides:

* Extenstion Methods
* Facade Access
* Common Interface for Standalone and Plugins
* Robust DVH Constraint classes

## Getting Started
* [Supercharging Plugins](articles/scriptBootstrapping.md)
* [Supercharging WPF Applications](articles/standAloneBootstrapping.md)
* [YouTube Video Tutorials](articles/videoTutorials.md)

## Features

### Extension Methods
There are several extension methods available for VMS equivalent classes. Check out [ESAPIX.Extensions](https://github.com/rexcardan/ESAPIX/tree/master/ESAPIX/Extensions) namespace to do stuff like this:
```cs
            var plan = patient.Courses
                .SelectMany(c => c.PlanSetups) //Get all plans from all courses
                .FirstOrDefault(p => p.Id.Contains("Prostate")); //Find first that has the work prostate in it
            var prostate = plan.StructureSet.Structures.FirstOrDefault(s => s.Id == "Prostate");
            //Cool. That was easy
            var v50Gy = plan.ExecuteQuery(prostate, "V50Gy[cc]");
```

### Facades
Facades are wrappers around the Varian classes which smooth out rough edges for unit testing and multithreaded access. Best of all, you won't even realize you are using them.
Checkout @facades.md to learn more.

### IScriptContext Interface
IScriptContext is a technique used by ESAPIX to abstract the difference between standalone applications and plugin applications. You can build one app that runs whichever way you want, which is great for development. One of the challenges with developing plugin applications is the need to debug it. IScriptContext is ESAPIX's solution to the problem. Watch a tutorial on how to use IScriptContext [here](https://www.youtube.com/watch?v=6LXhqgt0jT4).

### Robust DVH Constraint Help
ESAPIX has a lot of code dedicated to helping evaluate DVH metrics. You have the @mayoFormat.md at your disposal to do some complex queries quickly and evaluate the things which are most important.


### See Also
*	[Facades](articles/facades.md)
*	[Mayo Format](articles/mayoFormat.md)
