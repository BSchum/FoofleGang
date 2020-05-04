using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string launchScene;
    public void LaunchScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(launchScene, LoadSceneMode.Single);
    }

    public void LeaveApplication()
    {
        Application.Quit();
    }
}
