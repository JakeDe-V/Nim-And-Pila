using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetterModified : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target1, target2, target3, target4;
		public Transform[] targets;

		[SerializeField] private float distanceFromTargetTolerance = 5;

		private Transform target;
		private int targetsIndex;
		IAstarAI ai;

        private void Start()
        {
			//target = target1;
			target = targets[0];
			targetsIndex = 0;
        }

        void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null)
			{
				ai.destination = target.position;

				

				if ( Mathf.Abs(transform.position.x - target.position.x) <= distanceFromTargetTolerance && Mathf.Abs(transform.position.z - target.position.z) <= distanceFromTargetTolerance)
                {
					//print(transform.position);
					//print(target.position);
					//print(target1.position);
					//print(target2.position);
					/*if (target == target1) 
						{ 
						target = target2; 
						//print("going to target 2"); 
						return; 
						}
					else
					if (target == target2) 
						{ target = target3; 
						//print("going to target 3"); 
						return; 
					}
					else
					if (target == target3) 
						{ target = target4; 
						//print("going to target 4"); 
						return; 
					}
					else
					if (target == target4) 
					{ target = target1; 
						//print("going to target 1"); 
						return; }*/

					if (targetsIndex < targets.Length)
					{
						targetsIndex++;
					}
                    else
                    {
						targetsIndex = 0;
                    }

					target = targets[targetsIndex];

				}
			}
		}
	}
}
