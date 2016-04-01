using UnityEngine;
using System.Collections;

public class Civil : Humano {

    public bool isConstrutor;
    public bool isReprodutor;
    public bool isColetor;
    // Use this for initialization
    internal override void Start () {
        base.Start();
	}

    // Update is called once per frame
    internal override void Update () {
        base.Update();
    }

    public override void AoEnvelhecer()
    {
        if (idade >= 16)
        {
            isColetor = true;
            if (idade >= 20)
            {
                isReprodutor = true;
                isConstrutor = true;
            }
        }
    }
}
