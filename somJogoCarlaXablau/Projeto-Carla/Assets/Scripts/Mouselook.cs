using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouselook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    private float xRotation = 0f;
    private InputAction lookAction; // o baind que colocamos no playerAction
    public InputActionAsset inputActions; // scrip saber no que esta mexendo

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked; // trava o cursor do mouse
        lookAction = inputActions.FindAction("lookAction"); // vai procurar o baind lookAcion pra mexer nela

        if (lookAction != null)
        {
            lookAction.Enable(); // vai ligar a action
        }
    }

    void Update()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>(); // passa os valores de movimentação
        CameraMovement(lookInput); // vai passar a variavel ja com a mov e jogar pra camera
    }

    private void CameraMovement(Vector2 lookInput)
    {

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX); // vai mexer na mov do eixo x 

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limita a mov da camera em 90 graus 


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}