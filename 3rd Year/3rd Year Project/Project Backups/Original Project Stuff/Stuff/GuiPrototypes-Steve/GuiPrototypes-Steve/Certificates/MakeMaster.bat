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
    CALL :COLORTEXT 02 "Master Certificate Deployment Script Version 1.0"
    CALL :COLORTEXT 02 "======================================================="
    ECHO.
    GOTO :EOF



:START
    CALL :BANNER
    CALL :COLORTEXT 02 "Every prompt for a password refers to the same password"
    CALL :COLORTEXT 02 "Its the one that you assign to the Certificate"
    ECHO.
    CALL :COLORTEXT 0E "Master Certificate"
    SET /p MASTER=Name (No Blank Spaces): 
    SET /p PASSWD=Password (No Blank Spaces): 
    SET /p STARTS=Valid From (dd/mm/yyyy): 
    SET /p EXPIRES=Valid Until (dd/mm/yyyy): 
    SET /p GO=Are these details correct? [Y/N]: 
    IF /I "%GO%"=="y"   GOTO CREATE_MASTER
    IF /I "%GO%"=="yes" GOTO CREATE_MASTER

:CREATE_MASTER
    CALL :BANNER
    CALL :COLORTEXT 0E "Now You must Install this Certificate"
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

    CALL :COLORTEXT 02 "Screen 3 - SHA1-Cryptographic Hash"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click OK"
    ECHO.

    CALL :COLORTEXT 02 "Screen 4 - Welcome To the Certificate Export Wizard"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 5 - Export Private Key"
    CALL :COLORTEXT 0E "Select - Yes, export the private key"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 6 - Export File Format"
    CALL :COLORTEXT 0E "Leave everything as default"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 7 - Security"
    CALL :COLORTEXT 0E "Check the 'Password' Check Box"
    CALL :COLORTEXT 0E "Password='%PASSWD%'"
    CALL :COLORTEXT 0E "Confirm Password='%PASSWD%'"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 8 - File To Export"
    CALL :COLORTEXT 0E "File Name='%MASTER%'"
    CALL :COLORTEXT 02 "Click Next"
    ECHO.

    CALL :COLORTEXT 02 "Screen 9 - Completing the Certificate Export Wizard"
    CALL :COLORTEXT 02 "Click Finish"
    CALL :COLORTEXT 02 "Click OK"
    CALL :COLORTEXT 02 "Click Yes"
    ECHO.

    makecert -r -n "CN=%MASTER%" -b %STARTS% -e %EXPIRES% -eku 1.3.6.1.5.5.7.3.3 -sv %MASTER%.pvk %MASTER%.cer
    cert2spc %MASTER%.cer %MASTER%.spc
    pvkimprt -pfx %MASTER%.spc %MASTER%.pvk
    certutil.exe -user -f -p %PASSWD% -importPFX %MASTER%.pfx

    CALL :COLORTEXT 0E "Please Double Click on %MASTER%.cer to install the certificate"
    CALL :COLORTEXT 02 "Then Click the 'Install Certificate' button"
    CALL :COLORTEXT 02 "Choose 'Current User' and Click 'Next'"
    CALL :COLORTEXT 0E "Select 'Place all Certificates in the following store'"
    CALL :COLORTEXT 0E "Click 'Browse' and Select 'Trusted Root Certificate Authorities'"
    CALL :COLORTEXT 02 "Click 'OK' and then Click 'Next'"
    CALL :COLORTEXT 02 "Click 'Finish'"
    CALL :COLORTEXT 02 "When asked to Confirm Click 'Yes'"
    ECHO.
    PAUSE

    CALL :BANNER
    CALL :COLORTEXT 02 "Congratulations, you have created your Master Certificate"
    ECHO.
    CALL :COLORTEXT 02 "%MASTER%.cer is a public key and can be freely distributed"
    CALL :COLORTEXT 02 "%MASTER%.pvk and %MASTER%.pfx are private keys"
    CALL :COLORTEXT 0E "DO NOT DISTRIBUTE PRIVATE KEYS FOR ANY REASON"
    CALL :COLORTEXT 02 "You will use %MASTER%.cer and %MASTER%.pfx to sign Certificates"
    CALL :COLORTEXT 02 "Please remember the password"
    ECHO.

:END
    PAUSE
