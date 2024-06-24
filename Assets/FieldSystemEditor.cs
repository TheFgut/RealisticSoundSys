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
        for (int i = 0; i < points.Length;i++)
        {
            points[i] = Handles.PositionHandle(points[i], Quaternion.identity);
            Handles.Label(points[i], string.Format("Point{0}",i));

        }
        SceneView.RepaintAll();
    }

}
