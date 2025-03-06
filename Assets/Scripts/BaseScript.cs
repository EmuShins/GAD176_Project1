using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public Player player;

    #region Randomizer, randomizes the inputted number. For general use.
    protected int Randomizer(int minNumber, int maxNumber)
    {
        int randomNumber=Random.Range(minNumber, maxNumber);
        Debug.Log("Number was randomized between: " + minNumber + " " + maxNumber + ". The random number is: " + randomNumber);
        return randomNumber;
    }
    #endregion

    public IEnumerator WaitRoutine(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
