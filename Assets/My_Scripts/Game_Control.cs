using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Control : MonoBehaviour
{

     public GameObject asteroid;
     public Vector3 randomPos;
     public float start_time;
     public float loop_time;
     public float end_time;
     public Text text;
     public Text Game_Over_Text;
     public Text Restart_Text;
     bool GameOverControl = false;
     bool RestartControl = false;
     int score;

     void Start()
     {
         score = 0;
         text.text = "Score = " + score;
         StartCoroutine(create());
     }
     
     void Update()
     {
        if (Input.GetKeyDown(KeyCode.R) && RestartControl)
        {
            SceneManager.LoadScene("Space Shooter");
        }  
     }

    IEnumerator create()
     {
         yield return new WaitForSeconds(start_time);

         while (true) 
         {

               for (int i = 0; i < 10; i++) 
               { 
                  Vector3 vec = new Vector3 (Random.Range(-randomPos.x,randomPos.x), 0, randomPos.z);
                  Instantiate(asteroid, vec, Quaternion.identity);
                  yield return new WaitForSeconds(loop_time);
               }

               if (GameOverControl)
               {
                  Restart_Text.text = "Press R for restart the game";
                  RestartControl = true;
                  break;
               }


             yield return new WaitForSeconds(end_time);

         }
     }

     public void Scoreincrease(int Scorecomefrom)
     {
         score += Scorecomefrom;
         text.text = "Score = " + score;
         Debug.Log(score);
     }
     
     
     
     public void GameOver()
     {
        Game_Over_Text.text = "Game Over";
        GameOverControl = true;
     }
 }
