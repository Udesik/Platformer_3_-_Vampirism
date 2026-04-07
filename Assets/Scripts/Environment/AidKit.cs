using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour, ICollectible
{
    [SerializeField] private float _healAmount = 20f;

    public void Collect(Collector collector)
    {
        collector.ApplyHeal(_healAmount);
        Destroy(gameObject);
    }
}
