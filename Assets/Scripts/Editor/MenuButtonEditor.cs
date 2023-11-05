using UI;
using UnityEditor;
using UnityEditor.UI;

namespace Editor
{
    [CustomEditor(typeof(MenuButton), true)]
    [CanEditMultipleObjects]
    public class MenuButtonEditor : ButtonEditor
    {
        SerializedProperty m_MenuCursorProperty;
    
        protected override void OnEnable()
        {
            base.OnEnable();
            m_MenuCursorProperty = serializedObject.FindProperty("_menuCursor");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_MenuCursorProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
