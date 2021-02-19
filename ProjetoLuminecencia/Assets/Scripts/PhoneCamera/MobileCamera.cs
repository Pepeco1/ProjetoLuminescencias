using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCamera : MonoBehaviour
{
    private Camera myCamera = null;
    private GazeManager gazeManager = null;
    private List<GazedObject> objectsInPhoto = null;


    #region Unity Functions
    private void Awake()
    {
        gazeManager = GazeManager.Instance;
        myCamera = GetComponent<Camera>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakePicture();
            Debug.Log("Tirou foto");
            Debug.Log(objectsInPhoto.Count);
        }
    }

    #endregion

    #region public functions

    public void TakePicture()
    {

        myCamera.enabled = false;

        // Do camera flash

        LookForObjectsInPhoto();

        TryCompleteObjectives():

    }


    #endregion

    #region private functions

    private void LookForObjectsInPhoto()
    {
        objectsInPhoto = gazeManager.GetObjectsOnCamera(myCamera);
    }

    private void TryCompleteObjectives()
    {
        foreach(var objInPhoto in objectsInPhoto)
        {
            //Do other stuff?
            ObjectiveManager.Instance.TryCompleteObjective(objInPhoto);
        }
    }

    #endregion
}
