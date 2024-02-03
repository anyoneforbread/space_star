using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
    public string scene;
    public void change_scene()
    {
        SceneManager.LoadScene(scene);
    }
}
