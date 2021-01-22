using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    GameManager GM;
    public VadimAnimation vadimAnim;
    float countDown = 3f;
    public Transform vadimTrigger;

    float timeToDestroy = 3f;

    public int nrScuipat = 1;
    public TextMeshProUGUI nrScuipatTXT;
    public bool hasPowerUp = false;
    public GameObject powerUp;
    private void Awake()
    {
        //getting a reference to the game manager
        GM = GameObject.Find("GM").GetComponent<GameManager>();
    }
    void Shoot()
    {
        switch(nrScuipat)
        {
            case 1:
                {
                    GM.playerBullets.Add(Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y), Quaternion.identity));
                    break;
                }
            case 2:
                {
                    GM.playerBullets.Add(Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y), Quaternion.identity));
                    GM.playerBullets.Add(Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y+.25f), Quaternion.identity));
                    break;
                }
            case 3:
                {
                    GM.playerBullets.Add(Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y), Quaternion.identity));
                    GM.playerBullets.Add(Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y+.25f), Quaternion.identity));
                    GM.playerBullets.Add(Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y-.25f), Quaternion.identity));
                    break;
                }

               


        }
        //shoot the bullet

        //apply shooting animation
        vadimAnim.Scuipa();

        //apply shooting sound
       // GM.GetComponentInChildren<AudioManager>().Play(TagsManager.ScuipatSound, false);


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        //starting countdown to destroy bullet
        countDown -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.P) && nrScuipat<=3)
            nrScuipat++;

        Debug.LogError("cate gloante ar trb sa traga: " + nrScuipat);

        nrScuipatTXT.text = nrScuipat.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger && nrScuipat<3)
        {
            Debug.LogError("A atins powerup!");
            nrScuipat++;
            Destroy(collision.gameObject);
        }

    }
}
