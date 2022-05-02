using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mukavemet : MonoBehaviour
{
    #region Değişken Tanımları
    public GameObject AşağıOk, YukarıOk, SağaOk, SolaOk, SağaOkUzun, SolaOkUzun, YukarıOkUzun, AşağıOkUzun, SağaOkKısa,
        SolaOkKısa, YukarıOkKısa, AşağıOkKısa, XGerilmeText, YGerilmeText, XYKaymaGerilmesiSağText, XYKaymaGerilmesiSolText,
        SigmaMaxText, SigmaMinText, TaoMaxText, ThetaPText, ThetaSText, D1SigmaXText, D1SigmaYText, D2SigmaXText, D2SigmaYText,
        D2TaoXYSağText, D2TaoXYSolText, D1AçıText, D2AçıText, D1Açı, D2Açı,
        Düzlem1, Düzlem2, Düzlem3, DüzlemAyarMenü, BilgiMenüsü, ŞekilMenüsü;
    public float XGerilme, YGerilme, XYGerilme, SigmaMax, SigmaMin, D1YeniSigmaX, D1YeniSigmaY, D2YeniSigma, TaoMax, 
        ThetaP, ThetaS;
    public GameObject XSağ, XSol, YYukarı, YAşağı, XYSağ, XYSol, XYYukarı, XYAşağı, D1XSağ, D1XSol, D1YYukarı, D1YAşağı,
        D2XSağ, D2XSol, D2YYukarı, D2YAşağı, D2XYSağ, D2XYSol, D2XYYukarı, D2XYAşağı;
    #endregion
    #region Arayüz Ayarları
    public void XGerilmesiniBelirle()
    {
        XGerilme = GameObject.Find("INPT_XGerilme").GetComponent<InputField>().text == "" ? 0 : int.Parse(GameObject.Find("INPT_XGerilme").GetComponent<InputField>().text);
        if (XSağ == null && XSol == null)
        {
            XSağ = Instantiate(SağaOk, Vector3.zero, Quaternion.identity, Düzlem1.transform);

            XSol = Instantiate(SolaOk, Vector3.zero, Quaternion.identity, Düzlem1.transform);
        }
        XSağ.GetComponent<RectTransform>().localPosition = new Vector3(300, 0, 0);
        XSağ.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, XGerilme > 0 ? 90 : 270);

        XSol.GetComponent<RectTransform>().localPosition = new Vector3(-300, 0, 0);
        XSol.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, XGerilme > 0 ? -90 : 90);

        XGerilmeText.SetActive(true);
        XGerilmeText.GetComponent<Text>().text = XGerilme + " MPa";

        if (XGerilme == 0)
        {
            Destroy(XSağ);
            Destroy(XSol);
            XGerilmeText.SetActive(false);
        }
    }

    public void YGerilmesiniBelirle()
    {
        YGerilme = GameObject.Find("INPT_YGerilme").GetComponent<InputField>().text == "" ? 0 : int.Parse(GameObject.Find("INPT_YGerilme").GetComponent<InputField>().text);
        if (YYukarı == null && YAşağı == null)
        {
            YYukarı = Instantiate(AşağıOk, Vector3.zero, Quaternion.identity, Düzlem1.transform);

            YAşağı = Instantiate(YukarıOk, Vector3.zero, Quaternion.identity, Düzlem1.transform);
        }
        YYukarı.GetComponent<RectTransform>().localPosition = new Vector3(0, 300, 0);
        YYukarı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, YGerilme > 0 ? 180 : 0);

        YAşağı.GetComponent<RectTransform>().localPosition = new Vector3(0, -300, 0);
        YAşağı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, YGerilme > 0 ? 0 : 180);

        YGerilmeText.SetActive(true);
        YGerilmeText.GetComponent<Text>().text = YGerilme + " MPa";

        if (YGerilme == 0)
        {
            Destroy(YYukarı);
            Destroy(YAşağı);
            YGerilmeText.SetActive(false);
        }
    }

    public void XYKaymaGerilmesiniBelirle()
    {
        XYGerilme = GameObject.Find("INPT_XYKaymaGerilme").GetComponent<InputField>().text == "" ? 0 : int.Parse(GameObject.Find("INPT_XYKaymaGerilme").GetComponent<InputField>().text);
        if (XYSağ == null && XYSol == null && XYAşağı == null && XYYukarı == null)
        {
            XYSağ = Instantiate(SağaOkUzun, Vector3.zero, Quaternion.identity, Düzlem1.transform);

            XYYukarı = Instantiate(YukarıOkUzun, Vector3.zero, Quaternion.identity, Düzlem1.transform);

            XYSol = Instantiate(SolaOkUzun, Vector3.zero, Quaternion.identity, Düzlem1.transform);

            XYAşağı = Instantiate(YukarıOkUzun, Vector3.zero, Quaternion.identity, Düzlem1.transform);
        }
        XYSağ.GetComponent<RectTransform>().localPosition = new Vector3(0, 250, 0);
        XYSağ.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, XYGerilme > 0 ? 90 : -90);

        XYYukarı.GetComponent<RectTransform>().localPosition = new Vector3(250, 0, 0);
        XYYukarı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, XYGerilme > 0 ? 180 : 0);

        XYSol.GetComponent<RectTransform>().localPosition = new Vector3(0, -250, 0);
        XYSol.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, XYGerilme > 0 ? -90 : 90);

        XYAşağı.GetComponent<RectTransform>().localPosition = new Vector3(-250, 0, 0);
        XYAşağı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, XYGerilme > 0 ? 0 : 180);

        if (XYGerilme > 0)
        {
            XYKaymaGerilmesiSağText.SetActive(true);
            XYKaymaGerilmesiSolText.SetActive(false);
            XYKaymaGerilmesiSağText.GetComponent<Text>().text = XYGerilme + " MPa";
        }
        else if (XYGerilme < 0)
        {
            XYKaymaGerilmesiSolText.SetActive(true);
            XYKaymaGerilmesiSağText.SetActive(false);
            XYKaymaGerilmesiSolText.GetComponent<Text>().text = XYGerilme + " MPa";
        }
        else if (XYGerilme == 0)
        {
            Destroy(XYYukarı);
            Destroy(XYSağ);
            Destroy(XYSol);
            Destroy(XYAşağı);
            XYKaymaGerilmesiSağText.SetActive(false);
            XYKaymaGerilmesiSolText.SetActive(false);
        }
    }
    #endregion
    #region Hesaplamalar
    public void Hesapla()
    {
        float sigmaAVE = (XGerilme + YGerilme) / 2;
        float taoMAX = Mathf.Sqrt(Mathf.Pow((XGerilme - YGerilme) / 2, 2) + Mathf.Pow(XYGerilme, 2));
        float sigmaMAX = sigmaAVE + taoMAX;
        float sigmaMIN = sigmaAVE - taoMAX;

        float thetaP = Mathf.Atan(2 * XYGerilme / (XGerilme - YGerilme)) * Mathf.Rad2Deg / 2;
        float thetaS = Mathf.Atan((YGerilme - XGerilme) / (2 * XYGerilme)) * Mathf.Rad2Deg / 2;

        SigmaMax = sigmaMAX;
        SigmaMin = sigmaMIN;
        TaoMax = taoMAX;
        ThetaP = thetaP;
        ThetaS = thetaS;

        D1YeniSigmaX = XGerilme > YGerilme ? sigmaMAX : sigmaMIN;
        D1YeniSigmaY = XGerilme > YGerilme ? sigmaMIN : sigmaMAX;

        D2YeniSigma = sigmaAVE;

        DüzlemAyarMenü.SetActive(false);
        BilgiMenüsü.SetActive(true);
        ŞekilMenüsü.SetActive(false);

        SigmaMaxText.GetComponent<Text>().text = "Maximum Normal Gerilme: " + sigmaMAX.ToString("F2") + " MPa";
        SigmaMinText.GetComponent<Text>().text = "Minimum Normal Gerilme: " + sigmaMIN.ToString("F2") + " MPa";
        TaoMaxText.GetComponent<Text>().text = "Maximum Kayma Gerilmesi: " + taoMAX.ToString("F2") + " MPa";
        ThetaPText.GetComponent<Text>().text = "Maximum Normal Gerilme Açısı: " + thetaP.ToString("F2") + "°";
        ThetaSText.GetComponent<Text>().text = "Maximum Kayma Gerilmesi Açısı: " + thetaS.ToString("F2") + "°";

        Debug.Log("SigmaMax & SigmaMin: " + sigmaMAX + " & " + sigmaMIN + " TaoMax: " + taoMAX + " ThetaForSigma & ThetaForTaoMax: " + thetaP + " & " + thetaS);
    }

    public void SıfırlaVeBaşaDön()
    {
        XGerilme = 0;
        YGerilme = 0;
        XYGerilme = 0;

        SigmaMax = 0;
        SigmaMin = 0;
        TaoMax = 0;
        ThetaP = 0;
        ThetaS = 0;

        D1YeniSigmaX = 0;
        D1YeniSigmaY = 0;

        D2YeniSigma = 0;

        Düzlem2.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
        Düzlem3.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);

        Düzlem2.SetActive(false);
        Düzlem3.SetActive(false);
        Düzlem1.SetActive(true);

        DüzlemAyarMenü.SetActive(true);
        BilgiMenüsü.SetActive(false);
        ŞekilMenüsü.SetActive(false);

        GameObject.Find("INPT_XGerilme").GetComponent<InputField>().text = "";
        GameObject.Find("INPT_YGerilme").GetComponent<InputField>().text = "";
        GameObject.Find("INPT_XYKaymaGerilme").GetComponent<InputField>().text = "";

        Destroy(XSağ); Destroy(XSol); Destroy(YYukarı); Destroy(YAşağı); Destroy(XYSağ); Destroy(XYSol); Destroy(XYYukarı);
        Destroy(XYAşağı); Destroy(D1XSağ); Destroy(D1XSol); Destroy(D1YYukarı); Destroy(D1YAşağı);
        Destroy(D2XSağ); Destroy(D2XSol); Destroy(D2YYukarı); Destroy(D2YAşağı); Destroy(D2XYSağ); Destroy(D2XYSol);
        Destroy(D2XYYukarı); Destroy(D2XYAşağı);
    }

    //                                 c                a               e               d               b
    public float Interpolation(float FirstMin, float FirstMax, float SecondMin, float SecondMax, float value, bool BetweenFirst = true)
    {
        float x = 0;
        if (BetweenFirst)
        {
            x = (FirstMin * SecondMax + value * SecondMin - FirstMax * SecondMin - value * SecondMax) / (FirstMin - FirstMax);
        }
        else
        {
            x = (FirstMax * value + FirstMin * SecondMax - FirstMax * SecondMin - FirstMin * value) / (SecondMax - SecondMin);
        }
        return x;
    }
    #endregion
    #region Şekil Çizme
    public void ŞekilleriGöster()
    {
        DüzlemAyarMenü.SetActive(false);
        BilgiMenüsü.SetActive(false);
        ŞekilMenüsü.SetActive(true);
        Düzlem1.SetActive(false);
        Düzlem2.SetActive(true);
        Düzlem3.SetActive(true);

        if (D1YeniSigmaX != 0)
        {
            if (D1XSağ == null && D1XSol == null)
            {
                D1XSağ = Instantiate(SağaOkKısa, Vector3.zero, Quaternion.identity, Düzlem2.transform);
                D1XSol = Instantiate(SolaOkKısa, Vector3.zero, Quaternion.identity, Düzlem2.transform);
            }

            D1XSağ.GetComponent<RectTransform>().localPosition = new Vector3(200, 0, 0);
            D1XSağ.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D1YeniSigmaX > 0 ? 90 : 270);

            D1XSol.GetComponent<RectTransform>().localPosition = new Vector3(-200, 0, 0);
            D1XSol.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D1YeniSigmaX > 0 ? -90 : 90);

            D1SigmaXText.SetActive(true);
            D1SigmaXText.GetComponent<Text>().text = D1YeniSigmaX.ToString("F1") + " MPa";
            D1SigmaXText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaP);
        }
        else
        {
            D1SigmaXText.SetActive(false);
            Destroy(D1XSağ);
            Destroy(D1XSol);
        }

        if (D1YeniSigmaY != 0)
        {
            if (D1YYukarı == null && D1YAşağı == null)
            {
                D1YYukarı = Instantiate(YukarıOkKısa, Vector3.zero, Quaternion.identity, Düzlem2.transform);
                D1YAşağı = Instantiate(AşağıOkKısa, Vector3.zero, Quaternion.identity, Düzlem2.transform);
            }

            D1YYukarı.GetComponent<RectTransform>().localPosition = new Vector3(0, 200, 0);
            D1YYukarı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D1YeniSigmaY > 0 ? 180 : 0);

            D1YAşağı.GetComponent<RectTransform>().localPosition = new Vector3(0, -200, 0);
            D1YAşağı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D1YeniSigmaY > 0 ? 0 : 180);
            
            D1SigmaYText.SetActive(true);
            D1SigmaYText.GetComponent<Text>().text = D1YeniSigmaY.ToString("F1") + " MPa";
            D1SigmaYText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaP);
        }
        else
        {
            D1SigmaYText.SetActive(false);
            Destroy(D1YYukarı);
            Destroy(D1YAşağı);
        }

        if (TaoMax != 0)
        {
            if (D2XYSağ == null && D2XYSol == null && D2XYYukarı == null && D2XYAşağı == null)
            {
                D2XYSağ = Instantiate(SağaOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                D2XYSol = Instantiate(SolaOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                D2XYYukarı = Instantiate(YukarıOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                D2XYAşağı = Instantiate(AşağıOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
            }

            D2XYSağ.GetComponent<RectTransform>().localPosition = new Vector3(0, 150, 0);
            D2XYSağ.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, TaoMax > 0 ? 90 : 270);

            D2XYSol.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
            D2XYSol.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, TaoMax > 0 ? -90 : 90);

            D2XYYukarı.GetComponent<RectTransform>().localPosition = new Vector3(150, 0, 0);
            D2XYYukarı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, TaoMax > 0 ? 180 : 0);

            D2XYAşağı.GetComponent<RectTransform>().localPosition = new Vector3(-150, 0, 0);
            D2XYAşağı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, TaoMax > 0 ? 0 : 180);

            if (TaoMax > 0)
            {
                D2TaoXYSağText.SetActive(true);
                D2TaoXYSolText.SetActive(false);

                D2TaoXYSağText.GetComponent<Text>().text = TaoMax.ToString("F1") + " MPa";
                D2TaoXYSağText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaS);
            }
            if (TaoMax < 0) 
            { 
                D2TaoXYSolText.SetActive(true);
                D2TaoXYSağText.SetActive(false);

                D2TaoXYSolText.GetComponent<Text>().text = TaoMax.ToString("F1") + " MPa";
                D2TaoXYSolText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaS);
            }


            if (D2YeniSigma != 0)
            {
                if (D2XSağ == null && D2XSol == null && D2YYukarı == null && D2YAşağı == null)
                {
                    D2XSağ = Instantiate(SağaOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                    D2XSol = Instantiate(SolaOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                    D2YYukarı = Instantiate(YukarıOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                    D2YAşağı = Instantiate(AşağıOkKısa, Vector3.zero, Quaternion.identity, Düzlem3.transform);
                }

                D2XSağ.GetComponent<RectTransform>().localPosition = new Vector3(200, 0, 0);
                D2XSağ.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D2YeniSigma > 0 ? 90 : 270);

                D2XSol.GetComponent<RectTransform>().localPosition = new Vector3(-200, 0, 0);
                D2XSol.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D2YeniSigma > 0 ? -90 : 90);

                D2YYukarı.GetComponent<RectTransform>().localPosition = new Vector3(0, 200, 0);
                D2YYukarı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D2YeniSigma > 0 ? 0 : 180);

                D2YAşağı.GetComponent<RectTransform>().localPosition = new Vector3(0, -200, 0);
                D2YAşağı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, D2YeniSigma > 0 ? 0 : 180);

                D2SigmaXText.SetActive(true);
                D2SigmaXText.GetComponent<Text>().text = D2YeniSigma.ToString("F1") + " MPa";
                D2SigmaXText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaS);

                D2SigmaYText.SetActive(true);
                D2SigmaYText.GetComponent<Text>().text = D2YeniSigma.ToString("F1") + " MPa";
                D2SigmaYText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaS);
            }
            else
            {
                D2SigmaXText.SetActive(false);
                D2SigmaYText.SetActive(false);
                Destroy(D2XSağ);
                Destroy(D2XSol);
                Destroy(D2YYukarı);
                Destroy(D2YAşağı);
            }
        }
        else
        {
            D2TaoXYSolText.SetActive(false);
            D2TaoXYSağText.SetActive(false);
            Destroy(D2XYSağ);
            Destroy(D2XYSol);
            Destroy(D2XYYukarı);
            Destroy(D2XYAşağı);
        }

        Düzlem2.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, ThetaP);
        Düzlem3.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, ThetaS);

        D1AçıText.GetComponent<Text>().text = ThetaP.ToString("F2") + "°";
        //D1AçıText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaP);
        if (ThetaP > 0)
        {
            D1Açı.GetComponent<Image>().fillAmount = Interpolation(0, 1, 0, 360, ThetaP, false);
            D1Açı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("ThetaP > 0");
        }
        else if (ThetaP < 0)
        {
            D1Açı.GetComponent<Image>().fillAmount = Interpolation(0, 1, 0, 360, Mathf.Abs(ThetaP), false);
            D1Açı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, ThetaP);
            Debug.Log("ThetaP < 0");
        }
        else
        {
            D1Açı.GetComponent<Image>().fillAmount = 0;
            D1Açı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("ThetaP = 0");
        }

        D2AçıText.GetComponent<Text>().text = ThetaS.ToString("F2") + "°";
        //D2AçıText.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -ThetaS);
        if (ThetaS > 0)
        {
            D2Açı.GetComponent<Image>().fillAmount = Interpolation(0, 1, 0, 360, ThetaS, false);
            D2Açı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("ThetaS > 0");
        }
        else if (ThetaS < 0)
        {
            D2Açı.GetComponent<Image>().fillAmount = Interpolation(0, 1, 0, 360, Mathf.Abs(ThetaS), false);
            D2Açı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, ThetaS);
            Debug.Log("ThetaS < 0");
        }
        else
        {
            D2Açı.GetComponent<Image>().fillAmount = 0;
            D2Açı.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("ThetaS = 0");
        }
    }
    #endregion
}
