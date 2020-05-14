#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Drawing;

namespace CollectionObjects
{
    #region Import Classes
    public class Brand
    {
        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private VehicleType m_vehicleType;
        public VehicleType VehicleType
        {
            get { return m_vehicleType; }
            set { m_vehicleType = value; }
        }

        public Brand(string brandName)
        {
            m_brandName = brandName;
        }
        public Brand()
        {

        }
    }

    public class VehicleType
    {
        private string m_vehicleName;
        [DisplayNameAttribute("Vehicle Type")]
        public string VehicleName
        {
            get { return m_vehicleName; }
            set { m_vehicleName = value; }
        }

        private Model m_model;
        public Model Model
        {
            get { return m_model; }
            set { m_model = value; }
        }

        public VehicleType(string vehicle)
        {
            m_vehicleName = vehicle;
        }
        public VehicleType()
        {

        }
    }

    public class Model
    {
        private string m_modelName;
        [DisplayNameAttribute("Model")]
        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public Model(string name)
        {
            m_modelName = name;
        }
        public Model()
        {

        }
    }
    #endregion 
}
