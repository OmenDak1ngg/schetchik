using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += DisplayCounter;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayCounter;
    }

    private void DisplayCounter()
    {
        Debug.Log(_counter.CurrentCounter);
    }
}
