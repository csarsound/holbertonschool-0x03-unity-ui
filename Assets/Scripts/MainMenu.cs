using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // materials
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    // PlayMaze function
    public void PlayMaze()
    {
            
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    // quit game function ^^^
}
