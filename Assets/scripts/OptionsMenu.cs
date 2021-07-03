using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    // Array com todas as resoluções possiveis
    Resolution[] availableRes;

    //dropdown do menu com todas as opções de resolução 
    public TMP_Dropdown resDropdown;

    // Start is called before the first frame update
    void Start()
    {
        //conteudo do array = as resoluções de tela
        availableRes = Screen.resolutions;

        //limpa as opções padrões do dropdown
        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        //resolução selrcionada 
        int resAtual = 0;

        //enquanto o número de loops for entre 0 e o total de resoluções, passa por esse código e aumenta o número de loops em 1
        for (int i = 0; i < availableRes.Length; i++)
        {

            string option = availableRes[i].width + " x " + availableRes[i].height;
            resOptions.Add(option);

            if (availableRes[i].width == Screen.currentResolution.width && availableRes[i].height == Screen.currentResolution.height)
            {
                resAtual = i;

            }

            resDropdown.AddOptions(resOptions);
            resDropdown.value = resAtual;
            resDropdown.RefreshShownValue();
        }

    }
    public void ChangeResolution(int resolution) 
    {   //ele irá mudar a resolução quando a gente buldar a partir do selecionada no dropdown
        Resolution selecionada = availableRes[resolution];
        Screen.SetResolution(selecionada.width, selecionada.height, Screen.fullScreen); 

    }
    
    public void ChangeGraphics (int graphics)
    {
        QualitySettings.SetQualityLevel(graphics);
   
    }

    public void FullScreen(bool fullscreen) 
    {

        Screen.fullScreen = fullscreen;

    }

}
