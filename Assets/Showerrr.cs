using UnityEngine;

public class Showerrr : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] Bounter bounceController;

    private void OnEnable()
    {
        text.text = "0";
        bounceController.onBouncedOffGround.AddListener(UpdateUI);
    }

    void UpdateUI() { text.text = bounceController.Getbounces().ToString(); }


}
