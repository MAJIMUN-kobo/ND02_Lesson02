using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public GameObject[] core;   // コアのゲームオブジェクトの"配列"

    // === ステータス用の変数
    public GameObject corePrefab;   // コアのプレハブデータ
    public int hitPoint = 10;       // HP
    public int hitPointMax = 10;    // 最大HP

    // === 弾丸用変数
    public GameObject bulletPrefab; // 弾丸のプレハブデータ
    public float shotTimer;         // 発射までの時間
    public float shotTimerLimit;    // 発射までの最大時間 <= Timerがこれを過ぎると発射される

    // Start is called before the first frame update
    void Start()
    {
        this.CreateCore();   // コア生成メソッドの呼び出し

        core[0].GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
        core[1].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoint <= 0)
        {   // HPが 0 になると自分を削除する
            Destroy(this.gameObject);
        }

        // === 一定時間毎に弾丸を生成する
        shotTimer += Time.deltaTime;
        if(shotTimer > shotTimerLimit)
        {
            this.Shot();        // 弾丸を生成する
            shotTimer = 0;      // タイマーをリセット
        }
    }

    // [自作]弾丸を生成するメソッド
    void Shot()
    {
        int randomIndex = Random.Range(0, 10);  // coreの番号

        if (core[randomIndex] != null)
        {
            GameObject cloneBullet =
                Instantiate(bulletPrefab, core[randomIndex].transform.position, Quaternion.identity);
            cloneBullet.GetComponent<NormalBullet>().Initialize(10, new Vector3(-1, 0, 0), 0, this.gameObject);
        }
    }

    // [自作]コアを生成するメソッド
    void CreateCore()
    {
        for(int index = 0; index < core.Length; index++)
        {   // Length(長さ)の数だけ繰り返す
            // ①コアの生成
            GameObject cloneCore =
                Instantiate(corePrefab, new Vector3(Random.Range(0, 5), Random.Range(-5f, 5f), 0), Quaternion.Euler(0, 0, -30));

            // ②生成したコアを配列(0～9番)に入れる
            core[index] = cloneCore;

            // オーナーを設定する
            core[index].GetComponent<Core>().owner = this.gameObject;
        }
    }

    // 重なる(isTrigger)判定を検知する
    void OnTriggerEnter2D( Collider2D hitObject )
    {
        if(hitObject.transform.tag == "Bullet" && hitObject.GetComponent<NormalBullet>().owner != this.gameObject)
        {   // Tagの文字列が"Bullet"かどうかを判定する
            int counter = 0;
            for (int index = 0; index < core.Length; index++)
            {
                if (core[index] == null)
                {   // コアが"空じゃない"場合だけ、ダメージを通す
                    counter++;      // カウンターを 1 増やす       
                }
            }

            if(counter >= 10)
            {   // "コアがないカウンター"が 10 を超えている
                hitPoint -= 1;  // HPを減らす
            }

            // 衝突した弾丸を削除する
            Destroy(hitObject.gameObject);
        }
    }

}
