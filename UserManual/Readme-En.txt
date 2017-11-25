                      =======================================================
                           Easy Macros Version 1.3.1 - By ORelio (c) 2013
                                Website (FR) : http://microzoom.fr/
                      -------------------------------------------------------

===============
 Introduction
---------------

Thanks for choosing Easy Macros! Easy Macros is a free software allowing to easily define
macros for your games and applications, without the need of acquiring sophisticated gaming hardware!
Any keyboard should be compatible ... :-)

How does it work? Easy Macros is based on a scripting system. Each script defines how a macro works.
For instance, you choose a triggering key and define actions to perform.

==========================
 How to use the software
--------------------------

In order to use Easy Macros, just extract the zip archive wherever you want, then launch
EasyMacros.exe: An icon appears in the notification area, on the bottom left of the taskbar.
Right clicking this icon allows exiting the software of accessing its main interface.

Once the main interface of Easy Macro has been opened, you can manage existing macros, edit them
or create a new macro by typing instructions in the text area and clicking on the Save button.
Macros are then saved in the Macros folder so that they can easily be shared with
other users: just add the macro files you received to the Macros folder.

Tip: To launch Easy Macros when Windows starts, create a shortcut to EasyMacros.exe in the
following folder: C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

=======================
 How to build a macro
-----------------------

The skeleton of a macro looks like this:

Macro K Application
Instruction
Instruction
Instruction
...

The first line is the header, the following lines are the instructions: one instruction per line.

=========
 Header
---------

The header is made of 3 settings:
 - Macro type
 - Key triggering the macro
 - Target application for the macro

Supported macro types are the following:
 - Macro : This macro is triggered by the keyboard shortcut made of Activate Key + Macro key
 - SuperMacro : This macro is triggered by the Macro key alone, without Activate Key
 - MouseMacro : This macro is triggered by the combination of Activate Key + Mouse Button
 - SuperMouseMacro : This macro is triggered by a Mouse Button alone, without Activate Key
 - RewriteMacro : This macro is triggered by a custom keyboard shortcut, replacing the normal action
 - WinOpenMacro : This macro is triggered when a window satisfying the provided criteria opens
 - StartupMacro : This macro is triggered when the Easy Macros application is launched
 - IdleMacro : This macro is triggered after the computer was left idle for the specified time

The Macro key can be almost any keyboard key:
 - Currently, special keys such as Ctrl or Alt are not supported for triggering a macro
 - In the case of mouse macros, allowed keys are "Left", "Right", "Middle", "Previous", "Next"
 - In the case of window-open macros, just put X as Mecro key. This is syntactically required but ignored.
 - In the case of Idle macro, the macro key is replaced by the Idle time in seconds: IdleMacro <Time>
 - Idle macros are not triggered if an application is running fullscreen (video...)

Finally, the application targeted by the macro:
 - The macro will trigger only if the active window match the specified criteria
 - The criteria is a keyword that appears in the window title OR the exectuable name such as myapp.exe
 - For instance, if the window is named "VLC Media Player", setting "VLC" as criteria is enough
 - Is it possible to omit the criteria. In that case, the macro will trigger everywhere.
 - Is it possible to get window information with the Window Info tool within Easy Macros

Here are some valid headers:
 - Macro X VLC
 - SuperMacro T explorer.exe
 - MouseMacro Right Firefox
 - SuperMouseMacro Right
 - RewriteMacro LAlt+LWin+Enter
 - WinOpenMacro X notepad.exe
 - IdleMacro 300
 - StartupMacro

===============
 Instructions
---------------

