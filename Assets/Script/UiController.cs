using System;
using MessagePipe;
using UnityEngine;
using VContainer;
using TMPro;

public class UiController : MonoBehaviour
{
    [Inject]
    ISubscriber<StatusData> subscriber = null;

    private IDisposable disposable;

    [SerializeField]
    private TextMeshProUGUI id = null;

    [SerializeField]
    private TextMeshProUGUI attack = null;

    [SerializeField]
    private TextMeshProUGUI speed = null;

    public void Init()
    {
        var d = DisposableBag.CreateBuilder();
        subscriber.Subscribe(data =>
        {
            id.text = $"CharacterId : {data.characterId}";
            attack.text = $"attack Status : {data.attack}";
            speed.text = $"speed Status : {data.speed}";
        }).AddTo(d);
        disposable = d.Build();
    }

    private void OnDestroy()
    {
        disposable.Dispose();
    }
}