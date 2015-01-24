using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CustomPropertyDrawer(typeof(UnityScene))]
public class UnitySceneInspectorDrawer : PropertyDrawer {
	public static string NotDecidedScene = "[None]";
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);

		string sceneName = property.FindPropertyRelative("_sceneName").stringValue;

		List<string> sceneNames = new List<string>();

		sceneNames.Add(NotDecidedScene);
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			string scenePath = scene.path;
			scenePath = scenePath.Substring(scenePath.LastIndexOf('/') + 1);
			sceneNames.Add(scenePath.Substring(0, scenePath.LastIndexOf('.')));
		}

		int sceneIndex = 0;
		if (sceneNames.Contains(sceneName)) {
			sceneIndex = sceneNames.FindIndex(delegate(string obj) { return obj.Equals(sceneName); });
		}

		Rect sceneLabelRect = new Rect(position.x + position.height, position.y, (position.width-position.height)/2, position.height);
		Rect sceneFieldRect = new Rect(position.x + (position.width+position.height)/2, position.y, (position.width-position.height)/2, position.height);

		EditorGUI.LabelField(sceneLabelRect, label);
		sceneIndex = EditorGUI.Popup(sceneFieldRect, sceneIndex, sceneNames.ToArray());


		if (sceneIndex == 0) {
			property.FindPropertyRelative("_sceneName").stringValue = "";
		} else {
			property.FindPropertyRelative("_sceneName").stringValue = sceneNames[sceneIndex];
		}
		
		EditorGUI.EndProperty();
	}
}
