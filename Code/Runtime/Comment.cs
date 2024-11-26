using UnityEngine;

namespace CommentComponent
{
	[AddComponentMenu(" Comment")]
	public class Comment : MonoBehaviour
	{
		[TextArea]
		public string text = "";
		public int messageType = 1;
	}
}
