using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public void SelectFase()
    {
        SceneManager.LoadScene("levelÇelect");
        
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);


    }


}

