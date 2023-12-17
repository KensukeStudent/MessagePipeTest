using System;
using MessagePipe;
using UnityEngine;
using VContainer;

public class UiController : MonoBehaviour
{
    [Inject]
    ISubscriber<StatusData> subscriber = null;

    private IDisposable disposable;

    public void Init()
    {
        var d = DisposableBag.CreateBuilder();
        subscriber.Subscribe(data =>
        {
            Debug.Log(JsonUtility.ToJson(data));
        }).AddTo(d);
        disposable = d.Build();
    }

    private void OnDestroy()
    {
        disposable.Dispose();
    }
}