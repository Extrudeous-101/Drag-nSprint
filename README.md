# Drag'n Sprint
_Make your kobold move faster 🦎 <sup>(or slower, if you will)</sup> :)_
> [!NOTE]
> I made this mod just for fun and i'm not a good mod dev. Maybe it'll break something somewhere

Adds ability to run using `Left Shift`.

## Download and install
### Using Drag'n Wash ModFramework Mod Installer <sup>(new)</sup>
1. Go to [releases](https://github.com/Extrudeous-101/DragnSprint/releases) and download latest `Drag'n Sprint Installer.zip`
2. Unpack installer and open `Install.exe` (or `install-steamdeck.sh` if you are using Steam Deck)
3. Select game folder and press `Install`
### Using Drag'n Wash ModFramework Mod Installer Command line <sup>(new)</sup>
```bash
Install.exe --install [--game-dir <folder>] [--choice <id>=<value>]

bash install-steamdeck.sh --yes --install [--game-dir <folder>] [--choice <id>=<value>] [--no-launch-option]
```
### Manual install
0. Install BepInEx (bundled with Drag'n Wash ModFramework) and Drag'n Wash ModFramework
1. Go to [releases](https://github.com/Extrudeous-101/DragnSprint/releases) and download latest release (you only need
   Drag.nSprint.zip archive).
2. Move `Drag'nSprint` folder to `BepInEx\plugins` folder inside your game installation.

## Uninstall
### In-game
1. Open Options -> Mods -> Drag'n Sprint
2. Press Uninstall

### Using Drag'n Wash ModFramework Mod Installer <sup>(new)</sup>
1. Open `Install.exe`
2. Select game folder
3. Press `Uninstall`
### Using Drag'n Wash ModFramework Mod Installer Command line <sup>(new)</sup>
```bash
Install.exe --uninstall [--game-dir <folder>] [--remove-data] [--remove-bepinex]

bash install-steamdeck.sh --yes --uninstall [--remove-data] [--remove-bepinex]
```
### Manual uninstall
1. Open game folder and find \BepInEx\plugins\DragnSprint folder
2. Delete it
3. _\[Optional\] (Removing config files) Go to \BepInEx\config and delete extrudeous.dragnsprint.cfg_
4. _\[Optional\] Uninstall BepInEx and Drag'n Wash ModFramework_

## Requirements
- [Drag'n Wash ModFramework v1.3+](https://github.com/TomXV/dragnwash-modframework) ([install guide](https://github.com/TomXV/dragnwash-modframework/wiki/For-players))

## Features
- Sprinting (Default button: `Left Shift`)
- Changing sprint speed modifier (now in game options)
- Rebinding sprint button (yes, it's very bad, but i can't change that)
