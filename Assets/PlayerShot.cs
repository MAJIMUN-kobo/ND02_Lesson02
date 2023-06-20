using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // フィールド
    public GameObject bulletPrefab; // 弾丸のプレハブ


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // === "スペースキー"で弾丸を複製する
        if(Input.GetKeyDown(KeyCode.Space) == true )
        {
            // Instantiate( オリジナルオブジェクト, 複製する座標, 複製の角度 )
            GameObject cloneBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            cloneBullet.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), 0, 0);

            // 弾丸の初期設定を行う
            cloneBullet.GetComponent<NormalBullet>().Initialize(Random.Range(-10, 10), new Vector3(1, 0, 0), Random.Range(0.01f, 0.05f), this.gameObject);
        }
    }
}
