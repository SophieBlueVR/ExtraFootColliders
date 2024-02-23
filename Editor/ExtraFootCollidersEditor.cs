#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.SDK3.Avatars.Components;

namespace SophieBlue.ExtraFootColliders {
    [CustomEditor(typeof(ExtraFootColliders))]
    public class ExtraFootCollidersEditor : Editor {

        private static ExtraFootColliders mover;

        private static GUIContent labelSourceCollider = new GUIContent(
            "Source Collider",
            "Which finger collider to use for this foot");
        private static GUIContent labelOverrideSize = new GUIContent(
            "Override Size",
            "Override the default of using the foot collider size");


        public override void OnInspectorGUI() {
            mover = (ExtraFootColliders) target;

            // Header

            EditorGUILayout.LabelField($"{Version.VERSION}", new GUIStyle(EditorStyles.miniLabel) {
                richText = true,
                alignment = TextAnchor.UpperRight
            });

            if (Application.isPlaying) {
                EditorGUILayout.HelpBox("Exit play mode to use this tool.",
                                        MessageType.Info);
                return;
            }


            // Left Collider Setup

            EditorGUILayout.LabelField("Left Collider");
            EditorGUI.indentLevel++;

            mover.ColliderLeft = (ExtraFootColliders.ColliderType)EditorGUILayout.EnumPopup(labelSourceCollider, mover.ColliderLeft);

            mover.ColliderLeftSizeOverride = EditorGUILayout.Toggle(labelOverrideSize, mover.ColliderLeftSizeOverride);
            if (mover.ColliderLeftSizeOverride) {
                EditorGUI.indentLevel++;
                mover.ColliderLeftRadius = EditorGUILayout.FloatField("Radius", mover.ColliderLeftRadius);
                mover.ColliderLeftHeight = EditorGUILayout.FloatField("Height", mover.ColliderLeftHeight);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;


            // Right Collider Setup

            EditorGUILayout.LabelField("Right Collider");
            EditorGUI.indentLevel++;

            mover.ColliderRight = (ExtraFootColliders.ColliderType)EditorGUILayout.EnumPopup(labelSourceCollider, mover.ColliderRight);
            mover.ColliderRightSizeOverride = EditorGUILayout.Toggle(labelOverrideSize, mover.ColliderRightSizeOverride);
            if (mover.ColliderRightSizeOverride) {
                EditorGUI.indentLevel++;
                mover.ColliderRightRadius = EditorGUILayout.FloatField("Radius", mover.ColliderRightRadius);
                mover.ColliderRightHeight = EditorGUILayout.FloatField("Height", mover.ColliderRightHeight);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }
    }
}

#endif
