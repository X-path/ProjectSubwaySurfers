using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Spinanimation();
    }
    void Spinanimation()
    {
        transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 5, RotateMode.WorldAxisAdd)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Coin");
            this.gameObject.SetActive(false);
            UIManager.instance.CoinIncrease();
        }
    }
}
