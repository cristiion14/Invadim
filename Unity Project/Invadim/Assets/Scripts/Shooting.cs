using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    GameManager GM;
   public VadimAnimation vadimAnim;
    float countDown = 3f;
    List<GameObject> bulletList;
    public Transform vadimTrigger;


    private void Awake()
    {
        //getting a reference to the game manager
        GM = GameObject.Find("GM").GetComponent<GameManager>();
    }
    void Shoot()
    {
        //shoot the bullet
        Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y), Quaternion.identity);

        //apply shooting animation
        vadimAnim.Scuipa();

        //apply shooting sound
        GM.GetComponentInChildren<AudioManager>().Play(TagsManager.ScuipatSound, false);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        //starting countdown to destroy bullet
        countDown -= Time.deltaTime;



    }
}
