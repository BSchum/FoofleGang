using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneManager : MonoBehaviour
{
    public void StartGameScene()
    {
        GlobalVariable.Instance.plane = ARSession.FindObjectOfType<ARPlane>();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void StartPlaneScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlaneDetectionScene", LoadSceneMode.Single);
    }
}
