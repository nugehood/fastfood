using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{

    public AudioSource plyrAudio;

    public GameObject[] activeObj;

    public GameObject lantern;

    public Text lockedText;

    public AudioClip doorOpen, doorClose;

    public RectTransform crossHair;

    public Movement move;

    AudioSource audioSource;

    bool isPlaying;

    public bool isSit;

    public bool sitEvent;

    Transform obj;

    Animator animator;

    doorScript door;

    public float sensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public Camera cam;

    Camera guncam;

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
        guncam = GameObject.Find("Camera (1)").GetComponent<Camera>();

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
                    door.audioSource.PlayOneShot(doorOpen);
                    
                }
                else if (Input.GetMouseButtonDown(0)&&door.isopen)
                {
                    door.isopen = false;
                    door.audioSource.PlayOneShot(doorClose);
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
                    move.notrun = true;
                   
                }
                
               
            }

            if (hit.collider.gameObject.CompareTag("music"))
            {
                if (Input.GetMouseButtonDown(0)&&isPlaying)
                {
                    audioSource = hit.collider.GetComponent<AudioSource>();
                    audioSource.Stop();
                    isPlaying = false;
                    activeObj[0].SetActive(true);
                }

                else if (Input.GetMouseButtonDown(0) && !isPlaying)
                {
                    audioSource = hit.collider.GetComponent<AudioSource>();
                    audioSource.Play();
                    isPlaying = true;
                    
                }

                


            }


            

            if (hit.collider.gameObject.CompareTag("lock"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lockedText.text = "Door is locked!"; 
                    StartCoroutine(disableText());
                }
            }

            if (hit.collider.gameObject.CompareTag("key"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lockedText.text = "You pickup a key!";
                    StartCoroutine(disableText());
                    Destroy(hit.collider.gameObject);
                }
            }

            if (hit.collider.gameObject.CompareTag("blanket"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    animator = hit.collider.gameObject.GetComponent<Animator>();
                    animator.SetBool("open", true);
                }
            }

            if (hit.collider.gameObject.CompareTag("lantern"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.collider.gameObject);
                    lantern.SetActive(true);
                    guncam.depth = 80;
                    lockedText.text = "You got a lantern!";
                    StartCoroutine(disableText());
                }
            }

            

           

            
            
        }

    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(3f);
        lockedText.text = "";
        StopAllCoroutines();
    }
}
