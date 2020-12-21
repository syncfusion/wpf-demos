#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.PivotAnalysis.Base;

namespace syncfusion.pivotgriddemos.wpf
{
    public class MyCustomSummaryBase1 : SummaryBase
    {
        private double mTotalValue;

        public override void Combine(object other)
        {
            mTotalValue += (double)other;
        }

        public override void CombineSummary(SummaryBase other)
        {
            MyCustomSummaryBase1 dpsb = other as MyCustomSummaryBase1;

            if (null != dpsb)
            {
                mTotalValue += dpsb.mTotalValue;
            }
        }

        public override SummaryBase GetInstance()
        {
            return new MyCustomSummaryBase1();
        }

        public override object GetResult()
        {
            return mTotalValue / 3.33333;
        }

        public override void Reset()
        {
            mTotalValue = 0;
        }
    }


    public class MyCustomSummaryBase2 :
        SummaryBase
    {
        private double mTotalValue;

        public override void Combine(object other)
        {
            mTotalValue += (double)other;
        }

        public override void CombineSummary(SummaryBase other)
        {
            MyCustomSummaryBase2 dpsb = other as MyCustomSummaryBase2;

            if (null != dpsb)
            {
                mTotalValue += dpsb.mTotalValue;
            }
        }

        public override SummaryBase GetInstance()
        {
            return new MyCustomSummaryBase2();
        }

        public override object GetResult()
        {
            return mTotalValue / 5.5555;
        }

        public override void Reset()
        {
            mTotalValue = 0;
        }
    }
}