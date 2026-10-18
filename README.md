# 🎱 8-Ball Pool — Realistic Physics & Multiplayer Simulation Engine

[![Unity 2022.3 LTS](https://img.shields.io/badge/Unity-2022.3%20LTS-black.svg?style=flat&logo=unity)](https://unity.com/)
[![Language: C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20iOS%20%7C%20PC-brightgreen.svg)]()
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A high-fidelity, physically accurate 8-Ball Pool game engine built with Unity and C#. Features custom rigid-body collision handling, angular spin transfer (topspin, backspin, English/sidespin), real-time trajectory line prediction with multi-rail reflections, pocket detection, and responsive touch/mouse aiming controls.

---

## 🌟 Key Engineering Features

- **Accurate Ball Physics & Impulse Math:**
  - Dynamic friction, restitution coefficients, and rolling/sliding transition physics.
  - Custom angular momentum and spin transfer calculation upon ball-to-ball and ball-to-cushion contact.
- **Raycast & Reflection Trajectory System:**
  - Multi-bounce trajectory prediction lines simulating true reflection angles against table cushions.
  - Ghost ball visualization showing projected pocket angle on targeted balls.
- **Precision Cue Control:**
  - Smooth 360° rotational aiming with sensitivity dampening for micro-adjustments.
  - Dual-mode power slider with impulse scaling and release velocity decay.
  - Interactive cue ball contact point selector for precise spin input (draw, follow, stun, and english).
- **Comprehensive Rule Engine:**
  - Turn management (Open table, Solids vs Stripes assignment).
  - Scratch detection (Cue ball pocketed or off table) with ball-in-hand placement logic.
  - Legal break shot and 8-ball win/loss conditional evaluation.
- **Optimized Mobile Performance:**
  - Custom low-draw-call UI architecture.
  - Zero-allocation physics tick loops targeting steady 60 FPS on mid-range Android and iOS devices.

---

## 🏗️ Architecture & Scripts Overview

```
Assets/Scripts/
├── Cue/
│   ├── AimController.cs        # 360-degree rotational input & trajectory casting
│   ├── CueController.cs        # Visual cue stick placement & strike animations
│   ├── PowerController.cs      # Pull-back tension & force impulse calculation
│   └── SpinController.cs       # 2D offset matrix for angular spin & torque transfer
├── Physics/
│   ├── BallPhysics.cs          # Rolling resistance, restitution & surface damping
│   ├── CueBallController.cs    # Cue ball strike execution & ball-in-hand state
│   └── PocketDetector.cs       # Pocket trigger zones & drop physics
├── Game/
│   └── GameManager.cs          # Turn cycles, foul handling & match arbitration
└── UI/
    └── GameUI.cs               # Power gauge, score HUD & ball rack indicators
```

---

## 🛠️ Tech Stack & Requirements

- **Engine:** Unity 2022.3 LTS (or later)
- **Scripting:** C# (.NET Standard 2.1)
- **Render Pipeline:** Universal Render Pipeline (URP) / Built-in
- **Input System:** Cross-platform Mobile Touch & Desktop Mouse/Keyboard

---

## 👨‍💻 Developed by

**Noman Ali** — Unity Game Developer & 3D Technical Artist  
- **Email:** [noman.haydevs@gmail.com](mailto:noman.haydevs@gmail.com)  
- **GitHub:** [@nomanali2496](https://github.com/nomanali2496)  
- **Upwork:** [Noman Ali Profile](https://www.upwork.com/freelancers/~01bcadb303a1879813)  
- **Fiverr:** [Noman Ali Services](https://www.fiverr.com/s/L3327XY)  
