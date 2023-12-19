using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;    
    
    Vector3 _destPos;


    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;        
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    void UpdateDie()
    {

    }
    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.01f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            nma.Move(dir.normalized * moveDist);

            Debug.DrawRay(transform.position + Vector3.up * 0.5f, dir.normalized, Color.green);
            if(Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
            {
                _state = PlayerState.Idle;
                return;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        // ¿¡´Ï¸ÅÀÌ¼Ç       
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", _speed);
    }
    void UpdateIdle()
    {
        // ¿¡´Ï¸ÅÀÌ¼Ç        
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);

    }

    void OnRunEvent()
    {
        //Debug.Log("¶Ñ¹÷ ¶Ñ¹÷");
    }
    void Update()
    {
        switch(_state)
        {
            case PlayerState.Die: 
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }
      
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die) { return; }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,100.0f,LayerMask.GetMask("Wall"))) 
        {
            _destPos = hit.point; 
            _state = PlayerState.Moving;
        }
       
    }
}
