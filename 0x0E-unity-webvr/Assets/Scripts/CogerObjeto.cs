using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint;
    private GameObject PicketObject = null;

    // Update is called once per frame
    void Update()
    {
        if (PicketObject != null)
        {
            if (Input.GetKey("r"))
            {
                PicketObject.GetComponent<Rigidbody>().useGravity = true;
                PicketObject.GetComponent<Rigidbody>().isKinematic = false;
                PicketObject.gameObject.transform.SetParent(null);
                PicketObject = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Input.GetKey("e") && PicketObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = transform.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                PicketObject = other.gameObject;
            }
        }
    }
}
