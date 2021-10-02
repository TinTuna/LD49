using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D m_BackgroundCollider;
    private float m_BackgroundSize;
    void Start()
    {
        m_BackgroundCollider = GetComponent<BoxCollider2D>();
        m_BackgroundSize = m_BackgroundCollider.size.y;
    }

    void Update()
    {
        if (transform.position.y < -m_BackgroundSize*1.5) {
            RepeatBackground();
        }
    }

    void RepeatBackground() {
        Vector2 BGOffset = new Vector2(0, m_BackgroundSize*3f);
        transform.position = (Vector2)transform.position + BGOffset;
    }
}
