using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private SpawnObjectsController _spawnController;

    private void Start() => UpdateText();

    public void IncrementIndex()
    {
        _spawnController.AddTypeCounter(1);
        UpdateText();
    }
    public void DecrementIndex()
    {
        _spawnController.AddTypeCounter(-1);
        UpdateText();
    }

    private void UpdateText()
    {
        _textUI.text = _spawnController.GetSpawnableObjectName();
    }
}