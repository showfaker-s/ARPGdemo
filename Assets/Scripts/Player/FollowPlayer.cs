using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offDistance;//位置偏移
    public float distance = 0;
    public float scroSpeed = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player);
        offDistance = this.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offDistance + player.position;
        ScrollView();
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
}
