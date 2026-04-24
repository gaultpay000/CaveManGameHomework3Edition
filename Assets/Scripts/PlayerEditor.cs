using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerMovement player = (PlayerMovement)target;
        
        DrawHeader(player);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("playerHealth"));

        EditorGUILayout.Space(40);
        GUIStyle cameraStyle = new GUIStyle(EditorStyles.boldLabel);
            Rect cameraBox = GUILayoutUtility.GetRect(0, 32, GUILayout.ExpandWidth(true) );
        //camera
        {
        
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

            EditorGUI.DrawRect(cameraBox, new Color(.15f, .15f, .15f));    
            cameraStyle.alignment = TextAnchor.MiddleCenter;
            cameraStyle.fontSize = 20;
            EditorGUI.LabelField(cameraBox, "Player Prefs", cameraStyle);

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("mouseSensativity"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("verticalClamp"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraHolder"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("clubPos"));
        if (player.cameraHolder == null|| player.clubPos == null)
            {
                EditorGUILayout.HelpBox("missing important assets", MessageType.Warning);
            }
        }

        EditorGUILayout.Space(40);
        GUIStyle moveStyle = new GUIStyle(EditorStyles.boldLabel);
        Rect moveBox = GUILayoutUtility.GetRect(0, 32, GUILayout.ExpandWidth(true) );

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

            if (player.isMovingUp == true)
            {
                EditorGUI.DrawRect(moveBox, Color.red); 
            }
            else EditorGUI.DrawRect(moveBox, Color.green);
               
            moveStyle.alignment = TextAnchor.MiddleCenter;
            moveStyle.fontSize = 20;
            EditorGUI.LabelField(moveBox, "Movement", moveStyle);

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("jumpForce"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isMovingUp"));

        GUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("movex"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("movez"));
        GUILayout.EndHorizontal();

        //EditorGUILayout.PropertyField(serializedObject.Find)

        EditorGUILayout.Space(40);
        GUIStyle gravityStyle = new GUIStyle(EditorStyles.boldLabel);
        Rect gravityBox = GUILayoutUtility.GetRect(0, 32, GUILayout.ExpandWidth(true) );

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

            EditorGUI.DrawRect(gravityBox, new Color(.15f, .15f, .15f));   
               
            gravityStyle.alignment = TextAnchor.MiddleCenter;
            gravityStyle.fontSize = 20;
            EditorGUI.LabelField(gravityBox, "Rigidbody", gravityStyle);

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("rb"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("maxVelocity"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("linearDampening"));


    }
    void DrawHeader(PlayerMovement player)
    {
        Rect rect  = GUILayoutUtility.GetRect(0, 60, GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(rect, new Color(0.15f, 0.15f, 0.15f));

        GUIStyle style  = new GUIStyle(EditorStyles.boldLabel);
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize  = 18;
        EditorGUI.LabelField(rect, "Player", style);
    }
}
