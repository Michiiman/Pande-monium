using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    [SerializeField] private Animator animator;
    void Update()
    {
        // Obtener las entradas del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Mover el objeto
        transform.Translate(movement);
       
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Down", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Up", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }
        //// 
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Down", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Up", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
        }
    }
}
