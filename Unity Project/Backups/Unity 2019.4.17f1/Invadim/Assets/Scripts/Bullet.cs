using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float force = 400f;

    Rigidbody2D rb;
   public GameObject vadim;
    float countDown;
    float delay = 5f;

    private void Start()
    {
        vadim = GameObject.Find("Vadim");
        countDown = delay;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * force, ForceMode2D.Force);
    }


    private void Update()
    {
        countDown -= Time.deltaTime;


        if(countDown <=0)
        {
            Destroy(gameObject);
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == TagsManager.gaina)
        {
         //   vadim.GetComponent<Vadim>().kills++;
            Destroy(gameObject);
        }
    }
}
