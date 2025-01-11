using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class esferaMec2 : MonoBehaviour
{
    public float obj;
    [SerializeField] private string nomeDoLevelDeJogo3;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("objeto2"))
        {
            Debug.Log("coletou !!!");

                Destroy(other.gameObject);
                obj++;
                if(obj == 1)
                {
                    SceneManager.LoadScene(nomeDoLevelDeJogo3);
                }

        }
    }
}
