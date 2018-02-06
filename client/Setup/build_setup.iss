; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！
#define FileDir "..\Pandora\bin\Release"
; #define OutFileDir ".\"
#define OutFileWebDir "..\..\server\src\main\resources\static\software"
#define MyAppVersion "0.1.5"
#define OutFileName "PandoraBox"
#define MyAppName "PandoraBox"
#define MyAppDir "PandoraBox"
#define MyAppPublisher "PandoraBox"
#define MyAppExeName "PandoraBox.exe"


[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (生成新的GUID，点击 工具|在IDE中生成GUID。)
AppId={{19DFB321-204B-4415-B0C4-1929617CB895}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppDir}
DefaultGroupName={#MyAppName}
; OutputDir={#OutFileDir}
OutputDir={#OutFileWebDir}
OutputBaseFilename={#OutFileName}
SetupIconFile=..\Pandora\resources\icon.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone;

[Files]
Source: "{#FileDir}\MaterialSkin.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#FileDir}\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#FileDir}\PandoraBox.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#FileDir}\PandoraBox.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#FileDir}\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#FileDir}\file\Pandora.sqlite"; DestDir: "{app}\file"; Flags: ignoreversion
Source: "{#FileDir}\file\pandoraCache.txt"; DestDir: "{app}\file"; Flags: ignoreversion
Source: "{#FileDir}\x64\SQLite.Interop.dll"; DestDir: "{app}\x64"; Flags: ignoreversion
Source: "{#FileDir}\x86\SQLite.Interop.dll"; DestDir: "{app}\x86"; Flags: ignoreversion
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Dirs]
Name: {app}\file
Name: {app}\x86
Name: {app}\x64

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
;[Run]
;Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

