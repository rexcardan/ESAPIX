---
uid: facades.md
title: ESAPIX Facades
---

# Facades with ESAPIX

## Why Use Facades
Facades provide a layer in between you and Varian dlls. This has three main advantages:

### Offline development
You can quickly and easily develop with a quick reference to ESAPIX using NuGet. Take it on the road and don't worry about access to VMS systems for testing out ideas. Then, when you are ready, you can connect to the Varian architecture and run it without any code changes.

### Unit Testing
You can easily develop unit tests on any VMS equivalent class using the default MSTest suite. Now you can build a robust suite of tests to make sure your application is running smooth after every build.

```cs
        [TestMethod()]
        public void IsValidNameTestFail()
        {
            //You can't do this with VMS
            var ps = new PlanSetup();
            //Can't set this either
            ps.Id = "P0Prostate"; //Should fail
            Assert.IsFalse(NameChecker.IsValidName(ps));
        }
```
> The above method shows testing a class *NameChecker* for the method *IsValidName* which takes a PlanSetup object as an input and presumably makes sure the name is compliant with set standards. 

### Async Await Multithreading Support
You don't even have to think about threads anymore. Just grab the data and work with it however you want. ESAPIX Facades take care of all of the plumbing and threading work behind the scenes. It's like magic.

```cs
        private async static void GetPatientAsync(Application app)
        {
            //Try doing this without ESAPIX (eg. crash application)
            var pat = await Task.Run(() =>
            {
                return app.OpenPatientById("PHYSX_C3_DLG6X");
            });

            Console.WriteLine($"{pat.Id} : {pat.LastName}, {pat.FirstName}");
        }
```