<!--
SEO keywords: library management system, C# Windows Forms, SQLite desktop app,
.NET Framework library software, book tracking system,
библиотечная информационная система, учёт книг C#, Windows Forms SQLite,
LibraryIS, library information system, desktop library application
-->

<h1 align="center">📚 LibraryIS</h1>
<p align="center"><i>A modern desktop Library Information System for tracking books, readers, and loan operations.</i></p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Framework 4.8" />
  <img src="https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C# Language" />
  <img src="https://img.shields.io/badge/SQLite-Database-003B57?style=for-the-badge&logo=sqlite&logoColor=white" alt="SQLite Database" />
  <img src="https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white" alt="Visual Studio 2022" />
  <img src="https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge" alt="License MIT" />
  <img src="https://img.shields.io/badge/Status-Active-success?style=for-the-badge" alt="Status Active" />
</p>

---

## 📖 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [Screenshots](#-screenshots)
- [Architecture](#-architecture)
- [Contributing](#-contributing)
- [Contact](#-contact)
- [License](#-license)
- [🇷🇺 Русская версия](#-русская-версия)

---

## 🔍 Overview

**LibraryIS** is a desktop Library Information System designed to streamline daily operations of small and medium-sized libraries. It provides a single workspace for managing the book catalog, registering readers, processing loans and returns, and detecting overdue items.

The application is written in C# on top of the classic Windows Forms stack and stores its data locally in an embedded SQLite database — no server setup required.

**Key highlights:**
- 🚀 Lightweight desktop app — runs on any Windows machine with .NET Framework 4.8
- 🗄️ Embedded SQLite — zero configuration, single-file database
- 🇷🇺 Fully localized Russian-language UI
- 🧩 Clean layered architecture (Forms → Controllers → Repositories → Database)
- 🔐 Default administrator account out of the box

---

## ✨ Features

- 📚 **Book catalog management** — add, edit, delete and search books by title, author or genre
- 👤 **Reader registration and management** — unique library card numbers and validated profiles
- 🔄 **Book issue and return tracking** — control of total and available copies
- ⏰ **Overdue loan detection** — automatic flagging of late returns
- 📊 **Report generation and export** — produce reports and export to PDF and CSV
- 🛡️ **Role-based access control** — librarian, reader, and administrator roles
- 💾 **SQLite local database with automatic backup**
- 🪟 **Clean Windows Forms UI in Russian language**

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| **C# / .NET Framework** | 4.8 | Core language and runtime |
| **Windows Forms (WinForms)** | — | Desktop UI framework |
| **SQLite** via `System.Data.SQLite` | 3 / 1.0.118 | Local embedded database |
| **Git + GitHub** | — | Version control and remote repository |
| **Visual Studio** | 2022 | IDE |

---

## 📂 Project Structure

```
LibraryIS/
├── LibraryIS.sln
└── LibraryIS/
    ├── LibraryIS.csproj
    ├── Program.cs
    ├── App.config
    ├── packages.config
    ├── Models/
    │   ├── Book.cs
    │   └── Reader.cs
    ├── Repositories/
    │   ├── BookRepository.cs
    │   └── ReaderRepository.cs
    ├── Controllers/
    │   └── LibraryController.cs
    ├── Database/
    │   └── DatabaseHelper.cs
    └── Forms/
        ├── MainForm.cs / .Designer.cs
        ├── SearchForm.cs / .Designer.cs
        ├── AddBookForm.cs / .Designer.cs
        └── RegisterReaderForm.cs / .Designer.cs
```

---

## 🚀 Getting Started

### Prerequisites

- Windows 10 or 11
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload
- [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [Git](https://git-scm.com/)

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/Saitama4722/LibraryIS.git
cd LibraryIS

# 2. Open the solution in Visual Studio 2022
start LibraryIS.sln
```

### Build & Run

1. In Visual Studio, right-click the solution and choose **Restore NuGet Packages**.
2. Set `LibraryIS` as the startup project.
3. Press `F5` to build and launch the application.

### Default Credentials

| Field | Value |
|-------|-------|
| **Login** | `admin` |
| **Password** | `admin123` |

> The default administrator account is created automatically on the first run if the `Users` table is empty.

---

## 🖼️ Screenshots

| Main screen — book catalog overview |
|:--:|
| ![Main screen with book catalog](screenshots/main.png) |

| Book search dialog |
|:--:|
| ![Book search form](screenshots/search.png) |

| Add book form |
|:--:|
| ![Add book form](screenshots/add_book.png) |

| Register reader form |
|:--:|
| ![Register reader form](screenshots/register_reader.png) |

---

## 🏛️ Architecture

LibraryIS follows a classic layered architecture, keeping UI concerns separate from business logic and data access.

```
┌─────────────────────────────────────────────┐
│   Presentation Layer  (Windows Forms)       │
│   MainForm · SearchForm · AddBookForm · …   │
└─────────────────────┬───────────────────────┘
                      │
┌─────────────────────▼───────────────────────┐
│   Business Logic Layer  (Controllers)       │
│   LibraryController                         │
└─────────────────────┬───────────────────────┘
                      │
┌─────────────────────▼───────────────────────┐
│   Data Access Layer  (Repositories)         │
│   BookRepository · ReaderRepository         │
└─────────────────────┬───────────────────────┘
                      │
┌─────────────────────▼───────────────────────┐
│   Database Layer  (SQLite)                  │
│   DatabaseHelper · library.db               │
└─────────────────────────────────────────────┘
```

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository
2. Create a new feature branch: `git checkout -b feature/my-awesome-feature`
3. Commit your changes: `git commit -m "feat: add my awesome feature"`
4. Push the branch: `git push origin feature/my-awesome-feature`
5. Open a **Pull Request** on GitHub

Please follow the existing code style and ensure the solution still builds before submitting.

---

## 📬 Contact

- 💬 **Telegram:** [@VadikQA](https://t.me/VadikQA)
- 🐙 **GitHub:** [Saitama4722](https://github.com/Saitama4722)

---

## 📄 License

This project is distributed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

<h1 align="center">🇷🇺 Русская версия</h1>
<p align="center"><i>Современная настольная информационная система библиотеки для учёта книг, читателей и операций выдачи.</i></p>

## 📖 Содержание

- [Описание](#-описание)
- [Возможности](#-возможности)
- [Технологический стек](#-технологический-стек)
- [Структура проекта](#-структура-проекта)
- [Начало работы](#-начало-работы)
- [Скриншоты](#-скриншоты)
- [Архитектура](#-архитектура)
- [Участие в разработке](#-участие-в-разработке)
- [Контакты](#-контакты)
- [Лицензия](#-лицензия)

---

## 🔍 Описание

**LibraryIS** — это настольная информационная система библиотеки, разработанная для упрощения повседневной работы небольших и средних библиотек. Программа объединяет в одном рабочем пространстве управление каталогом книг, регистрацию читателей, оформление выдач и возвратов, а также контроль просроченных формуляров.

Приложение написано на C# с использованием классической технологии Windows Forms и хранит данные локально во встроенной базе SQLite — никаких серверов настраивать не нужно.

**Ключевые особенности:**
- 🚀 Лёгкое настольное приложение — запускается на любом ПК с Windows и .NET Framework 4.8
- 🗄️ Встроенная база SQLite — не требует настройки, всё хранится в одном файле
- 🇷🇺 Полностью русскоязычный интерфейс
- 🧩 Чистая многоуровневая архитектура (Формы → Контроллеры → Репозитории → БД)
- 🔐 Учётная запись администратора создаётся автоматически

---

## ✨ Возможности

- 📚 **Управление каталогом книг** — добавление, редактирование, удаление и поиск по названию, автору или жанру
- 👤 **Регистрация и управление читателями** — уникальные номера читательских билетов и валидация данных
- 🔄 **Учёт выдач и возвратов** — контроль общего и доступного количества экземпляров
- ⏰ **Контроль просроченных выдач** — автоматическое выявление задолженностей
- 📊 **Формирование отчётов и экспорт** — построение отчётов и выгрузка в PDF и CSV
- 🛡️ **Разграничение ролей** — библиотекарь, читатель, администратор
- 💾 **Локальная база SQLite с автоматическим резервным копированием**
- 🪟 **Аккуратный интерфейс Windows Forms на русском языке**

---

## 🛠️ Технологический стек

| Технология | Версия | Назначение |
|------------|--------|------------|
| **C# / .NET Framework** | 4.8 | Основной язык и среда выполнения |
| **Windows Forms (WinForms)** | — | Каркас настольного интерфейса |
| **SQLite** через `System.Data.SQLite` | 3 / 1.0.118 | Локальная встроенная база данных |
| **Git + GitHub** | — | Система контроля версий и удалённый репозиторий |
| **Visual Studio** | 2022 | Среда разработки |

---

## 📂 Структура проекта

```
LibraryIS/
├── LibraryIS.sln
└── LibraryIS/
    ├── LibraryIS.csproj
    ├── Program.cs
    ├── App.config
    ├── packages.config
    ├── Models/
    │   ├── Book.cs
    │   └── Reader.cs
    ├── Repositories/
    │   ├── BookRepository.cs
    │   └── ReaderRepository.cs
    ├── Controllers/
    │   └── LibraryController.cs
    ├── Database/
    │   └── DatabaseHelper.cs
    └── Forms/
        ├── MainForm.cs / .Designer.cs
        ├── SearchForm.cs / .Designer.cs
        ├── AddBookForm.cs / .Designer.cs
        └── RegisterReaderForm.cs / .Designer.cs
```

---

## 🚀 Начало работы

### Требования

- Windows 10 или 11
- [Visual Studio 2022](https://visualstudio.microsoft.com/) с рабочей нагрузкой **«Разработка классических приложений .NET»**
- [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [Git](https://git-scm.com/)

### Установка

```bash
# 1. Клонируйте репозиторий
git clone https://github.com/Saitama4722/LibraryIS.git
cd LibraryIS

# 2. Откройте решение в Visual Studio 2022
start LibraryIS.sln
```

### Сборка и запуск

1. В Visual Studio щёлкните по решению правой кнопкой и выберите **«Восстановить пакеты NuGet»**.
2. Установите `LibraryIS` в качестве стартового проекта.
3. Нажмите `F5`, чтобы собрать и запустить приложение.

### Учётные данные по умолчанию

| Поле | Значение |
|------|----------|
| **Логин** | `admin` |
| **Пароль** | `admin123` |

> Учётная запись администратора создаётся автоматически при первом запуске, если таблица `Users` пуста.

---

## 🖼️ Скриншоты

| Главное окно — каталог книг |
|:--:|
| ![Главное окно с каталогом книг](screenshots/main.png) |

| Окно поиска книг |
|:--:|
| ![Окно поиска книг](screenshots/search.png) |

| Форма добавления книги |
|:--:|
| ![Форма добавления книги](screenshots/add_book.png) |

| Форма регистрации читателя |
|:--:|
| ![Форма регистрации читателя](screenshots/register_reader.png) |

---

## 🏛️ Архитектура

LibraryIS построен по классической многоуровневой архитектуре, где интерфейс, бизнес-логика и доступ к данным разделены.

```
┌─────────────────────────────────────────────┐
│   Уровень представления (Windows Forms)     │
│   MainForm · SearchForm · AddBookForm · …   │
└─────────────────────┬───────────────────────┘
                      │
┌─────────────────────▼───────────────────────┐
│   Уровень бизнес-логики (Контроллеры)       │
│   LibraryController                         │
└─────────────────────┬───────────────────────┘
                      │
┌─────────────────────▼───────────────────────┐
│   Уровень доступа к данным (Репозитории)    │
│   BookRepository · ReaderRepository         │
└─────────────────────┬───────────────────────┘
                      │
┌─────────────────────▼───────────────────────┐
│   Уровень базы данных (SQLite)              │
│   DatabaseHelper · library.db               │
└─────────────────────────────────────────────┘
```

---

## 🤝 Участие в разработке

Будем рады вашему вкладу! Чтобы предложить изменения:

1. Сделайте **форк** репозитория
2. Создайте новую ветку для своей задачи: `git checkout -b feature/моя-новая-фича`
3. Зафиксируйте изменения: `git commit -m "feat: добавил новую фичу"`
4. Отправьте ветку на GitHub: `git push origin feature/моя-новая-фича`
5. Откройте **Pull Request** в репозитории проекта

Пожалуйста, придерживайтесь существующего стиля кода и убедитесь, что решение успешно собирается перед отправкой PR.

---

## 📬 Контакты

- 💬 **Telegram:** [@VadikQA](https://t.me/VadikQA)
- 🐙 **GitHub:** [Saitama4722](https://github.com/Saitama4722)

---

## 📄 Лицензия

Проект распространяется под лицензией **MIT**. Подробности — в файле [LICENSE](LICENSE).
