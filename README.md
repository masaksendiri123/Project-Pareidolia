# Project Pareidolia

Project Pareidolia adalah prototipe game Unity (multi-scene) yang dibuat untuk course online Codelamp. Repo ini berisi project Unity lengkap dan dapat langsung dibuka di Unity Editor.

## Overview
- Engine: Unity 2022.3.62f1 (LTS, URP)
- Bahasa: C# (MonoBehaviour lifecycle)
- Input: Unity Input System 1.14.2
- UI: UGUI + TextMesh Pro
- Pipeline: Universal Render Pipeline (URP 14)
- Target: Standalone (Windows).

## Persyaratan Sistem
- Windows 10/11 (disarankan)
- Unity Hub + Unity Editor 2022.3.62f1 (LTS)
- Ruang penyimpanan sesuai kebutuhan aset Unity

## Setup & Run
1. Clone repo: `git clone <URL repo>`
2. Buka Unity Hub → Open → arahkan ke folder proyek ini
3. Tunggu proses import aset dan resolusi paket selesai (URP, TextMesh Pro, Input System)
4. Buka scene awal: `Assets/Scenes/MainMenuScene.unity`
5. Tekan Play di Unity Editor

Catatan:
- Sistem Input menggunakan package `com.unity.inputsystem`. Pastikan aktif (Edit → Project Settings → Player → Active Input Handling: Input System Package).
- Beberapa sistem (seperti AudioManager) menggunakan pendekatan `DontDestroyOnLoad` untuk persistensi antar scene.

## Build
1. Buka File → Build Settings
2. Pastikan daftar "Scenes In Build" sudah berisi scene berikut:
   - Assets/Scenes/MainMenuScene.unity
   - Assets/Scenes/Town (Act1).unity
   - Assets/Scenes/Town (Act1,2).unity
   - Assets/Scenes/House (Act2).unity
   - Assets/Scenes/Town (Act3).unity
   - (Opsional) Assets/Scenes/TestingMechanicsScene.unity
3. Pilih target platform (mis. Windows Standalone) → Build

## Struktur Proyek (ringkas)
- Assets/
  - Scenes/
    - MainMenuScene.unity, Town (Act1).unity, Town (Act1,2).unity, House (Act2).unity, Town (Act3).unity, TestingMechanicsScene.unity
  - Scripts/
    - CharacterMovement/
      - CharacterMovement.cs (gerak karakter via Input System)
      - CameraScript.cs (kontrol kamera & orientasi)
      - MovementStatusHandler.cs (status gerak: bisa bergerak/tidak)
    - InteractionStuff/
      - OnOffFlashlightScript.cs, ProgressObjectiveScript.cs, CompletionObjectiveScript.cs, HitboxSound.cs (interaksi & objektif)
    - Manager/
      - AudioManager.cs (pengelola audio, persist dengan DontDestroyOnLoad)
      - StoryManager.cs, StartSoundManager.cs (alur cerita & audio awal)
    - MenuScripts/
      - MainMenu.cs (logika menu utama)
    - ScriptForUI/
      - ObjectiveUIScript.cs (UI objektif/progres)
      - OpenUIForDialogAndNote.cs, DialogTypewritterEffect.cs (UI dialog/teks)
    - ScriptableObject/
      - TextChatData.cs, Sound.cs, "Chase Script.cs" (data berbasis ScriptableObject)
  - ExternalPackages/
    - Day-Night Skyboxes/ (aset skybox pihak ketiga)
  - UIAsset/
    - Sprite/ (mis. Crosshair.png)
  - TextMesh Pro/ (resource TMP)
- Packages/
  - manifest.json (daftar paket UPM: URP, TextMesh Pro, Input System, Timeline, UGUI, Visual Scripting, dsb.)
- ProjectSettings/
  - EditorBuildSettings.asset (daftar scene build) & ProjectVersion.txt

## Fitur Singkat
- Perpindahan pemain (CharacterController) dengan Input System.
- Kamera orang pertama/ketiga (tergantung setelan) dengan penguncian kursor.
- Sistem objektif dengan UI progres.
- Interaksi objek (raycast/trigger) dan flashlight on/off.
- Manajemen audio berbasis daftar `Sound` (play/stop, opsi random pitch).
