using UnityEngine;
using System.Collections;

public class movementZamuraiC : MonoBehaviour {

    float velocidad = 7.0f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int maskLayer;
    float camRayLength=100f;
    bool Attack=false;
	// Use this for initialization
	void Awake () {
        maskLayer = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("b"))
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }
        Ataque(Attack);
        Move(h,v);
        Giro();
        Animacion(h, v);
     }
    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * velocidad * Time.deltaTime;
        playerRigidbody.MovePosition(this.transform.position + movement);
    }
    void Giro()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay,out floorHit,camRayLength,maskLayer))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animacion(float h, float v)
    {
        bool move=h!=0 || v!=0f;
        anim.SetBool("Run", move);
    } 

    void Ataque(bool attack)
    {
        anim.SetBool("Attack", attack);
    }
}
