# 🎮 **AR Image Target → Digital Twin Interactive System**

👨‍💻 Pengembang
---------------------------------------------------------------
Nama: Moh Magribi Ramadhan

NIM: F55124104

Kelompok: 4

Program Studi: Informatika – Universitas Tadulako
Tahun: 2025

**Project Base — Tugas Besar AR / VR**
**Kelompok 4**

# 📌 **Overview**

Proyek ini merupakan integrasi antara **Augmented Reality (AR)** berbasis *Vuforia Image Target* dan **Digital Twin Virtual Environment** dalam satu aplikasi.

Pengguna memulai dari mode **AR Scene**, yaitu:

* Pemindaian marker (Image Target)
* Objek 3D (Box, Drum, Conveyor) muncul di atas marker
* User dapat **tap objek** untuk mengaktifkan atau menonaktifkan state
* Tombol **“Ke Digital Twin”** akan muncul untuk berpindah scene

Setelah ditekan, aplikasi berpindah ke **Digital Twin Scene** tempat pengguna dapat:

* Melihat representasi virtual dari objek:

  * Box_DT
  * Drum_DT
  * Conveyor_DT
* State objek (aktif / nonaktif) mengikuti kondisi pada AR
* Visual berubah otomatis (warna hijau saat aktif)

Proyek dikembangkan menggunakan:

* **Unity 6.2 (6000.x)**
* **Vuforia Engine (Image Target)**
* **C# Scripts (AR Interaction, Global State, Digital Twin Visual Sync)**
* **Android Build Support**

---
📁 Struktur Folder Project

Assets/

├── AR/

│   ├── ARScene.unity

│   ├── ImageTarget_Box

│   ├── ImageTarget_Drum

│   ├── ImageTarget_Conveyor

│   ├── Box_AR (Cube)

│   ├── Drum_AR (Cylinder)

│   └── Conveyor_AR (Cube panjang)

│

├── DigitalTwin/

│   ├── DigitalTwinScene.unity

│   ├── Box_DT

│   ├── Drum_DT

│   └── Conveyor_DT

│

├── Scripts/

│   ├── ARSelectableItem.cs

│   ├── ARTapInput.cs

│   ├── ARItemTracker.cs

│   ├── InventoryManager.cs

│   └── DigitalTwinItem.cs

│

└── UI/

    ├── BtnBackToAR
    
    ├── BtnToDigitalTwin
    
    └── Canvas


# 🚀 **Cara Build & Run**

## 1️⃣ Instalasi yang Dibutuhkan

Pastikan perangkat sudah terpasang:

✔ Unity 6000.x
✔ Android Build Support
✔ Vuforia Engine (Project Settings → XR → Vuforia)
✔ TextMeshPro (UI)
✔ URP (opsional)

---

## 2️⃣ Cara Menjalankan Proyek di Unity

## 🅰 **Mode AR (ARScene)**

Buka scene:

```
Assets/AR/ARScene.unity
```

Pastikan:

### ✔ ARCamera

* Di-tag **MainCamera**
* Memiliki:

  * **Vuforia Behaviour**
  * **ARTapInput.cs**
  * **SceneLoader.cs** (untuk navigasi)

### ✔ Image Target

Terdapat 3 target:

1. **ImageTarget_Box**
2. **ImageTarget_Drum**
3. **ImageTarget_Conveyor**

Masing-masing memiliki:

* **Vuforia Image Target Behaviour**
* **ARItemTracker.cs**
* Objek turunan (child):

  * Box_AR → Cube
  * Drum_AR → Cylinder
  * Conveyor_AR → Cube panjang
* Punya Collider + ARSelectableItem script

### ✔ Tombol “Ke Digital Twin”

Menjalankan:

```csharp
SceneLoader.LoadDigitalTwinScene();
```

---

## 🅱 **Mode Digital Twin (DigitalTwinScene)**

Buka scene:

```
Assets/DigitalTwin/DigitalTwinScene.unity
```

Pastikan:

### ✔ Main Camera

* Layer default
* Menggunakan Canvas UI

### ✔ Objek Digital Twin

* Box_DT  → Cube
* Drum_DT → Cylinder
* Conveyor_DT → Cube panjang
* Setiap objek memiliki:

  * Mesh Renderer
  * Collider
  * **DigitalTwinItem.cs** (sinkronisasi state)

### ✔ Tombol “Kembali ke AR”

Menjalankan:

```csharp
SceneLoader.LoadARScene();
```

---

## 🅾 **Build Android**

```
File → Build Settings → Android
```

Add Scenes:

```
0 — ARScene
1 — DigitalTwinScene
```

Lalu:

✔ Build APK
✔ Install ke HP
✔ Scan marker → interaksi AR → pindah ke Digital Twin

---

# 🔄 **Alur AR → Digital Twin**

1. Kamera mendeteksi gambar marker.
2. Vuforia mengaktifkan ImageTarget.
3. Objek 3D muncul (Cube/Cylinder).
4. User mengetuk objek (toggle active/nonactive).
5. **InventoryManager.cs** menyimpan state global.
6. Tekan tombol **Ke Digital Twin**.
7. Digital Twin membaca state:

   * Box aktif → Box_DT hijau
   * Drum pasif → Drum_DT abu
   * Conveyor aktif → Conveyor_DT hijau
8. Tombol “Kembali ke AR” membawa pengguna kembali.

---

# 🎯 **Fitur Utama**

### 🧩 **Image Target AR Tracking**

* 3 marker dengan fungsi berbeda
* Tracking stabil & responsif
* Objek muncul tepat di atas marker

### 👆 **AR Interaction (Tap Select)**

* Input System + Raycast
* Collider detection
* Ubah warna objek saat aktif

### 🏙 **Digital Twin Visual Sync**

* Warna/animasi mengikuti state AR
* Data tidak hilang meski berpindah scene

### 🔁 **Smooth Scene Transition**

* AR → Digital Twin → AR
* Tidak merusak state
* Tidak menghapus InventoryManager (DontDestroyOnLoad)

### 📱 **Android Ready**

* FPS stabil
* Scene loading cepat
* Tracking marker mulus

---

# 📦 **Asset & File Eksternal**

Karena GitHub membatasi ukuran file, maka:

✔ File besar disimpan di Google Drive:

* Aset marker
* Build APK
* Dokumentasi laporan

📥 **Assets Tambahan**
(isi link drive jika ada)

📥 **Build APK**
(isi link drive jika ada)

📥 **Dokumentasi**
(isi link drive jika ada)

📥 **Video Demo**
(isi link drive jika ada)

---

# 🧑‍🤝‍🧑 **Kelompok**

1. Moh Magribi Ramadhan_F55124104
2. Andika_F55124083
3. Andi Fathit Muhammad I.B Samad_F55124097
4. Esar Fauzan_F55124092
5. Ramon Pasungke_F55124115



# 🧪 **Pengujian (Usability + Performance)**

### ✔ **Usability Test**

* Marker mudah terbaca
* Objek AR responsif saat di-tap
* Tombol AR → Digital Twin mudah digunakan
* State objek konsisten setelah perpindahan scene

### ✔ **Performance Test**

* Tracking stabil
* FPS 30–60
* Tidak terjadi crash saat transisi
* Objek Digital Twin update dengan tepat

---

# 🎉 **Project Completed**

Sistem AR → Digital Twin sudah berjalan penuh

* Tracking ✔
* Interaksi ✔
* Global Sync ✔
* Digital Twin ✔
* Transition ✔
