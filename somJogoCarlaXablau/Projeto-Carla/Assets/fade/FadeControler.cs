using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControler : MonoBehaviour
{
    public GameObject fadeObj;

    public void StartFadeOut(){
        Animator aniFade = fadeObj.GetComponent<Animator>();
        aniFade.SetBool("fadeout",true);
    }
}
