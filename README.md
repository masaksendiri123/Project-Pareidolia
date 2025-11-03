# Project Pareidolia

Project Pareidolia adalah prototipe game Unity (single scene) yang dibuat untuk course online Codelamp. Repo ini berisi project Unity lengkap dan dapat langsung dibuka di Unity Editor.

## Overview
- Engine: Unity 2022.3.62f1 (LTS, URP)
- Bahasa: C# (MonoBehaviour lifecycle)
- Input: Unity Input System
- Target: Standalone (Windows)

## Struktur Proyek
- Assets/
  - Scenes/
    - SampleScene.unity (scene utama saat ini)
  - Scripts/
    - CameraScript.cs (kontrol kamera, mengunci kursor, rotasi kamera & orientasi badan)
    - MovingCamera.cs (memindahkan transform ke `cameraPosition` setiap frame)
    - CharacterMovement.cs (kontrol gerak karakter via Input System)
    - ObjectRaycastInteraction.cs (raycast untuk interaksi objek)
    - OnOffFlashlightScript.cs (toggle flashlight yang dipegang karakter)
    - PlayerInputAction.inputactions (aset Input System)
  - ExternalPackages/
    - Day-Night Skyboxes (skybox)
  - UIAsset/
    - Sprite/Crosshair.png (crosshair sementara)
- Packages/
  - manifest.json (daftar paket UPM)
- ProjectSettings/
  - ProjectVersion.txt (versi editor Unity: 2022.3.62f1)

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

## Deskripsi Skrip
- `CameraScript.cs`: baca input `Vector2` dari Input System, rotasi kamera dan `playerBodyOrientation`, kunci kursor.
- `MovingCamera.cs`: mengikuti posisi `cameraPosition` setiap frame.
- `CharacterMovement.cs`: logika gerak karakter berbasis Input System.
- `ObjectRaycastInteraction.cs`: raycast untuk interaksi objek di depan pemain.
- `OnOffFlashlightScript.cs`: hidup/matikan senter.

## Titik Masuk
- Ditentukan oleh Unity melalui scene yang diload (saat ini `SampleScene.unity`).
- Tidak ada `Main`; siklus hidup melalui MonoBehaviour (`Start`, `Update`, dll.).
