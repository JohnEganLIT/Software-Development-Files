@setlocal enableextensions
@cd /d "%~dp0"

:INIT
    @ECHO OFF
    TITLE a game for youtube 
    SETLOCAL EnableDelayedExpansion
    FOR /F "tokens=1,2 delims=#" %%a IN ('"prompt #$H#$E# & ECHO ON & FOR %%b IN (1) DO rem"') DO (
      SET "DEL=%%a"
    )
    GOTO :START


:COLORTEXT
    ECHO OFF
    <NUL SET /p ".=%DEL%" > "%~2"
    FINDSTR /v /a:%1 /R "^$" "%~2" NUL
    DEL "%~2" > NUL 2>&1
    ECHO.
    GOTO :EOF


:BANNER
    CLS
    CALL :COLORTEXT 02 "======================================================="
    CALL :COLORTEXT 02 "Self Signed Certificate Deployment Script Version 1.0"
    CALL :COLORTEXT 02 "======================================================="
    ECHO.
    GOTO :EOF



:START
    CALL :BANNER
    CALL :COLORTEXT 02 "Every prompt for a password refers to the same password"
    CALL :COLORTEXT 02 "Its the one that you assign to the Certificate"
    ECHO.
    CALL :COLORTEXT 0E "Self Signed Certificate"
REM    SET /p MASTER=Master Certificate File Name (No Extension): 
REM    SET /p PASSWD=Password (No Blank Spaces): 
SET MASTER=master
SET PASSWD=password
    CALL :COLORTEXT 0E "Master Certificate = '%MASTER%'"
    CALL :COLORTEXT 0E "Password = '%PASSWD%'"
    SET /p NAME=Name (No Blank Spaces): 
    SET /p STARTS=Valid From (dd/mm/yyyy): 
    SET /p EXPIRES=Valid Until (dd/mm/yyyy): 
    SET /p GO=Are these details correct? [Y/N]: 
    IF /I "%GO%"=="y"   GOTO CREATE_CLIENT
    IF /I "%GO%"=="yes" GOTO CREATE_CLIENT



:CREATE_CLIENT
    CALL :BANNER
    CALL :COLORTEXT 0E "Creating Certificate"
    CALL :COLORTEXT 0E "All Prompts for Password are asking for '%PASSWD%'"
    ECHO.

    CALL :COLORTEXT 02 "Screen 1 - Subject Key"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 0E "Confirm Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click OK"
    ECHO.

    CALL :COLORTEXT 02 "Screen 2 - Subject Key"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click OK"
    ECHO.

    CALL :COLORTEXT 02 "Screen 3 - Issuer Signiture"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click OK"
    ECHO.

    makecert -ic %MASTER%.cer -iv %MASTER%.pvk -n "CN=%MASTER%" -b %STARTS% -e %EXPIRES% -sv %NAME%.pvk -pe -sky exchange %NAME%.cer
    cert2spc %NAME%.cer %NAME%.spc



:WINDOWS_COMPATIBLE
    CALL :BANNER
    CALL :COLORTEXT 0E "Making Certificate Windows Compatible"
    CALL :COLORTEXT 0E "All Prompts for Password are asking for '%PASSWD%'"
    ECHO.

    CALL :COLORTEXT 02 "Screen 4 - SHA1-Cryptographic Hash"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click OK"
    ECHO.

    CALL :COLORTEXT 02 "Screen 5 - Welcome To the Certificate Export Wizard"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 6 - Export Private Key"
    CALL :COLORTEXT 0E "Select - Yes, export the private key"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 7 - Export File Format"
    CALL :COLORTEXT 0E "Leave everything as default"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 8 - Security"
    CALL :COLORTEXT 0E "Check the 'Password' Check Box"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 0E "Confirm Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 9 - File To Export"
    CALL :COLORTEXT 0E "File Name='%NAME%'"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 10 - Completing the Certificate Export Wizard"
    CALL :COLORTEXT 02 "Click Finish"
    CALL :COLORTEXT 02 "Click OK"
    CALL :COLORTEXT 02 "Click Yes"
    ECHO.

    pvkimprt -pfx %NAME%.spc %NAME%.pvk




:INSTALLING
    CALL :BANNER
    CALL :COLORTEXT 0E "Install Certificate To Windows Store"
    CALL :COLORTEXT 0E "Use all default values when installing a self signed certificate"
    ECHO.
    CALL :COLORTEXT 02 "Then Click the 'Install Certificate' button"
    CALL :COLORTEXT 02 "Choose 'Current User' and Click 'Next'"
    CALL :COLORTEXT 0E "Select 'Automatically select the certificate store based on the type of certificate'"
    CALL :COLORTEXT 02 "Click 'Finish'"
    ECHO.
%NAME%.cer
    PAUSE

    CALL :BANNER
    ECHO.
    CALL :COLORTEXT 0E "Congratulations, you have created a Self Signed Certificate"
    CALL :COLORTEXT 0E "%NAME%.cer is a public key and can be freely distributed"
    CALL :COLORTEXT 0E "%NAME%.pvk and %NAME%.pfx are private keys"
    CALL :COLORTEXT 0E "DO NOT DISTRIBUTE PRIVATE KEYS FOR ANY REASON"
    ECHO.

:END
    PAUSE
