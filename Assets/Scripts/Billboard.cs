using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + camTransform.forward);
    }
}
