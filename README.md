# Rural Planning Game - Smart India Hackathon 2024

## Overview
This is a winning project - a **real-time GIS-based rural planning game**, developed for the **Smart India Hackathon 2024** under **Problem Statement ID – 1704**. The game enables users to plan and develop villages upon **drone land survey maps and GIS data**, making rural infrastructure planning interactive and engaging.

### Team Details:
- **Team Name:** Dead_Lock
- **Theme:** Robotics and Drones
- **Category:** Software
- **Team ID:** 24401

## Features
### 🌍 **Rural Infrastructure Planning**

- **Road Construction:** Players can create roads using snap points for measurable and optimal placement.
- **Building Placement:** Houses, schools, hospitals, and windmills can be strategically positioned.
- **Admin Panel:** Allows government officials to visualize rural development metrics like literacy and healthcare scores.
- **Environmental Considerations:** Proximity of industrial areas to residential zones is analyzed.
- **Water Management:** Players can place wells and handpumps to ensure water accessibility.

### 📊 **Data-Driven Decision Making**
- **Literacy Score:** Percentage of houses connected to schools.
- **Healthcare Score:** Accessibility of hospitals from residential areas.
- **Infrastructure Score:** Evaluates placement efficiency for roads and buildings.
- **Taxation System:** Helps optimize fund allocation for rural development.

### 🎮 **Gameplay Mechanics**
- Touch-based **road creation** using snap-points.
- **Agricultural Land Classification** by marking lands as **residential, industrial, or agricultural**.
- **In-game missions** to educate villagers about government schemes.

## 🛠 Tech Stack
- **Game Engine:** Unity (C#)
- **3D Model Generation:** Three.js
- **GIS Data Handling:** Python (OSMnx, Overpass API)
- **Backend:** Node.js, MongoDB
- **Authentication:** PlayFab
- **Android Development:** Java/Kotlin

## 🔄 Workflow
1. **GIS Data Fetching:** Uses Python GIS libraries to fetch real-world village maps.
2. **Map Conversion:** Converts 2D GIS data into **3D models** using Three.js.
3. **Game Integration:** Integrates **3D village models** into Unity.
4. **User Interaction:** Players interact via a touch-based UI.
5. **Admin Analytics Panel:** Government officials analyze collected data.
6. **Future Expansion:** More **rural development aspects** will be added.

## 💡 Challenges Tackled
- **Real-Time Map to 3D Conversion:** Solved using OSMnx, cloud storage, and Three.js.
- **GIS Fencing Implementation:** Used Python GIS libraries to **extract precise village boundaries**.
- **Rural Development Scoring System:** Designed to **help policymakers optimize village planning**.

## 🚀 Future Scope
- **Farming Simulations:** Ploughing, sowing, irrigation, and harvesting in-game tasks.
- **Localized Multi-Language Support:** To make the game accessible to rural communities.
- **Expanded Infrastructure Elements:** Includes **renewable energy projects, smart irrigation, and advanced analytics**.

## 📌 Installation & Setup
1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-repo-name.git
   ```
2. **Open in Unity:**
   - Install **Unity (Latest Version)**
   - Open the project directory in Unity
3. **Backend Setup:**
   - Install Node.js
   - Run MongoDB Server
   - Start backend services:
     ```bash
     cd backend
     npm install
     npm start
     ```
4. **Build & Run:**
   - Compile the project and deploy it on Android.

## 🤝 Contributors
| Name | Role |
|------|------|
| Vikash Kumar | Game Development, Road Construction System |
| Mrinal Kumar | UI/UX Design |
| Arnav Raj | Backend Development, Admin Panel |
| Sourya Dey | Web Authentication |
| Aryan Sidhant | Web & Authentication System |
| Isha Mandal | Android Development |

## 📜 License
This project is licensed under **MIT License**.

## 📞 Contact
For queries, reach out at: **your-email@example.com**

---
### 🎯 *Empowering Rural Development through Gamification!*


