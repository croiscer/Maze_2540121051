using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerScript>() != null)  
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (nextScene.Equals(""))
        {
            Debug.LogWarning("Variable 'nextScene' hasn't been set to a value");
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
