using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override bool DontDestroy { get; } = true;

    /// <summary>
    /// MessagePipe
    /// </summary>
    [SerializeField]
    private GameLifetimeScope lifetimeScope = null;

    [SerializeField]
    private UiManager uiManager = null;

    protected override void Awake()
    {
        base.Awake();
        lifetimeScope.Build();
        uiManager.OnAwake();
    }

    public static T RegisterPrefab<T>(T prefab, Transform parent) where T : UnityEngine.Object
    => I.lifetimeScope.RegisterPrefabInject(prefab, parent);
}
