using UnityEngine;
using UnityEditor;
using System.Security.Permissions;
using UnityEditor.Rendering;
using System.Reflection.Emit;
//using Codice.CM.Client.Gui;

[CustomEditor(typeof(DefaultEnemyTemplate))]
public class EnemySOEditor : Editor
{
    private bool showStats = true; // 
    public override void OnInspectorGUI()
    {

        DefaultEnemyTemplate enemySO = (DefaultEnemyTemplate)target;

        SerializedProperty name = serializedObject.FindProperty("enemyName");

        SerializedProperty health = serializedObject.FindProperty("enemyHealth");
        

        //weaponObject.rarity = num.floatValue;

        //DrawHeader(weaponObject);
        DrawHeader(enemySO);

        

        // if (weaponObject.icon != null)
        // {
            EditorGUILayout.Space(10);
            GUILayout.BeginHorizontal();

            //GUILayout.Label(, GUILayout.Width(64), GUILayout.Height(64));

            GUILayout.BeginVertical();

            // EditorGUILayout.Space(16);

            Rect labelBox = GUILayoutUtility.GetRect(0, 32, GUILayout.ExpandWidth(true) );

            if (enemySO.enemyHealth <= 20)
        {
            EditorGUI.DrawRect(labelBox, Color.red);
        }
            else if (enemySO.enemyHealth > 80)
        {
            EditorGUI.DrawRect(labelBox, Color.green);
        }
        else EditorGUI.DrawRect(labelBox, Color.yellow);
            GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 20;
            EditorGUI.LabelField(labelBox, "Enemy Stats", style);

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        //}
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyHealth"));
        //EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyMaxHealth"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("behaviorTree"));

        EditorGUILayout.Space();

        //showStats = EditorGUILayout.Foldout(showStats, "Stats", true);

        if(showStats)
        {
            EditorGUI.indentLevel++;

            // EditorGUILayout.PropertyField(serializedObject.FindProperty("num"));

            // if (weaponObject.weaponType.HasFlag(WeaponType.Ranged) ||
            //     weaponObject.weaponType.HasFlag(WeaponType.Magic))
            // {
            //     EditorGUILayout.PropertyField(serializedObject.FindProperty("fireRate"));
            //     EditorGUILayout.PropertyField(serializedObject.FindProperty("range"));
            // }

            // if (weaponObject.weaponType.HasFlag(WeaponType.Ranged))
            // {
            //     EditorGUILayout.PropertyField(serializedObject.FindProperty("infiniteAmmo"));
                
            //     if (!weaponObject.infiniteAmmo)
            //     {
            //         EditorGUILayout.PropertyField(serializedObject.FindProperty("ammoCapacity"));
            //     }
            // }

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        Color previousColor = GUI.backgroundColor;

        GUI.backgroundColor = Color.red;

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponColor"));
        //EditorGUILayout.Slider(serializedObject.FindProperty("rarity"), 0f, 1f);

        GUI.backgroundColor = previousColor;


        EditorGUILayout.Space();

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("fireSound"));

        // if (weaponObject.fireSound != null)
        // {
        //     GUILayout.TextField("clip Duration: " + weaponObject.fireSound.length.ToString("n2") + " seconds");

        //     if (GUILayout.Button("Play Fire Sound"))
        //     {
        //         Debug.Log("Play fire sound");
        //     }
        // }

        Rect rect = GUILayoutUtility.GetRect(18, 18);
       // EditorGUI.ProgressBar(rect, weaponObject.rarity, "Rarity");


        serializedObject.ApplyModifiedProperties();
    }

    void DrawHeader(DefaultEnemyTemplate enemySO)
    {
        Rect rect  = GUILayoutUtility.GetRect(0, 40, GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(rect, new Color(0.15f, 0.15f, 0.15f));

        GUIStyle style  = new GUIStyle(EditorStyles.boldLabel);
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize  = 18;
        EditorGUI.LabelField(rect, enemySO.enemyName, style);
    }
}
