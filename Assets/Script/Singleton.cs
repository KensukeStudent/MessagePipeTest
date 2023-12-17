using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected abstract bool DontDestroy { get; }

    private static T instance;

    public static T I
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError($"{typeof(T)}のインスタンスが存在しません。");
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (I != this)
        {
            Destroy(gameObject);
            return;
        }

        if (DontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// 解放処理
    /// </summary>
    public void Release()
    {
        Destroy(gameObject);
        instance = null;
    }
}