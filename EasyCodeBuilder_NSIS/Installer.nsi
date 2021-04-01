# Modern UI
!include MUI2.nsh
# nsDialogs
!include nsDialogs.nsh
# LogicLib
!include LogicLib.nsh
!define VERSION "1.1.5.2a"
Name "EasyCodeBuilder ${VERSION}"
OutFile "Setup_EasyCodeBuilder_${VERSION}.exe"
InstallDir "$PROGRAMFILES\EasyCodeBuilder"
SetCompressor lzma
RequestExecutionLevel admin

XPStyle on 
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "..\LICENSE"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
# UnInst
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH
# JPUI
!insertmacro MUI_LANGUAGE "Japanese"
# IFCE
!define MUI_ABORTWARNING

Section 
    SetOutPath "$INSTDIR"
    File "..\EasyCodeBuilder\bin\Release\EasyCodeBuilder.exe"
    File "..\EasyCodeBuilder\bin\Release\EasyCodeBuilder.exe.config"
    File "..\LICENSE"
    WriteUninstaller "$INSTDIR\Uninstall.exe"
    CreateDirectory "$SMPROGRAMS\EasyCodeBuilder"
    SetOutPath "$INSTDIR"
    CreateShortcut "$SMPROGRAMS\EasyCodeBuilder\EasyCodeBuilder.lnk" "$INSTDIR\EasyCodeBuilder.exe" ""
    CreateShortcut "$SMPROGRAMS\EasyCodeBuilder\Uninstall.lnk" "$INSTDIR\Uninstall.exe" ""
  
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EasyCodeBuilder" "DisplayName" "EasyCodeBuilder ${VERSION}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EasyCodeBuilder" "DisplayVersion" "${VERSION}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EasyCodeBuilder" "Publisher" "binary number"

    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EasyCodeBuilder" "UninstallString" '"$INSTDIR\Uninstall.exe"'
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EasyCodeBuilder" "DisplayIcon" '"$INSTDIR\EasyCodeBuilder.exe"'
SectionEnd
Section "Uninstall"
    Delete "$INSTDIR\Uninstall.exe"
    Delete "$INSTDIR\EasyCodeBuilder.exe"
    Delete "$INSTDIR\EasyCodeBuilder.exe.config"
    Delete "$INSTDIR\LICENSE"
    Delete "$SMPROGRAMS\EasyCodeBuilder\EasyCodeBuilder.lnk"
    Delete "$SMPROGRAMS\EasyCodeBuilder\Uninstall.lnk"
    RMDir "$SMPROGRAMS\EasyCodeBuilder"
    RMDir "$INSTDIR"
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EasyCodeBuilder"
SectionEnd