using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XManager : MonoBehaviour
{
    [SerializeField] private GameObject x_marker;
    [SerializeField] private Image flash_image;
    private float timeLeft=1;
    private float flashTime=1;
    private bool flashing;
    private bool flashingOut;

    private GameObject x_mark;
    // Start is called before the first frame update

    public void place_marker(Vector3 x_pos)
    {
        x_mark = Instantiate(x_marker);
        x_mark.transform.position = x_pos;
    }

    public void flash()
    {
        flashing = true;
    }

    private void Update()
    {

        if (flashing)
        {
            if (timeLeft < 0)
            {
                flashing = false;
                timeLeft = flashTime;
            }
            else
            {
                timeLeft -= Time.deltaTime;
                Color c = flash_image.color;
                c.a = (timeLeft / flashTime-0.5f);
                flash_image.color=c;
                Debug.Log("FLASH");
                Debug.Log(c.a);

            }
        }
    }
}
