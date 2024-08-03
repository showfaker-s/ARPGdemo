using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private void OnMouseEnter()
    {
        CursorManager._instance.UpdateCursor(CursorManager.CursorStatus.npc_talk);
    }
    private void OnMouseExit()
    {
        CursorManager._instance.UpdateCursor(CursorManager.CursorStatus.nornal);

    }
}
