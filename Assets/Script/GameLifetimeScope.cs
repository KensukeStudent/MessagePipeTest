using MessagePipe;
using VContainer;
using VContainer.Unity;
using UnityEngine;

/// <summary>
/// MessagePipeクラス 基本は送受信の型登録のみを定義する
/// </summary>
public class GameLifetimeScope : LifetimeScope
{
    /// <summary>
    /// メッセージのやり取りをしたいデータを定義してください
    /// </summary>
    protected override void Configure(IContainerBuilder builder)
    {
        // MessagePipeを登録
        var options = builder.RegisterMessagePipe();
        // IPublisher/ISubscriberでやり取りする型登録
        builder.RegisterMessageBroker<StatusData>(options);
    }

    /// <summary>
    /// プレハブを生成とInjectを両方行う
    /// </summary>
    public T RegisterPrefabInject<T>(T prefab, Transform parent) where T : UnityEngine.Object
    {
        return Container.Instantiate(prefab, parent);
    }

    /// <summary>
    /// 既に生成済みのデータに対するInject
    /// </summary>
    public void Inject(object instance) => Container.Inject(instance);
}