using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : NetworkBehaviour {

	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private NetworkAnimator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;


	
	void Start()
	{
        if (!isLocalPlayer)
        {
            return;
        }
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<NetworkAnimator>();
		anim.SetTrigger("Parado");
	}

	void Update()
	{
        if (!isLocalPlayer)
        {
            return;
        }
        Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));
		
		if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
				gravidade.y = 3f;
				jump = false;
			}
		}
		move += gravidade;
		cc.Move (move* Time.deltaTime);
		Anima ();
	}
	 
	void Anima()
	{
		if (!Input.anyKey)
		{
			anim.SetTrigger("Parado");
		} 
		else 
		{
			if(Input.GetKeyDown("space"))
			{
				anim.SetTrigger("Pula");
				jump = true;
			}
			else
			{
				anim.SetTrigger("Corre");
			}
		}
	}
}
