using UnityEngine;

public class Credits : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextBox>().Initialize(TextEnum.Credits);
    }
}
