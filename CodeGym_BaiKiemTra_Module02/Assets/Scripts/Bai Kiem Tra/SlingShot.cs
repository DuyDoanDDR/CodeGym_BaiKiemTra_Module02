using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public Transform centerPoint;

    public GameObject bulletPrefab;
    private GameObject currentBullet;
    private bool isDragging;
    private Rigidbody bulletrb;
    public bool isRealease = false;
    public float dragMaxDistance = 20f;
    public float force = 1000f;


    // Start is called before the first frame update
    void Start()
    {

    }

    void StartDrag()
    {
        Debug.Log("StartDrag!");
        currentBullet = Instantiate(bulletPrefab, centerPoint.position, Quaternion.identity);
        bulletrb = currentBullet.GetComponent<Rigidbody>();


        bulletrb.isKinematic = true;
        isDragging = true;
    }
    void DragBullet()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
        Vector3 dragVector = mousePos - centerPoint.position;
        dragVector = Vector3.ClampMagnitude(dragVector, dragMaxDistance);
        currentBullet.transform.position = centerPoint.position + dragVector;
    }

    public void ReleaseBullet()
    {
        isRealease = true;
        isDragging = false;
        bulletrb.isKinematic = false;

        Vector3 flyingDir = centerPoint.position - currentBullet.transform.position;
        bulletrb.AddForce(flyingDir * force);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }
        if (isDragging)
        {
            DragBullet();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseBullet();
        }
    }
}
