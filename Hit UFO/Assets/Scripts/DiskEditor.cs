﻿using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(Disk))]
[CanEditMultipleObjects]
public class DiskEditor : Editor
{
	SerializedProperty score;  
	SerializedProperty color;    
	SerializedProperty scale;    

	void OnEnable()
	{
		score = serializedObject.FindProperty("score");
		color = serializedObject.FindProperty("color");
		scale = serializedObject.FindProperty("scale");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.IntSlider(score, 0, 5, new GUIContent("score"));
		serializedObject.ApplyModifiedProperties();
	}
}
