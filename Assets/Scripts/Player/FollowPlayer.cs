using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offDistance;//位置偏移
    private float distance = 0;
    private float scroSpeed = 1.5f;
    private bool isRotating = false;
    private float rotatSpeed = 1.5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player);
        offDistance = this.transform.position - player.position;
    }
    void Update()
    {
        transform.position = offDistance + player.position;
        ScrollView();

        RotateView();
    }
    private void ScrollView()
    {
        //向前滑动是拉远，返回正值
        distance = offDistance.magnitude;//长度
        distance += Input.GetAxis("Mouse ScrollWheel") * scroSpeed;
        //限制最大最小视距
        distance = Mathf.Clamp(distance, 2, 9);
        //单位量乘distance
        offDistance = offDistance.normalized * distance;
    }
    private void RotateView()
    {
        //Input.GetAxis("Mouse X")鼠标在水平方向的移动
        //Input.GetAxis("Mouse Y")鼠标在垂直方向的移动
        if (Input.GetMouseButtonDown(1)) isRotating = true;
        if (Input.GetMouseButtonUp(1)) isRotating = false;
        if (isRotating)
        {
            //必须放在RotateAround上面
            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            //transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X" ) * rotatSpeed);
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X" ) * rotatSpeed);
            //围绕相机的right轴旋转，效果更好；相机旋转，position和rotation都会被影响
            transform.RotateAround(player.position,transform.right, -Input.GetAxis("Mouse Y") * rotatSpeed);
            //限制旋转角度，position也要修正
/*            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;*/
            float x = transform.eulerAngles.x;
            if(x < 10 || x > 80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
            //修正相机和角色间的偏移量
            offDistance = this.transform.position - player.position;
        }
    }

}
