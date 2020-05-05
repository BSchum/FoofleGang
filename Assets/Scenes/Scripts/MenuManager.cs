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

    public void SetDifficulty(GameManager.Difficulty choix)
    {
        GlobalVariable.Instance.difficulty = choix;
    }

    public void OnClickDropdown(int choix)
    {
        GameManager.Difficulty difficulty = GameManager.Difficulty.Medium;
        switch (choix)
        {
            case 1 :
                difficulty = GameManager.Difficulty.Medium;
                break;
            case 2 :
                difficulty = GameManager.Difficulty.Medium;
                break;
            case 3:
                difficulty = GameManager.Difficulty.Medium;
                break;
            default:
                difficulty = GameManager.Difficulty.Medium;
                break;
        }

        this.SetDifficulty(difficulty);
    }
}
