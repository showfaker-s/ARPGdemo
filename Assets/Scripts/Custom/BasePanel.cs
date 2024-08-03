using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasePanel<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //�ӳ�����ȥ�ң���Ϊ�̳���mono������new
                instance = FindObjectOfType<T>();
            }
            return instance;

        }
    }

}
