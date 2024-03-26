using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;

public static class CreateUtility
{
   public static void CreatePrefab(string path)
   {
        GameObject newObject = PrefabUtility.InstantiatePrefab(Resources.Load(path)) as GameObject;
        Place(newObject); 
   }

    private static void Place(GameObject gameObject)
    {
        //Find location
        SceneView lastView = SceneView.lastActiveSceneView;
        gameObject.transform.position = lastView ? lastView.pivot : Vector3.zero;

        // Make sure we place the object in the proper scene, withj a relevant name
        StageUtility.PlaceGameObjectInCurrentStage(gameObject);
        GameObjectUtility.EnsureUniqueNameForSibling(gameObject);

        // Record undo, and select
        Undo.RegisterCreatedObjectUndo(gameObject, $"Create Object {gameObject.name}");
        Selection.activeGameObject = gameObject;

        // For prefabs, let's mark the scene as dirty for saving
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
