using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClocksManager : MonoBehaviour
{
    public GameObject clockPrefab;
    UnityEvent newClockEvent;

    //I would normally go through a singleton or a static class; you can't have a static class inherit from Monobehaviour tho,
    //And I would need a bit more time to freshen up on Singletons.
    public SoundsManager soundsManagerScript;

    [Range(1, 50)]
    public int clocksAmount = 1;

    float clockX = 0;
    float clockY = 0;

    void Start()
    {
        PopulateClocks(clocksAmount);
        newClockEvent = soundsManagerScript.SetupEvent(newClockEvent);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateClock();
            newClockEvent.Invoke();
        }
    }

    void PopulateClocks(int clocksAmount) {
        for (int i = 0; i < clocksAmount; i++) {
            CreateClock();
        }
    }

    void CreateClock() {
        Instantiate(clockPrefab, new Vector3(clockX, clockY, 0), Quaternion.identity);

        if (Random.Range(0, 100) < 50) clockX += 10;
        else clockY += 10;
    }
}
