using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMCame : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (transform.localEulerAngles.y != 0)
        {
            float rotX = transform.localEulerAngles.x;
            float rotZ = transform.localEulerAngles.z;
            transform.localEulerAngles = new Vector3(rotX, 0, rotZ);
        }
        // 只获取目标物体的x轴位置移动，其余不变
        //transform.localEulerAngles = new Vector3(target.rotation.x, transform.rotation.y, target.rotation.z);
    }
}
