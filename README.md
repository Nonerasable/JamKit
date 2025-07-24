
# JamKit 🎮

JamKit is a lightweight and modular Unity starter kit for game jams and rapid prototyping.  
It helps you focus on gameplay instead of boilerplate setup.

---

## ✨ Features

- 🚀 **Scene Management**
    - Simple loading with loading screen and progress bar
    - Level configuration via `ScriptableObject`

- 🧩 **Service Locator**
    - Centralized access to game systems (`SceneLoader`, `SoundSettingsManager`, `UIManager`, etc.)
    - Auto-initialized in every scene via `SceneBootstrapper`

- 🧠 **Input System**
    - Built-in support for the **New Unity Input System**
    - Separate `Game` and `UI` action maps
    - Auto-handling of cursor + input context when UI windows open/close

- 🎧 **Sound Settings**
    - Mixer-based volume sliders: `Master`, `Music`, `SFX`
    - Sliders update AudioMixer groups in real time

- 🪟 **UI Windows**
    - Modular window system with `BaseWindow` and `IWindow` interface
    - Pause screen and "Thanks for playing" screen included
    - Easy UI toggling via Escape input

- 📦 **Example**
    - Minimal example included (`JamKitExample/`) with scenes:
        - `MainMenu`, `LoadingScene`, and `Level1`

---

## 📁 Project Structure
<pre>
Assets/ 
├── JamKit/ # Core systems (reusable) 
│ ├── Core/ # ServiceLocator, LevelConfig, SceneBootstrapper, etc. 
│ ├── InputActions/ # Input maps & config (New Input System) 
│ ├── Services/ # SceneLoader, UIManager, SoundSettingsManager, etc. 
│ ├── UI/ # BaseWindow, Loading UI, Volume sliders 
│ └── Sounds/ # AudioMixer with exposed parameters 
│ ├── JamKitExample/ # Example usage 
│ ├── Data/ # FirstLevelConfig.asset 
│ ├── Scenes/ # MainMenu, LoadingScene, Level1 
│ └── Scripts/ 
│ └── UI/ # PauseWindow, MainMenuView, PlayerInputController 
│ ├── Settings/ # Project-level configs (e.g. InputSystem settings)  
</pre>

---

## 🛠 Getting Started

1. Clone the repo into your Unity `Assets/` folder
2. Open `MainMenu.unity` to start from the beginning
3. Press **Play** — everything works out of the box:
    - Escape = Pause
    - Play Level
    - See loading screen
    - Finish & return to menu

---

## 💡 Notes

- Uses `DontDestroyOnLoad` for shared services
- You can safely launch any scene directly — `SceneBootstrapper` ensures services are initialized
- Volume sliders expect exposed parameters in `DefaultAudioMixer`: `MusicVolume`, `SfxVolume`, `MasterVolume`

---

Happy jamming! 🕹️
