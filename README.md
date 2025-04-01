# WorkoutTrackerApp
# 🏋️ Workout Tracker App

A personalized cross-platform workout tracking application built with **.NET MAUI** and **C#**, designed to visually log workouts, rest days, and inactivity across multiple months using a calendar-based interface.

---

## 🚀 Tech Stack

- **.NET MAUI (Multi-platform App UI)**: Enables single-codebase deployment to **iOS**, **Android**, and **Windows**.
- **C#**: Primary language for UI logic and business rules.
- **MVU-style XAML + Code-Behind**: Provides declarative UI layout with dynamic logic.
- **Preferences API** (`Microsoft.Maui.Storage`): Lightweight key-value store used for **persistent local data**, even across app sessions.
- **System.Text.Json**: Used to serialize and deserialize workout data efficiently.

---

## 🎯 Why .NET MAUI?

- **Cross-platform Efficiency**: MAUI allows deploying the same UI and backend logic across Windows, iOS, and Android.
- **Native Performance**: Under the hood, MAUI compiles to native controls and leverages platform-specific APIs.
- **Minimal Dependencies**: No external backends or databases required — the app works 100% offline and is optimized for single-user use.

---

## ✅ Features

- 🗓 **Monthly Calendar View**  
  View each month's days with color-coded indicators:
  - 💪 Green for workout days
  - 😴 Yellow for rest days
  - ❌ Red for inactive days

- 📆 **Multi-Month Navigation**  
  Switch between January, February, March, and more with month tabs.

- 👆 **Tap-to-Set Rest Days**  
  Easily mark any day as a rest day with a simple tap interaction.

- 💾 **Automatic Local Persistence**  
  All workout and rest data is saved locally using Preferences, so it's retained even after app restarts.

- 🧘 **Single-User Personal Focus**  
  Designed exclusively for personal use — no login or account system needed.

---

## 📱 Deployment

- Developed on **Windows 11** using Visual Studio 2022
- Targets **iOS (iPhone)** and **Windows Desktop**
- Personal publishing to the **Apple App Store** planned for private distribution (via TestFlight or App Store Connect)

---

## 🛠 Roadmap / Next Steps

- [ ] Add editable workout details to each day
- [ ] iCloud or device backup integration (optional)
- [ ] iOS deployment and App Store listing (private)
- [ ] Monthly progress tracking and stats

---

