//----------------------------------------------------
//ゲームを管理するもの、シングルトン
//GameManager.cs
//s.nakamura
//----------------------------------------------------

using UnityEngine;
/// <summary>
/// ゲーム管理クラス
/// </summary>
public class GameManager : SingletonMonoBehaiviour<GameManager>
{
    [Header("テスト用変数")]
    public int testNumber = 0;

    /// <summary>
    /// 一回だけやる仮想メソッド
    /// </summary>
    protected override void Awake()
    {
        //親の処理をする
        base.Awake();
    }
        
    /// <summary>
    /// 現在設定されてるテスト変数を表示するメソッド
    /// </summary>
   public void OutputTestDebugLog()
    {
        //現在設定されてるテスト変数を表示する
        Debug.Log($"現在設定されているテスト変数 : {testNumber}");
    }
}