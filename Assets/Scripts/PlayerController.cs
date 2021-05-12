using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MovePlayer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookspeed = 3f;

    private MovePlayer motor;


    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent <MovePlayer> ();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw ("Horizontal");
        
        float zMov = Input.GetAxisRaw ("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * speed;

        motor.Move (velocity);

        float yRot = Input.GetAxis ("Mouse X");
        Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookspeed;
        motor.Rotate (rotation);

        float xRot = Input.GetAxis ("Mouse Y");
        Vector3 camRotation = new Vector3 (xRot, 0f, 0f) * lookspeed;
        motor.RotateCam (camRotation);

        
    }

}