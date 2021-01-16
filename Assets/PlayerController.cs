using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    public float playerSpeed, jumpForce;
    [SerializeField] 
    bool grounded = true;
    public GameObject respawnPoint;

    public GameObject plat1, plat2, plat3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        SetInactive();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        PlatformControls();
    }

    public void Move(){
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y, rb.velocity.z);
    }

    public void Jump(){
        if(Input.GetKeyDown("space") && grounded){        
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    
    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    public void PlatformControls(){
        if(Input.GetKeyDown("1")){
            SetInactive();
            plat1.SetActive(true);
            plat2.SetActive(true);
        }
        if(Input.GetKeyDown("2")){
            SetInactive();
            plat2.SetActive(true);
            plat3.SetActive(true);
        }
        if(Input.GetKeyDown("3")){
            SetInactive();
            plat1.SetActive(true);
            plat3.SetActive(true);
        }
    }

    public void SetInactive(){
        plat1.SetActive(false);
        plat2.SetActive(false);
        plat3.SetActive(false);
    }
    

    void OnTriggerEnter(Collider other){           
        if(other.gameObject.tag == "DeathZone"){
            tr.position = respawnPoint.transform.position;
        } 
    }
}
