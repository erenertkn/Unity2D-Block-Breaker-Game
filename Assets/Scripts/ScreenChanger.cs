using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{

    public void ChangeTheScene()
    {
        SceneManager.LoadScene(SceneController());
    }

    private int GetSceneNumber()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private int SceneController()
    {
        if(GetSceneNumber()!=SceneManager.sceneCountInBuildSettings-1)
        {
            return (GetSceneNumber() + 1);
        }
        else
        {
            FindObjectOfType<Status>().DestroyThisStat();
            return 0;
        }
    }
}
