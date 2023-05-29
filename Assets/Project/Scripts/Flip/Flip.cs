using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool _flipX;
    private bool _flipY;

    public bool flipX
    {
        get 
        {
            return _flipX;
        }

        set
        {
            if (value == _flipX)
                return;

            if(value)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                _flipX = true;
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                _flipX = false;
            }
        }
    }

    public bool flipY
    {
        get
        {
            return _flipY;
        }

        set
        {
            if (value == _flipY)
                return;

            if (value)
            {
                transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
                _flipY = true;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
                _flipY = false;
            }
        }
    }
}
