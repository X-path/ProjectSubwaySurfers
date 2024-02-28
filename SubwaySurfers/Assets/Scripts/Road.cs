using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]public float Speed;
    [SerializeField] public List<GameObject> Obstacles = new List<GameObject>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.GState != GameState.Play)
            return;

        HandleMovement();
    }
    void HandleMovement()
    {
        transform.Translate(0, 0, -Speed * Time.deltaTime);
    }

    public void Reset()
    {
        for (int i = Obstacles.Count - 1; i > 0; i--)
        {
            Obstacles[i].transform.parent = null;
            SimplePool.Despawn(Obstacles[i]);
        }

        CloneManager.instance.ObstacleCreate(this.transform);

    }

}
