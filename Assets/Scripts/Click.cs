using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        PianoKey pianoKey = hit.transform.GetComponent<PianoKey>();
                        if (pianoKey != null)
                        {
                            pianoKey.Tocar();
                        }
                    }
                }
            }
        }

        
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                PianoKey pianoKey = hit.transform.GetComponent<PianoKey>();
                if (pianoKey != null)
                {
                    pianoKey.Tocar();
                }
            }
        }
#endif
    }
}
