using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        //play the game sound
        GetComponentInChildren<AudioManager>().Play(TagsManager.GameSound, true);
    }
}
