using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject here
            if (player.HasKitchenObject())
            {
                // Player is carrying kitchenObject
                player.GetKitchenObject().SetKitchObjectParent(this);
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {

            // There is KitchenObject here
            if (player.HasKitchenObject())
            {
                // Player has carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestorySelf();
                    }
                }
                else
                {
                    // Player is not carrying Plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Couner is holding a Plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestorySelf();
                        }
                    }

                }
            }
            else
            {
                // Player is not carrying anything
                GetKitchenObject().SetKitchObjectParent(player);
            }
        }
    }

}
