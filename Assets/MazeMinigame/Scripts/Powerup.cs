using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Powerup
{
    
    public abstract void powerup(GameObject character);

    public abstract int getSpawnRate();

}
