# Summary
* This repo contains the coding interview questions and my solutions in C#
* Each folder is a single problem.
    * The `Question.md` contains the question
    * The `Solution.md` contains the solution and the space time complexity.

## Instructions for setting up C# project with VS Code
* Open Terminal/Powershell
* Navigate to the problem folder
* Use `dotnet new` to initalize the project. This generate the `Program.cs`, `project.json` files. 
* Use `code .` to open VS Code from command line with this folder as the root folder.
    * When VS Code opens, if there is a `project.json` file. VS Code would notify you to install some assetes. The two assets which will be installed are `.vscode\tasks.json` and `.vscode\launch.json`. These two files are required to run the debugger for the application.
* Remove the `Program.cs` since the `Question.cs` already contains the `static Main()` method.
* Build the project using `dotnet build`
