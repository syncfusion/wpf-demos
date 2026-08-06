@echo off
echo Starting copy all demos to UISuite_SB...

:: Remove Directory that are not needed in UISuite
echo Removing Directory from UISuite...
if exist "diagram" rmdir "diagram" /s /q
if exist "gantt" rmdir "gantt" /s /q
if exist "scheduler" rmdir "scheduler" /s /q
if exist "kanban" rmdir "kanban" /s /q
if exist "samplebrowser" rmdir "samplebrowser" /s /q
if exist "showcase\bpmn editor" rmdir "showcase\bpmn editor" /s /q
if exist "showcase\brainstorming diagram" rmdir "showcase\brainstorming diagram" /s /q
if exist "showcase\diagram builder" rmdir "showcase\diagram builder" /s /q
if exist "showcase\floor planner" rmdir "showcase\floor planner" /s /q
if exist "showcase\logical circuit designer" rmdir "showcase\logical circuit designer" /s /q
if exist "showcase\network diagram" rmdir "showcase\network diagram" /s /q
if exist "showcase\organizational layout" rmdir "showcase\organizational layout" /s /q
if exist "showcase\workflow editor" rmdir "showcase\workflow editor" /s /q


echo Renaming folder...
ren "UIKeySampleBrowser" "samplebrowser"


@echo off
setlocal
echo Process completed successfully!