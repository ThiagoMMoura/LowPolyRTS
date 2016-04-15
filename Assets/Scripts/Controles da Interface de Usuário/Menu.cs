using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private Animator _animator;
    private CanvasGroup _canvasGroup;

    public bool EstaAberto
    {
        get { return _animator.GetBool("estaAberto"); }
        set { _animator.SetBool("estaAberto", value); }
    }

	void Awake () {
        _animator = GetComponent<Animator>();
        _canvasGroup = GetComponent<CanvasGroup>();
	}
	
	
	void Update () {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Abrir"))
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
        else
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }
	}
}
