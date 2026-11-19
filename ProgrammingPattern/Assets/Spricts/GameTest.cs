//--------------------------------------------------
//シングルトンが正しく動いているか確認するもの
//GameTest.cs
//s.nakamura
//--------------------------------------------------
using UnityEngine;

/// <summary>
/// シングルトン確認用スクリプト
/// </summary>
public class GameTest : MonoBehaviour
{
    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        //Aキーを押したとき
        if (Input.GetKeyDown(KeyCode.A))
        {
            //テスト変数が今いくつか表示する
            GameManager.Instance.OutputTestDebugLog();
        }

        //Sキーを押したとき
        if (Input.GetKeyDown(KeyCode.S))
        {
            //テスト変数を１足す
            GameManager.Instance.testNumber++;
        }
    }
}
