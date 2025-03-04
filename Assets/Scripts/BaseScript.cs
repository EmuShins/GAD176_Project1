using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public Player player;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected int Randomizer(int minNumber, int maxNumber)
    {
        int randomNumber=Random.Range(minNumber, maxNumber);
        Debug.Log("Number was randomized between: " + minNumber + " " + maxNumber + ". The random number is: " + randomNumber);
        return randomNumber;
    }
}
