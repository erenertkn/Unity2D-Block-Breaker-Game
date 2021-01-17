using System;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Blocknew))] 
public class CustomEditorGUI : Editor
{
     bool tempBreakable;

     SerializedProperty breakableProp;
     int tempBlock;

     private void OnEnable()
     {
         breakableProp = serializedObject.FindProperty("unbreakable");
     }
 public override void OnInspectorGUI()
 {
     Blocknew blockScript = (Blocknew)target;
     DrawDefaultInspector();
     if(GUI.changed){
         blockScript.setBreakable(blockScript.unbreakable);
         blockScript.setSprite(blockScript.block);
     }
      
 }
}