# Project Pareidolia

Project Pareidolia adalah prototipe game Unity (single scene) yang dibuat untuk course online Codelamp. Repo ini berisi project Unity lengkap dan dapat langsung dibuka di Unity Editor.

## Overview
- Engine: Unity 2022.3.62f1 (LTS, URP)
- Bahasa: C# (MonoBehaviour lifecycle)
- Input: Unity Input System
- Target: Standalone (Windows)

## Persyaratan Sistem
- Windows 10/11 (disarankan)
- Unity Hub + Unity Editor 2022.3.62f1 (LTS)
- Ruang penyimpanan sesuai kebutuhan aset Unity

## Setup & Run
1. Clone repo: `git clone <URL repo>`
2. Buka Unity Hub → Open → arahkan ke folder proyek ini
3. Tunggu impor aset dan resolusi paket selesai
4. Buka scene: `Assets/Scenes/SampleScene.unity`
5. Tekan Play di Unity Editor

## Build
1. File → Build Settings
2. Pastikan `SampleScene` ada di "Scenes In Build"
3. Pilih target platform (mis. Windows Standalone) → Build

## Struktur Proyek
- Assets/
  - Scenes/
    - SampleScene.unity (scene utama saat ini)
  - Scripts/
    - CharacterMovement/
      - CharacterMovement.cs (kontrol gerak karakter via Input System)
      - CameraScript.cs (kontrol kamera, kunci kursor, rotasi kamera & orientasi badan)
      - MovementStatusHandler.cs (mengelola status gerak: jalan/lari/diam)
      - MoveCameraToCharacter.cs (memindahkan kamera ke target `cameraPosition` tiap frame)
    - ScriptForUI/
      - OpenUIForDialogAndNote.cs (buka UI untuk dialog & catatan)
      - DialogTypewritterEffect.cs (efek pengetikan teks dialog)
    - ScriptableObject/
      - TextChatData.cs (data dialog/teks berbasis ScriptableObject)
    - ObjectRaycastInteraction.cs (raycast untuk interaksi objek)
    - OnOffFlashlightScript.cs (toggle flashlight yang dipegang karakter)
    - AudioManager.cs (pengelola pemutaran audio)
    - Sound.cs (definisi klip/saluran suara)
  - ExternalPackages/
    - Day-Night Skyboxes/ (skybox)
  - UIAsset/
    - Sprite/
      - Crosshair.png (crosshair sementara)
  - TextMesh Pro/ (font, shader, resources TMP)
- Packages/
  - manifest.json (daftar paket UPM)
- ProjectSettings/
  - ProjectVersion.txt (versi editor Unity: 2022.3.62f1)
