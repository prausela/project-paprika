using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoliBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _loliReady;
    [SerializeField] private GameObject _loliCorrect;
    [SerializeField] private GameObject _loliCorrect2;
    [SerializeField] private GameObject _loliIncorrect;

    public void GotIt()
    {
        _loliReady.SetActive(false);
        if (_loliCorrect.activeSelf)
        {
            _loliCorrect.SetActive(false);
            _loliCorrect2.SetActive(true);
        }
        else
        {
            _loliCorrect.SetActive(true);
            _loliCorrect2.SetActive(false);
        }
        _loliIncorrect.SetActive(false);
    }

    public void DidntGetIt()
    {
        _loliReady.SetActive(false);
        _loliCorrect.SetActive(false);
        _loliCorrect2.SetActive(false);
        _loliIncorrect.SetActive(true);
    }

    public void GoNeutral()
    {
        _loliReady.SetActive(true);
        _loliCorrect.SetActive(false);
        _loliCorrect2.SetActive(false);
        _loliIncorrect.SetActive(false);
    }

    public void Celebrate()
    {
        _loliReady.SetActive(false);
        _loliCorrect.SetActive(false);
        _loliCorrect2.SetActive(true);
        _loliIncorrect.SetActive(false);
    }
}
