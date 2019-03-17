using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{

    private const  int _bufferFrames = 100;
    private MyKeyFrame[] _keyFrames = new MyKeyFrame[_bufferFrames];
    private Rigidbody _rigibody;

    private GameManager _gameManager;
    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(_gameManager.Recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
       
    }

    private void PlayBack()
    {
        _rigibody.isKinematic = true;
        int frame = Time.frameCount % _bufferFrames;
        //Debug.Log("Reading Frame : " + frame);
        transform.position = _keyFrames[frame].Position;
        transform.rotation = _keyFrames[frame].Rotation;

    }

    private void Record()
    {
        _rigibody.isKinematic = false;
        int frame = Time.frameCount % _bufferFrames;
        float time = Time.time;
        //Debug.Log("Write Frame : " + frame);
        _keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

[System.Serializable]
public struct MyKeyFrame
{
    public float m_FrameTime;
    public Vector3 Position;
    public Quaternion Rotation;

       
   public MyKeyFrame( float time, Vector3 pos, Quaternion quaternion)
    {
        m_FrameTime = time;
        Position = pos;
        Rotation = quaternion;
    }
}
