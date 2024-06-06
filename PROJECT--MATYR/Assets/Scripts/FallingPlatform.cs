using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float delayTime;
    [SerializeField] private float delayDestroy;

    private float gravity = -9.8f;
    private bool isDropping = false;

    void Update()
    {
        if(isDropping)
        {
            float x = transform.position.x;
            float y = transform.position.y + gravity * Time.deltaTime;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("touch player");
            StartCoroutine(nameof(DelayDrop));
        }
    }

    IEnumerator DelayDrop()
    {
        yield return new WaitForSeconds(delayTime);
        isDropping = true;
        Destroy(gameObject, delayDestroy);
    }
    
}
