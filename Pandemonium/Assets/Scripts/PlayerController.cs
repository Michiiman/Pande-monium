using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private ProyectileLogic roller;
    [SerializeField] private AudioSource deathSound;

    void Update()
    {
        /// 
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

        if (GameManager.Instance.CurrentState != GameState.Gameplay) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput * speed* Time.deltaTime, 0f, verticalInput * speed* Time.deltaTime) ;
        transform.Translate(movement);

        // anims
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
    }

    private void Start()
    {
        StartCoroutine(AttackPlayerRoutine());
    }

    private void PlayerAttack()
    {
        if (GameManager.Instance.CurrentState != GameState.Gameplay) return;
        ProyectileLogic Proyectile_Clone = Instantiate(roller, transform.position, Quaternion.identity);
        Proyectile_Clone.Setup(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    IEnumerator AttackPlayerRoutine()
    {
        while (true)
        {
            PlayerAttack();
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.CurrentState != GameState.Gameplay) return;
        Debug.Log("collide");
        if (other.gameObject.CompareTag("Enemy"))
        {
            // PlayerDie
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        deathSound.Play();
        GameManager.Instance.LoseGame();
    }
}