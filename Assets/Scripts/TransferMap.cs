using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferMap : MonoBehaviour
{
    Camera MainCam;
    [SerializeField]
    BoxCollider2D targetBound;
    [SerializeField]
    Vector3 transferPosition;
    [SerializeField]
    string transferMapname;
    // Start is called before the first frame update
    void Start()
    {
        MainCam = FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Transform>().position = transferPosition;
            MainCam.transform.position = new Vector3(transferPosition.x, transferPosition.y, MainCam.transform.position.z);
            MainCam.GetComponent<FollowCamera>().SetBound(targetBound);
            AudioManager.instance.PlayBGM(transferMapname);
        }
    }
}
