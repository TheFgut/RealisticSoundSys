using UnityEngine;
using UnityEditor;

public class FieldSystemEditor : EditorWindow
{
    [SerializeField]private Vector3[] points = new Vector3[10];
    private FieldSystem _fieldSystem;

    [MenuItem("Window/Field System Editor")]
    public static void ShowWindow()
    {
        // Альтернативный способ получить окно редактора
        FieldSystemEditor window = ScriptableObject.CreateInstance<FieldSystemEditor>();
        window.titleContent = new GUIContent("Field System Editor");
        window.Show();
    }

    private void OnGUI()
    {
        _fieldSystem = (FieldSystem)EditorGUILayout.ObjectField("Field System", _fieldSystem, typeof(FieldSystem), true);

    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Handles.color = Color.red;
        if (_fieldSystem != null)
        {
            FieldSystem.Frame[] frames = _fieldSystem.Frames;
            foreach (FieldSystem.Frame frame in frames)
            {
                frame.center = Handles.PositionHandle(frame.center, Quaternion.identity);
                Handles.Label(frame.center, "Frame");
            }
        }
        SceneView.RepaintAll();
    }

}
