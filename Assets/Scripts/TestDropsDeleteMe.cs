using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDropsDeleteMe : MonoBehaviour
{
    DropManager dm;
    // Start is called before the first frame update
    void Start()
    {
        dm = GetComponent<DropManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(dm.DropItem());
        }
    }
}
