# mars-rovers

## overview
### basic
dotnetcore
- simple library with interfaces
- library with basic implementations
- console app for demo purposes
- unit tests
  
### next
- webapi to process, create fleets, process
  movement commands etc
- mongo data access layer
- mongo database to store information on
current missions, fleets, rovers and their positions

### pretty ambitious, but you never know
- React UI to visualize the positions of the rovers
- More advanced Rover types e.g. airborne drones, 
navigation of uneven terrain, obstacles etc.

### library

###### interfaces
- ISimpleRover :
  - IMover
    - Move
  - ITurner
    - Turn 
- IFleet
  - AddRover
- IMission
  - DeployFleet
  
##### enums (can leverage existing)
- Direction (Left/Right)
- CompassDirection