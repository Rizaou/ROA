using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    [Header("Characters"), 
    SerializeField] private GameObject characterRed;   
    [SerializeField] private GameObject characterBlue;
    [SerializeField] private GameObject characterGreen;

    [SerializeField] private float runSpeed = 10f;
    [SerializeField] public AnimationCurve toSwimCurve;
    public AnimationCurve toPathCurve;

    private void Start()
    {
        Debug.Log(GameManager.instance.gameObject.name);
    }


    private void Update()
    {
        if (GameManager.instance.gameStarted)
            WhenGameStarted();

    }


    private void WhenGameStarted()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }


    public void PlayRunAnimation()
    {
        characterRed.GetComponent<Animator>().SetBool("gameStarted", true);
        characterGreen.GetComponent<Animator>().SetBool("gameStarted", true);
        characterBlue.GetComponent<Animator>().SetBool("gameStarted", true);
    }

}
