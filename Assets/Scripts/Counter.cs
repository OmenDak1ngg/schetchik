using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _stepDelay = 0.5f;
    private int _startCounter = 0;
    private int _currentCounter;
    private bool _isCounterIncrement;

    public event Action Changed;
    public int CurrentCounter => _currentCounter;

    private void Start()
    {
        _isCounterIncrement = false;
        _currentCounter = _startCounter;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounterIncrement == false)
            {
                _isCounterIncrement = true;
               StartCoroutine(IncreaseCounter());
            }
            else
            {
                _isCounterIncrement = false;
                StopCoroutine(IncreaseCounter());
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (_isCounterIncrement)
        {
            _currentCounter++;
            Changed?.Invoke();
            yield return new WaitForSeconds(_stepDelay);
        }
    }
}
