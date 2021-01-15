; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Sistema igreja"
#define MyAppVersion "1.0"
#define MyAppPublisher "My Company, Inc."
#define MyAppURL "https://www.example.com/"
#define MyAppExeName "WindowsFormsApp1.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{663C4C2F-9FDE-4CCC-A6CB-A2DB896278C7}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\compiladores
OutputBaseFilename=igreja
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\BouncyCastle.Crypto.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\business.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\business.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\business.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\Database.mdf"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\Database_log.ldf"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\EntityFramework.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\itextsharp.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\leand\Documents\codigo-github\projeto-igreja-30-12-2020\igreja_dll\WindowsFormsApp1\bin\Debug\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

