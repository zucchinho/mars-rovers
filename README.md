# mars-rovers

I've created a small library- Nasa.MarsMission.Rovers- which
provides the base interfaces/classes for a Mars
rover mission. It is fairly generic, with the key base classes
accepting string input and leveraging
abstraction to delegate specific implementation
details- such as interpreting the command, processing/executing the
steps- to derived classes.

The idea is to allow for different types of rover, 
more advanced and with different features. An
incomplete example can be seen in the Airborne project,
with the beginnings of an AirborneDrone implementation.

For the original exercise, I created the necessary implementations
in the Basic project. Here, a basic rover is implemented, whose
capabilities are limited to moving on a horizontal grid (corresponding
to the plateau). The BasicRover is limited to moving 1 unit, and 90 degree
turns i.e. left/right. But a less limited surface rover could even be derived 
from the SurfaceRoverBase abstract class. For example, one able to move a 
variable units, turn 180, move orthogonal to its direction, or move diagonally.

The Basic code is exercised via a couple of xUnit tests in the Test project.
Here you can see the Rover and the Fleet respectively processing viable input, and
produced the correct output, as required in the challenge. The specific input/output
scenario specified in the test is marked with a comment, in the BasicFleetTest class.

## To build and run the code

This is a .NET library, to build it open the solution in Visual Studio
(or similar IDE e.g. Jetbrains Rider) and build. Or you can build from the 
command line via running "dotnet build" in the solution directory.

To run the unit tests, either in an open IDE using the integrated test
UI or via the command line with "dotnet test" in the solution directory.

You should have .NET Core installed, normally this will come as an option
on Visual Studio. Otherwise can be downloaded here:

https://dotnet.microsoft.com/download/dotnet/3.1

## What could come next?

While completing the exercise, I considered some 
fun and interesting ways of building upon this code, to 
create something more engaging and interactive.

To give an overview of where I'd take this project:
- .NET Core WebApi to process, create fleets, process
  movement commands and return output etc. via this library
- Database to store information on current missions, 
  fleets, rovers and their positions
- Mongo data access layer - used by the WebApi,
  to CRUD saved states etc.
- React UI to visualize the positions of the rovers. Start
  simple with a pixel grid, but could evolve.
- More advanced Rover types e.g. airborne drones, 
navigation of uneven terrain, obstacles etc.