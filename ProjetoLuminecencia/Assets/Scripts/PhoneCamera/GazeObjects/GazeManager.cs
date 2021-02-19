using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GazeManager : Singleton<GazeManager>
{

    private List<GazedObject> gazedObjects = null;


    private void Awake()
    {
        gazedObjects = FindObjectsOfType<GazedObject>().ToList();
    }


    public List<GazedObject> GetObjectsOnCamera(Camera gazingCamera)
    {

        var objectsInCamera = new List<GazedObject>();

        foreach (var gazedObject in gazedObjects)
        {

            if (gazedObject.IsObjectInCamera(gazingCamera))
            {
                objectsInCamera.Add(gazedObject);
            }

        }

        return objectsInCamera;

    }


}

