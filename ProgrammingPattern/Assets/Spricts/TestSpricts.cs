//---------------------------------------------------
//UIUtilityのメソッドのテスト
//TestSpricts.cs
//s.nakamura
//---------------------------------------------------
using UnityEngine;

public class TestSpricts : MonoBehaviour
{
    private void Start()
    {
        int a = 1234567980;
        //aの値を1の位から3桁ずつ,を入れて文字列に変換する
        string b = UIUtility.NumberFormatter(a);

        float c = 0.45286f;
        //cの値を小数点2までの%に直して文字列に変換する
        string d = UIUtility.ConvertPercent(c);

        //UIUtilityのメソッドが思った通り動いているか確認するためのデバックログ
        Debug.Log($"3桁ずつ,を入れた数字:{b}");
        Debug.Log($"パーセントに直した数字:{d}");
    }
}