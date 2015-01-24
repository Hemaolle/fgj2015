using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(UnityLayer))]
public class UnityLayerInspectorDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);

		Rect tagEnableRect = new Rect(position.x, position.y, position.height, position.height);
		Rect tagLabelRect = new Rect(position.x + position.height, position.y, (position.width-position.height)/2, position.height);
		Rect tagFieldRect = new Rect(position.x + (position.width+position.height)/2, position.y, (position.width-position.height)/2, position.height);

		bool isEnabled = property.FindPropertyRelative("isEnabled").boolValue;
		property.FindPropertyRelative("isEnabled").boolValue = EditorGUI.Toggle(tagEnableRect, isEnabled);
		EditorGUI.LabelField(tagLabelRect, label);

		if (property.FindPropertyRelative("isEnabled").boolValue) {
			int layer = Mathf.Max(0, property.FindPropertyRelative("_layer").intValue);
			property.FindPropertyRelative("_layer").intValue = EditorGUI.LayerField(tagFieldRect, layer);
		}

		EditorGUI.EndProperty();
	}
}
