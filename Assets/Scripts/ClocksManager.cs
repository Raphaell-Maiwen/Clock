using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClocksManager : MonoBehaviour
{
    public GameObject clockPrefab;

    [Range(1, 50)]
    public int clocksAmount = 1;

    void Start()
    {
        PopulateClocks(clocksAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateClocks(int clocksAmount) {
        float clockX = 0;
        float clockY = 0;

        for (int i = 0; i < clocksAmount; i++) {
            Instantiate(clockPrefab, new Vector3(clockX, clockY ,0), Quaternion.identity);

            if (Random.Range(0, 100) < 50) clockX += 10;
            else clockY += 10;
        }
    }
}
