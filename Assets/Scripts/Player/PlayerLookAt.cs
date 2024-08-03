using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    public GameObject effect_click_prefab;
    //public Vector3 targetPositon = Vector3.zero;//目标位置
    public Vector3 targetPositon;
    private bool isBtnDown = false;//鼠标是否按下


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
            //&& UICamera.hoveredObject.gameObject == null//鼠标下面没有UI控件
            )
        {
            bool isoverUI = UICamera.isOverUI;
            GameObject hoverGo = UICamera.hoveredObject.gameObject;

            //MainCamera作为主视野，把屏幕上的点转为射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //拿到碰撞信息
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                //鼠标按下
                isBtnDown = true;
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
/*                if (isBtnDown)
                {
                    LookAtTarget(hitInfo.point);
                }
                else
                {
                    if (playerMove.isMoving)//若正在移动,修正朝向，因为有可能是上坡，导致停下条件不满足一直向前移动
                    {
                        LookAtTarget(targetPositon);
                    }
                }*/
            }
        }
        //鼠标抬起瞬间,就不检测移动目标位置了
        if (Input.GetMouseButtonUp(0))
        {
            isBtnDown = false;
        }
        if (isBtnDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //拿到碰撞信息
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
                LookAtTarget(hitInfo.point);
        }
        else
        {
            if (playerMove.isMoving)//若正在移动,修正朝向，因为有可能是上坡，导致停下条件不满足一直向前移动
            {
                LookAtTarget(targetPositon);
            }
        }
    }
    //实例化出点击的效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.2f, hitPoint.z);
        Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //朝向目标位置
    void LookAtTarget(Vector3 hitPoint)
    {
        //得到要移动的目标位置
        targetPositon = new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
        //让主角朝向目标位置,lookAt只会改变y轴的旋转
        this.transform.LookAt(targetPositon);
    }
}
