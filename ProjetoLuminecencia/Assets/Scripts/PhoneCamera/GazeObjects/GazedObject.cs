using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazedObject : MonoBehaviour
{

    [SerializeField] private Transform targetPoint;
    [SerializeField] private Camera gazingCamera;

    [SerializeField] private float seeingDistance = 30f;

    private void Update()
    {

        if (IsOnCamera())
        {
            Debug.Log("Yes");
        }
        else
        {
            Debug.Log("NO");
        }


    }

    #region private functions

    private bool IsOnCamera()
    {
        Vector3 screenPoint = gazingCamera.WorldToViewportPoint(targetPoint.position);

        // Behind camera
        if (screenPoint.z < 0)
            return false;

        // Is on field of view
        if (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        {

            Vector3 dir = (targetPoint.position - gazingCamera.transform.position).normalized;
            Ray ray = new Ray(gazingCamera.transform.position, dir);
            
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, seeingDistance))
            {

                var gazedObj = hitInfo.transform.GetComponentInParent<GazedObject>();

                if(GameObject.ReferenceEquals(gazedObj, this))
                {
                    return true;
                }
            }


        }

        return false;
        
    }
    #endregion

}

