using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public GameObject hoursAnchor;
    public GameObject minutesAnchor;

    //For tests' sake
    public GameObject secondsAnchor;

    // Update is called once per frame
    void Update()
    {
        //UpdateNeedle(secondsAnchor, DateTime.Now.Second, -6);
        UpdateNeedle(minutesAnchor, DateTime.Now.Minute, -6);
        UpdateNeedle(hoursAnchor, DateTime.Now.Hour, 15);
    }

    void UpdateNeedle(GameObject needleAnchor, int amountOfTime, int multiplicator) {
        Vector3 NextNeedleRotation = needleAnchor.transform.rotation.eulerAngles;
        NextNeedleRotation.z = amountOfTime * multiplicator;
        needleAnchor.transform.rotation = Quaternion.Euler(NextNeedleRotation);
    }
}
