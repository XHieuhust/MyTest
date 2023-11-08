using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Obsacle
{
    
    public override void beHitted()
    {
        rigidObsacle.isKinematic = false;
        float directionX = Random.Range(-0.2f, 0.2f);
        rigidObsacle.AddForce(new Vector2(directionX, 1) * ForceFly);
    }

}
