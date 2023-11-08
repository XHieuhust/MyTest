using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : Obsacle
{   
    
    public override void beHitted()
    {
        rigidObsacle.isKinematic = false;
        float directionX = Random.Range(-0.7f, 0.7f);
        rigidObsacle.AddForce(new Vector2(directionX, 1) * ForceFly);
    }

}
