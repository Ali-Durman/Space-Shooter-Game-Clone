using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Control : MonoBehaviour
{
    Rigidbody fizik;
    public float LazerHiz;
      void Start()
      {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward*LazerHiz;
      }

}
