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


}
