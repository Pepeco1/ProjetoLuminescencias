using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMatSetup : MonoBehaviour
{

    [SerializeField] Camera phoneCamera = null;
    [SerializeField] Material material = null;
    [SerializeField] Image imageUI = null;

    // Start is called before the first frame update
    void Start()
    {

        if (phoneCamera.targetTexture != null)
            phoneCamera.targetTexture.Release();

        phoneCamera.targetTexture = new RenderTexture(720, 1080, 24);
        material.mainTexture = phoneCamera.targetTexture;

        //imageUI.preserveAspect = true;

    }


}
