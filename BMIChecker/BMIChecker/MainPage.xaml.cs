﻿using System;
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
                    // TODO:メッセージ出力する
                    break;
                }

                // 体重の確認
                if (txtWeight.Text == "")
                {
                    strMessage = "体重を入力してください。";
                    // TODO:メッセージ出力する
                    break;
                }

                // パラメータチェックする
                // 型変換する
                bmi.Height = float.Parse(txtHeight.Text) / 100;
                bmi.Weight = float.Parse(txtWeight.Text);
                var result = bmi.CheckParam();
                if (result != ErrorCode.NoERR)
                {
                    // TODO:メッセージ出力する
                    break;
                }

                // BMIの計算をする
                var BMIResult = bmi.Calc();
                if (BMIResult != ErrorCode.NoERR)
                {
                    // TODO:エラーメッセージ出力する
                    break;
                }
                txtResultBMI.Text = bmi.BmiValue.ToString("#.#");

                // 標準体重
                txtResulStdWeight.Text = bmi.StdWeight.ToString("#.#");

                // 標準体重との差
                txtResultDiffStdWeight.Text = bmi.DiffOfStdWeight.ToString("#.#");

                // 判定
                bmi.BMIJudge();
                txtResult.Text = bmi.ResultMessage;
                break;
            }
        }
    }
}
