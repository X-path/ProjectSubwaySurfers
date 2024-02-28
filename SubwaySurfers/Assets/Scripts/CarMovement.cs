using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        if (UIManager.instance.GState != GameState.Play)
            return;

        HandleMovement();
    }
    void HandleMovement()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
