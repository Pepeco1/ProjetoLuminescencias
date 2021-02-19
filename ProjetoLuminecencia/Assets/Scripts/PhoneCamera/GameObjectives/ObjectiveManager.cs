using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectiveManager : Singleton<ObjectiveManager>
{

    private List<PhotoObjective> photoObjectives = null;

    private void Awake()
    {

        var gazedObjectsInScene = FindObjectsOfType<GazedObject>().ToList();
        gazedObjectsInScene.ForEach((gazedObject) => photoObjectives.Add(new PhotoObjective(gazedObject)));
    
    }

    public bool TryCompleteObjective(GazedObject obj)
    {

        //Checks in photoObjectives list if any pgotoObjective has obj as objective.
        var correspondantObjective = photoObjectives.FirstOrDefault(
            objective => objective.IsThisYourObjective(obj));

        if(correspondantObjective != null)
        {
            correspondantObjective.CompleteObjective();
            return true;
        }

        return false;
    }




}
