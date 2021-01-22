using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class CTP : MonoBehaviour
{
    float currentHealth = 100f;
    public Image healthBar;

    public bool hasDied = false;
    Vector3 initialScale;

    GameObject vadim;
    public GameObject ctpPrefab;

    float damage = 10;
    bool ctpInstantiated = false;
    private void Start()
    {
        vadim = GameObject.Find("Vadim");

        initialScale = transform.localScale;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

    private void Update()
    {
        if(vadim.GetComponent<Vadim>().kills >15 && !ctpInstantiated)
        {
            Debug.LogError("A venit CTPUU");
            //Instantiate boss ctp
            Instantiate(ctpPrefab, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), Quaternion.identity);

            ctpInstantiated = true;
        }
        if(currentHealth <= 0)
        {
            hasDied = true;
           // gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == TagsManager.bullet && currentHealth>0)
        {
            transform.localScale = initialScale * .8f;
            transform.rotation = Quaternion.Euler(0f, 0f, -30f);

            TakeDMG(damage);
        }
    }

    void TakeDMG(float ammout)
    {
        currentHealth -= ammout;
        if (currentHealth <= 0)
        {
            hasDied = true;
            Destroy(gameObject);

        }
    }

}
