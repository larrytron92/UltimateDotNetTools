# The Ultimate .NET Tools

This is a .NET Standard 2.0 project with an additional .NET Core 3.1 Console Application to test code. The .NET Standard project will be built into a NuGet Package for use across the Microsoft .NET technologies in C#, Visual Basic and F#.

Please visit <https://dotnet.microsoft.com/platform/dotnet-standard> to see which .NET technologies .NET Standard 2.0 supports. 

Orginally I planned to build this in .NET Standard 2.1 to really get the best performance out of the newest version of C# but it would limited the amount of compatible technologies because in my experience as a software developer working for various companies, a lot of them are stuck on outdated technologies and cannot afford to spend time rebuilding everything from the ground up.

# The purpose of this project

The purpose of this project is to provide a set of simple extension methods for .NET developers. The library offers convenience for small little coding nuisances whilst preventing some very common null errors that developers forget to implement because Microsoft has yet to add these null checks into each of the 3 supported languages themselves.

As programming langauges get more advanced thanks to contributions from the community, it allows developers to streamline their code writing by helping them get their app up and running as quickly as possible. As a community we can share small bits of code that we used to tackle a specific issue, so others can learn from your experience.

.NET Framework, Core and Xamarin are the most popular technologies used for developing websites and apps. All three major technologies can be programmed in C#, F# and Visual Basic. .NET Standard is a class library to share common logic among each of the three aforementioned technologies without needed to write the code again. Just create the project, stick the code in, publish it to NuGet and then download it into your app and...voilà!

# The main philosophy of this project

The most important lesson I've learnt as a programmer is to: Build your tools before you build the app. Understand what data will be going in and out of the app, then set a standard for the app to follow in order to prevent crashing or unintended effects.

The standards needs to include error checking, exception handling, data converting, 

I've modeled the philosophy from my experience current job and a previous job where more senior devs would program the libraries for the others to use. At my current job, I've managed to program three generations of a .NET Standard API for my colleagues to quickly connect their .NET Core apps to our REST services. Each generation became more efficient as I honed my software development abilities and expand the toolset to include the same extension methods found in this project.

# An example of how useful this toolset can be

A common root cause of programs crashing is because of null data. Developers can miss out the possibility that a null object or value has been returned because something has gone wrong in the logic somewhere. Most users are NOT computer programmers, so they are unlikely to understand why the program has froze or an error page is shown.

Let's use a generic list in C# as an example... (Note that this also applies to Visual Basic and F# too)

```
List test = null;

if (test.Any())
{
  
}
```

Guaranteed, an exception will be thrown because you're trying to trigger a method for an object that hasn't come into existence yet. It's like trying ask your unborn baby to help you with your tax returns, the baby hasn't arrived yet neither does it know how to file taxes!
