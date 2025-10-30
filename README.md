# Project Pareidolia

Project Pareidolia adalah sebuah project game/prototype yang dibuat untuk salah satu course online Codelamp dalam jangka waktu kurang dari 1 bulan. Repository ini berisi project Unity lengkap sehingga dapat dibuka langsung di Unity Editor.

## Ringkasan / Overview
- Jenis: Unity game prototype (Single scene)
- Bahasa: C# (via Unity)
- Engine: Unity 2022.3.62f1 (LTS)
- Rendering: Universal Render Pipeline (URP)
- Input: Unity Input System
- Manajer Paket: Unity Package Manager (Packages/manifest.json)

## Tech Stack & Dependensi Utama (dari Packages/manifest.json)
- com.unity.render-pipelines.universal: 14.0.12 (URP)
- com.unity.inputsystem: 1.14.2
- com.unity.textmeshpro: 3.0.7
- com.unity.timeline: 1.7.7
- com.unity.ugui: 1.0.0 (UI)
- com.unity.visualscripting: 1.9.4
- com.unity.test-framework: 1.1.33 (framework testing)
- Integrasi IDE: Rider, Visual Studio, VS Code (opsional)
- Unity built-in modules (physics, audio, video, dll.)

Catatan: Semua dependensi dikelola otomatis oleh Unity melalui Unity Package Manager. Saat project dibuka di Unity, paket akan di-resolve sesuai manifest.

## Struktur Proyek (ringkas)
- Assets/
  - Scenes/
    - SampleScene.unity (scene utama saat ini)
  - Scripts/
    - CameraScript.cs (kontrol kamera berbasis Input System; mengunci kursor, rotasi kamera & orientasi badan)
    - MovingCamera.cs (memindahkan transform kamera mengikuti `cameraPosition`)
    - PlayerInputAction.inputactions (aset Input System)
  - Settings/
    - URP-*.asset, UniversalRenderPipelineGlobalSettings.asset (konfigurasi URP)
- Packages/
  - manifest.json (daftar paket UPM)
- ProjectSettings/
  - ProjectVersion.txt (versi editor Unity: 2022.3.62f1)
- README.md (dokumen ini)

## Persyaratan Sistem / Requirements
- OS: Windows 10/11 direkomendasikan (platform lain mungkin bisa, tetapi konfigurasi saat ini berfokus pada Standalone Windows).
- Unity Hub dan Unity Editor: 2022.3.62f1 (LTS) agar kompatibel dengan pengaturan project.
- Ruang penyimpanan: sesuai kebutuhan Unity (aset minimal).
- Git (opsional) untuk cloning repository.

## Menjalankan Proyek (Setup & Run)
1. Clone repository ini.
   - Git: `git clone <URL repo>`
2. Buka Unity Hub, klik "Open" lalu arahkan ke folder proyek ini.
3. Tunggu Unity menyelesaikan impor aset dan resolusi paket UPM.
4. Buka scene: `Assets/Scenes/SampleScene.unity`.
5. Tekan tombol Play di toolbar Unity untuk menjalankan.

### Kontrol (Input)
- Proyek menggunakan Unity Input System. Aset input berada di `Assets/Scripts/PlayerInputAction.inputactions`.
- `CameraScript` membaca nilai `Vector2` dari aksi input (mis. gerakan mouse/analog) untuk memutar kamera dan orientasi karakter.
- Jika aksi belum terhubung di inspector, pastikan `InputActionReference` pada `CameraScript` diarahkan ke aksi yang sesuai di aset input.

## Build
1. Buka menu File > Build Settings.
2. Pastikan `SampleScene` sudah terdaftar di Scenes In Build.
3. Pilih target platform (mis. Windows, Standalone) lalu klik Build.

Saat ini tidak ada skrip build khusus; proses build dilakukan melalui Unity Editor.

## Skrip & Titik Masuk
- Titik masuk runtime dikendalikan oleh Unity melalui scene yang di-load (saat ini `SampleScene.unity`).
- Tidak ada entry point manual (seperti `Main`) di C#; lifecycle mengikuti MonoBehaviour (`Start`, `Update`, dll.).
- Skrip utama:
  - `CameraScript.cs`: mengunci kursor, membaca input, dan memutar kamera serta orientasi badan (`Transform playerBodyOrientation`).
  - `MovingCamera.cs`: memindahkan posisi GameObject ke posisi `cameraPosition` setiap frame.

## Variabel Lingkungan (Env Vars)
- Tidak ada variabel lingkungan khusus yang diperlukan untuk menjalankan proyek ini saat ini.
- Jika kelak ada integrasi layanan eksternal (analytics, backend, dsb.), tambahkan dokumentasi env vars di sini. TODO.

## Testing
- Unity Test Framework sudah terpasang (com.unity.test-framework: 1.1.33).
- Saat ini belum ditemukan berkas tes di repo (EditMode/PlayMode). TODO:
  - Tambahkan folder `Assets/Tests/EditMode` dan/atau `Assets/Tests/PlayMode`.
  - Contoh tes PlayMode untuk memverifikasi perilaku kamera dan input.

## Lisensi
- Lisensi belum ditentukan di repository ini. TODO: tambahkan file LICENSE dan perbarui bagian ini (mis. MIT/Apache-2.0/Proprietary).

## Kredit
- Dibuat sebagai bagian dari course online Codelamp.

## Catatan Pengembangan
- Jika Anda memperbarui versi Unity, perbarui juga `ProjectSettings/ProjectVersion.txt` dan dokumentasi ini.
- Paket UPM dikelola melalui `Packages/manifest.json`. Hindari mengedit `packages-lock.json` secara manual.
- Belum ngapa ngapain
