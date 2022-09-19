using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _calculatorCanvas;
    [SerializeField] private GameObject _comparerCanvas;

    private GameObject _currentCanvas;

    private void Start()
    {
        _calculatorCanvas.SetActive(true);
        _comparerCanvas.SetActive(false);

        _currentCanvas = _calculatorCanvas;
    }

    public void SwitchCanvas(GameObject canvas)
    {
        if (_currentCanvas == null || canvas == null)
            return;

        _currentCanvas.SetActive(false);
        _currentCanvas = canvas;

        _currentCanvas.SetActive(true);
    }
}
