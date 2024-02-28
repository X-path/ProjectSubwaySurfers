using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadReset : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log($"Reset");
            transform.parent.position = new Vector3(0, 0, 40);
            transform.parent.GetComponent<Road>().Reset();
        }
    }
}
