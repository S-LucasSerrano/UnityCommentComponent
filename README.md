
# Unity Comment Componet

Like leaving small notes in the comments of your code, this Unity component lets you leave messages on game objects. Perfect for letting your teammates and your future self know that the game stops working if they delete that mysterious cube under the second level.

![Capture Gif](./GithubResources/CapturaGif.gif)


### How to use it

* Add the content of the `Code` folder to your project.
-  Select the game object that you want to add a comment to and go `Add Component` → `Comment`.
- Write the comment, choose the message type and `Save`. Is compatible with [Unity's Rich Text](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html)!
*  To edit the comment: `right click` → `Edit comment`.


### How it works

The Comment component is a simple MonoBehaviour that stores the comment's text and message type. A custom editor draws it as a help box and implements the editing functionality.