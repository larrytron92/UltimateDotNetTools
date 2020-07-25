# The Ultimate .NET Tools

This is a .NET Standard 2.0 project with an additional .NET Core 3.1 Console Application to test code. The .NET Standard project will be built into a NuGet Package for use across the Microsoft .NET technologies in C#, Visual Basic and F#.

Please visit <https://dotnet.microsoft.com/platform/dotnet-standard> to see which .NET technologies .NET Standard 2.0 supports. 

Orginally I planned to build this in .NET Standard 2.1 but it would limited the list of compatible technologies because, in my experience as a software developer working for various companies, a lot of them are stuck on outdated technologies and cannot afford to spend time rebuilding everything from the ground up.

# The purpose of this project

The purpose of this project is to provide a set of simple extension methods for .NET developers. The library offers convenience for small little coding nuisances whilst preventing some very common null errors that developers forget to implement because Microsoft has yet to add these null checks into each of the 3 supported languages themselves.
