using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject owner;                // �R�A�̏��L��
    public GameMaster gameMasterComponent;  // �Q�[���}�X�^�[�̃R���|�[�l���g
    

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

            gameMasterComponent = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            gameMasterComponent.gameScore += 100;   // GameMaster��gameScore���Q�Ƃ���

            Destroy(this.gameObject);       // ����(Core)���폜����
            Destroy(hitObject.gameObject);  // �Փ˂����e�ۂ�����
        }
    }
}
