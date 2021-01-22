using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingFlap : MonoBehaviour
{
    public float freq = 5f;
    public float amp = 30f;
    public float offset = 30f;
    public float phase = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * freq + phase) * amp + offset);
    }
}
