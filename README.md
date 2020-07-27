# The Ultimate .NET Tools

This is a .NET Standard 2.0 project with an additional .NET Core 3.1 Console Application to test code. The .NET Standard project will be deployed as a NuGet Package for use across the Microsoft .NET technologies in C#, Visual Basic and F#.

Please visit <https://dotnet.microsoft.com/platform/dotnet-standard> to see which .NET technologies .NET Standard 2.0 supports. 

Orginally I planned to build this project in .NET Standard 2.1 to really get the best performance out of the newest version of C#, but it would limited the amount of compatible technologies because in my experience as a software developer working for various companies, a lot of them are stuck on outdated technologies and cannot afford to spend time rebuilding everything from the ground up.

# Technologies & Dependencies

.NET Standard 2.0

C# 8.0

.NET Core 3.1 Console Application

System.Text.Json

# The purpose of this project

The purpose of this project is to provide a set of simple extension methods for .NET developers. The library offers convenience for small little coding nuisances whilst preventing some very common null errors that developers forget to implement because Microsoft has yet to add these null checks into each of the 3 supported languages themselves.

Ideally, if you have to write a piece of logic more than once, it's best to create a small method that does the same thing and make it accessible anywhere in the app for future use.

.NET Framework, Core and Xamarin are the most popular technologies used for developing websites and apps. All three major technologies can be programmed in C#, F# and Visual Basic. .NET Standard is a class library to share common logic among each of the three aforementioned technologies without needed to write the code again. Just create the library, stick the code in, publish it to NuGet and then download it into your app and...voilà!

# The main philosophy of this project

The most important lesson I've learnt as a programmer is to: Build your tools before you build the app. Understand what data will be going in and out of the app, then set a standard for the app to follow in order to prevent crashing or unintended effects.

The standards needs to include error checking, exception handling, data converting and the company's business logics.

I've modeled the philosophy from experiences at my current job and a previous job, where more senior devs would program the libraries for everyone to use. At my current job, I've managed to program three generations of a .NET Standard API for my colleagues to quickly connect their .NET Core apps to our REST services. Each generation became more efficient as I honed my software development abilities and expand the toolset to include the same extension methods found in this project.

# An example of how useful this toolset can be

A common root cause of programs crashing is because it's trying to read or manupulate null data. Developers can overlook the possibility that a null object or value has been returned because something has gone wrong in the logic and it leads to the program not functioning properly. 

Most users are NOT computer programmers, so they are unlikely to understand why the program has froze or an error page is shown.

Let's use a generic list in C# as an example... (Note that this also applies to Visual Basic and F# too)

```
List<string> test = null;

if (test.Any())
{
  
}
```

So I've declared a variable call "test" and it will hold a list of strings, BUT I haven't instantiated it yet. Then I'm trying to use the "Any" extension method in System.Linq, to see if list actually has something inside.

Guaranteed, an exception will be thrown because you're trying to trigger a method for an object that hasn't come into existence yet. It's like trying ask your unborn baby to help you with your tax returns, the baby hasn't arrived yet neither does it know how to file taxes!

So what exactly can be done about this? You can do it this way...

```
List<string> test = null;

if (test != && test.Any())
{
  
}
```

But then you'd have to write that if statement every time you create a list and need to check something inside of it.

OR...you can use an IEnumerable extension method I've already created to check if the list is null before checking if it has something inside.

```
List<string> test = null;

if (test.IsNotNullOrEmpty())
{
  
}
```

By bringing in the UltimateDotNetTools namespace, you now have some access to the IsNotNullOrEmpty method, which can save your behind if you use frquently use collections.

# What APIs are available?

So far I've added helpers for the most frequently used data types from the various projects I've worked on over the years:

* String
* Value
* DateTime
* Enum
* List

# Community Guidlines

This project is free for anyone to download of modify to their heart's content. As a community we should be sharing bits of code used to solve common problems, so others can learn from your experience.

If you would like to add some extension methods then please feel free to do a pull request.
