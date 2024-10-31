using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += OnCountChanged;    
    }

    private void OnDisable()
    {
        _counter.CountChanged -= OnCountChanged;
    }

    private void OnCountChanged(int count)
    {
        _text.text = count.ToString("");
    }
}
