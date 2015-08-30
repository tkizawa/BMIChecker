using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIChecker
{
    /// <summary>
    /// BMI計算のクラス
    /// </summary>
    class bmicalc
    {

        /// <summary>
        /// パラメータチェック
        /// </summary>
        /// <param name="Height">身長</param>
        /// <param name="Weight">体重</param>
        /// <returns></returns>
        public ErrorCode CheckParam(float Height, float Weight)
        {
            ErrorCode retErr = ErrorCode.NoERR;

            if (Height == 0)
            {
                retErr = ErrorCode.Height;
            }
            if (Weight == 0)
            {
                retErr = ErrorCode.Weight;
            }

            return (retErr);
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
