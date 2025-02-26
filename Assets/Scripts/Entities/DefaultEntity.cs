using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEntity : MonoBehaviour , IEntity
{
    protected int health=100;
    protected float moveSpeed=1f;
    protected Vector3 location;
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {


    }
   
    protected virtual void Death()
    {
        //Default settings for an entity's death
        if(health<=0)
        {
             Debug.Log(this + " just died.");
            Destroy(gameObject);
        }
        //Destroy object
    }

    public virtual void Move(Vector3 targetLocation, Vector3 currentLocation)
    {
        //moves from the currentLocation to the targetLocation gradually.
        //.normalized might need to be removed in the future because it may affect the move speed.
        Vector3 moveTo=Vector3.Lerp(currentLocation,targetLocation,moveSpeed*Time.deltaTime);
        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }

    protected void TakeDamage(int damageReceieved)
    {
        health-=damageReceieved;
        Debug.Log(this + " took " + damageReceieved + " damage. total health is now: " + health);
        Death();
    }

    protected int Randomizer(int minNumber, int maxNumber)
    {
        int randomNumber=Random.Range(minNumber, maxNumber);
        Debug.Log("Number was randomized between: " + minNumber + " " + maxNumber + ". The random number is: " + randomNumber);
        return randomNumber;
    }

    public void IAttack()
    {

    }

}
