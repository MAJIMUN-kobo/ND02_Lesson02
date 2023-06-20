using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // �t�B�[���h
    public GameObject bulletPrefab; // �e�ۂ̃v���n�u


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // === "�X�y�[�X�L�["�Œe�ۂ𕡐�����
        if(Input.GetKeyDown(KeyCode.Space) == true )
        {
            // Instantiate( �I���W�i���I�u�W�F�N�g, ����������W, �����̊p�x )
            GameObject cloneBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            cloneBullet.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), 0, 0);

            // �e�ۂ̏����ݒ���s��
            cloneBullet.GetComponent<NormalBullet>().Initialize(Random.Range(-10, 10), new Vector3(1, 0, 0), Random.Range(0.01f, 0.05f), this.gameObject);
        }
    }
}
