using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneManager : MonoBehaviour
{
    public void StartGameScene()
    {
        GameObject sessionOrigin = GameObject.Find("/AR Session Origin");
        GameObject.Find("/PlaneScene").SetActive(false);
        sessionOrigin.GetComponent<ARRaycastManager>().enabled = false;
        sessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
        foreach (var plane in sessionOrigin.GetComponent<ARPlaneManager>().trackables) {
            plane.enabled = false;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
    }

    public void StartPlaneScene()
    {
        GameObject sessionOrigin = GameObject.Find("/AR Session Origin");
        sessionOrigin.GetComponent<ARRaycastManager>().enabled = true;
        sessionOrigin.GetComponent<ARPlaneManager>().enabled = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlaneDetectionScene", LoadSceneMode.Additive);
    }
}
