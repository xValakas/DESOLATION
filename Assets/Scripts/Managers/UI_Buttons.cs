using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
