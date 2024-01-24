[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/uYY8lrdZ)

# Headless Zombie Demo: Unity

> **Name:** Megan Hamilton-Mills
> **ID:** 23643881

This project forms part of my final submission for the MSc Games Development *'Games Programming'* module.

### Table of Contents

- [Software Used](#software-used)
- [Installation](#installation)
- [Features](#features)
- [Acknowledgments](#acknowledgments)

### Software Used

- Visual Studio Code 2023 (v1.85)
- Unity 2022.3.5f1 (LTS)

### Installation

1.  Clone the repository: `git clone https://github.com/ManMetGames/Headless-Zombie-Unity.git`
2.  Open the project in Unity
3.  Run the project

### Features

The aim of this project was to create a unique game mechanic in both Unity and Unreal Engine 5.

My mechanic is essentially a 3D recreation of the headless zombie enemy from the side-scrolling stealth game *Deadbolt*. The player navigates the 3D environment using a navigation mesh while being hunted by a headless zombie consisting of a separate detached head and body.

The zombie's body only chases the player when they are within the head's line of vision. This is represented by a trigger volume, illustrated in this demo by a 3D cone whose visibility can be toggled on and off via a button. Additionally, a toggleable tracking ball moves to the last position where the player was seen by the zombie, offering a visual representation of the zombie's tracking behaviour.

The demo incorporates various camera angles, including top-down, side view, front view, and isometric view. The world was modelled in-editor for each solution to compare their prototyping tools.

### Acknowledgements

- Rigged Player/Enemy Models: [Banana Yellow Games: Banana Man](https://assetstore.unity.com/packages/3d/characters/humanoids/banana-man-196830) on Unity Asset Store
- Player Animations: [Kevin Iglesias: Basic Motions FREE](https://assetstore.unity.com/packages/3d/animations/basic-motions-free-154271#content) on Unity Asset Store
- Zombie Animations: [Animus Digital: Zombie Animation Pack Free](https://assetstore.unity.com/packages/3d/animations/zombie-animation-pack-free-150219) on Sketchfab