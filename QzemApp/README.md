# QzemApp

QzemApp is a .NET MAUI multi-platform client app whose purpose is to serve the clients of Qzem by changing dimona contracts on mobile device. The app allows you to view dimona contracts on selected date and manage dimona contracts by changing the start and end time.

## Dependencies

Though QzemApp mobile app relies on the repo eXpresso for it's backend functionalities.

## Architecture

The app architecture consists of two parts:
* A .NET MAUI mobile app for iOS, macOS, Android, and Windows.
* A .NET Framework 4.8 API which is deployed on a server.

### .NET MAUI App

This project contains the following platforms, frameworks, and features:
- [x] .NET MAUI
- [x] XAML
- [x] Behaviors
- [x] Bindings
- [x] Central Styles
- [x] Converter
- [ ] NUnit Tests

### Backend Services

All the backend services-related code and components are maintained as [eXpresso](https://github.com/In-Medio/eXpresso) repo.

## Supported platforms

The app targets three platforms:
* iOS
* macOS
* Android
* Universal Windows Platform (UWP)
  * UWP is supported only in Visual Studio for Windows, not Visual Studio for macOS
  
## Requirements

* Visual Studio 2022 (2022 or higher) to compile C# language features (or Visual Studio MacOS)
* Visual Studio Community Edition is fully supported!
  * .NET MAUI add-ons for Visual Studio (available via the Visual Studio installer)
  
## Setup

### 1. Ensure the .NET MAUI platform is installed

You can do that by following the steps mentioned in Installing .NET MAUI

### 2. Ensure .NET MAUI is updated

Visual Studio will periodically automatically check for updates. You can also manually check for updates using   the Update Visual Studio options.

### 3. Project Setup

Restore NuGet packages for the project.

### 4. Ensure Android Emulator is installed

You can use any Android emulator although it is highly recommended to use an x86-based version.

![image](https://user-images.githubusercontent.com/34289957/210576002-c9928270-c342-4abf-a057-3612ca68fc5e.png)

To deploy and debug the application on a physical device, refer to the [Debug on an Android device](https://learn.microsoft.com/nl-nl/xamarin/android/deploy-test/debugging/debug-on-device?tabs=windows) article.

## Clean and Rebuild

If you see build issues when pulling updates from the repo, try cleaning and rebuilding the solution.

## Licenses

This project uses some third-party assets with a license that requires attribution:
* MVVM Community Toolkit
