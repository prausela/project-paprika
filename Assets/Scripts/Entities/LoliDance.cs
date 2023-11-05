using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoliDance : MonoBehaviour
{
    [SerializeField] private GameObject _loli1;
    [SerializeField] private GameObject _loli2;
    [SerializeField] private GameObject _loli3;
    [SerializeField] private GameObject _loli4;

    [SerializeField] private float _duration = 0.5f;
    private float _currentElapsed;

    private void Awake()
    {
        _currentElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _currentElapsed += Time.deltaTime;
        if (_currentElapsed < _duration)
        {
            return;
        }

        _currentElapsed = 0;
        float randomLoli = Random.Range(0f, 4f);
        switch (randomLoli)
        {
            case >= 0 and < 1:
                _loli1.SetActive(true);
                _loli2.SetActive(false);
                _loli3.SetActive(false);
                _loli4.SetActive(false);
                break;
            case >= 1 and < 2:
                _loli1.SetActive(false);
                _loli2.SetActive(true);
                _loli3.SetActive(false);
                _loli4.SetActive(false);
                break;
            case >= 2 and < 3:
                _loli1.SetActive(false);
                _loli2.SetActive(false);
                _loli3.SetActive(true);
                _loli4.SetActive(false);
                break;
            case >= 3:
                _loli1.SetActive(false);
                _loli2.SetActive(false);
                _loli3.SetActive(false);
                _loli4.SetActive(true);
                break;
        }
    }
}
