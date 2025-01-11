using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = -9.81f;
    public float moveX;
    public float moveZ;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    public Animator ani;
    public Transform positionAnimationbody;
    public float objeto;
    [SerializeField] private string nomeDoLevelDeJogo1;
    
    [SerializeField] private GameObject obj1;
    


    void Start()
    {
        ani = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        positionAnimationbody.position = transform.position;
        ani.SetFloat("vertical", Input.GetAxis("Vertical"));
        ani.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        isGrounded = controller.isGrounded; // verifica se esta no chão
        if (isGrounded && velocity.y < 0) // se a velocidade for 0, ele muda a velocidade.y para que continue movimentando
        {
            velocity.y = -2f; 
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime); // executa o cc com o tempo da unity
    }
    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveX = input.x;
        moveZ = input.y;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obj"))
        {
            Debug.Log("coletou !!!");

                Destroy(other.gameObject);
                objeto++;

                if(objeto == 1)
                {
                    obj1.SetActive(false);
                    SceneManager.LoadScene(nomeDoLevelDeJogo1);
                }

                
        }  
    }
    
    
}
