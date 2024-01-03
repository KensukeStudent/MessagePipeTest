using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private UiController prefab = null;

    [SerializeField]
    private Button button = null;

    [SerializeField]
    private Character charaPrefab = null;

    [SerializeField]
    private Button charaGeneButton = null;

    // 生成クラス

    private UiController controller = null;

    private Character character = null;

    public void OnAwake()
    {
        // キャラクターのステータス情報を表示
        button.onClick.AddListener(() =>
        {
            if (controller == null)
            {
                var go = GameManager.RegisterPrefab(prefab, transform);
                controller = go;
                go.Init();
            }
        });

        // 適当な秒間でステータスが向上
        charaGeneButton.onClick.AddListener(() =>
        {
            if (character == null)
            {
                var go = GameManager.RegisterPrefab(charaPrefab, transform);
                character = go;
                go.Init();
            }
        });
    }
}