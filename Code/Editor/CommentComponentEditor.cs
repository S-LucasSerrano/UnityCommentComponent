using UnityEngine;
using UnityEditor;

namespace CommentComponent
{
	[CustomEditor(typeof(Comment))]
	public class CommentComponentEditor : Editor
	{
		private Comment targetComment = null;
		private bool editing = false;

		private string commentText
		{
			get
			{
				if (targetComment == null)
					return null;
				return targetComment.text;
			}
			set
			{
				if (targetComment == null)
					return;
				if (value == targetComment.text)
					return;

				targetComment.text = value;
				EditorUtility.SetDirty(targetComment);
			}
		}
		string newCommentText = null;

		private MessageType commentType
		{
			get
			{
				if (targetComment == null)
					return MessageType.Info;
				return (MessageType)targetComment.messageType;
			}
			set
			{
				if (targetComment == null)
					return;
				if ((int)value == targetComment.messageType)
					return;

				targetComment.messageType = (int)value;
				EditorUtility.SetDirty(targetComment);
			}
		}
		MessageType newCommentType = MessageType.None;


		private void OnEnable()
		{
			targetComment =	(Comment)target;

			newCommentText = commentText;
			newCommentType = commentType;

			if (targetComment.isFirstTimeDrawingEditor)
			{
				targetComment.isFirstTimeDrawingEditor = false;
				editing = true;
			}

			saveChangesMessage = "Do you want to save the changes made to your comment?";
		}

		public override void OnInspectorGUI()
		{
			// Draw comment.
			if (editing == false)
			{
				EditorStyles.helpBox.richText = true;
				EditorGUILayout.HelpBox("\n" + commentText + "\n", commentType);
			}

			// Show the option to change the comment on right click.
			Event currentClick = Event.current;
			if (currentClick.type == EventType.ContextClick)
			{
				GenericMenu menu = new GenericMenu();
				menu.AddItem(new GUIContent("Edit comment"), false, () =>
				{
					editing = true;
				});
				menu.ShowAsContext();

				currentClick.Use();
			}

			// Edit comment.
			if (editing)
			{
				EditorGUILayout.Space();

				newCommentText = GUILayout.TextArea(newCommentText, GUILayout.MaxHeight(EditorGUIUtility.singleLineHeight * 3));
				newCommentType = (MessageType)EditorGUILayout.EnumPopup(newCommentType);
				if (newCommentText != commentText || newCommentType != commentType)
					hasUnsavedChanges = true;

				EditorGUILayout.Space();
				if (GUILayout.Button("Save"))
				{
					editing = false;
					SaveChanges();
				}
			}
		}

		public override void SaveChanges()
		{
			if (!hasUnsavedChanges)
				return;
			base.SaveChanges();

			Undo.RecordObject(targetComment, "Modified message on " + targetComment.name);
			commentText = newCommentText;
			commentType = newCommentType;
		}
	}
}
