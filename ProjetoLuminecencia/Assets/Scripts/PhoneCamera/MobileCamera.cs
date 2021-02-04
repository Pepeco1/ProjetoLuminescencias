using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobileCamera : MonoBehaviour
{
    private Camera myCamera = null;
    private List<GazedObject> gazedObjects = null;
    private List<GazedObject> objectsInPhoto = null;

    private void Awake()
    {
        gazedObjects = FindObjectsOfType<GazedObject>().ToList();
        myCamera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakePicture();
    }

    public void TakePicture()
    {

        myCamera.enabled = false;

        // Do camera flash

        LookForObjectsInPhoto();

    }

    #region private functions
    
    private void LookForObjectsInPhoto()
    {
        gazedObjects.ForEach((gazedObject) => AddGazedToPhotoList(gazedObject));
    }

    private void AddGazedToPhotoList(GazedObject gazed)
    {
        objectsInPhoto.Add(gazed);
    }

    #endregion
}
