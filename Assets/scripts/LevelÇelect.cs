using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelÇelect : MonoBehaviour
{
    public List <GameObject> fases;
    GameObject selectedLevel;
    public void Start() 
    {
        foreach (Transform child in transform) 
        {
            fases.Add(child.gameObject);
        }

    } 

    
    public void LevelChange()
    {
        selectedLevel = EventSystem.current.currentSelectedGameObject;
        SceneManager.LoadScene(fases.IndexOf(selectedLevel.gameObject)+2);

    }
}
