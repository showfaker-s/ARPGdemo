using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offDistance;//λ��ƫ��
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
        //��ǰ��������Զ��������ֵ
        distance = offDistance.magnitude;//����
        distance += Input.GetAxis("Mouse ScrollWheel") * scroSpeed;
        //���������С�Ӿ�
        distance = Mathf.Clamp(distance, 2, 9);
        //��λ����distance
        offDistance = offDistance.normalized * distance;
    }
    private void RotateView()
    {
        //Input.GetAxis("Mouse X")�����ˮƽ������ƶ�
        //Input.GetAxis("Mouse Y")����ڴ�ֱ������ƶ�
        if (Input.GetMouseButtonDown(1)) isRotating = true;
        if (Input.GetMouseButtonUp(1)) isRotating = false;
        if (isRotating)
        {
            //�������RotateAround����
            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            //transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X" ) * rotatSpeed);
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X" ) * rotatSpeed);
            //Χ�������right����ת��Ч�����ã������ת��position��rotation���ᱻӰ��
            transform.RotateAround(player.position,transform.right, -Input.GetAxis("Mouse Y") * rotatSpeed);
            //������ת�Ƕȣ�positionҲҪ����
/*            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;*/
            float x = transform.eulerAngles.x;
            if(x < 10 || x > 80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
            //��������ͽ�ɫ���ƫ����
            offDistance = this.transform.position - player.position;
        }
    }

}
