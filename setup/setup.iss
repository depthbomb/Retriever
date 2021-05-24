#include "buttons.iss"

#define MyAppName "Retriever"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "Caprine Logic"
#define MyAppURL "https://github.com/depthbomb/Retriever"
#define MyAppExeName "Retriever.GUI.exe"

[Setup]
AppId={{E44732E1-6C84-4849-8B4C-714A39CA4B3A}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
; AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL=https://github.com/depthbomb/Scraps/releases
AppCopyright=Copyright (C) 2021 Caprine Logic
DefaultDirName={autopf}\Caprine Logic\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
LicenseFile=.\License.rtf
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=commandline
OutputDir=.\
OutputBaseFilename=retriever_setup
SetupIconFile=..\retriever.ico
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=classic
ArchitecturesAllowed=x64

[Types]
Name: "full"; Description: "Full installation"
Name: "compact"; Description: "Compact installation"
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Components]
Name: "gui"; Description: "GUI Application"; Types: full compact custom; Flags: fixed
Name: "cli"; Description: "CLI application"; Types: full

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "..\Retriever\bin\Publish\win10-x64\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion; Components: gui
Source: "..\Retriever.CLI\bin\Publish\win10-x64\retriever.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: cli
Source: ".\license.txt"; DestDir: "{app}"; Flags: ignoreversion

[INI]
Filename: "{app}\Changelog.url"; Section: "InternetShortcut"; Key: "URL"; String: "http://bit.ly/rtvr-changelog"
Filename: "{app}\Source Code.url"; Section: "InternetShortcut"; Key: "URL"; String: "http://bit.ly/rtvr-repo"

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: files; Name: "{app}\Changelog.url"
Type: files; Name: "{app}\Source Code.url"
Type: dirifempty; Name: "{app}"
