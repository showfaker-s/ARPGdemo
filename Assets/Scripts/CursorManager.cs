using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager _instance;

    public Texture2D cursor_nornal;
    public Texture2D cursor_npc_talk;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;

    private Vector2 hotpot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;
    public enum CursorStatus
    {
        nornal,
        npc_talk,
        attack,
        lockTarget,
        pick
    }
    void Start()
    {
        _instance = this;
    }
    public void UpdateCursor(CursorStatus cursorStatus)
    {
        switch (cursorStatus)
        {
            case CursorStatus.nornal:
                Cursor.SetCursor(cursor_nornal, hotpot, mode);

                break;
            case CursorStatus.npc_talk:
                Cursor.SetCursor(cursor_npc_talk, hotpot, mode);

                break;
            case CursorStatus.attack:
                Cursor.SetCursor(cursor_attack, hotpot, mode);

                break;
            case CursorStatus.lockTarget:
                Cursor.SetCursor(cursor_lockTarget, hotpot, mode);

                break;
            case CursorStatus.pick:
                Cursor.SetCursor(cursor_pick, hotpot, mode);

                break;
            default:
                break;
        }
    }
}
