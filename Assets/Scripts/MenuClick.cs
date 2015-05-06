using UnityEngine;
using System.Collections;

public class MenuClick : MonoBehaviour {

	// Use this for initialization
    void OnMouseDown()
    {
        Debug.Log("Loading shit");
        Application.LoadLevel(1);
    }
}
