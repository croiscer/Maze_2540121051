using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    private bool canMove;
    public bool CanMove { get => canMove; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        canMove = false;

        Screen.SetResolution(Screen.width, Screen.width / 16 * 9, true);
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            canMove = true;
            tutorialText.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
