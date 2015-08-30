using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace BMIChecker
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private bmicalc bmi = new bmicalc();

        public MainPage()
        {
            this.InitializeComponent();
            ClearTextBox();
            txtHeight.Text = "174";
            txtWeight.Text = "63.6";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            txtResultBMI.Text = "";
            txtResulStdWeight.Text = "";
            txtResultDiffStdWeight.Text = "";
            txtResult.Text = "";
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            string strMessage = string.Empty;
            while (true)
            {
                // テキストボックスの確認をする。
                // 身長の確認
                if (txtHeight.Text == "")
                {
                    strMessage = "身長を入力してください。";
                    break;
                }

                // 体重の確認
                if (txtWeight.Text == "")
                {
                    strMessage = "体重を入力してください。";
                    break;
                }

                // パラメータチェックする
                // 型変換する
                //float fHeight=(float)(txtHeight.Text)
                float fHeight = float.Parse(txtHeight.Text)/100;
                float fWeight = float.Parse(txtWeight.Text);
                var result = bmi.CheckParam(fHeight, fWeight);
                switch (result)
                {
                    case ErrorCode.NoERR:
                        break;
                    case ErrorCode.Height:
                        strMessage = "身長が0cmになっています。正しい値を入れて下さい。";
                        // TODO:メッセージを出力する
                        break;
                    case ErrorCode.Weight:
                        strMessage = "体重が0kgになっています。正しい値を入れて下さい。";
                        // TODO:メッセージを出力する
                        break;
                    default:
                        break;
                }
                if (result != ErrorCode.NoERR)
                    break;

                // BMIの計算をする
                float fBMI = fWeight / (fHeight * fHeight);
                if (fBMI == 0)
                {
                    strMessage = "BMIが正常に算出できませんでした。";
                    break;
                }
                txtResultBMI.Text = fBMI.ToString("#.#");

                // 標準体重
                float fStdWeight = (fHeight * fHeight * 22);
                txtResulStdWeight.Text = fStdWeight.ToString("#.#");

                // 標準体重との差
                float fDiff = fWeight - fStdWeight;
                txtResultDiffStdWeight.Text = fDiff.ToString("#.#");

                // 判定
                string strResult = string.Empty;
                // BMIより判定
                if (fBMI < 18.5)
                {
                    // 痩せています
                    strResult = "痩せています";
                }
                if ((fBMI >= 18.5) && (fBMI < 25))
                {
                    // 標準体重
                    strResult = "標準体重";
                }
                if ((fBMI >= 25) && (fBMI < 30))
                {
                    // 肥満レベル1
                    strResult = "肥満レベル1";
                }
                if ((fBMI >= 30) && (fBMI < 35))
                {
                    // 肥満レベル2
                    strResult = "肥満レベル2";
                }
                if ((fBMI >= 35) && (fBMI < 40))
                {
                    // 肥満レベル3
                    strResult = "肥満レベル3";
                }
                if (fBMI >= 40)
                {
                    // 肥満レベル4
                    strResult = "肥満レベル4";
                }

                txtResult.Text = strResult;

                break;
            }
        }
    }
}
