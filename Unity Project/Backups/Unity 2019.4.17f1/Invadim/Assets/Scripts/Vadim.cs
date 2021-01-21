using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vadim : MonoBehaviour
{
    public int lifes = 3;

    public GameObject loseMessage;
    Transform initialPos;

    float initialHealth = 100f;
    public float currentHealth;

    float speed = 10;
    Vector3 velocity;

    GameObject vadimToInstantiate;
    Quaternion initialRot;

    GameManager GM;
    bool hasDied = false;
    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GameManager>();
        vadimToInstantiate = this.gameObject;
        initialPos = transform;
        initialRot = transform.rotation;
        currentHealth = initialHealth;
    }

    void Move()
    {
        //the x and y values based on input
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        //direction
        velocity = new Vector2(xPos, yPos);


        //applying direction to the position of the player
        transform.position += velocity * speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.8f, 8f),
                                         Mathf.Clamp(transform.position.y, -4f, 4.3f), 0f
                                                    );
        if (currentHealth <= 0f)
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        //transform.localEulerAngles = new Vector3(0, 0, velocity.y);
    }

    void Update()
    {
        if (!hasDied)
        {
            Move();
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRot, Time.deltaTime * 5f);
        }
    }

   public void TakeDMG(float ammout)
    {
        currentHealth -= ammout;
        transform.rotation = Quaternion.Euler(0f, 0f, 30f);
        if (currentHealth <= 0 && !hasDied)
        {
            //play death song 
            GM.audioManager.Play(TagsManager.DeathSound, false);

            //stop the game theme
            GM.audioManager.Stop(TagsManager.GameSound);

            //show the lose message
            loseMessage.SetActive(true);

            //restart level
            StartCoroutine(RestartLevel(3f));

            hasDied = true;
            lifes--;
            
        }
    }
    IEnumerator RestartLevel(float t)
    {
        yield return new WaitForSeconds(t);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}