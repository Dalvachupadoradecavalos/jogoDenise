using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class carroandando : MonoBehaviour
{
    public float vel;
    Rigidbody rb;
    public GameObject Parede;
    public bool Ativo=true;
    public GameObject obj;
    [SerializeField] private string nomeDoLevelDeJogo;
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
         if(Ativo==true){
        rb.velocity = new Vector3(vel, 0);}
        else{
            rb.velocity = new Vector3(0, 0);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("parede"))
        {
            Debug.Log("bateu !!!");
            Destroy(obj);
            SceneManager.LoadScene(nomeDoLevelDeJogo);
        }
 
    }
    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject==Parede){
             Debug.Log("Venceu !!!");
             Ativo=false;
             vel=0;
        }

    }



    }


