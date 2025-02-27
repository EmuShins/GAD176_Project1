using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
     void IMoveInput();
     float IMovePlayer(float moveTo, float moveFrom);
     void IMoveCamera();
     void IWeaponInput();
}
