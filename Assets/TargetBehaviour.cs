using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public GameObject[] core;   // �R�A�̃Q�[���I�u�W�F�N�g��"�z��"

    // === �X�e�[�^�X�p�̕ϐ�
    public GameObject corePrefab;   // �R�A�̃v���n�u�f�[�^
    public int hitPoint = 10;       // HP
    public int hitPointMax = 10;    // �ő�HP

    // === �e�ۗp�ϐ�
    public GameObject bulletPrefab; // �e�ۂ̃v���n�u�f�[�^
    public float shotTimer;         // ���˂܂ł̎���
    public float shotTimerLimit;    // ���˂܂ł̍ő厞�� <= Timer��������߂���Ɣ��˂����

    // Start is called before the first frame update
    void Start()
    {
        this.CreateCore();   // �R�A�������\�b�h�̌Ăяo��

        core[0].GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
        core[1].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoint <= 0)
        {   // HP�� 0 �ɂȂ�Ǝ������폜����
            Destroy(this.gameObject);
        }

        // === ��莞�Ԗ��ɒe�ۂ𐶐�����
        shotTimer += Time.deltaTime;
        if(shotTimer > shotTimerLimit)
        {
            this.Shot();        // �e�ۂ𐶐�����
            shotTimer = 0;      // �^�C�}�[�����Z�b�g
        }
    }

    // [����]�e�ۂ𐶐����郁�\�b�h
    void Shot()
    {
        int randomIndex = Random.Range(0, 10);  // core�̔ԍ�

        if (core[randomIndex] != null)
        {
            GameObject cloneBullet =
                Instantiate(bulletPrefab, core[randomIndex].transform.position, Quaternion.identity);
            cloneBullet.GetComponent<NormalBullet>().Initialize(10, new Vector3(-1, 0, 0), 0, this.gameObject);
        }
    }

    // [����]�R�A�𐶐����郁�\�b�h
    void CreateCore()
    {
        for(int index = 0; index < core.Length; index++)
        {   // Length(����)�̐������J��Ԃ�
            // �@�R�A�̐���
            GameObject cloneCore =
                Instantiate(corePrefab, new Vector3(Random.Range(0, 5), Random.Range(-5f, 5f), 0), Quaternion.Euler(0, 0, -30));

            // �A���������R�A��z��(0�`9��)�ɓ����
            core[index] = cloneCore;

            // �I�[�i�[��ݒ肷��
            core[index].GetComponent<Core>().owner = this.gameObject;
        }
    }

    // �d�Ȃ�(isTrigger)��������m����
    void OnTriggerEnter2D( Collider2D hitObject )
    {
        if(hitObject.transform.tag == "Bullet" && hitObject.GetComponent<NormalBullet>().owner != this.gameObject)
        {   // Tag�̕�����"Bullet"���ǂ����𔻒肷��
            int counter = 0;
            for (int index = 0; index < core.Length; index++)
            {
                if (core[index] == null)
                {   // �R�A��"�󂶂�Ȃ�"�ꍇ�����A�_���[�W��ʂ�
                    counter++;      // �J�E���^�[�� 1 ���₷       
                }
            }

            if(counter >= 10)
            {   // "�R�A���Ȃ��J�E���^�["�� 10 �𒴂��Ă���
                hitPoint -= 1;  // HP�����炷
            }

            // �Փ˂����e�ۂ��폜����
            Destroy(hitObject.gameObject);
        }
    }

}
