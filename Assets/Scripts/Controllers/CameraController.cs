using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField] Vector3 _delta = new Vector3(0, 6.0f, -5.0f);
    [SerializeField] GameObject _player = null;

    public void SetPlayer(GameObject player) { _player = player; }

    void Start()
    {

    }


    void LateUpdate()
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            if (_player.IsVaild() == false) 
            { 
                return; 
            }

            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, (int)Define.Layer.Ground))
            {                
                float dist = (float)((hit.point - _player.transform.position).magnitude * 0.8);
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else 
            { 
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform.position);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
