using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DefaultEntity, IPlayer
{
    private int lives=3;
    private float moveDistance = 10f;
    private float currentPosition;

    //Used for mouse and moving the camera
    private Vector3 mousePos;
    protected  float yRotation=0f;
    private float mouseSensitivity=2f;
    public GameObject playerCamera;

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

    //Handles input for the player. This includes movement.
    #region IGetInput

    public void IGetInput()
    {
        //Simple WASD movement
        if (Input.GetKey(KeyCode.W))
        {
            currentPosition=transform.position.z;
            Debug.Log("Player has pressed W.");
            currentPosition=IMovePlayer(currentPosition+moveDistance,currentPosition);
            transform.position=new Vector3(transform.position.x,transform.position.y,currentPosition);
           
        }
        else if(Input.GetKey(KeyCode.S))
        {
            currentPosition=transform.position.z;
            Debug.Log("Player has pressed S.");
            currentPosition=IMovePlayer(currentPosition-moveDistance,currentPosition);
            transform.position=new Vector3(transform.position.x,transform.position.y,currentPosition);

        }
        else if(Input.GetKey(KeyCode.D))
        {
            currentPosition=transform.position.x;
            Debug.Log("Player has pressed D.");
            currentPosition=IMovePlayer(currentPosition+moveDistance,currentPosition);
            transform.position=new Vector3(currentPosition,transform.position.y,transform.position.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentPosition=transform.position.x;
            Debug.Log("Player has pressed A.");
            currentPosition=IMovePlayer(currentPosition-moveDistance,currentPosition);
            transform.position=new Vector3(currentPosition,transform.position.y,transform.position.z);
        }
        //Moves the camera depending on where the mouse is on the screen.
        MoveCamera();
        Debug.Log("mousePos is: " + mousePos);
    }
    #endregion

    protected virtual void SwapWeapon()
    {

    }
    
    //Performs the Lerp calculations used to move the player. Called from IGetInput.
    #region IMovePlayer
    public float IMovePlayer(float moveTo, float moveFrom)
    {
       float newPos=Mathf.Lerp(moveFrom,moveTo,moveSpeed*Time.deltaTime);
        //transform.position += newPos * moveSpeed * Time.deltaTime;
        return newPos;
    }
    #endregion
    //Moves the camera according to where the mouse cursor is on the screen. Called from IGetInput.
    #region MoveCamera
    private void MoveCamera()
    {
        float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity;
        float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity;

        yRotation-=mouseY;
        yRotation= Mathf.Clamp(yRotation, -90f, 90f);
        playerCamera.transform.localEulerAngles= Vector3.right* yRotation;

        player.transform.Rotate(Vector3.up * mouseX);
    }
    #endregion
}
