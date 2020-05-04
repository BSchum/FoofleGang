using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceInGame : MonoBehaviour
{
    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        //SceneManager.LoadScene(0);
    }
}
