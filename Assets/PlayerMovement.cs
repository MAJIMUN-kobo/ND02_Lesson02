using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �t�B�[���h
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

    // �d�Ȃ�(isTrigger)��������m����
    void OnTriggerEnter2D( Collider2D hitObject )
    {
        if(hitObject.transform.tag == "Bullet" && hitObject.GetComponent<NormalBullet>().owner != this.gameObject)
        {   // ���g�����L��(owner)�ł͂Ȃ��e�ۂƏՓ˂����ꍇ...
            Destroy(hitObject.gameObject);      // �e�ۂ��폜
            Destroy(this.gameObject);           // ���g(Player)���폜
        }
    }
}
