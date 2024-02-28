using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    public static CloneManager instance = null;
    [SerializeField] List<GameObject> Obstacles = new List<GameObject>();
    int endZPos = 2;
    List<int> zPosList = new List<int>();
    [SerializeField] Transform road1;
    [SerializeField] Transform road2;
    List<int> posXList = new List<int> { -2, 0, 2 };
    [SerializeField] List<int> randomXPosList = new List<int>();
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
    void Start()
    {
        for (int i = 0; i < Obstacles.Count; i++)
        {
            SimplePool.Preload(Obstacles[i], 20);
        }

        ZPosListAdd();

        ObstacleCreate(road1);
        ObstacleCreate(road2);
    }

    public void ObstacleCreate(Transform road)
    {
        while (endZPos <= 38)
        {

            randomXPosList = GetRandomElements(posXList, 2);

            for (int i = 0; i < 2; i++)
            {
                GameObject obstacle = SimplePool.Spawn(Obstacles[Random.Range(0, Obstacles.Count)], road.position, Quaternion.identity);
                obstacle.transform.parent = road;

                road.GetComponent<Road>().Obstacles.Add(obstacle);

                int posX = randomXPosList[i];

                bool isDistance = GetRoadObstacle(road.GetComponent<Road>(), obstacle);

                zPosList[i] += isDistance ? (int)obstacle.transform.localScale.z : 0;

                obstacle.transform.localPosition = new Vector3(posX, 0, zPosList[i]);

                zPosList[i] += (int)obstacle.transform.localScale.z + Random.Range(2, 5);

            }
            int max = zPosList.Max(r => r);
            endZPos = max;
            randomXPosList.Clear();

        }
        endZPos = 4;
        zPosList.Clear();
        ZPosListAdd();

    }

    List<int> GetRandomElements(List<int> sourceList, int count)
    {
        List<int> tempList = new List<int>(sourceList);

        List<int> selectedElements = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            int selectedElement = tempList[randomIndex];

            tempList.RemoveAt(randomIndex);
            selectedElements.Add(selectedElement);
        }

        return selectedElements;
    }

    bool GetRoadObstacle(Road road, GameObject obstacle)
    {
        for (int i = road.Obstacles.Count - 1; i > 0; i--)
        {
            if (obstacle.transform.position.x == road.Obstacles[i].transform.position.x &&
            (obstacle.transform.position.z - road.Obstacles[i].transform.position.z) < road.Obstacles[i].transform.localScale.z / 2)
            {
                return true;
            }

        }

        return false;
    }
    void ZPosListAdd()
    {
        for (int i = 0; i < 2; i++)
        {
            zPosList.Add(4);
        }
    }

}

