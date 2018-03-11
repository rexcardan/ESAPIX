ESAPIX
===================

ESAPIX is an open source extension library for the Varian Eclipse Scripting API that contains extra methods, and bootstrapping frameworks to quickly develop applications for research and clinical use. 
It has no affiliation with Varian Medical Systems. It provides implementations for multithreading, asynchronous calls, 
debugging plugins, and with the ESAPIX.Bootstrapping library : dependency injection, and view model "auto finding" through the Prism 6 library.


## Supported Eclipse Versions
* 11
* 13.6
* 13.7
* 15.0
* 15.1
* 15.5


[![Open Source Love](https://badges.frapsoft.com/os/mit/mit.svg?v=102)](https://github.com/ellerbrock/open-source-badge/)

----------

# Getting Started
1. Install the appropriate ESAPIX library (Version) through NuGet. 
	* Right click your project >> Manage NuGet Packages >> (Search "ESAPI")
2. In your project, instead of calling:

```cs
 var app = Application.CreateApplication("...");
 ```
 Call :
 ```cs
 var sac = new StandAloneContext(()=>Application.CreateApplication("..."));
  ```

## StandAloneContext vs VMS...Application
Using ESAPIX StandAloneContext (SAC) wraps the real Varian classes in a thread controlled environment using [Facades]("https://rexcardan.github.io/ESAPIX/articles/facades.html"). This trick allows for
using easy multithreading since ESAPIX will handle calling VMS proper classes on the correct thread. Additionally, these lightweight wrappers (Facades) can be used to 
mock Varian classes for [unit testing](https://www.youtube.com/watch?v=HUuCU2Hplgw) and [offline development]("https://www.youtube.com/watch?v=pxazDPo3Ugc"). Also, the data can be quickly serialized
into JSON using the [FacadeSerializer](https://github.com/rexcardan/ESAPIX/blob/master/ESAPIX/Facade/Serialization/FacadeSerializer.cs) class.

## Contributing
Most of all, ESAPIX is a unified, open source framework that is designed to be used and contributed to by the medical physics community. It uses the MIT open source license to ensure that
code can be used in whatever tools you need in the fight against cancer. If you are interested in contributing code, please [see an example]("https://www.youtube.com/watch?v=Zq2wasAW6iw") of submitting code to this repository.
## WPF Application
### Video Tutorial (Deprecated. For versions <1.5.0.0)
[![Quick Startup ESAPIX](https://img.youtube.com/vi/qPVIR8Jxs94/0.jpg)](https://www.youtube.com/watch?v=qPVIR8Jxs94) 

To dive deeper, check out [more examples and API documentation](https://rexcardan.github.io/ESAPIX/).

