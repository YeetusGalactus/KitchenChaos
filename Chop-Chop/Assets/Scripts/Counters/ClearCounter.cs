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
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    //player is not holding a plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        //Counter is holding a plateS
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) { 
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            } else {
                // Player does not have a kitchen object
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
