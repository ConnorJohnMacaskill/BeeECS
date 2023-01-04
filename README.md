# Introduction
Another, newer [ECS](https://en.wikipedia.org/wiki/Entity_component_system) engine written using the C# Monogame framework, known as BeeECS. A working game of asteroids using the engine is included.

# Structure

The engine logic is centralised in the BeeECS project, with asteroids implemented in the Asteroids project.

# Assets & Entities

Assets are stored externally and loaded at runtime for easy modification, including entities which are stored as XML files and built up using predefined components, an example of which can be found in Player.xml.
