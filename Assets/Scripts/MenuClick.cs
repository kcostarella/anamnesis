﻿using UnityEngine;
using System.Collections;

public class MenuClick : MonoBehaviour {

	// Use this for initialization
    void OnMouseDown()
    {
        Application.LoadLevel(2);
    }
}
