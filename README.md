# Mstore
Windows ONLY
One of my side project hobbies

This is a free and highly custumizable 'app store' for windows.

BE AWARE: my code is terrible and a mess, WIP

This app stores all it's files in a C:/Mstore folder, the app reads .json files in the pakages folder and allows the user to download and run the exes specified in the json file

### Json Format:
{"Name":"","DownloadURL":"","Description":"","JName":"","exe":"","args":null,"IsInstalled":false}

Name: name displayed to user

download URL: http to zip file

Description: description of app shown to the user

JName: what the computer calls the app, NO SPACES

exe: path to exe relative to the zip file

args: possible arguments to use when launching app (useless for most apps)

IsInstalled: false, when you download via the app, i will set it to true



## LEGAL
You can use this app freely, it will always be free.

You can change the source code as much as you wish.

You can distribute a changed version of this app, paid or not BUT you must refrence this github page.

You do not need to show me/give me your changes (but I hope that you do, so that this can grow).
