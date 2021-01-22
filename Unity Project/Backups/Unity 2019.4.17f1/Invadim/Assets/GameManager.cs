using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
   public List<GameObject> playerBullets = new List<GameObject>();
   public List<GameObject> enemyBullets = new List<GameObject>();

    List<GameObject> instantiatedPowerUps = new List<GameObject>();

    float initialTimeToSpawn = 13f;
    float timeToSpawn;
    public GameObject powerUp;

   public CTP ctp;
    Vadim vadim;

    public EnemySpawner enemySpawner;

   public TextMeshProUGUI GameWin;
    private void Start()
    {
        timeToSpawn = initialTimeToSpawn;

        GameWin.enabled = false;

        vadim = GameObject.Find("Vadim").GetComponent<Vadim>();
        //Play game theme
        audioManager.Play(TagsManager.GameSound, true);
    }

    private void Update()
    {

        Debug.LogError("IS CTP DEAD?" + ctp.hasDied);

        //Spawn powerups every timeToSpawn secconds
        if(Time.time>timeToSpawn && vadim.GetComponent<Shooting>().nrScuipat <3)
        {
            instantiatedPowerUps.Add(Instantiate(powerUp, new Vector3(vadim.transform.position.x + Random.Range(-5, 5), vadim.transform.position.y + Random.Range(1, 5), 0), Quaternion.identity));
            timeToSpawn += initialTimeToSpawn;
        }

        //game win condition
        if(ctp.hasDied)
        {
            //show the game win page
            GameWin.enabled = true;
            GameWin.text = "CONGRATIULATIONS, YOU HAVE DEFEATED CTP AND THE GOUVERNMENT IS YOURS! " + " \n" + "Number of kills: " + enemySpawner.Kills;
        }

        //game lose condition
        if(vadim.hasDied)
        {
            GameWin.enabled = true;
            GameWin.text = "OOf, Vadim was killed by CTP and his army....";
        }
    }

}
