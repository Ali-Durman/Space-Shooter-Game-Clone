using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids_Movement : MonoBehaviour
{

    Rigidbody fizik;
    public float AsteroidHiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * AsteroidHiz;
    }
}
