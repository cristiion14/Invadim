using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainaBullet : MonoBehaviour
{
    float force = 400f;

    Rigidbody2D rb;
    public GameObject vadim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //getting reference to vadim
        rb.AddForce(Vector2.right * force, ForceMode2D.Force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == TagsManager.gaina)
            Destroy(gameObject);
    }
}
