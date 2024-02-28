using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<Road> roads = new List<Road>();
    public float acceleration = 2f;
    private void Update()
    {
        if (UIManager.instance.GState != GameState.Play)
            return;

        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].Speed += acceleration * Time.deltaTime;
            roads[i].Speed = Mathf.Clamp(roads[i].Speed, 3, 6);
        }
        UIManager.instance.ScoreIncrease();
    }
}
