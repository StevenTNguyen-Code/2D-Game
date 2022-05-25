using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

//This script was provided by Brackeys video on Enemies in 2D games. 
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath; 

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.1f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);

        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale= new Vector3 (1f,1f,1f); 
        }
    }
}
