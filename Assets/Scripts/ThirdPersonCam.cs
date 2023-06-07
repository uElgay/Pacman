using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public float rotationSpeed;
    public GameObject obj;
    public Transform t_camera;
    private Vector3 camera_offset;

    private RaycastHit hit;

    private void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        camera_offset=t_camera.localPosition;
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(!IsDestroyed())
        {
            Vector3 viewDir=player.position-new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward=viewDir.normalized;

        float horizontalInput=Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");
        Vector3 inputDir=orientation.forward*verticalInput+orientation.right*horizontalInput;

        if(inputDir!=Vector3.zero){
            playerObj.forward=Vector3.Slerp(playerObj.forward,inputDir.normalized,Time.deltaTime*rotationSpeed);          
        }
        if(Physics.Linecast(transform.position,transform.position + transform.localRotation*camera_offset, out hit))
        {
            t_camera.localPosition=new Vector3(0,0,-Vector3.Distance(transform.position,hit.point));
        }
        else
        {
            t_camera.localPosition=camera_offset;
        }

        } 
    }
    public bool IsDestroyed()
         {
            return obj == null && !ReferenceEquals(obj, null);
         }
}
