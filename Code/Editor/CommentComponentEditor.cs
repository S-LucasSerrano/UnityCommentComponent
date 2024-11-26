using UnityEngine;
using UnityEditor;


namespace CommentComponent
{
	[CustomEditor(typeof(Comment))]
	public class CommentComponentEditor : Editor
	{
		private Comment targetComment = null;
		private bool editing = false;

		int undoGroupIndex = -1;


		private void OnEnable()
		{
			targetComment =	(Comment)target;
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
					undoGroupIndex = Undo.GetCurrentGroup();
				});
				menu.ShowAsContext();

				currentClick.Use();
			}

			// Edit comment.
			if (string.IsNullOrEmpty(commentText))
				editing = true;
			if (editing)
			{
				Undo.RecordObject(targetComment, "Modified comment on " + targetComment.gameObject.name);

				EditorGUILayout.Space();
				commentText = GUILayout.TextArea(commentText, GUILayout.MaxHeight(EditorGUIUtility.singleLineHeight * 3));
				commentType = (MessageType)EditorGUILayout.EnumPopup(commentType);

				EditorGUILayout.Space();
				if (GUILayout.Button("Save"))
				{
					editing = false;
					Undo.CollapseUndoOperations(undoGroupIndex);
				}
			}
		}

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
	}
}
