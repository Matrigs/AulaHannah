using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void OnTriggerEnter2D (Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {

            //SceneManager.LoadScene("level-2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
            
        }

        


    }

}