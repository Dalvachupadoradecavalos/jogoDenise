using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class esferaMec1 : MonoBehaviour
{
    public float obj;
    [SerializeField] private string nomeDoLevelDeJogo2;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("objeto1"))
        {
            Debug.Log("coletou !!!");

                Destroy(other.gameObject);
                obj++;
                if(obj == 1)
                {
                    SceneManager.LoadScene(nomeDoLevelDeJogo2);
                }

        }
    }
}
