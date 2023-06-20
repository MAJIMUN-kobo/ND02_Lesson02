using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject owner;                // コアの所有者
    public GameMaster gameMasterComponent;  // ゲームマスターのコンポーネント
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D( Collider2D hitObject )
    {
        if(hitObject.transform.tag == "Bullet" && hitObject.GetComponent<NormalBullet>().owner != owner)
        {   // 衝突したオブジェクトのTagが"Bullet"の場合のみ処理する

            gameMasterComponent = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            gameMasterComponent.gameScore += 100;   // GameMasterのgameScoreを参照する

            Destroy(this.gameObject);       // 自分(Core)を削除する
            Destroy(hitObject.gameObject);  // 衝突した弾丸も消す
        }
    }
}
