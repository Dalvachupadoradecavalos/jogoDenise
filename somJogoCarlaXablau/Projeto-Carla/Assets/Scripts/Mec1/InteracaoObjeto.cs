using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteracaoObjeto : MonoBehaviour
{
    public Transform posicaoSegurando; //  posição e rotação onde o objeto será segurado.
    private GameObject objetoSegurado; // Armazena o objeto atualmente segurado.
    public GameObject localColocacao; // Indica onde o objeto deve ser colocado ao soltar.

    public void OnPegar() 
    {
        // Physics.OverlapSphere: Cria uma esfera invisível em torno do jogador para detectar objetos próximos.
      
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f); // Verifica objetos próximos 
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Pegavel")) // Objeto válido para pegar
                {
                    objetoSegurado = collider.gameObject;
                    objetoSegurado.GetComponent<Rigidbody>().isKinematic = true; // Desativa a física do objeto para
                                                            //  que ele não caia ou seja influenciado pela gravidade enquanto está sendo segurado.
                    break;
                }
            }
        
    }

    public void OnSoltar()
    {

        if (objetoSegurado != null && localColocacao != null) // Solta no local correto
        {
            objetoSegurado.transform.SetParent(null); // Remove o objeto do controle do jogador (não é mais "filho" do jogador no hierarchy).
            objetoSegurado.transform.position = localColocacao.transform.position; // Coloca o objeto na posição exata do local designado.
            objetoSegurado.GetComponent<Rigidbody>().isKinematic = false; // Reativa física
            objetoSegurado = null; // Limpa a referência ao objeto segurado.
        }
        else if (objetoSegurado != null)
        {
            objetoSegurado.transform.SetParent(null);
            objetoSegurado.GetComponent<Collider>().isTrigger = true; // desativa colisões sólidas do objeto
            objetoSegurado.GetComponent<Rigidbody>().isKinematic = false; // Reativa física
            objetoSegurado = null; //  Limpa a referência ao objeto.
        }
    }

    private void Update()
    {
        // Mantém o objeto segurado na frente do jogador
        if (objetoSegurado != null)
        {
            objetoSegurado.transform.position = posicaoSegurando.position; // posição do objeto segurado como a mesma da posição indicada por posicaoSegurando.
            objetoSegurado.transform.rotation = posicaoSegurando.rotation; // rotação do objeto segurado para coincidir com a rotação do posicaoSegurando.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Colocavel")) 
        {
            localColocacao = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Colocavel"))
        {
            localColocacao = null;
        }
    }
}
