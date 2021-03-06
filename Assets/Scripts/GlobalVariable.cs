﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GlobalVariable
{
    public float planeY;
    public GameManager.Difficulty difficulty { get;  set; }

    public Player player { get; set; }

    public float gameScore = 0;


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
