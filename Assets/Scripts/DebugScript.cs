using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class DebugScript : MonoBehaviour
{
    public static UnityEvent SetUpEvent(UnityEvent eventToSetup) {
        eventToSetup = new UnityEvent();
        eventToSetup.AddListener(LogEvent);
        return eventToSetup;
    }

    static void LogEvent() {
        Debug.Log(DateTime.Now);
    }
}
