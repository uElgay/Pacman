using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text txt;

    void Start()
    {
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
        txt.text="Score : "+PlayerDeath.Instance.score.ToString();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }

    void Update()
    {
        if(Input.GetKey("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }
}