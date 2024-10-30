using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const float TimeStep = 0.5f;

    [SerializeField] private Text _text;

    private bool _isRunning;
    private int _count;

    private void Start()
    {
        _isRunning = false;
        _count = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isRunning == false)
        {
            _isRunning = true;
            StartCoroutine(IncreaseTimer());
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && _isRunning == true)
        {
            _isRunning = false;
        }
    }

    private IEnumerator IncreaseTimer()
    {
        var wait = new WaitForSeconds(TimeStep);
        
        while (_isRunning)
        {
            yield return wait;
            _count++;
            _text.text = _count.ToString("");
        }
    }
}
