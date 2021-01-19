using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

   public VadimAnimation vadimAnim;
    float countDown = 3f;
    List<GameObject> bulletList;
    public Transform vadimTrigger;
    void Shoot()
    {
        Instantiate(bullet, new Vector3(vadimTrigger.transform.position.x, vadimTrigger.transform.position.y), Quaternion.identity);
        //vadimAnim.vadimAnim.SetBool("CanShoot", true);
        vadimAnim.Scuipa();
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
