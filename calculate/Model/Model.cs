#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace syncfusion.calculatedemos.wpf
{
    public class Model
    {
        #region "API Definition"

        public ICommand manualCmd;
        public ICommand algebraicCmd;
        public ICommand angelCmd;
        public ICommand autoAngelCmd;
        public ICommand autoCalcCmd;
        public ICommand contorlCmd;

        #endregion

        public ICommand AlgebraicCmd
        {
            get
            {
                if (algebraicCmd == null)
                    algebraicCmd = new DelegateCommand<object>(ExecuteAlegbraicCommand);
                return algebraicCmd;
            }
            set
            {
                algebraicCmd = value;
            }
        }
        public ICommand AngelCmd
        {
            get
            {
                if (angelCmd == null)
                    angelCmd = new DelegateCommand<object>(ExecuteAngleCommand);
                return angelCmd;
            }
            set
            {
                angelCmd = value;
            }
        }
        public ICommand AutoAngelCmd
        {
            get
            {
                if (autoAngelCmd == null)
                    autoAngelCmd = new DelegateCommand<object>(ExecuteAutoAngleCmd);
                return autoAngelCmd;
            }
            set
            {
                autoAngelCmd = value;
            }
        }
        public ICommand AutoCalcCmd
        {
            get
            {
                if (autoCalcCmd == null)
                    autoCalcCmd = new DelegateCommand<object>(ExecuteAutoCalcCmd);
                return autoCalcCmd;
            }
            set
            {
                autoCalcCmd = value;
            }
        }
        public ICommand ContorlCmd
        {
            get
            {
                if (contorlCmd == null)
                    contorlCmd = new DelegateCommand<object>(ExecuteControlCmd);
                return contorlCmd;
            }
            set
            {
                contorlCmd = value;
            }
        }

        public ICommand ManualCmd
        {
            get
            {
                if (manualCmd == null)
                    manualCmd = new DelegateCommand<object>(ExecuteMaualCommand);
                return manualCmd;
            }
            set
            {
                manualCmd = value;
            }
        }

        #region Command Execution
        private void ExecuteAlegbraicCommand(object param)
        {
            AlgebraicExpressions alg = new AlgebraicExpressions();
            alg.Show();
        }
        private void ExecuteAngleCommand(object param)
        {
            AngleForm ang = new AngleForm();
            ang.Show();
        }
        private void ExecuteAutoAngleCmd(object param)
        {
            AutoAngleForm auto = new AutoAngleForm();
            auto.Show();
        }

        private void ExecuteAutoCalcCmd(object param)
        {
            AutoCalcForm autocal = new AutoCalcForm();
            autocal.Show();
        }
        private void ExecuteControlCmd(object param)
        {
            MoreComplexForm cont = new MoreComplexForm();
            cont.Show();
        }
        private void ExecuteMaualCommand(object param)
        {
            ManualCalcForm manual = new ManualCalcForm();
            manual.Show();
        }
        #endregion
    }
}
