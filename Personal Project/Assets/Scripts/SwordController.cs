using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    GameObject swordOriginal;
    GameObject swordHolder;
    GameObject swordUp;
    GameObject swordLeft;
    float swingTime = 0.01f;
    float swingSpeed = 0.2f;
    bool swinging = false;
    // Start is called before the first frame update
    void Start()
    {
        swordHolder = GameObject.Find("SwordHolder");
        swordUp = GameObject.Find("SwordUp");
        swordLeft = GameObject.Find("SwordLeft");
        swordOriginal = GameObject.Find("SwordOriginalPos");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !swinging)
        {
                StartCoroutine(swing());
        }
        transform.position = swordHolder.transform.position;
        transform.rotation = swordHolder.transform.rotation;
    }IEnumerator swing()  
{
        swinging = true;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(swingTime);
            swordHolder.transform.localPosition = Vector3.Slerp(swordHolder.transform.localPosition, swordUp.transform.localPosition, swingSpeed);
            swordHolder.transform.localRotation = Quaternion.Slerp(swordHolder.transform.localRotation, swordUp.transform.localRotation, swingSpeed);

        }
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(swingTime);
            swordHolder.transform.localPosition = Vector3.Slerp(swordHolder.transform.localPosition, swordLeft.transform.localPosition, swingSpeed);
            swordHolder.transform.localRotation = Quaternion.Slerp(swordHolder.transform.localRotation, swordLeft.transform.localRotation, swingSpeed);

        }
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(swingTime);
            swordHolder.transform.localPosition = Vector3.Slerp(swordHolder.transform.localPosition, swordOriginal.transform.localPosition, swingSpeed);
            swordHolder.transform.localRotation = Quaternion.Slerp(swordHolder.transform.localRotation, swordOriginal.transform.localRotation, swingSpeed);

        }
        swinging = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && swinging)
        {
            Destroy(other.gameObject);
        }
    }
    
}



