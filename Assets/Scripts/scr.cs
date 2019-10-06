using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour {
    SpriteRenderer m_SpriteRenderer;
    public float period = 0f;
    float nextactiontime = 1.0f;
    void changeColor() {
        Color m_NewColor = RandomColor();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = m_NewColor;
    }
    // Start is called before the first frame update
    void Start() {
        changeColor();
    }
    Color RandomColor() {
        // A different random value is used for each color component (if
        // the same is used for R, G and B, a shade of grey is produced).
        return new Color(Random.value, Random.value, Random.value);
    }
}
