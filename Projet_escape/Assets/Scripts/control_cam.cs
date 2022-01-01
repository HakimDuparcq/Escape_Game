using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_cam : MonoBehaviour
{
    public float movForce = 50;
    public Transform targetTransform;
    public float offsetx = 10;
    public float offsety = 10;
    private Rigidbody mrigid;
    Vector3 destination;
    private Vector3 lautre;
    Vector3 Rotation;
    public float sensibilite =4f;
    // Start is called before the first frame update
    void Start()
    {
        mrigid = GetComponent<Rigidbody>();
        PlayerPrefs.SetFloat("offsettx", offsetx);
        PlayerPrefs.SetFloat("offsetty", offsety);
        PlayerPrefs.SetFloat("force_cam", movForce);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(targetTransform.right * Input.GetAxis("Mouse Y") * 20);
        if (Input.GetMouseButton(1))
        {
            Rotation.z += Input.GetAxis("Mouse Y") * sensibilite;
            Rotation.y += Input.GetAxis("Mouse X") * sensibilite;
        }
   

        Rotation.z = Mathf.Clamp(Rotation.z, -100f, 400f);
        //lautre=lautre + targetTransform.right * Input.GetAxis("Mouse X") * 2;
        targetTransform.rotation = Quaternion.Euler(0, Rotation.y, Rotation.z);

        //destination = targetTransform.position - (targetTransform.forward * offsetx - targetTransform.up * offsety);
        destination = targetTransform.position - (targetTransform.forward*PlayerPrefs.GetFloat("offsettx") - targetTransform.up* PlayerPrefs.GetFloat("offsetty")) ;
        //Debug.Log(destination);
        //mrigid.AddForce((-transform.position + destination) * movForce);
        mrigid.AddForce((-transform.position + destination) * PlayerPrefs.GetFloat("force_cam"));
        transform.LookAt(targetTransform.position);
    }



}
