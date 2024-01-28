using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ProyectileLogic : MonoBehaviour
{
    public float fuerza = 5f;
    public Vector3 dir = Vector3.up;
    public float timeAlive = 4f;
    [SerializeField] private float velocidadRotacion = 30f;
    public GameObject Sprite;

    public void Setup(Vector3 direction)
    {
        dir = direction;
        StartCoroutine(ProjectileTime());
    }

    private void Start()
    {
        AddForceToDirection();
    }

    private void AddForceToDirection()
    {
        if (dir == Vector3.zero) dir = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        dir.Normalize();
        
        
        transform.Translate(dir * fuerza * Time.deltaTime);
    }

    private void Update()
    {
        AddForceToDirection();
        Sprite.transform.Rotate(new Vector3(0, 0, 1), velocidadRotacion * Time.deltaTime);
    }

    private IEnumerator ProjectileTime()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().DeathSound();
        }
    }
}