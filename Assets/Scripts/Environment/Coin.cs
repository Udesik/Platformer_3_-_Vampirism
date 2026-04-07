using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public event Action PickedUp;
    
    public void Collect(Collector collector)
    {
        collector.AddCoin();
        PickedUp?.Invoke();
    }
}

