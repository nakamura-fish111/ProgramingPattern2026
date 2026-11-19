//--------------------------------------------------
//どこでも使える汎用オブジェクトプール
//ObjectPool.cs
//s.nakamura
//--------------------------------------------------

//オブジェクトプールは、オブジェクトをあらかじめ生成しておき
//使いまわすことで生成と破棄のコストを削減する仕組み。
//敵や弾やエフェクトなど、頻繁に生成と破棄を繰り返すオブジェクトに使うといい。
//Queueとはリスト型のクラスで、登録と取り出しを行うことができる。
//上から順番に取り出したり、古いものから格納したりできる
//汎用的なクラスをテンプレートクラスと呼ぶ。
//テンプレートはどんなクラスでも使えるようにするための仕組みで、ObjectPool<T>のTの部分がテンプレートクラスになっている。

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 汎用オブジェクトプール
/// </summary>
public class ObjectPool<T> where T : Component
{
    //生成プレハブ
    private T prefab = null;

    //プールの管理キュー
    private Queue<T> pool = new Queue<T>();

    //生成オブジェクトをまとめる親のトランスフォーム
    private Transform parent = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        //プレハブと親を設定
        this.prefab = prefab;
        this.parent = parent;

        //初期生成
        for (int i = 0; i < initialSize; i++)
        {
            T obj = CreateNewObject();
            pool.Enqueue(obj);
        }
    }

    /// <summary>
    /// 新規オブジェクト生成
    /// </summary>
    private T CreateNewObject()
    {
        //オブジェクト生成
        T obj = GameObject.Instantiate(prefab, parent);
        obj.gameObject.SetActive(false);
        return obj;
    }

    /// <summary>
    /// オブジェクトを取り出す
    /// </summary>
    public T Get()
    {
        //プールにオブジェクトがあればプールから取得
        if (pool.Count > 0)
        {
            //キューから登録をはずす
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            //足りない場合は新しく生成する
            return CreateNewObject();
        }
    }

    /// <summary>
    /// オブジェクトを返却する
    /// </summary>
    /// <param name="obj"></param>
    public void Release(T obj)
    {
        //オブジェクトを非アクティブにしてサイド登録する
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
