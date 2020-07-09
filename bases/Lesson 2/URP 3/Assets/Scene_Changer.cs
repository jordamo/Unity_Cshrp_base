using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{

    public event EventHandler<int> ChangeSceneEvent;
    private int max_scenes;
    private void Awake()
    {
        max_scenes = SceneManager.sceneCount+1;
        ChangeSceneEvent += ChangeScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeSceneEvent?.Invoke(gameObject, SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ChangeScene(object sender, int id)
    {
        SceneManager.LoadScene((id+1)%max_scenes);
    }
}
