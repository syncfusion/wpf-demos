#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace FirstSample
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
                    algebraicCmd = new AlgebraicCmd();
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
                    angelCmd = new AngleCmd();
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
                    autoAngelCmd = new AutoAngleCmd();
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
                    autoCalcCmd = new AutoCalcCmd();
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
                    contorlCmd = new ControlCmd();
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
                    manualCmd = new Manualcmd();
                return manualCmd;
            }
            set
            {
                manualCmd = value;
            }
        }

    }
}
