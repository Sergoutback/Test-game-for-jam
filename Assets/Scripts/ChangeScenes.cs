using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeTo0_MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeTo1_GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeTo2_SettingsScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeTo3_MainScene()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
