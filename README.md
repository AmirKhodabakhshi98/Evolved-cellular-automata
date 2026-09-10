# Evolved Cellular Automata for Procedural Level Generation

A prototype **procedural content generation (PCG)** system that uses a **genetic algorithm (GA)** to evolve **cellular automata (CA) rules** for generating maze-like 2D game levels.

## Overview

Manually designing game levels can be costly and time-consuming. This project explores whether level-generation rules can instead be **evolved automatically**.

The system evolves cellular automata rules using a genetic algorithm. Each evolved rule is applied to **randomly initialized starting states**, with the goal of producing playable levels featuring:

- Long solution paths
- Large numbers of dead ends
- Maze-like structures
- Few unreachable areas

Unlike approaches relying on predetermined starting states, this project investigates whether a single evolved CA rule can produce useful levels across **multiple random initial configurations**.

## Results

Across **6 experiments, 60 levels were generated**, of which **58 were playable**.

The results demonstrate that it is possible to evolve CA rules capable of transforming random starting states into game-like levels. The experiments also identified areas for improvement, particularly around unreachable cells and the genetic algorithm's fitness/evolution strategy.

## Prototype

The repository includes an artefact demonstrating an evolved cellular automaton iteratively transforming a random starting state into a generated level.

> **Example of an evolved cellular automata applied over a starting state for 5 iterations:** [*Upload/embed video of the evolved CA iterating over a starting state here.*](https://github.com/user-attachments/assets/0668b61a-694d-4940-93a5-72ee97b8f9e4
)

## Technologies & Concepts

- Procedural Content Generation (PCG)
- Cellular Automata
- Genetic Algorithms
- Evolutionary optimization
- 2D level generation
- Game level evaluation
- Unity game engine
- C#

## Key Takeaway

This project demonstrates an end-to-end approach to **evolving procedural game-generation rules**, combining evolutionary algorithms with cellular automata to explore automated level design.

## Authors

**Amir Khodabakhshi**
**Adel Sabanovic**
