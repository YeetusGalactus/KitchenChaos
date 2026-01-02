using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player) {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab); //spawn kitchen object
        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player); // immediately set transform to player(give the item to the player)
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
}
