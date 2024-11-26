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
			// Mostrar comentario.
			if (editing == false)
			{
				EditorStyles.helpBox.richText = true;
				EditorGUILayout.HelpBox("\n" + messageText + "\n", messageType);
			}

			// Mostrar la opcion de cambiar el mensaje al hacer click derecho.
			Event currentClick = Event.current;
			if (currentClick.type == EventType.ContextClick)
			{
				GenericMenu menu = new GenericMenu();
				menu.AddItem(new GUIContent("Editar comentario"), false, () =>
				{
					editing = true;
					undoGroupIndex = Undo.GetCurrentGroup();
				});
				menu.ShowAsContext();

				currentClick.Use();
			}

			// Editar comentario.
			if (string.IsNullOrEmpty(messageText))
				editing = true;
			if (editing)
			{
				Undo.RecordObject(targetComment, "Changed Message");

				EditorGUILayout.Space();
				messageText = GUILayout.TextArea(messageText, GUILayout.MaxHeight(EditorGUIUtility.singleLineHeight * 3));
				messageType = (MessageType)EditorGUILayout.EnumPopup(messageType);

				EditorGUILayout.Space();
				if (GUILayout.Button("Confirmar"))
				{
					editing = false;
					Undo.CollapseUndoOperations(undoGroupIndex);
				}
			}
		}

		private string messageText
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

		private MessageType messageType
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
