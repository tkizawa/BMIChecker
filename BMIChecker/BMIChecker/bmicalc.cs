using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BMIChecker
{
    /// <summary>
    /// BMI計算のクラス
    /// </summary>
    class bmicalc
    {
        /// <summary>
        /// 身長
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// BMI値
        /// </summary>
        public float BmiValue { get; set; }
        
        /// <summary>
        /// 判定文字列
        /// </summary>
        public string ResultMessage { get; set; }

        public string ResultColor { get; set; }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 標準体重
        /// </summary>
        public float StdWeight { get; set; }

        /// <summary>
        /// 標準体重との体重差
        /// </summary>
        public float DiffOfStdWeight { get; set; }

        /// <summary>
        /// パラメータチェック
        /// </summary>
        /// <returns>エラーコード</returns>
        public ErrorCode CheckParam()
        {
            ErrorCode retErr = ErrorCode.NoERR;

            if (Height == 0)
            {
                retErr = ErrorCode.Height;
                ErrorMessage = "身長が0cmです。正しい値を入れて下さい。";
            }

            if (Height < 0)
            {
                retErr = ErrorCode.Height;
                ErrorMessage = "身長が適切ではありません。正しい値を入れて下さい。";
            }
            if (Weight == 0)
            {
                retErr = ErrorCode.Weight;
                ErrorMessage = "体重が0kgです。正しい値を入れて下さい。";
            }
            if (Weight < 0)
            {
                retErr = ErrorCode.Weight;
                ErrorMessage = "体重が適切ではありません。正しい値を入れて下さい。";
            }
            return (retErr);
        }

        /// <summary>
        /// 計算
        /// </summary>
        /// <returns></returns>
        public ErrorCode Calc()
        {
            string strMessage = string.Empty;
            ErrorCode error = ErrorCode.NoERR;

            // BMIの計算をする
            BmiValue = Weight / (Height * Height);
            if (BmiValue == 0)
            {
                ErrorMessage = "BMIが正常に算出できませんでした。";
                error = ErrorCode.Calc;
            }
            else
            {
                // 標準体重
                StdWeight = (Height * Height * 22);

                // 標準体重との差
                DiffOfStdWeight = Weight - StdWeight;
            }
            return (error);
        }

        /// <summary>
        /// BMI判定
        /// BMIの数値から判定文字列を返す
        /// </summary>
        /// <returns>判定文字列</returns>
        public void BMIJudge()
        {
            // BMIより判定
            if (BmiValue < 18.5)
            {
                // 痩せています
                ResultMessage = "痩せています";
                ResultColor = "Blue";
            }
            else if ((BmiValue >= 18.5) && (BmiValue < 25))
            {
                // 標準体重
                ResultMessage = "標準体重";
                ResultColor = "Green";
            }
            else if ((BmiValue >= 25) && (BmiValue < 30))
            {
                // 肥満レベル1
                ResultMessage = "肥満レベル1";
                ResultColor = "Red";
            }
            else if ((BmiValue >= 30) && (BmiValue < 35))
            {
                // 肥満レベル2
                ResultMessage = "肥満レベル2";
                ResultColor = "Red";
            }
            else if ((BmiValue >= 35) && (BmiValue < 40))
            {
                // 肥満レベル3
                ResultMessage = "肥満レベル3";
                ResultColor = "Red";
            }
            else if (BmiValue >= 40)
            {
                // 肥満レベル4
                ResultMessage = "肥満レベル4";
                ResultColor = "Red";
            }
            else
            {
                // 該当なし
                ResultMessage = "肥満度が判定できません。";
                ResultColor = "Red";
            }
        }
    }

    /// <summary>
    /// エラーコード
    /// </summary>
    enum ErrorCode
    {
        NoERR,
        Height,
        Weight,
        Calc,
    }
}
