# c4fjumplist
C4F - Windows 7 - JumpList Sample

Forked from CodePlex: https://archive.codeplex.com/?p=c4fjumplist
https://channel9.msdn.com/coding4fun/articles/Windows-7-Jump-Lists
https://web.archive.org/web/20110902142529/https://channel9.msdn.com/coding4fun/articles/Windows-7-Jump-Lists

In this article/sample, learn how to provide quick access to links and actions in your Windows 7 application by creating a JumpList. (MSDN Coding 4 Fun)

## Project Description
In this article/sample, learn how to provide quick access to links and actions in your Windows 7 application by creating a JumpList. (MSDN Coding 4 Fun)

## Introduction
Windows 7 includes a wealth of new features for developers to take advantage of. This includes better rendering subsystems, new sensor and location API’s, file libraries, federated search, and of course, the improved Taskbar. My last article discussed the Taskbar’s ability to show custom previews and toolbar icons. This article focuses on Jumplists – the replacement for notification area context menus.

If you haven’t done so yet, download Visual Studio 2008 Express Edition or higher (C# or VB). Even better, Visual Studio 2010 Beta 2 is now available and it’s well worth the download. All Express editions are free, and either 2008 or 2010 versions will work fine with this article’s accompanying code.

## What’s a JumpList?
JumpLists are a new concept in Windows 7 that allow developers to provide shortcuts to users right from their icon’s context menu in the taskbar or Start menu. This could be a simple link to a documents folder or library for a given application, or a link back to the same application with a parameter passed to cause something to happen. This is used in Live Messenger to change online status, display the new message window, or open web pages relating to the application. In the end, all of these are shortcuts. Shortcuts to URL’s, or shortcuts back to the executable with an argument that causes some change to occur.
