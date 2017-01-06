REM Adapted from: https://magenic.com/thinking/using-opencover-and-reportgenerator-to-get-unit-testing-code-coverage-metrics-in-net

ECHO OFF
CLS

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
 
REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0Roadmapp.trx" del "%~dp0Roadmapp.trx%"
 
REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"
 
REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
 
REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)
 
REM Launch the report
if %errorlevel% equ 0 (
 call :RunLaunchReport
)
exit /b %errorlevel%
 
:RunOpenCoverUnitTestMetrics
"%~dp0..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%~dp0..\packages\NUnit.ConsoleRunner.3.5.0\tools\nunit3-console.exe" ^
-targetargs:"\"%~dp0..\Roadmap_NTest\bin\Debug\Roadmapp_NTest.dll\"" ^
-filter:"+[*]* -[Roadmapp_NTest]* -[*]Roadmapp.RouteConfig" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\Roadmapp.xml"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.2.5.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\Roadmapp.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%