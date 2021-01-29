using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazedObject : MonoBehaviour
{

    [SerializeField] private float percentageOfScreenApearenceAcception = 0.6f;
    [SerializeField] private float seeingDistance = 30f;

    private int pointsSeenNow = 0;

    [SerializeField] private Transform[] targetPointsArray;
    [SerializeField] private Camera gazingCamera;

    private void Update()
    {

        Debug.Log((float) pointsSeenNow / targetPointsArray.Length);

        if (IsObjectOnCamera())
        {
            Debug.Log("Yes");
        }
        else
        {
            Debug.Log("NO");
        }


    }

    #region private functions

    private bool IsObjectOnCamera()
    {

        if (AreAllPointsInFOV())
        {
            if (PointsSeenAreEnough())
            {
                return true;
            }

        }

        return false;
        
    }

    private bool AreAllPointsInFOV()
    {

        bool allInFOV = true;
        foreach(var point in targetPointsArray)
        {
            if (IsPointOnFOV(point) == false)
                allInFOV = false;
        }

        return allInFOV;
    }

    private bool IsPointOnFOV(Transform point)
    {
        Vector3 screenPoint = gazingCamera.WorldToViewportPoint(point.position);

        // Behind camera
        if (screenPoint.z < 0)
            return false;

        // Is on field of view
        if (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
            return true;

        return false;
    }

    private bool IsCameraSeeingPoint(Transform point)
    {
        Vector3 dir = (point.position - gazingCamera.transform.position).normalized;
        Ray ray = new Ray(gazingCamera.transform.position, dir);

        
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, seeingDistance))
        {


            var gazedObj = hitInfo.transform.GetComponentInParent<GazedObject>();

            if (GameObject.ReferenceEquals(gazedObj, this))
            {
                Debug.DrawRay(gazingCamera.transform.position, dir * seeingDistance, Color.green);
                return true;
            }
            else
            {
                Debug.DrawRay(gazingCamera.transform.position, dir * seeingDistance, Color.red);
            }

        }

        Debug.DrawRay(gazingCamera.transform.position, dir * seeingDistance, Color.blue);


        return false;
    }

    private int HowManyPointsAreSeen()
    {

        int numOfPointsSeen = 0;
        foreach (var point in targetPointsArray)
        {
            if (IsCameraSeeingPoint(point))
            {
                numOfPointsSeen++;
            }
        }

        return numOfPointsSeen;

    }

    private bool PointsSeenAreEnough()
    {
        pointsSeenNow = HowManyPointsAreSeen();
        if (((float) pointsSeenNow / targetPointsArray.Length) > percentageOfScreenApearenceAcception)
        {
            return true;
        }

        return false;

    }
    #endregion

}

