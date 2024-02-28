using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("Obstacle");
            other.gameObject.transform.root.GetComponent<Player>().ObstacleCrash();
        }
    }
    
}
