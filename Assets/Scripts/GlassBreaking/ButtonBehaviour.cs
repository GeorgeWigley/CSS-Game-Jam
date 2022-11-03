using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MatrixToggle
{
    // Start is called before the first frame update
    void Start()
    {
         gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnClick() {
        Debug.Log("BUTTON PRESSED");
        var obj = GameObject.FindWithTag("Disable");
        Debug.Log(obj);
        obj.GetComponent<MeshRenderer>().enabled = false;
        obj.GetComponent<Collider>().enabled = false;

    }

    public override void EnterMatrixView()
    {
         gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public override void ExitMatrixView()
    {
         gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
