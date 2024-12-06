
# Unity Comment Component

Like leaving small notes in the comments of your code, this Unity component lets you leave messages on game objects. Perfect for letting your teammates and your future self know that the game stops working if they delete that mysterious cube under the second level.

![Capture Gif](./GithubResources/CapturaGif.gif)


### How to use it

* Add the content of the `Code` folder to your project.
-  Select the game object that you want to add a comment to and go `Add Component` → `Comment`.
- Write the comment, choose the message type and `Save`. Is compatible with [Unity's Rich Text](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html)!
*  To edit the comment: `right click` → `Edit comment`.


### How it works

The Comment component is a simple MonoBehaviour that stores the comment's text and message type. A custom editor draws it as a help box and implements the editing functionality.


### Useful links

Some great introduction to custom editors if this is your first time around them:
- Unity Manual → https://docs.unity3d.com/6000.1/Documentation/Manual/editor-CustomEditors.html
- The good ol' Brackeys → https://www.youtube.com/watch?app=desktop&v=RInUu1_8aGw&t=638s

How to check when the user right clicks on your editor:
- https://docs.unity3d.com/ScriptReference/Event-current.html
- https://docs.unity3d.com/ScriptReference/Event-type.html

Drawing a custom context menu:
- https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GenericMenu.html

Prompt the user to save or discard unsaved changes:
- https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Editor-hasUnsavedChanges.html
- https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Editor-saveChangesMessage.html

Allow users to undo the changes made to your object:
- https://docs.unity3d.com/ScriptReference/Undo.RecordObject.html

I'm using Kenney's Cursor Pack for the component icon!
- https://kenney.nl/assets/cursor-pack