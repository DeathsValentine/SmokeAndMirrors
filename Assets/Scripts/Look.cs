using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    void Start()
    {
        
    }

    public float sensitivity = 9.0f;
    public float minVert = -75.0f;
    public float maxVert = 75.0f;

    private float _rotationX = 0;

    public enum RotationAxes
    {
        mouseXAndY = 0, mouseX = 1, mouseY = 2
    }

    public RotationAxes axes = RotationAxes.mouseXAndY;

    void Update()
    {
        if (axes == RotationAxes.mouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
        else if (axes == RotationAxes.mouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
