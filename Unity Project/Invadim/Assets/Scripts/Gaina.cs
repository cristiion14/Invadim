using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaina : MonoBehaviour
{
    Rigidbody2D rb;

    float timeBTWShoots = 3f;

    [SerializeField]
    float health = 100f;

    [SerializeField]
    float damage = 100;

    float speed = 5f;
   public Transform deadZoneLeft, deadZoneRight;

    Vadim vadim;

    public GameObject bullet;

    private void Start()
    {
        vadim = GameObject.Find("Vadim").GetComponent<Vadim>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Die();
        Movement();
        StartCoroutine(Shoot());
    }


    public bool canMoveLeft = true;
    void Movement()
    {
        if(canMoveLeft)
            transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= deadZoneLeft.position.x)
        {
            Debug.LogError("Stanga");
            canMoveLeft = false;
            rb.velocity += Vector2.right * 400 * Time.deltaTime;
            //transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (transform.position.x >= deadZoneRight.position.x)
        {
            Debug.Log("Dreapta");
            rb.velocity = Vector3.left * 400 * Time.deltaTime;

        }
    }


   IEnumerator Shoot()
    {
        Instantiate(bullet);
        yield return new WaitForSeconds(timeBTWShoots);
        Instantiate(bullet);


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == TagsManager.bullet)
            TakeDMG(damage);
    }

    void TakeDMG(float ammout)
    {
        health -= ammout;
    }

    void Die()
    {
        if (health <= 0)
            Destroy(gameObject);

        health = 100;
    }
}
