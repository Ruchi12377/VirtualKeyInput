using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class VirtualInput : MonoBehaviour
{
    [SerializeField] private Button execute;
    private InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponent<InputField>();
        execute.onClick.AddListener(OnClick);
    }

    private async void OnClick()
    {
        var target = _inputField.text.ToUpper().Replace(" ", "");
            
        _inputField.text = "";

        foreach (var x in target)
        {
            if (CheckKey(x))
            {
                Debug.Log("input : " + x);
                await Task.Delay(100);
                //Down
                WinApi32.keybd_event((byte)x, 0, 0, (UIntPtr)0);
                //Wait
                await Task.Delay(1000);
                //Up
                WinApi32.keybd_event((byte)x, 0, 2, (UIntPtr)0);
                //Wait
                await Task.Delay(100);
            }
        }
    }

    private static bool CheckKey(char c) => '0' <= c && c <= '9' || 'A' <= c && c <= 'Z' || c == '\t';
}