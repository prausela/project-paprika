using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    public float DotSpeed => _dotSpeed;
    [SerializeField] private float _dotSpeed = 1;

    private TextMeshProUGUI _loadingText;

    private String _textDefault;
    private float _timer;
    private int _counter;
    
    void Start()
    {
        _loadingText = GetComponent<TextMeshProUGUI>();
        _textDefault = _loadingText.text;
        _timer = 0;
        _counter = 0;
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _dotSpeed)
        {
            if (_counter == 3)
            {
                _loadingText.text = _textDefault;
                _counter = 0;
            }
            else
            {
                _loadingText.text += ".";
                _counter += 1;
            }
            _timer = 0;
        }
    }
}
