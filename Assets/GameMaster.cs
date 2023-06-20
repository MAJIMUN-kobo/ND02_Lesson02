using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // === メンバ変数
    public int gameScore;   // ゲームのスコア
    public int heighScore;  // ハイスコア

    public float gameTime;      // ゲームの制限時間
    public float gameTimeLimit; // 制限時間（最大数）

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // === ハイスコアを更新
        if(gameScore > heighScore)
        {
            heighScore = gameScore;
        }
    }
}
