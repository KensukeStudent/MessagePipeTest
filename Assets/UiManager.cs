using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private UiController prefab = null;

    [SerializeField]
    private Button button = null;

    public void OnAwake()
    {
        button.onClick.AddListener(() =>
        {
            var go = GameManager.RegisterPrefab(prefab, transform);
            go.Init();
        });
    }
}