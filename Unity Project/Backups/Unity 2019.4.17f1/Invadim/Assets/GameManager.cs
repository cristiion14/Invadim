using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
   public List<GameObject> playerBullets = new List<GameObject>();
   public List<GameObject> enemyBullets = new List<GameObject>();
    float timeToDestroyBullets = 3f;

    private void Start()
    {
        //Play game theme
        audioManager.Play(TagsManager.GameSound, true);
    }

    private void Update()
    {
       
    }
}
