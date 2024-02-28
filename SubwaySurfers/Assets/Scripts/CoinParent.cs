using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParent : MonoBehaviour
{
    [SerializeField] List<GameObject> Coins = new List<GameObject>();

    private void OnEnable()
    {
        for (int i = 0; i < Coins.Count; i++)
        {
            Coins[i].SetActive(true);
        }
    }
}
