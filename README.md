# UnityShooterOnlineWithPatterns
Shooter with patterns developed in Unity engine

The project is still under development.
The main goal of the project was to use design patterns in the C # language. Also to use in practice libraries of MLAPI package to create a network game.
Implementation an OOP practice, separation of essences and responsibility to create a reusable code architecture.

The following patterns are currently implemented: Strategy, Observator, MVC.
<img src="https://i.ibb.co/H4knD6t/Weapon-Diagram.png" alt="Weapon-Diagram" border="0">
<br><br>

Even the same type of weapon can have different shoot behavior depending of the set values. Shooting behavior can be changed by substituting shootBehavior field in the AutomaticPistol component to another value that a component inherited from ShootBehavior.
<div align="center">
  <img src="https://i.ibb.co/1mGTNRZ/image.png" alt="image" border="0">
</div>
<br><br>

Subscribing to events and separation of concerns for the logic of player behavior makes it easier to test each individual block. Each player component (created by me) is independent and can be removed without harm to the project.
<div align="center">
  <img src="https://i.ibb.co/LxmC9yC/image.png" alt="image" border="0">
</div>
<br><br>

All character logic is controlled by the PlayerController script. This script subscribes to the events that occur and the execution of a specific action of the player object is passed to a specific method, if a component of such a method exists.
<div align="center">
  <img src="https://i.ibb.co/6Pcrtsq/image.png" alt="image" border="0">
</div>
