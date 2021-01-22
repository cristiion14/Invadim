using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gaina : MonoBehaviour
{
    EnemySpawner enemySpawner;
    Rigidbody2D rb;

    float timeBTWShoots = 3f;

   public float health = 100f;

    float damage = 25;

    float speed = 5f;

    Vadim vadim;

    public GameObject bullet;
    public Transform trigger;

    GameManager GM;

    Quaternion initialRot;
    Vector3 initialScale;
    public float vFreq, vAmp, vOffset, vPhase;
    public float hFreq, hAmp, hOffset, hPhase;
    public float theZ;
    float timeSinceShot = 0f;


    float rangeOffset = 2f;
    private void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GameManager>();
        vadim = GameObject.Find("Vadim").GetComponent<Vadim>();
        rb = GetComponent<Rigidbody2D>();
        initialRot = transform.rotation;
        initialScale = transform.localScale;
        enemySpawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }


    private void Update()
    {
        Movement();
        Shoot();
        timeSinceShot += Time.deltaTime;

        if (gameObject.tag == TagsManager.CTP)
            damage = 15;
    }


    public bool canMoveLeft = true;
    void Movement()
    {

        Vector3 desiredPos = new Vector3(
            Mathf.Sin(Time.time * hFreq + hPhase) * hAmp + hOffset,
            Mathf.Sin(Time.time * vFreq + vPhase) * vAmp + vOffset
            , transform.position.z);
        Debug.Log(desiredPos);
        rb.MovePosition(desiredPos);
        transform.localScale = Vector3.Lerp(transform.localScale, initialScale, Time.deltaTime * 5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRot, Time.deltaTime * 5f);
    }


   void Shoot()
    {
       List<GameObject> bullets = new List<GameObject>();

        if (timeSinceShot > timeBTWShoots)
        {
            timeBTWShoots = Random.Range(0.5f, 3f);
            
           GM.enemyBullets.Add(Instantiate(bullet, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), transform.position.z+ Random.Range(-3, 3)), Quaternion.identity));
            timeSinceShot = 0f;
        }

        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == TagsManager.bullet)
        {
            transform.localScale = initialScale * .8f;
            transform.rotation = Quaternion.Euler(0f, 0f, -30f);

            TakeDMG(damage);
        }
    }

    bool hasDiedCTP = false;
    void TakeDMG(float ammout)
    {
        health -= ammout;
        if (health <= 0)
        {
            if(gameObject.tag == TagsManager.CTP)
            {
                //GAME OVER!!!
                GM.GameWin.enabled = true;
                vadim.enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
            enemySpawner.SpawnEnemy();
            Destroy(gameObject);
        }
    }


    public bool targetFound(Vector3 target)
    {
        float distance = (target - transform.position).sqrMagnitude;
        if (distance <= rangeOffset * rangeOffset)
            return true;
        else
            return false;
    }
}
