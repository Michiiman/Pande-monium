using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Cube  ; 
    public float speed = 5f;

    
    void Start()
    {
       Cube = GameManager.Instance.player.transform;
    }


    void Update()
    {
        if (Cube != null)
        {
            // Calcula la direcci�n hacia el objetivo
            Vector3 direction = Cube.position - transform.position;

            // Normaliza la direcci�n para mantener una velocidad constante
            Vector3 normalizedDirection = direction.normalized;

            // Calcula la nueva posici�n hacia la cual se mover� el objeto
            Vector3 newPosition = transform.position + normalizedDirection * speed * Time.deltaTime;

            // Mueve el objeto hacia la nueva posici�n
            transform.position = newPosition;
            
        }
    }

}
