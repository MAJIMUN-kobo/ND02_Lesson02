using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject owner;    // �R�A�̏��L��


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
        {   // �Փ˂����I�u�W�F�N�g��Tag��"Bullet"�̏ꍇ�̂ݏ�������
            Destroy(this.gameObject);       // ����(Core)���폜����
            Destroy(hitObject.gameObject);  // �Փ˂����e�ۂ�����
        }
    }
}
