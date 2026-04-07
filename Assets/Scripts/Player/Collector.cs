using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ICollectible item))
        {
            item.Collect(this);
        }
    }

    public void ApplyHeal(float amount) => _health.Heal(amount);
    
    public void AddCoin() => Debug.Log("Монетка собрана!");
}