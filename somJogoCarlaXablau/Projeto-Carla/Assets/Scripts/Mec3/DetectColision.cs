using UnityEngine;

public class DetectColision : MonoBehaviour
{
    // Este método é chamado quando uma colisão ocorre
    private void OnCollisionEnter(Collision collision)
    {
        // Emite uma mensagem de debug no console
        Debug.Log("Colisão detectada com: " + collision.gameObject.name);
    }
}