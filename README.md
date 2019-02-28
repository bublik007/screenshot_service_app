# Screenshot Service App
The repository contains a C# background service app that, in response to a certain key press, takes a screenshot and adds a timestamp to it; when another key is pressed and while it is being hold, the app shows the taken screenshot full screen. This program is an extraction of a more sophisticated system that I am developing in the scope of my industrial PhD research project. The system is intended to facilitate human-computer interaction in industrial control rooms. Due to the company policies, I cannot reveal more details about the original system. 

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

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
An example
```

### And coding style tests

Explain what these tests test and why

```
An example
```

## Deployment

The binaries of the program, .i.e the .exe file, should work on any modern PC running any recent version of Windows OS. You just need to copy the .exe file to any location of your PC, and double click on the .exe file in order to execute it. If the system tray icon has appeared, I believe this can be treated as a fair enough evidence that the program has started correctly. Then use the key combinations to take and view the screenshots. In case you face any problems, please drop me a line with a description of the problem, I will try my best to look into the issue.

## Built With

* .NET Framework 4.5
* C# 
* WPF

## Contributing

In general, I do not expect anyone to contribute to this project. However, if you have any suggestions or requests, please contact me personally or sumbit a pull request.

## Versioning

For versioning, I just use incremental numbers in the format "v_X_Y", where v stands for "version" and X, Y are incremental numbers, e.g. "v_1_0" is the initial version of the code before any refactoring. The version "v_2_0" is a new release containing all the refactoring done in the scope of the WASp software course.

## Authors

* **Veronika Domova** - *Initial work* 

## License

To avoid misunderstandings, please let me know if you want to use this code for your own purposes. I might agree on that for a chocolate :) 

## Acknowledgments

* The developed code was inspired by many examples found on forums and in tutorials in Internet.
