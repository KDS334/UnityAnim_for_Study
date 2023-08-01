using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum STATE { IDLE, MOVE, SHIELD, ATTACK, DIE };

    private Animator Anim = null;
    [SerializeField] private STATE CurState = STATE.IDLE;
    [SerializeField] private Collider SwordCollier = null;
    private Vector3 Dir = Vector3.zero;
    private int AttackStack = 0;
    

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        SwordCollier.enabled = false;
    }

    private void Update()
    {
        State();
        KeyInput();
    }

    private void State()
    {
        switch (CurState)
        {
            case STATE.MOVE:
                transform.position += Dir * Time.deltaTime * 0.5f;
                break;
            case STATE.SHIELD:
                break;
            case STATE.ATTACK:
                if (1f < Anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
                {
                    Anim.SetTrigger("Idle");
                    CurState = STATE.IDLE;
                    AttackStack = 0;
                    SwordCollier.enabled = false;
                }
                break;
            case STATE.IDLE:
                break;
        }
    }

    private void KeyInput()
    {
        if (Input.GetMouseButtonDown(0) && 3 > AttackStack)
        {
            Anim.SetTrigger("S" + (++AttackStack).ToString());
            SwordCollier.enabled = true;
            CurState = STATE.ATTACK;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (1 <= AttackStack)
            {
                SwordCollier.enabled = false;
                AttackStack = 0;
            }

            Anim.SetTrigger("Shield");
            CurState = STATE.SHIELD;
        }

        if (1 <= AttackStack)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Anim.SetTrigger("Forward");
            Dir = Vector3.forward;
            CurState = STATE.MOVE;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Anim.SetTrigger("BackWard");
            Dir = Vector3.back;
            CurState = STATE.MOVE;
        }
        
        if (!Input.anyKey)
        {
            Anim.SetTrigger("Idle");
            CurState = STATE.IDLE;
        }
    }
}
