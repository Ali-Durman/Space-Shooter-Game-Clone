using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Particle_Effect_Delete : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 3);
    }

}