Once the macro has been triggered, instructions are run one by one, from the first line to the last line.
Supported instructions are the following:

 - Key X : Generate a key press on the X key
 - KeyDown X : Generate a key press, without releasing it (Useful with Shift, Alt or Ctrl)
 - KeyUp X : Release a key pressed with a KeyDown instruction

 - Mouse X : Generate a mouse button click: Left, Up, Right, Previous, Next
 - MouseDown X : Generate a mouse button click, without releasing it
 - MouseUp X : Release a button pressed with a MouseDown instruction

 - Sleep n : Wait n milliseconds before proceeding to the next instruction
 - Run myapp.exe argument1 "argument 2" argument 3 etc: Launch a program
 - Close myapp.exe / Close Window Title : Close a window as if the user clicked on the red [X] button
 - Kill myapp.exe : Kills the specified process (beware, data loss may occur since the app can't save anything)

Regarding special keys, not producing a single character when pressed, keywords can be used in the script:

  Scroll, LShift, RShift, Shift, LCtrl, RCtrl, LAlt, RAlt, Alt, Back, Enter, Tab, Pause, Caps, Numlock,
  Escape, Space, End, Home, Left, Up, Right, Down, PrintScreen, Snapshot, Insert, Delete, WinLeft, WinRight

Note that key names preprended with "L" or "R" are for disambiguating keys duplicate keys the keyboard.
For instance, LCtrl stands for the "Ctrl" key located on the left, and RCtrl is for the "Ctrl" key on the right.

An easy way of obtaining key names is by using the scratchpad button from Easy Macros's main interface.
Pressing a key directly shows its name on the scratchpad.

Tip: Mouse, MouseDown and MouseUp instructions can take coordinates as an additional argument.
For instance, "Mouse Left 600,420" will perform a mouse click at 600 (horizontal), 420 (vertical) on the screen.

=================
 Script example
-----------------

SuperMacro X VLC
Key Alt
Sleep 50
Key V
Key A

This triggers a screenshot in VLC Media Player.

==================
 Version history
------------------

Version 1.0
 - Initial Easy Macro release
 - Allows associating macros to keyboard keys
 - Notification area icon, GUI for defining macros
 - Macro types: Macro, SuperMacro, MouseMacro, SuperMouseMacro
 - Instructions: Key, KeyDown, KeyUp, Sleep
 - Full set of keys for use in macros

Version 1.0.1
 - Fix typing issue for ¨ and ^ modifiers on French keyboards: êâôëüï

Version 1.1
 - Improve GUI: More intuitive
 - Improve detection of exe name for active window
 - Message box with hints on first launch or if Easy Macros is already running
 - Add WinOpenMacro: Triggered when a specific window opens
 - Add Run instruction: launch a program
 - Add Kill instruction: kill a process
 - Add Close instruction: close a window
 - GUI: Add button for opening macro folder
 - GUI: Add ability to grab info from an existing window
 - Ability to trigger macros using extra mouse buttons: Middle, Previous, Next
 - Fix character encoding in macro files
 - Update ActivityMonitor DLL, used for capturing user input

Version 1.2
 - Add StartupMacro: Triggered when launching Easy Macros
 - Add IdleMacro: Triggered after mouse & keyboard inactivity for a specified time period
 - Add Mouse, MouseDown, MouseUp instructions: generate mouse events

Version 1.3
 - Ability to trigger macros with almost any keyboard key, including non-letter and OEM keys
 - Ability to trigger macros with a custom keyboard shortcut e.g. key1+key2+key3
 - Add RewriteMacro: Prevents original action from being performed
   example #1: SuperMacro E notepad.exe -> run macro, then write 'e' in notepad
   example #2: RewriteMacro E notepad.exe -> run macro, then ignore/prevent the original 'e' keypress
 - GUI: Enable and disable macros directly from the main interface
 - Add scratchpad to obtain key names directly by pressing them

Version 1.3.1
 - English GUI on non-french Windows environments
 - Reorganize source code and translate comments

=================
 Special thanks
-----------------

Easy Macros has been created using the following resources:
 - UserActivityMonitor (DLL), by George Mamaladze, CodeProject Article no.7294
 - KeyboardEvents (Article), by Naren Neelamegam, CodeProject Article no.7305
 - GNOME Keyboard Shorcut (Icon), by the GNOME team, http://gnome.org/
