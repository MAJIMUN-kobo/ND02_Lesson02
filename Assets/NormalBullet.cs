using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public GameObject owner;    // 弾丸の所有者（オーナー）
    public float speed;         // 速度
    public Vector3 direction;   // 向き
    public float accele;        // 加速度


    // === 初期化用メソッド
    public void Initialize( float sp, Vector3 dir, float acc, GameObject obj )
    {
        owner = obj;        // 所有者を設定
        speed = sp;         // 速度を設定
        direction = dir;    // 向きを設定
        accele = acc;       // 加速度を設定
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += accele;
        this.transform.Translate(direction * speed * Time.deltaTime);
    }

}
