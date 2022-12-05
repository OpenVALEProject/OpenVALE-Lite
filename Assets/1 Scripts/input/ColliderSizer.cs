using UnityEngine;

public class ColliderSizer : MonoBehaviour {
    void Start() {
        var collider = GetComponent<BoxCollider>();
        var rectTransform = transform.GetComponent<RectTransform>();
        // Must center everything if pivot not already centered (equal to (0.5, 0.5))
        var xAdjustment = (float) (0.5 - rectTransform.pivot.x);
        var yAdjustment = (float) (0.5 - rectTransform.pivot.y);
        // Center is local to the GameObject
        collider.center = new Vector3(xAdjustment * rectTransform.rect.width, yAdjustment * rectTransform.rect.height, 0);
        collider.size = new Vector3(rectTransform.rect.width, rectTransform.rect.height, 0.1f);
    }
}
