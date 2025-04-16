using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private static int LeftMouseButoon = 0;

    private float _stepDelay = 0.5f;
    private int _startCounter = 0;
    private int _currentCounter;
    private bool _isCounterIncrement;
    private Coroutine _coroutine;

    public event Action Changed;
    public int CurrentCounter => _currentCounter;

    private void Start()
    {
        _isCounterIncrement = false;
        _currentCounter = _startCounter;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButoon))
        {
            if (_isCounterIncrement == false)
            {
                _isCounterIncrement = true;
               _coroutine = StartCoroutine(IncreaseCounter());
            }
            else
            {
                _isCounterIncrement = false;
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        var wait = new WaitForSeconds(_stepDelay);

        while (_isCounterIncrement)
        {
            _currentCounter++;
            Changed?.Invoke();
            yield return wait;
        }
    }
}
