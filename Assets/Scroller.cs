using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private Rigidbody2D RIGIDBODY;
    private float m_Speed = -1.5f;
    [SerializeField] private bool m_stopScrolling;
    // Start is called before the first frame update
    void Start()
    {
        RIGIDBODY = GetComponent<Rigidbody2D>();
        RIGIDBODY.velocity = new Vector2(0, m_Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_stopScrolling) {
            RIGIDBODY.velocity = Vector2.zero;
        } else {
            RIGIDBODY.velocity = new Vector2(0, m_Speed);
        }
    }
}
