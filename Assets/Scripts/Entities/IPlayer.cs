using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
     void IGetInput();
     float IMovePlayer(float moveTo, float moveFrom);
}
