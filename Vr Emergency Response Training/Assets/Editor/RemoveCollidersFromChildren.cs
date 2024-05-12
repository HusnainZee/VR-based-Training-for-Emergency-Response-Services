using UnityEngine;
using UnityEditor;

public class RemoveCollidersFromChildren : Editor
{
    [MenuItem("Tools/Remove All Colliders From Children")]
    private static void RemoveColliders()
    {
        // Check if there is an active GameObject selected
        if (Selection.activeGameObject == null)
        {
            EditorUtility.DisplayDialog("No Selection", "Please select a parent object in the hierarchy.", "OK");
            return;
        }

        // Get all Collider components in children of the selected GameObject
        Collider[] colliders = Selection.activeGameObject.GetComponentsInChildren<Collider>();

        // Begin undo group
        Undo.RecordObjects(colliders, "Remove All Colliders");

        // Remove all found colliders
        foreach (var collider in colliders)
        {
            Undo.DestroyObjectImmediate(collider);
        }

        // Display a message when done
        if (colliders.Length > 0)
        {
            Debug.Log("Removed " + colliders.Length + " colliders from " + Selection.activeGameObject.name);
        }
        else
        {
            EditorUtility.DisplayDialog("No Colliders Found", "There are no collider components in the children of the selected object.", "OK");
        }
    }
}
