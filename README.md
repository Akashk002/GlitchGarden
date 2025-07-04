Gameplay video - https://youtu.be/J22cF_R0YAQ

Project Structure & Script Overview
Your project is organized into several main modules, each with its own set of scripts:
Defender: Handles all logic related to defender units (e.g., Cactus, Gnome, GraveStone, StarTrophy).
Attacker: Handles logic for enemy units (e.g., Lizard, Fox).
Projectile: Manages projectiles fired by defenders.
DefenederCell: Manages the UI and logic for defender selection cells.
Grid: Manages the game grid and slots.
Level: Handles level progression and spawning logic.
Utilities: Contains shared services (e.g., event system, object pooling, singleton base).
Audio: Manages sound effects and music.
Design Patterns Used
1. State Machine Pattern
Where Used: Both Defenders and Attackers.
How:
Each unit type (e.g., CactusController, GnomeController, LizardController, FoxController) has a dedicated state machine (e.g., CactusStateMachine, LizardStateMachine).
State machines implement interfaces (IStateMachineDefender, IStateMachineAttacker) and manage transitions between states (Idle, Attack, TakeDamage, Die, etc.).
States are implemented as classes (e.g., DefenderIdleState, AttackerAttackState) that encapsulate behavior for each state.
Example: FoxController creates a FoxStateMachine, which manages state transitions and calls the appropriate logic for each state.
2. Service Locator Pattern
Where Used: Throughout the project, especially in GameService and via singleton services.
How:
GameService acts as a central hub, providing access to all major services (e.g., DefenderService, AttackerService, ProjectileService, LevelService, EventService).
Singleton pattern is used for services like AudioService, CurrencyManager, and GameService itself, via a generic base (GenericMonoSingleton<T>).
Example: Any script can access GameService.Instance.DefenderService to interact with defenders, or AudioService.Instance to play sounds.
3. Observer Pattern
Where Used: For event-driven communication between systems.
How:
The EventService class defines events using generic EventController classes, supporting different signatures.
Systems subscribe to events (e.g., OnPlaceDefender, OnShootProjectile, OnSpawnAttacker) and react when those events are invoked.
Example: DefenderService subscribes to OnPlaceDefender to handle defender placement, and ProjectileService subscribes to OnShootProjectile to spawn projectiles.
4. MVC (Model-View-Controller) Pattern
Where Used: For both Defenders and Attackers, and UI elements.
How:
Model: Holds data and logic (e.g., DefenderModel, AttackerModel).
View: Handles rendering and user interaction (e.g., DefenderView, AttackerView, DefenderCellView).
Controller: Orchestrates logic, updates model and view (e.g., DefenderController, AttackerController, DefenderCellController).
Example: When a defender is placed, the controller creates the model and view, links them, and manages their interactions.
Example Script Descriptions
DefenderController.cs
Acts as the controller in MVC for defenders.
Manages the defender's state, health, and attack logic.
Delegates animation and visual updates to DefenderView.
Uses a state machine for behavior transitions.
AttackerController.cs
Controller for attackers, following MVC.
Manages movement, attacking, and state transitions.
Uses a state machine for complex behaviors (e.g., idle, move, attack, jump, take damage, die).
DefenderService.cs / AttackerService.cs
Service classes responsible for creating, pooling, and managing units.
Subscribe to relevant events via the observer pattern.
Use the service locator pattern for accessing other services.
EventService.cs
Implements the observer pattern.
Provides a flexible event system for decoupled communication between systems.
GenericMonoSingleton.cs
Implements the singleton pattern for services, supporting the service locator approach.
DefenderCellController.cs / DefenderCellView.cs
MVC for UI cells that allow the player to select and place defenders.
Object Pooling (GenericObjectPool.cs, DefenderPool.cs, AttackerPool.cs, ProjectilePool.cs)
Efficiently manages object reuse for performance.
How the Patterns Work Together
State Machines encapsulate unit behavior, making it easy to add new states or units.
Service Locator (via singletons and GameService) provides global access to core systems, reducing coupling.
Observer (via EventService) enables decoupled, event-driven communication, so systems can react to game events without direct references.
MVC separates concerns, making the codebase more maintainable and testable.