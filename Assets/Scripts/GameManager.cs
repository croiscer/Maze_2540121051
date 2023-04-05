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
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            canMove = true;
            tutorialText.SetActive(false);
        }
    }

}
