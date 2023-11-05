using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    [SerializeField] private float _dotSpeed = 1;
    [SerializeField] private string _loadedText = "Loaded!";

    private TextMeshProUGUI _loadingText;

    private string _textDefault;
    private float _timer;
    private int _counter;
    private bool _loaded;
    
    void Start()
    {
        _loadingText = GetComponent<TextMeshProUGUI>();
        _textDefault = _loadingText.text;
        _timer = 0;
        _counter = 0;
        _loaded = false;
    }
    
    void Update()
    {
        if (_loaded)
        {
            return;
        }
        
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

    public void HasLoaded()
    {
        _loaded = true;
        _loadingText.text = _loadedText;
    }
}
