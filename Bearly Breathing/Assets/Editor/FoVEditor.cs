using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FoVEditor : Editor
{
    void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
    }
}
