using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressPanel : MonoBehaviour
{
    [SerializeField] private StageProgress stageProgress;
    [SerializeField] private Sprite[] stageImageSprite;
    [SerializeField] private Image[] threeImage = new Image[3];
    [SerializeField] private Image[] fiveImage = new Image[5];
    private int stageCount = 0;

    private void Start()
    {
        stageCount = PlayerPrefs.GetInt("Stage");
        Debug.Log("stage -> " + stageCount);
        ImageUpdate();
    }

    private void ImageUpdate()
    {
        for(int i = 0; i < stageCount; i++)
        {
            if (stageCount == 3)
                ImageValue(threeImage, i, stageProgress.MapData[i]);
            else if(stageCount == 5)
                ImageValue(fiveImage, i, stageProgress.MapData[i]);
        }
    }

    private void ImageValue(Image[] image, int imageIndex, int spriteIndex)
    {
        image[imageIndex].sprite = stageImageSprite[spriteIndex];
    }
}