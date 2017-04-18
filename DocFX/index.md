<center>![Logo](images/esapixLogo.jpg "ESAPIX Logo")</center>

Welcome to the ESAPIX library homepage. Kick start your Eclipse Scripting with a powerful, open source library.


##Basic Operations

###Reading and Writing
```csharp
var dcm = DICOMObject.Read(@"MyDICOMFile.dcm");

//You can also read from bytes (eg. a stream)
var dBytes = File.ReadAllBytes(@"MyDICOMFile.dcm");
var dcm = DICOMObject.Read(dBytes);

//***COOL CODE GOES HERE***

//Writing is equally easy
dcm.SaveAs("MyHackedDICOMFile.dcm");
```

###See Also
*	@structure.md
*	@selection.md
*	@helpers.md
