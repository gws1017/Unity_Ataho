using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float RayDistance = 1f;
    [SerializeField]
    GameManager manager;

    public string mapName = "village";

    float h;
    float v;

    Vector3 dirVec;

    bool isHorizonMove;

    Rigidbody2D rigid;
    Animator anim;
    GameObject scanObject;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(manager.isAction == false)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            bool hDown = Input.GetButtonDown("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool vUp = Input.GetButtonUp("Vertical");
            bool hUp = Input.GetButtonUp("Horizontal");
            if (hDown)
                isHorizonMove = true;
            else if (vDown)
                isHorizonMove = false;
            else if (hUp || vUp)
                isHorizonMove = h != 0;

            //Animation
            if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);

            }
            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
                anim.SetBool("isChange", false);

            if (vDown && v == 1)
                dirVec = Vector3.up;
            else if (vDown && v == -1)
                dirVec = Vector3.down;
            else if (hDown && h == -1)
                dirVec = Vector3.left;
            else if (hDown && h == 1)
                dirVec = Vector3.right;
        }
       

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Enter"))
        {
            if(scanObject != null)
            {
                manager.Action(scanObject);
            }
        }

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0,v);
        rigid.velocity = moveVec * speed;

        Debug.DrawRay(rigid.position, dirVec * RayDistance, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, RayDistance,LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;
    }
}
