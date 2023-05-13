using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundsManager : MonoBehaviour
{
    public AudioSource clockSpawnedSound;

    public UnityEvent SetupEvent(UnityEvent eventToSetup) {
        eventToSetup = new UnityEvent();
        eventToSetup.AddListener(PlayClockSpawnedSound);

        return eventToSetup;
    }

    void PlayClockSpawnedSound() {
        clockSpawnedSound.Play();
    }
}
