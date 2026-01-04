using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            //There is no kitchen object on the counter
            if (player.HasKitchenObject()) { 
                //Player has a kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //Player does not have a kitchen object
            }
        } else {
            //There is a kitchen object on counter
            if (player.HasKitchenObject()) {
                //Player has a kitchen object
            } else {
                // Player does not have a kitchen object
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
