using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
   public List<GameObject> playerBullets = new List<GameObject>();
   public List<GameObject> enemyBullets = new List<GameObject>();
    float timeToDestroyBullets = 3f;

    public GameObject powerUp;
    Vadim vadim;
    private void Start()
    {
        vadim = GameObject.Find("Vadim").GetComponent<Vadim>();
        //Play game theme
        audioManager.Play(TagsManager.GameSound, true);
    }

    private void Update()
    {
        StartCoroutine(SpawnPoerUps(10));
    }

    IEnumerator SpawnPoerUps(float t)
    {
        yield return new WaitForSeconds(t);
        Instantiate(powerUp, new Vector3(vadim.transform.position.x + Random.Range(-6, 6), vadim.transform.position.y + Random.Range(-4, 4), 0), Quaternion.identity);
    }
}
