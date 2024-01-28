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
            // Calcula la dirección hacia el objetivo
            Vector3 direction = Cube.position - transform.position;

            // Normaliza la dirección para mantener una velocidad constante
            Vector3 normalizedDirection = direction.normalized;

            // Calcula la nueva posición hacia la cual se moverá el objeto
            Vector3 newPosition = transform.position + normalizedDirection * speed * Time.deltaTime;

            // Mueve el objeto hacia la nueva posición
            transform.position = newPosition;
            
        }
    }

}
