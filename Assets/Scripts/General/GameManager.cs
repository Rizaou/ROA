using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public CharactersMovement characters;
    public bool gameStarted = false;



    [Header("UI"),SerializeField]
    private GameObject startButton;

    private GameManager()
    {
        instance = this;
    }




    // UI Functions

    public void StartButton()
    {
        Debug.LogWarning("Game started");

        startButton.SetActive(false);


        characters.PlayRunAnimation();
        gameStarted = true;
    }




    //Properties

    public CharactersMovement PropCharacters
    {
        get
        {
            return characters;
        }
    }
}
