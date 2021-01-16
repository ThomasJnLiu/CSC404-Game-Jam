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
    
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        gameManager = FindObjectOfType<GameManager>();
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
            SetActive("1");
        }
        if(Input.GetKeyDown("2")){
            SetActive("2");
        }
        if(Input.GetKeyDown("3")){
            SetActive("3");
        }
    }

    public void SetActive(string option) {
        switch (option) {
            case "1":
                gameManager.config[GameManager.PHASE_STATE] = GameManager.PhaseState.PHASE_1;
                Debug.Log(gameManager.config[GameManager.PHASE_STATE]);
                break;
            case "2":
                gameManager.config[GameManager.PHASE_STATE] = GameManager.PhaseState.PHASE_2;
                break;
            case "3":
                gameManager.config[GameManager.PHASE_STATE] = GameManager.PhaseState.PHASE_3;
                break;
            default:
                Debug.Log("Cannot do anything here");
                break;
        }
    }
    

    void OnTriggerEnter(Collider other){           
        if(other.gameObject.tag == "DeathZone"){
            tr.position = respawnPoint.transform.position;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Sphere")
        {
            Destroy(collision.collider.gameObject);
            gameManager.UpdateScore();
        }
        
    }
}
