using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool dragging;

    Vector3 originalScale;
    Vector3 offset;


    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseDrag()
    {
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        offset.z = transform.position.z;
        transform.position += offset;
    }

    public void OnMouseEnter()
    {
        transform.localScale *= 1.2f;
    }

    public void OnMouseExit()
    {
        transform.localScale = originalScale;
    }
}

