using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform CounterTopPoint;

    public void Interact() {
        Debug.Log("Interacted");
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, CounterTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
