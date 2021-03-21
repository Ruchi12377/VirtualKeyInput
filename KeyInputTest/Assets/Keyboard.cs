using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    private List<(Image img, Text text, char label)> _keys;
    private static readonly Color Light = new Color(1, 1, 1, 1);
    private static readonly Color Dark = new Color(0.5f, 0.5f, 0.5f, 1);
    private void Awake()
    {
        var images = new List<Image>();
        images.AddRange(transform.GetChild(0).GetComponentsInChildren<Image>());
        images.AddRange(transform.GetChild(1).GetComponentsInChildren<Image>());
        images.AddRange(transform.GetChild(2).GetComponentsInChildren<Image>());
        
        _keys = images.Select(x => (img : x, text : x.transform.GetChild(0).GetComponent<Text>()))
            .Select(x => (x.img, x.text, x.text.text.ToLower()[0])).ToList();
    }

    public void Update()
    {
        _keys.ForEach(x =>
        {
            var (img, _, label) = x;
            img.color = Input.GetKey(label.ToString()) ? Light : Dark;
        });
    }
}
