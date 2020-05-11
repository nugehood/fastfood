using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    RenderSettings render;

    public RectTransform crossHair;

    public Movement move;

    AudioSource audioSource;

    bool isPlaying;

    public bool isSit;

    Transform obj;

    Animator animator;

    doorScript door;

    public float sensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Ray ray;
        ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,5))
        {
            if (hit.collider!= null&&hit.collider.gameObject.tag!="Untagged")
            {
                crossHair.localScale = new Vector3(0.1845333f, 0.1845333f, 0.1845333f);
            }
            else if(hit.collider!= null&&hit.collider.gameObject.tag == "Untagged")
            {
                crossHair.localScale = new Vector3(0.0989508f, 0.0989508f, 0.0989508f);
            }

            if (hit.collider.gameObject.CompareTag("door")){
            
                door = hit.collider.gameObject.GetComponent<doorScript>();
                
                if (Input.GetMouseButtonDown(0)&&!door.isopen)
                {
                    door.isopen = true;
                   
                    
                }
                else if (Input.GetMouseButtonDown(0)&&door.isopen)
                {
                    door.isopen = false;
                }

              
            }

            if (hit.collider.gameObject.CompareTag("trigger"))
            {
                if (Input.GetMouseButtonDown(0)&&!isSit)
                {
                    obj = hit.collider.gameObject.GetComponent<Transform>();
                    move.controller.enabled = false;
                    playerBody.position = obj.position;
                    isSit = true;
                }

                else if (Input.GetMouseButtonDown(0) && isSit)
                {
                    
                }
            }

            if (hit.collider.gameObject.CompareTag("music"))
            {
                if (Input.GetMouseButtonDown(0)&&isPlaying)
                {
                    audioSource = hit.collider.GetComponent<AudioSource>();
                    audioSource.Stop();
                    isPlaying = false;
                }

                else if (Input.GetMouseButtonDown(0) && !isPlaying)
                {
                    audioSource = hit.collider.GetComponent<AudioSource>();
                    audioSource.Play();
                    isPlaying = true;
                }
            }

            

           

            
            
        }

        
        
    }
}
