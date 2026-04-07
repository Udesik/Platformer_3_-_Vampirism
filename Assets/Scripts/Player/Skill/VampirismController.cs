using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampirismController : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private VampirismView _vampirismView;

    [SerializeField] private int _duration = 6;
    [SerializeField] private int _coolDownTime = 4;
    [SerializeField] private float _delay = 1f;
    
    private const KeyCode RadianceKey = KeyCode.E;
    private bool _isWorking = false;

    private void Update()
    {
        if (Input.GetKeyDown(RadianceKey) && !_isWorking)
        {
            StartCoroutine(StartAbility());
        }
    }

    private IEnumerator StartAbility()
    {
        _isWorking = true;
        var wait = new WaitForSeconds(_delay);

        _vampirismView.StartAbility();
        
        for (int i = 0; i < _duration; i++)
        {
            _vampirism.Tick();
            yield return wait;
        }

        _vampirismView.StartCooldown();
        
        for (int i = _coolDownTime; i > 0; i--)
        {
            _vampirismView.UpdateCooldown(i);
            yield return wait;
        }

        _vampirismView.Stop();
        _isWorking = false;
    }
}
