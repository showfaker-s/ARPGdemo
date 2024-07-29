using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animation animation;

    private PlayerMove move;
    void Start()
    {
        move = this.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(move.state == PlayerState.Idle)
        {
            PlayerAnim("Idle");
        }else if(move.state == PlayerState.Moving)
        {
            PlayerAnim("Run");
        }
    }
    void PlayerAnim(string animName)
    {
        //直接跳转到指定动画
        animation.CrossFade(animName);
    }
}
