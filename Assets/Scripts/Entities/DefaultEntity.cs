using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEntity : MonoBehaviour
{
    protected int health=100;
    protected float moveSpeed=1f;
    protected Vector3 location;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected virtual void Move(Vector3 targetLocation, Vector3 currentLocation)
    {
        //moves from the currentLocation to the targetLocation gradually.

    }

    protected int Randomizer(int minNumber, int maxNumber)
    {
        int randomNumber=Random.Range(minNumber, maxNumber);
        Debug.Log("Number was randomized between: " + minNumber + " " + maxNumber + ". The random number is: " + randomNumber);
        return randomNumber;
    }

    protected virtual void Attack()
    {

    }
}
