using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(UnityStandardAssets.Characters.ThirdPerson.AICharacterControl))]
public class Movel : Unidade {

    public int velocidadeDeslocamento;
    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl _characterController;

    // Use this for initialization
    internal override void Start()
    {
        base.Start();
        _characterController = unidade.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
    }

    // Update is called once per frame
    // internal override void Update () {
    //    base.Update();
    //    if (Input.GetButtonUp("Fire2"))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit; //Pontos da colisão...
    //        if (Physics.Raycast(ray.origin, ray.direction, out hit))
    //        {
    //            StartCoroutine(MoverPara(hit.point));
    //        }
    //    }
    //}

    //public float speed = 3.0F;
    //public float rotateSpeed = 3.0F;
    //internal override void Update()
    //{
    //    CharacterController controller = GetComponent<CharacterController>();
    //    transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    //    Vector3 forward = transform.TransformDirection(Vector3.forward);
    //    float curSpeed = speed * Input.GetAxis("Vertical");
    //    controller.SimpleMove(forward * curSpeed);
    //}

    internal IEnumerator MoverPara(Vector3 ponto)
    {
        print("Move para: " + ponto.ToString());
        yield return null;
    }
}
