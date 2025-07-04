Gameplay video - https://youtu.be/J22cF_R0YAQ

🔧 Project Structure & Script Overview
I’ve structured the project into clean, modular components to ensure maintainability, scalability, and readability. Each module handles a specific responsibility within the game’s architecture:

📁 Main Modules:
Defender:
Handles all logic for defender units such as Cactus, Gnome, GraveStone, and StarTrophy.

Attacker:
Manages logic for enemy units including Lizard and Fox.

Projectile:
Controls all logic related to projectiles fired by defenders.

DefenderCell:
Handles UI and logic for defender selection slots/cells.

Grid:
Manages the grid system and slots for unit placement.

Level:
Oversees level progression, wave management, and attacker spawning logic.

Utilities:
Contains reusable and global systems such as the Event System, Object Pooling, and Singleton base classes.

Audio:
Manages all music, SFX, and sound-related functionalities.

🎯 Design Patterns Used
1. State Machine Pattern
📍 Where Used:

Defenders and Attackers

🧠 How I Applied It:

Each unit (e.g., CactusController, LizardController) has a dedicated state machine (e.g., CactusStateMachine, FoxStateMachine) that governs transitions between states such as:

Idle, Attack, TakeDamage, Die, etc.

States are represented by standalone classes (e.g., DefenderIdleState, AttackerAttackState) implementing interfaces like IStateMachineDefender or IStateMachineAttacker.

🔁 Example:

FoxController creates a FoxStateMachine, which manages all behavior transitions and encapsulates the logic for each state.

2. Service Locator Pattern
📍 Where Used:

Widely throughout the project using a central hub called GameService.

🧠 How I Applied It:

GameService acts as a global access point to major services like:

DefenderService, AttackerService, ProjectileService, LevelService, AudioService, etc.

These services use a generic singleton base class (GenericMonoSingleton<T>) to ensure one consistent instance throughout the game.

🔁 Example:

Any component can call GameService.Instance.DefenderService or AudioService.Instance to interact with systems without tightly coupling code.

3. Observer Pattern
📍 Where Used:

For decoupled communication between systems using a centralized EventService.

🧠 How I Applied It:

EventService uses generic EventController<T> classes to define and manage game events like:

OnPlaceDefender, OnShootProjectile, OnSpawnAttacker.

Systems can subscribe, unsubscribe, and react to these events without knowing each other directly.

🔁 Example:

DefenderService listens for OnPlaceDefender to instantiate units.

ProjectileService listens for OnShootProjectile to fire projectiles.

4. MVC (Model-View-Controller) Pattern
📍 Where Used:

Defenders, Attackers, and various UI components like Defender Cells.

🧠 How I Applied It:

Model: Stores unit data and logic (DefenderModel, AttackerModel).

View: Renders visuals and handles animation (DefenderView, AttackerView, DefenderCellView).

Controller: Connects logic with visuals (DefenderController, AttackerController, DefenderCellController).

🔁 Example:

When a defender is placed:

The controller initializes the model and view.

It links them and manages all state transitions and data updates.

🧾 Key Script Responsibilities
🔹 DefenderController.cs
Acts as the controller in MVC for defenders.

Manages health, attack logic, and behavior transitions.

Delegates animation and visuals to DefenderView.

Uses a state machine for dynamic behavior.

🔹 AttackerController.cs
MVC controller for attackers.

Manages movement, attack behavior, and state transitions like jump, damage, and death.

🔹 DefenderService.cs / AttackerService.cs
Central services for creating, pooling, and managing unit lifecycles.

Subscribed to relevant events via EventService.

Use the Service Locator pattern for accessing other systems.

🔹 EventService.cs
Implements the Observer Pattern using event controllers.

Enables decoupled communication across the game.

🔹 GenericMonoSingleton.cs
Base class for singleton services.

Supports the Service Locator Pattern by enforcing one instance per system.

🔹 DefenderCellController.cs / DefenderCellView.cs
MVC for UI defender cells.

Controls defender selection and placement logic.

🔹 Object Pooling System
(GenericObjectPool.cs, DefenderPool.cs, AttackerPool.cs, ProjectilePool.cs)

Efficiently reuses units and projectiles to optimize performance.

🔗 How the Patterns Work Together
State Machines isolate unit behavior, enabling clean extensibility for new actions or units.

Service Locator ensures all systems are easily accessible without tight coupling.

Observer Pattern enables reactive, decoupled communication between systems (e.g., spawn, attack, place).

MVC Architecture separates responsibilities, improving testability, debugging, and scalability.