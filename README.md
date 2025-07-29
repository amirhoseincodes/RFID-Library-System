# 📘 RFID Library Management System

This project was developed as the **final project for the Digital Systems Design (DSD)** course. It implements a library management system using RFID technology, enabling real-time book scanning, loan tracking, and book data editing through a clean graphical interface.


---

## 🔗 Original Version

The initial version of this project, called **Library Book Registration System**, was Published on the **Bozorgmehr Qaenat University **. You can find the original repository at:  
[https://git.buqaen.ac.ir/library/gate](https://git.buqaen.ac.ir/library/gate)

---

## 👤 Original Author

The system was originally developed by **Hassan Zaaferani**  on November 5, 2022. For more details, visit their GitLab repository linked above.

---

## 📦 Features

- 🔍 **Real-Time RFID Tag Detection**  
    Supports scanning multiple RFID tags simultaneously using up to two antenna readers.
    
- 📋 **Book Information Retrieval**  
    Automatically fetches book metadata (title, author, publication date, etc.) by scanned RFID tag.
    
- 🔁 **Loan Management**  
    Marks books as loaned or returned through a configurable interface.
    
- 🧾 **Live List View**  
    Displays a real-time log of scanned books including loan status and timestamps.
    
- 📝 **Manual Edit Mode**  
    Allows manual editing of book information or loan status via dedicated forms.
    
- ⚙️ **JSON-Based Configuration**  
    Reads and writes application settings (e.g., beep sounds, reader modes) via a local `config.json` file.
    
- 🔊 **Beep & Alarm Integration**  
    Plays custom beep or alarm sounds on tag recognition or invalid scans.
    

---

## 🛠️ Technologies Used

- C# (.NET Framework)
    
- Windows Forms
    
- ADO.NET (for database interaction)
    
- SQL Server (local or network)
    
- MR6100 RFID API
    
- SoundPlayer for audio playback
    

---

## 🧱 New Project Structure

```
MR6100Demo-gate/
│
├── Assets/Audio
|         ├── alarm.wav
|         ├── beep1.wav
|         ├── beep2.wav
|         ├── beep3.wav
|         ├── beep4.wav
|
├── Core/
│   ├── AppMode.cs
│   ├── BookInfo.cs
│   ├── ConfigManager.cs
│   ├── Document.cs
│   ├── Tools.cs
│
├── classes/
│   └── Document.cs
│
├── Forms/
│   ├── mainForm.cs
|   ├── KioskForm.cs
|   ├── InventoryForm.cs
|
├── log/
│   └── [فایل‌های صوتی]
│
├── Program.cs
├── Tools.cs
├── AssemblyInfo.cs
├── app.config
├── packages.config
|
├── config.json
|
├── Libs:
│   ├── MR6100Api.dll
│   ├── Newtonsoft.Json.dll
│   ├── RestSharp.dll
├── ListViewNF.cs
 
```

---

## ⚙️ Database Schema (Simplified)

**Table: Books**

| Field     | Type     | Description                             |
| --------- | -------- | --------------------------------------- |
| RFID      | NVARCHAR | Unique RFID tag ID                      |
| Title     | NVARCHAR | Book title                              |
| Header    | NVARCHAR | Author name                             |
| DateOfPub | NVARCHAR | Publication date                        |
| RecordNo  | INT      | Registry number                         |
| BookTID   | NVARCHAR | Internal book ID                        |
| LOAN      | BIT      | Loan status (0 = available, 1 = loaned) |

---

## 📸 Screenshots
tag detection, book info editing, reader setting and RFID scan logs.

> ![[Screenshot 2025-07-29 104229.png]]_Add screenshots here showing t![[multiFormExample.png]]_
![[Appearance2.png]]
---

## 🚀 How to Run

1. Clone the repository:
    
    ```bash
    git clone https://github.com/yourusername/RFID-Library-System.git
    ```
    
2. Open the `.sln` file in Visual Studio.
    
3. Ensure the `LibraryDB` database is created with the `Books` table.
    
4. Modify the connection string in `BookInfo.cs`:
    
    ```csharp
    string connectionString = "Data Source=.;Initial Catalog=LibraryDB;Integrated Security=true";
    ```
    
5. Build and run the solution.
    

---

## 📥 Dependencies

- MR6100 RFID Reader SDK/API  
    _(Include official DLL from hardware vendor)_
    

---

## 📌 Notes

- Tested on Windows with local SQL Server only.
    
- Only MR6100 readers currently supported.
    
- Dual-reader support is optional; works with a single reader as well.
