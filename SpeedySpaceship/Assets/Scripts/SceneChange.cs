using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneName;

    public void Run()
    {
        Debug.Log("Switching to scene " + SceneName);
        SceneManager.LoadScene(SceneName);
    }

}
