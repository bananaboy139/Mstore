# Mstore
Windows ONLY

This is a free and highly customizable 'app store' for windows.

BE AWARE: my code is terrible and a mess, WIP

This app stores all it's files in a C:/Mstore folder, the app reads .json files in the pakages folder and allows the user to download and run the exes specified in the json file

### Json Format:
{"Name":"","DownloadURL":"","Description":"","JName":"","exe":"","args":"", "User": "", "Password": ""}

Name: name displayed to user

download URL: http to zip file

Description: description of app shown to the user

JName: unique name the app uses to identify the app

exe: path to exe relative to the zip file

args: possible arguments to use when launching app (optional)

user: the username of the online credential to use when downloading (optional)

password:the password of the online credential to use when downloading (optional)

