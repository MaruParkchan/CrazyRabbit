using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleText : MonoBehaviour
{
    [SerializeField] private GameObject targetImage; // 활성화할 창

    //[SerializeField] private Text startKey; // 텍스트 크기 변화줄 Text Object
    //[SerializeField] private int sizeSpeed; // 텍스트 크기 변환 속도 
    //[SerializeField] private int maxValue; // 최대 크기
    //[SerializeField] private int minValue; // 최소 크기

    private KeyCode startKeyInput = KeyCode.Space; // Input 키 
    private int fontValue = 50; // 폰트 사이즈 
    private bool isSize;  // True 일시 Up - False 일시 Down
    private bool click; // 바로 클릭 못하게 막기 

    void Start()
    {

        // StartCoroutine(SizeUpDownLoop()); 
    }

    void Update()
    {
        //startKey.fontSize = fontValue;

        //if (isSize)
        //    SizeUp_();
        //else
        //    SizeDown_();

        InputKey();
    }

    //private void SizeUp_() // 폰트 사이즈 업 
    //{
    //    if (fontValue < maxValue)
    //        fontValue += sizeSpeed;
    //    else
    //        isSize = false;
    //}

    //private void SizeDown_() // 폰트 사이즈 다운
    //{
    //    if (fontValue > minValue)
    //        fontValue -= sizeSpeed;
    //    else
    //        isSize = true;
    //}

    private void InputKey() // 클릭 메소드
    {
        if (Input.GetKeyDown(startKeyInput))
        {
            this.gameObject.SetActive(false);
            targetImage.SetActive(true);
        }
    }

    #region 
    //IEnumerator SizeUpDownLoop()
    //{
    //    while(true)
    //    {
    //        yield return StartCoroutine(SizeUp());

    //        yield return StartCoroutine(SizeDown());
    //    }
    //}

    //IEnumerator SizeUp()
    //{
    //    while(fontValue < maxValue)
    //    {
    //        fontValue += sizeSpeed;
    //        yield return null;
    //    }
    //}

    //IEnumerator SizeDown()
    //{
    //    while (fontValue > minValue)
    //    {
    //        fontValue -= sizeSpeed;
    //        yield return null;
    //    }
    //}
    #endregion

    //IEnumerator ClickOn()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    click = true;
    //}
}