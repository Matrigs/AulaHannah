using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play () 
    {
        SceneManager.LoadScene("level-1");
        
        
    }

    public void Exit () 
    {
        Application.Quit();
        Debug.Log("Você saiu do jogo");


    }

}