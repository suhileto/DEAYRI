using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Test : MonoBehaviour
{
    [Header("Requirements")]
    [SerializeField] TextMeshProUGUI caption;
    [SerializeField] private string subtitle;

    [Header("Options")]
    [SerializeField] private int spacesCount;
    [SerializeField] private int subtitleCount;

    private List<string> subtitleSpaces = new List<string>();
    private int subtitleLength;

    private void Update()
    {
        caption.text = subtitle;

        subtitleLength = subtitle.Length;
        DivideSpaces();

        if (subtitleSpaces.Count >= spacesCount || subtitleLength > subtitleCount)
        {
            caption.text = "";
            subtitle = "";
            subtitleSpaces.Clear();
        }
    }

    private void DivideSpaces()
    {
        subtitleSpaces = subtitle.Split(' ').ToList();
    }
}
