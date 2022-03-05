#define Name = "ContactsApp"
#define Version = "1.0.0"       
#define Publisher = "Malyshev Alexei 588-1"
#define URL = "vk.com/mr.fostik"

[Setup]
AppName={#Name}
AppVersion={#Version}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

;//Стандартный путь установки
DefaultDirName={pf}\{#Name}
;//Название группы в ПУСК
DefaultGroupName={#Name}

;//Иконка установщика
SetupIconFile={#SourcePath}\{#Name}.ico
Compression=lzma
SolidCompression=yes     
OutputDir={#SourcePath}
OutputBaseFileName={#Name}

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone

[Icons]
Name: "{commondesktop}\ContactsApp"; Filename: "{app}\\ContactsApp.UI.exe"; IconFilename: {app}\ContactsApp.ico; Tasks: desktopicon quicklaunchicon 

[Files]
Source: "{#SourcePath}\\{#Name}.ico"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs;
Source: "{#SourcePath}\\..\\ContactsApp\ContactsApp.UI\bin\Release\\ContactsApp.UI.exe"  ; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs;
Source: "{#SourcePath}\\..\\ContactsApp\ContactsApp.UI\bin\Release\\*"  ; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; Excludes: contacts.json;

[UninstallDelete]
Type: filesandordirs; Name: {app};