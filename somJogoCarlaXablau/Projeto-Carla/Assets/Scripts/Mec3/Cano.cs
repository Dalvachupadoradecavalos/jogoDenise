using UnityEngine;

public class Cano : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento
    public bool calabreso = false;

    void Update()
    {
        // Move o objeto ao longo do eixo Z
        transform.position += Vector3.forward * velocidade * Time.deltaTime;

        if (calabreso)
        {
            Debug.Log("Deu certo essa porra");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Imprime uma mensagem no console quando colidir com outro objeto
        calabreso = true;
        Debug.Log("Colidiu com: " + collision.gameObject.name);
    }
}