//--------------------------------------------
//どこでも使えるシングルトンのテンプレート、親スプリクト
//SingletonMonoBehaiviour.cs
//s.nakamura
//--------------------------------------------

//Singletonは一個だけ作るもの
//先生曰くゲームシーン１つにつき二個は使うらしい
//UIなどの管理するものにつけるのがいいとされている
//使いこなすのはかなり難しい
//ここでもテンプレートを使っているのでどこでも使えるんだろう
//子が親の処理を使い時はbaseですよ
//staticはずっと使うやつなんですよ終わるまでとまらないんですよ
//abstractは継承されることが前提のクラス、このスクリプトみたいに
//TはテンプレートのT！！！！！！！
//下のwhere T : MonoBeheは条件を指定して、テンプレートのTで、クラスはを指定する…らしい
//SprictableObjectにも使えるの???

using UnityEngine;
using System;

/// <summary>
/// シングルトンの親スプリクト
/// </summary>
public class SingletonMonoBehaiviour<T> : MonoBehaviour where T : MonoBehaviour
{
    //生成したインスタンス
    private static T instance;

    /// <summary>
    /// Instanceが生成されているかを確認する
    /// </summary>
    public static T Instance
    {
        get
        {
            //instanceに何も入ってないなら
            if(instance == null)
            {
                //探すものを取得する
                Type t = typeof(T);

                //今開いているシーンから探すものをアタッチしてるObjectを取得する
                instance = (T)FindFirstObjectByType(t);

                //それでも何も入ってないならエラーを出す
                if(instance == null)
                {
                    Debug.LogError(t + "アタッチしているGameObjectはありません");
                }
            }
            //インスタンスを返す
            return instance;
        }
    }

    /// <summary>
    /// 一回だけやる仮想メソッド
    /// </summary>
    virtual protected void Awake()
    {
        //ほかのゲームオブジェクトにアタッチされていないかを調べる
        //アタッチされている場合は破棄する
        CheckInstance();
    }

    /// <summary>
    /// 自分以外に同じものがいたら
    /// </summary>
    protected bool CheckInstance()
    {
        //instanceに何も入ってないなら、instanceに自分を入れてtrueを返す
        if (instance == null)
        {
            instance = this as T;
            return true;
        }
        //Instanceに自分が入っていたらtrueを返す
        else if(Instance == this)
        {
            return true;
        }
        //どちらでもなかったら自分を消してfalseを返す
        Destroy(this);
        return false;
    }
}
