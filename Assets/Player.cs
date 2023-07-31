using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum STATE { IDLE, MOVE, ATTACK, DIE };

    private Animator Anim = null;
    private STATE m_eCurState = STATE.IDLE;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Anim.SetTrigger("Forward");
            m_eCurState = STATE.MOVE;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Anim.SetTrigger("Idle");
            m_eCurState = STATE.IDLE;
        }

        switch (m_eCurState) 
        { 
            case STATE.MOVE:
                transform.position += Vector3.forward * Time.deltaTime * 0.1f;
                break;
            case STATE.IDLE:
                break;
        }
    }
}
