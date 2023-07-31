using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum STATE { IDLE, MOVE, SHIELD, ATTACK, DIE };

    private Animator Anim = null;
    [SerializeField] private STATE CurState = STATE.IDLE;
    private Vector3 Dir = Vector3.zero;

    private readonly int hashForward = Animator.StringToHash("Forward");
    private readonly int hashBackWard = Animator.StringToHash("BackWard");
    private readonly int hashRight = Animator.StringToHash("Right");
    private readonly int hashLeft = Animator.StringToHash("Left");
    private readonly int hashIdle = Animator.StringToHash("Idle");
    private readonly int hashShield = Animator.StringToHash("Shield");

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Anim.SetTrigger(hashForward);
            Dir = Vector3.forward;
            CurState = STATE.MOVE;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Anim.SetTrigger(hashRight);
            Dir = Vector3.right;
            CurState = STATE.MOVE;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Anim.SetTrigger(hashLeft);
            Dir = Vector3.left;
            CurState = STATE.MOVE;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Anim.SetTrigger(hashBackWard);
            Dir = Vector3.back;
            CurState = STATE.MOVE;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Anim.SetTrigger(hashShield);
            CurState = STATE.SHIELD;
        }
        else
        {
            Anim.SetTrigger(hashIdle);
            CurState = STATE.IDLE;
        }

        switch (CurState) 
        { 
            case STATE.MOVE:
                transform.position += Dir * Time.deltaTime * 0.5f;
                break;
            case STATE.SHIELD:
                break;
            case STATE.IDLE:
                break;
        }
    }
}
