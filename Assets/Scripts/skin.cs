using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skin : MonoBehaviour {
    public float nextactiontime;
    private float period;
    SpriteRenderer m_SpriteRenderer;
    public Color[] skinColors;
    void changeColor() {
        int skin_color_num = Random.Range(0, skinColors.Length);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = skinColors[skin_color_num];
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