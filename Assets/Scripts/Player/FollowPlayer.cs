using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offDistance;//λ��ƫ��
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
        //��ǰ��������Զ��������ֵ
        distance = offDistance.magnitude;//����
        distance += Input.GetAxis("Mouse ScrollWheel") * scroSpeed;
        //���������С�Ӿ�
        distance = Mathf.Clamp(distance, 2, 9);
        //��λ����distance
        offDistance = offDistance.normalized * distance;
    }
}
