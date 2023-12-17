using UnityEngine;
using VContainer;
using MessagePipe;
using UniRx;

public class Character : MonoBehaviour
{
    [Inject]
    IPublisher<StatusData> publishStatus = null;

    /// <summary>
    /// データ参照用のためのIdを定義
    /// </summary>
    [SerializeField]
    private int characterId;

    [SerializeField]
    private string characterName;

    private StatusData statusData = null;

    public void Init()
    {
        statusData = new StatusData(characterId, characterName);
        Observable.Timer(System.TimeSpan.Zero, System.TimeSpan.FromSeconds(Random.Range(0.5f, 2.5f)))
        .Subscribe(x =>
        {
            IncreaseAttack();
        }
        ).AddTo(this);

        Observable.Timer(System.TimeSpan.Zero, System.TimeSpan.FromSeconds(Random.Range(0.5f, 2.5f)))
        .Subscribe(x =>
        {
            IncreaseSpeed();
        }
        ).AddTo(this);
    }

    private void UpdateStatus()
    {
        publishStatus.Publish(statusData);
    }

    public void IncreaseSpeed()
    {
        statusData.speed += Random.Range(0, 100);
        UpdateStatus();
    }

    public void IncreaseAttack()
    {
        statusData.attack += Random.Range(0, 100);
        UpdateStatus();
    }
}

public class StatusData
{
    public int characterId;

    public string characterName;

    public int attack = 0;

    public int speed = 0;

    public StatusData(int id, string name)
    {
        characterId = id;
        characterName = name;
    }
}