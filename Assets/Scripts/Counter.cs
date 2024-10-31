using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeStep;

    public event Action<int> CountChanged;

    private readonly KeyCode _start = KeyCode.Mouse0; 
    private int _count;
    private bool _isRunning;
    private Coroutine _coroutine;

    private void Start()
    {
        _count = 0;
        _isRunning = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_start))
        {
            if(_isRunning == false)
            {
                _isRunning = true;
                Restart();
            }
            else
            {
                _isRunning = false;
                Stop();
            }
        }
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(IncreaseCounter(_timeStep));
    }

    private void Stop()
    {
        if(_coroutine != null )
            StopCoroutine(_coroutine);
    }

    private IEnumerator IncreaseCounter(float timeStep)
    {
        var wait = new WaitForSeconds(timeStep);
        
        while (enabled)
        {
            yield return wait;
            _count++;
            CountChanged?.Invoke(_count);
        }
    }
}
