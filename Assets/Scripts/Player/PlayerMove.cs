using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Moving,
}
public class PlayerMove : MonoBehaviour
{
    public float speed = 3.5f;
    public PlayerState state = PlayerState.Idle;

    private PlayerLookAt dir;
    private CharacterController characterController;

    public bool isMoving = false;
    void Start()
    {
        dir = GetComponent<PlayerLookAt>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        //��ȡ�����ľ���
        float distance = Vector3.Distance(dir.targetPositon,this.transform.position);
        //�ٽ��жϲ���Ŀ��ֵ������һ����С��ֵ
        if(distance > 0.3f)
        {
            isMoving = true;
            //�����ƶ�����
            state = PlayerState.Moving;
            //�ṩһ���ٶȣ����ƶ�
            characterController.SimpleMove(this.transform.forward * speed);
        }
        else
        {
            state = PlayerState.Idle;
        }
    }
}
