// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerAnimatorManager.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in PUN Basics Tutorial to deal with the networked player Animator Component controls.
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace OnlineParty
{
	public class PlayerAnimatorManager : MonoBehaviourPun 
	{
        #region Private Fields

        [SerializeField]
	    private float directionDampTime = 0.0f;
	    //private float directionDampTime = 0.25f;
        Animator animator;

		#endregion

		#region MonoBehaviour CallBacks

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
	    void Start () 
	    {
	        animator = GetComponent<Animator>();
	    }
	        
		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
	    void Update () 
	    {

			// Prevent control is connected to Photon and represent the localPlayer
	        if( photonView.IsMine == false && PhotonNetwork.IsConnected == true )
	        {
	            return;
	        }

			// failSafe is missing Animator component on GameObject
	        if (!animator)
	        {
				return;
			}

			// deal with Jumping
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);			


			var chatGui = GameObject.Find("ChatGui");


			if(chatGui == null || !chatGui.activeSelf)
			{
				// only allow jumping if we are running.
				if (stateInfo.IsName("Base Layer.Run"))
				{
					// When using trigger parameter
					if (Input.GetButtonDown("Fire2")) animator.SetTrigger("Jump"); 
				}
			
				// deal with movement
				float h = Input.GetAxis("Horizontal");
				float v = Input.GetAxis("Vertical");
				float speed = (h==0 && v==0? 0 : 1);
				float velocity = (v == -1? -speed: speed);
				// prevent negative Speed.
				
				if( v < 0 )
				{
					v = 0;
				}

				// set the Animator Parameters
				animator.SetFloat( "Speed", speed );
				animator.SetFloat( "Velocity", velocity);
				animator.SetFloat( "DirectionX", h, directionDampTime, Time.deltaTime );
				animator.SetFloat( "DirectionY", v, directionDampTime, Time.deltaTime );
			}
			else
			{
				animator.SetFloat( "Speed", 0 );
				animator.SetFloat( "Velocity", 0 );
				animator.SetFloat( "DirectionX", 0, directionDampTime, Time.deltaTime );
				animator.SetFloat( "DirectionY", 0, directionDampTime, Time.deltaTime );
			}
		}

		#endregion

	}
}