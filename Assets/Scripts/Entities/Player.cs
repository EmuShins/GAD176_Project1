using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DefaultEntity
{
    private int lives=3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndGame()
    {
        if(lives<=0)
        {
            Debug.Log("Oh no, the player ran out of lives! The game has ended.");
            Time.timeScale=0;
        }

    }

    protected virtual void Input()
    {

    }

    protected virtual void SwapWeapon()
    {

    }
}
