using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainaBullet : MonoBehaviour
{
    float force = 400f;

    [SerializeField]
    float damage = 50;
    
    Rigidbody2D rb;

    float countDown;
    float delay = 5f;

    Vadim vadim;
    private void Start()
    {
        vadim = GameObject.Find("Vadim").GetComponent<Vadim>();
        countDown = delay;
        rb = GetComponent<Rigidbody2D>();
        //getting reference to vadim
        rb.AddForce(Vector2.left * force, ForceMode2D.Force);
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
        if (collision.collider.tag == TagsManager.vadim)
        {
            Debug.LogError("Collision with+ " + collision.collider.name);
            vadim.TakeDMG(damage);
        }
    }
}
