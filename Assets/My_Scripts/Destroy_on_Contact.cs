using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_on_Contact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Player_Explosion;
    GameObject gamecontrol;
    Game_Control Control;

    private void Start()
    {
        gamecontrol = GameObject.FindGameObjectWithTag("GameControl");
        Control = gamecontrol.GetComponent<Game_Control>();
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.tag != "Limit")
         {
            Destroy(other.gameObject); // Bize çarpan veya bize gelen oyun objesini yok ediyoruz.
            Destroy(gameObject);       // Kendimizi (sc yi yazdýðýmýz objeyi) yok ediyoruz.
            Instantiate (Explosion, transform.position, transform.rotation);
            Control.Scoreincrease(10);
         }

        if (other.tag == "Player")
        {
            Instantiate (Player_Explosion, other.transform.position, other.transform.rotation);     // Bir objeyi oluþturmamýza yarayan kod Instantiate.
            Control.GameOver();
        }
        

    }
}
