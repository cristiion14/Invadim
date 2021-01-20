using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VadimAnimation : MonoBehaviour
{
    public Animator vadimAnim;
    public void Scuipa()
    {
        vadimAnim.SetTrigger(TagsManager.scuipat);
    }
}
