using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public GameObject owner;    // �e�ۂ̏��L�ҁi�I�[�i�[�j
    public float speed;         // ���x
    public Vector3 direction;   // ����
    public float accele;        // �����x


    // === �������p���\�b�h
    public void Initialize( float sp, Vector3 dir, float acc, GameObject obj )
    {
        owner = obj;        // ���L�҂�ݒ�
        speed = sp;         // ���x��ݒ�
        direction = dir;    // ������ݒ�
        accele = acc;       // �����x��ݒ�
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
