using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoObjective
{

    private bool isCompleted = false;
    private GazedObject objective = null;


    public PhotoObjective(GazedObject gazed)
    {
        objective = gazed;
    }

    public bool IsThisYourObjective(GazedObject gazed)
    {

        if (GameObject.ReferenceEquals(objective, gazed))
            return true;

        return false;

    }

    public void CompleteObjective()
    {
        isCompleted = true;
    }

}
