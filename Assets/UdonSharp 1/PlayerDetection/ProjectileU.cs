
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ProjectileU : UdonSharpBehaviour
{
    public Text textField;
    public Rigidbody blockRigidBody;
    public ConstantForce force;
    private Vector3 _defaultPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        //reset the block
         _defaultPosition = blockRigidBody.position;
        blockRigidBody.rotation = Quaternion.identity;
        blockRigidBody.velocity = Vector3.zero;
    }

    public void SendProjectile()
    {
        textField.text = $"Sending projectile at {Time.time}";
        
        ResetBlock();
        
        //enable the force
        force.enabled = true;
        
    }

    public override void OnPlayerCollisionExit(VRCPlayerApi player)
    {
        textField.text = $"{player.displayName} Exited at {Time.time}";
        ResetBlock();
    }

    public override void OnPlayerCollisionEnter(VRCPlayerApi player)
    {
        textField.text = $"Collision! at {Time.time}";
        player.PlayHapticEventInHand(VRC_Pickup.PickupHand.Left,0.25f,1f,1f);
        player.PlayHapticEventInHand(VRC_Pickup.PickupHand.Right,0.25f,1f,1f);
        ResetBlock();
    }

    private void ResetBlock()
    {
        //reset the block
        force.enabled = false;
        blockRigidBody.velocity = Vector3.zero;
        blockRigidBody.angularVelocity = Vector3.zero;
        blockRigidBody.position = _defaultPosition;
        blockRigidBody.rotation = Quaternion.identity;
    }
}
