using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    //I would normally use a config file, choose among the needles designed there, and have it explicit in the file
    //which needle is the hour and which is the minute, so it would be less prone to error than relying on gameobjects order.
    public List<GameObject> needlesSet;

    GameObject hoursAnchor;
    GameObject minutesAnchor;

    //For optimization's sake
    int lastMinute = 0;

    //For tests' sake
    public GameObject secondsAnchor;


    UnityEvent minuteSameAsHourEvent;

    private void Start(){
        GameObject thisNeedleSet = needlesSet[UnityEngine.Random.Range(0, needlesSet.Count)];
        hoursAnchor = Instantiate(thisNeedleSet.transform.GetChild(0).gameObject, this.transform.position, Quaternion.identity);
        hoursAnchor.transform.parent = this.transform;
        minutesAnchor = Instantiate(thisNeedleSet.transform.GetChild(1).gameObject, this.transform.position, Quaternion.identity);
        minutesAnchor.transform.parent = this.transform;

        minuteSameAsHourEvent = DebugScript.SetUpEvent(minuteSameAsHourEvent);
    }

    //TODO if time allows: make it so minutes and hours progress slowly? instead of going from one minute to another directly.
    void Update()
    {
        int currentMinute = DateTime.Now.Minute;

        if (lastMinute != currentMinute) {
            lastMinute = currentMinute;
            UpdateNeedle(minutesAnchor, currentMinute, -6);
            UpdateNeedle(hoursAnchor, DateTime.Now.Hour, -30);

            if (minutesAnchor.transform.rotation.eulerAngles.z == hoursAnchor.transform.rotation.eulerAngles.z) {
                minuteSameAsHourEvent.Invoke();
            }
        }

        //UpdateNeedle(secondsAnchor, DateTime.Now.Second, -6);
    }

    void UpdateNeedle(GameObject needleAnchor, int amountOfTime, int multiplicator) {
        Vector3 NextNeedleRotation = needleAnchor.transform.rotation.eulerAngles;
        NextNeedleRotation.z = amountOfTime * multiplicator;
        needleAnchor.transform.rotation = Quaternion.Euler(NextNeedleRotation);
    }
}
