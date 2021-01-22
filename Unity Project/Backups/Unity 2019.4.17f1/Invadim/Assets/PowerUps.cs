using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    float countDown;
    float delay = 3f;

    private void Start()
    {
        countDown = delay;
    }

    private void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
            Destroy(gameObject);
    }
}
