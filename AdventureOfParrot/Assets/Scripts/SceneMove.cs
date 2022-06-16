using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Stage");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Start");
    }
}
