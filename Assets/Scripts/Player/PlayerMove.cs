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
        //获取两点间的距离
        float distance = Vector3.Distance(dir.targetPositon,this.transform.position);
        //临界判断不用目标值，而用一个很小的值
        if(distance > 0.3f)
        {
            isMoving = true;
            //控制移动动画
            state = PlayerState.Moving;
            //提供一个速度，简单移动
            characterController.SimpleMove(this.transform.forward * speed);
        }
        else
        {
            state = PlayerState.Idle;
        }
    }
}
