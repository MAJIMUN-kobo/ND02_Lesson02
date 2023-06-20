using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // フィールド
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) == true)
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    // 重なる(isTrigger)判定を検知する
    void OnTriggerEnter2D( Collider2D hitObject )
    {
        if(hitObject.transform.tag == "Bullet" && hitObject.GetComponent<NormalBullet>().owner != this.gameObject)
        {   // 自身が所有者(owner)ではない弾丸と衝突した場合...
            Destroy(hitObject.gameObject);      // 弾丸を削除
            Destroy(this.gameObject);           // 自身(Player)を削除
        }
    }
}
