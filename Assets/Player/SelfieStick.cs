using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    public float PanSpeed = 10f;

    private GameObject _player;
    private Vector3 _armROatation;
	// Use this for initialization
	void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _armROatation = transform.rotation.eulerAngles;
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        _armROatation.y += Input.GetAxis("RHoriz") * PanSpeed;
        _armROatation.x += Input.GetAxis("RVert")* PanSpeed;

        Debug.Log(_armROatation);
        transform.position = _player.transform.position;
        transform.rotation = Quaternion.Euler(_armROatation);
	}
}
