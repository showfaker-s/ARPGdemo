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
                //从场景中去找，因为继承了mono，不能new
                instance = FindObjectOfType<T>();
            }
            return instance;

        }
    }

}
