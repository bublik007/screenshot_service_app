# Screenshot Service App
The repository contains a C# background service app that, in response to a certain key press, takes a screenshot and adds a timestamp to it; when another key is pressed and while it is being hold, the app shows the taken screenshot full screen. This program is a part of a more complex system that is intended to facilitate the workflows of operators in control rooms with many overview screens.

## Getting Started

The instructions below will help you to get a copy of the source code of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to run the binaries on a Windows machine.

### Prerequisites

The code is intended to be used on Windows OS. In order to compile and run the sources of the software, you need .NET Framework of version 4.5 installed on your machine. I believe, the easiest way to to get everything up and running for compiling the source coude is to install Visual Studio IDE. Usually, it comes with all the necessary libraries. When developing this software, I did not use any extraordinary libraries or third-party frameworks, that is why a standard Visual Studio installation should be more than enough.

### Installing
1. Download the source code as a zip file or fork/check out the repository through git. 

2. In your Visual Studio IDE, click File --> Open --> Project/Solution. In the opened window provide the path to the downloaded in the previous step repository, namely to the folder where the .sln file is located. 

3.  If everything went smooth, you should be able to see the sources in the Solution Explorer window of the IDE.

4. Compile and run the code using the appropriate commands in the IDE.

5. If the compilation and the start up process went smooth, an icon should appear in the system tray indicating that the program is up and running. 

6. Now try taking a screenshot. For this, press "Print Screen" button on your keyboard. If a screenshot has been taken, you should get a corresponding system notification.

7. Now try to get the taken screenshot shown full screen. For this, press and hold "down" button and press once the "left" or "right" button. The newly taken screenshot should appear full screen. In the middle of the screenshot, there should be a timestamp of the exact time it was taken. Release "down" button to make the screenshot disappear from your screen.

## Running the tests

The project called UnitTests contains unit tests that cover the majority of the functions in the main code. The tests were written using xUnit framework. The tests can be launched in Visual Studio. Part of the functionality, namely related to GUI and keyboard events, is not being tested since I could not find a straightforward way to test them. I might get back to implementing tests if i get some inspiration.

## Deployment

The binaries of the program, .i.e the .exe file, should work on any modern PC running any recent version of Windows OS. You just need to copy the .exe file to any location of your PC, and double click on the .exe file in order to execute it. If the system tray icon has appeared, I believe this can be treated as a fair enough evidence that the program has started correctly. Then use the key combinations to take and view the screenshots. In case you face any problems, please drop me a line with a description of the problem, I will try my best to look into the issue.

## Built With

* .NET Framework 4.5
* C# 
* WPF

## Contributing

In general, I do not expect anyone to contribute to this project. However, if you have any suggestions or requests, please contact me personally or sumbit a pull request.

## Versioning

For versioning, I just use incremental numbers in the format "vX.Y", where v stands for "version" and X, Y are incremental numbers, e.g. "v1.0" is the initial version of the code before any refactoring. The version "v2.0" is a new release containing all the refactoring done in the scope of the WASP software course.

When commenting commits, I tend to stick to the following message template:

```
Type: A short sentence about the commit

[Optional] description
```

Used commit types:

<table>
  <thead>
    <tr>
      <th>Type</th>
      <th>Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Feature</td>
      <td>A new feature</td>
    </tr>
    <tr>
      <td>Refactor</td>
      <td>Code enhancement</td>
    </tr>
    <tr>
      <td>Bugfix</td>
      <td>A bug fix</td>
    </tr>
    <tr>
      <td>Doc</td>
      <td>Documentation update</td>
    </tr>
     <tr>
      <td>UTest</td>
      <td>Unit tests</td>
    </tr>
  </tbody>
</table>

## Authors

* **Veronika Domova** - *Initial work* 

## License

To avoid misunderstandings, please let me know if you want to use this code for your own purposes. Due to the company policies, I am not supposed to make the code public. 

## Acknowledgments

* The developed code was inspired by many examples found on forums and in tutorials in Internet.
