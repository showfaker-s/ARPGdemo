using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    public GameObject effect_click_prefab;
    //public Vector3 targetPositon = Vector3.zero;//Ŀ��λ��
    public Vector3 targetPositon;
    private bool isBtnDown = false;//����Ƿ���


    private PlayerMove playerMove;
    void Start()
    {
        targetPositon = this.transform.position;
        playerMove = this.GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && !UICamera.isOverUI
            //&& UICamera.hoveredObject.gameObject == null//�������û��UI�ؼ�
            )
        {
            bool isoverUI = UICamera.isOverUI;
            GameObject hoverGo = UICamera.hoveredObject.gameObject;

            //MainCamera��Ϊ����Ұ������Ļ�ϵĵ�תΪ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //�õ���ײ��Ϣ
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                //��갴��
                isBtnDown = true;
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
/*                if (isBtnDown)
                {
                    LookAtTarget(hitInfo.point);
                }
                else
                {
                    if (playerMove.isMoving)//�������ƶ�,����������Ϊ�п��������£�����ͣ������������һֱ��ǰ�ƶ�
                    {
                        LookAtTarget(targetPositon);
                    }
                }*/
            }
        }
        //���̧��˲��,�Ͳ�����ƶ�Ŀ��λ����
        if (Input.GetMouseButtonUp(0))
        {
            isBtnDown = false;
        }
        if (isBtnDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //�õ���ײ��Ϣ
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
                LookAtTarget(hitInfo.point);
        }
        else
        {
            if (playerMove.isMoving)//�������ƶ�,����������Ϊ�п��������£�����ͣ������������һֱ��ǰ�ƶ�
            {
                LookAtTarget(targetPositon);
            }
        }
    }
    //ʵ�����������Ч��
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.2f, hitPoint.z);
        Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //����Ŀ��λ��
    void LookAtTarget(Vector3 hitPoint)
    {
        //�õ�Ҫ�ƶ���Ŀ��λ��
        targetPositon = new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
        //�����ǳ���Ŀ��λ��,lookAtֻ��ı�y�����ת
        this.transform.LookAt(targetPositon);
    }
}
