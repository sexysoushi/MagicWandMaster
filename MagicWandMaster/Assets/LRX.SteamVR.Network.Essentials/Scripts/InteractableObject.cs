using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum ObjectSnap
{
    Grip,
    Exact
}

public class InteractableObject : NetworkBehaviour
{

    public ObjectSnap snapType;
    public bool isUsable;

	//[SyncVar]
	//public NetworkInstanceId touchingControllerId;


    // NOTE: possible optimization: when attaching the object to the controller, we do not need to keep sending transform sync updates
    // for this object since the position is depending on the parent, the controller, which we already sync..
	[ClientRpc]
	public void RpcAttachToHand(NetworkInstanceId handId)
    {
        var hand = ClientScene.FindLocalObject(handId);
        if (hand == null)
            return;
        AttachToHand(hand);
    }

    // this should be run on Client & Server!
    public void AttachToHand(GameObject hand)
    {
        //var controller = hand.transform.parent;
        var attachpoint = hand.transform.FindChild("Attachpoint");
        switch (snapType)
        {
            case ObjectSnap.Exact:
                transform.parent = attachpoint.transform;
                break;
            case ObjectSnap.Grip:
                Helper.AttachAtGrip(attachpoint, transform);
                break;
        }
        GetComponent<Rigidbody>().isKinematic = true;
    }
    
    [ClientRpc]
	public void RpcDetachFromHand(Vector3 currentHolderVelocity)
	{
        DetachFromHand(currentHolderVelocity);
    }

    public void DetachFromHand(Vector3 currentHolderVelocity)
    {
        transform.parent = null;
        var rigidbodyOfObject = GetComponent<Rigidbody>();
        rigidbodyOfObject.isKinematic = false;
        rigidbodyOfObject.velocity = currentHolderVelocity*1.5f;
    }
}