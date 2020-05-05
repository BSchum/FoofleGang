using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GlobalVariable
{
    public float planeY;
    public GameManager.Difficulty difficulty { get; set; } = GameManager.Difficulty.Medium;

    public Player player { get; set; }


    #region Init / Gestion du singleton

    private static GlobalVariable instance;
    public static GlobalVariable Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GlobalVariable();
            }

            return instance;
        }
    }
    #endregion

}
