using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _skillSprite;

    private void Awake()
    {
        _skillSprite.SetActive(false);
    }
    
    public void StartAbility()
    {
        _skillSprite.SetActive(true);
        _text.text = "";
    }

    public void StartCooldown()
    {
        _skillSprite.SetActive(false);
    }

    public void UpdateCooldown(int secondsLeft)
    {
        if (secondsLeft <= 0)
        {
            _text.text = "";
        }
        else
        {
            _text.text = Convert.ToString(secondsLeft);
        }
    }

    public void Stop()
    {
        _text.text = "";
        _skillSprite.SetActive(false);
    }
}
