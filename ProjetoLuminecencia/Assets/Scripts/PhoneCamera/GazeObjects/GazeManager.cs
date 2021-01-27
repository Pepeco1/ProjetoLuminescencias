using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GazeManager : MonoBehaviour
{

    private List<GazedObject> gazedObjects = null;


    private void Awake()
    {
        gazedObjects = FindObjectsOfType<GazedObject>().ToList();
    }

    private void Update()
    {
        
    }


}

