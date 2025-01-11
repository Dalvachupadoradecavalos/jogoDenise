using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class esfera : MonoBehaviour
{
    public float obj;
    [SerializeField] private string nomeDoLevelDeJogoFinal;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("objeto3"))
        {
            Debug.Log("coletou !!!");

                Destroy(other.gameObject);
                obj++;
                if(obj == 1)
                {
                    SceneManager.LoadScene(nomeDoLevelDeJogoFinal);
                }

        }
    }
}
