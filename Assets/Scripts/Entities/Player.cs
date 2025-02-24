using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DefaultEntity, IPlayer
{
    private int lives=3;
    private float moveDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IGetInput();
    }

    private void EndGame()
    {
        if(lives<=0)
        {
            Debug.Log("Oh no, the player ran out of lives! The game has ended.");
            Time.timeScale=0;
        }

    }

    public void IGetInput()
    {
        playerLocation = transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Player has pressed W.");
           
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("Player has pressed S.");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("Player has pressed D.");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Player has pressed A.");
        }
    }

    protected virtual void SwapWeapon()
    {

    }
}
