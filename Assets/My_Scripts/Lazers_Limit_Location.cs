using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazers_Limit_Location : MonoBehaviour
{

    private void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);
    }

}
