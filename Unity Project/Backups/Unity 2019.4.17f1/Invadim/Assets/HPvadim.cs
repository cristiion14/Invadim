using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPvadim : MonoBehaviour
{
    RectTransform rectTransform;
    public Vadim vadim;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3(Mathf.Clamp01(vadim.currentHealth * 0.01f), .8f, 1f);
    }
}
