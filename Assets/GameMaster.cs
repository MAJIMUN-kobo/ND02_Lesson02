using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // === �����o�ϐ�
    public int gameScore;   // �Q�[���̃X�R�A
    public int heighScore;  // �n�C�X�R�A

    public float gameTime;      // �Q�[���̐�������
    public float gameTimeLimit; // �������ԁi�ő吔�j

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // === �n�C�X�R�A���X�V
        if(gameScore > heighScore)
        {
            heighScore = gameScore;
        }
    }
}
