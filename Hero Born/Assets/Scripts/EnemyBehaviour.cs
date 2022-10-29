using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider rr)
    {
        if(rr.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }

    void OnTriggerExit(Collider rr)
    {
        if(rr.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
