using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int AttackedHash = Animator.StringToHash("Attacked");

    public void UpdateSpeed(float speed)
    {
        _animator.SetFloat(SpeedHash, Mathf.Abs(speed));
    }

    public void UpdateAttacked(bool attacked)
    {
        _animator.SetBool(AttackedHash, attacked);
    }

    public void Flip(float direction)
    {
        if (direction == 0) return;
        
        float xSize;
        
        if (direction > 0) 
        {
            xSize = 5f;
        } 
        else 
        {
            xSize = -5f;
        }
        
        transform.localScale = new Vector3(xSize, 5f, 1f);
    }
}