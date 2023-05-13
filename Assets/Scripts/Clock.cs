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

    //For optimization's sake
    int lastMinute = 0;

    //TODO if time allows: make it so minutes and hours progress slowly? instead of going from one minute to another directly.
    void Update()
    {
        int currentMinute = DateTime.Now.Minute;

        if (lastMinute != currentMinute) {
            lastMinute = currentMinute;
            UpdateNeedle(minutesAnchor, currentMinute, -6);
            UpdateNeedle(hoursAnchor, DateTime.Now.Hour, 15);
        }

        //UpdateNeedle(secondsAnchor, DateTime.Now.Second, -6);
    }

    void UpdateNeedle(GameObject needleAnchor, int amountOfTime, int multiplicator) {
        Vector3 NextNeedleRotation = needleAnchor.transform.rotation.eulerAngles;
        NextNeedleRotation.z = amountOfTime * multiplicator;
        needleAnchor.transform.rotation = Quaternion.Euler(NextNeedleRotation);
    }
}
