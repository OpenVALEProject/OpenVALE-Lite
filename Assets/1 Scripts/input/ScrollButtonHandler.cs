using UnityEngine;
using UnityEngine.UI;

public class ScrollButtonHandler : MonoBehaviour {

    private Scrollbar scrollbar;

    void Start() {
        scrollbar = GetComponent<Scrollbar>();
    }

    public void Up() {
        var current = scrollbar.value;
        scrollbar.value = Mathf.Min(current + .1f, 1);
    }

    public void Down() {
        var current = scrollbar.value;
        scrollbar.value = Mathf.Max(current - .1f, 0);
    }
}
