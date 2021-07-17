using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenü;
    public GameObject optionsMenü;
    public void Pause() 
    {
        Time.timeScale = 0;
        pauseMenü.SetActive(true);
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        pauseMenü.SetActive(false);
        optionsMenü.SetActive(false);
    }   

}
