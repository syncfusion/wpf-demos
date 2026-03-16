#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemos.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ForceDirectedTreeViewModel : DiagramViewModel
    {
        ForceDirectedDetails DataSources;

        private int repulsionStrength = 25000;
        private double attractionStrength = 0.6;
        private int maxIteration = 1500;
        public DemoControl View;

        /// <summary>
        /// Gets or sets the value of hte AttractionStrength
        /// </summary>
        public double AttractionStrength
        {
            get
            {
                return attractionStrength;
            }
            set
            {
                if (!attractionStrength.Equals(value))
                {
                    attractionStrength = value;
                    OnPropertyChanged(nameof(AttractionStrength));
                    (this.LayoutManager.Layout as ForceDirectedTreeLayout).AttractionStrength = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the RepulsionStrength
        /// </summary>
        public int RepulsionStrength
        {
            get
            {
                return repulsionStrength;
            }
            set
            {
                if (!repulsionStrength.Equals(value))
                {
                    repulsionStrength = value;
                    OnPropertyChanged(nameof(RepulsionStrength));
                    (this.LayoutManager.Layout as ForceDirectedTreeLayout).RepulsionStrength = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the MaximumIteration
        /// </summary>
        public int MaximumIteration
        {
            get
            {
                return maxIteration;
            }
            set
            {
                if (!maxIteration.Equals(value))
                {
                    maxIteration = value;
                    OnPropertyChanged(nameof(MaximumIteration));
                    (this.LayoutManager.Layout as ForceDirectedTreeLayout).MaximumIteration = value;
                }
            }
        }

        public ForceDirectedTreeViewModel()
        {
            // Initialize Diagram properties
            Menu = null;
            Tool = Tool.ZoomPan;
            DefaultConnectorType = ConnectorType.Line;

            // Initialize DataSourceSettings for SfDiagram

            DataSourceSettings = new DataSourceSettings()
            {
                ParentId = "Manager",
                Id = "Id",
                DataSource = Getdata(),

            };

            // Initialize LayoutSettings for SfDiagram

            LayoutManager = new LayoutManager()
            {
                Layout = new ForceDirectedTreeLayout()
                {
                    AttractionStrength = 0.6,
                    RepulsionStrength = 25000,
                    MaximumIteration = 1000,
                }
            };
        }

      

        /// <summary>
        /// Method to Get the data for DataSource
        /// </summary>
        private ForceDirectedDetails Getdata()
        {
            DataSources = new ForceDirectedDetails()
            {
                 // ===== Center hubs (Root) =====
                new ForceDirectedDetail() { Id = "Dept", Role = "Departments", Color = "#00B4D8", Width = 140, Height = 140 },

                // Development cluster (Blue/Indigo)
                new ForceDirectedDetail() { Id = "Dev", Role = "Development\nTeam", Manager = "Dept", Color = "#4169E1", Width = 120, Height = 120 },

                // ===== POs under Development (Blue/Indigo) =====
                new ForceDirectedDetail() { Id = "PO1", Role = "PO-1", Manager = "Dev", Color = "#4169E1", Width = 100, Height = 100 },
                new ForceDirectedDetail() { Id = "PO2", Role = "PO-2", Manager = "Dev", Color = "#4169E1", Width = 100, Height = 100 },
  
                // Teams around PO-1 (Same color as PO-1)
                new ForceDirectedDetail() { Id = "PO1_T1", Role = "Team-1", Manager = "PO1", Color = "#4169E1", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "PO1_T2", Role = "Team-2", Manager = "PO1", Color = "#4169E1", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "PO1_T3", Role = "Team-3", Manager = "PO1", Color = "#4169E1", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "PO1_T4", Role = "Team-4", Manager = "PO1", Color = "#4169E1", Width = 80, Height = 80 },

                // Teams around PO-2 (Same color as PO-2)
                new ForceDirectedDetail() { Id = "PO2_T1", Role = "Team-1", Manager = "PO2", Color = "#4169E1", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "PO2_T2", Role = "Team-2", Manager = "PO2", Color = "#4169E1", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "PO2_T3", Role = "Team-3", Manager = "PO2", Color = "#4169E1", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "PO2_T4", Role = "Team-4", Manager = "PO2", Color = "#4169E1", Width = 80, Height = 80 },

                // ===== Sales cluster (Purple) =====
                new ForceDirectedDetail() { Id = "Sales", Role = "Sales Team", Manager = "Dept", Color = "#9D4EDD", Width = 120, Height = 120 },

                new ForceDirectedDetail() { Id = "AGM1", Role = "AGM-1", Manager = "Sales", Color = "#9D4EDD", Width = 100, Height = 100 },
                new ForceDirectedDetail() { Id = "AGM2", Role = "AGM-2", Manager = "Sales", Color = "#9D4EDD", Width = 100, Height = 100 },

                // Teams around AGM-1 (Same color as AGM-1)
                new ForceDirectedDetail() { Id = "AGM1_T1", Role = "Team-1", Manager = "AGM1", Color = "#9D4EDD", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "AGM1_T2", Role = "Team-2", Manager = "AGM1", Color = "#9D4EDD", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "AGM1_T3", Role = "Team-3", Manager = "AGM1", Color = "#9D4EDD", Width = 80, Height = 80 },

                // Teams around AGM-2 (Same color as AGM-2)
                new ForceDirectedDetail() { Id = "AGM2_T1", Role = "Team-1", Manager = "AGM2", Color = "#9D4EDD", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "AGM2_T2", Role = "Team-2", Manager = "AGM2", Color = "#9D4EDD", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "AGM2_T3", Role = "Team-3", Manager = "AGM2", Color = "#9D4EDD", Width = 80, Height = 80 },

                // ===== HR cluster (Light Pink) =====
                new ForceDirectedDetail() { Id = "HR", Role = "HR Team", Manager = "Dept", Color = "#FF69B4", Width = 120, Height = 120 },

                new ForceDirectedDetail() { Id = "HR_Mgr", Role = "Manager", Manager = "HR", Color = "#FF69B4", Width = 100, Height = 100 },
                new ForceDirectedDetail() { Id = "HR_T1", Role = "Team-1", Manager = "HR_Mgr", Color = "#FF69B4", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "HR_T2", Role = "Team-2", Manager = "HR_Mgr", Color = "#FF69B4", Width = 80, Height = 80 },

                // ===== UX cluster (Teal/Cyan variant) =====
                new ForceDirectedDetail() { Id = "UX", Role = "UX Team", Manager = "Dept", Color = "#20B2AA", Width = 120, Height = 120 },

                new ForceDirectedDetail() { Id = "UX_Mgr1", Role = "Manager-1", Manager = "UX", Color = "#20B2AA", Width = 100, Height = 100 },
                new ForceDirectedDetail() { Id = "UX_Mgr2", Role = "Manager-2", Manager = "UX", Color = "#20B2AA", Width = 100, Height = 100 },

                // Teams around Manager-1 (Same color as Manager-1)
                new ForceDirectedDetail() { Id = "UX1_T1", Role = "Team-1", Manager = "UX_Mgr1", Color = "#20B2AA", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "UX1_T2", Role = "Team-2", Manager = "UX_Mgr1", Color = "#20B2AA", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "UX1_T3", Role = "Team-3", Manager = "UX_Mgr1", Color = "#20B2AA", Width = 80, Height = 80 },

                // Teams around Manager-2 (Same color as Manager-2)
                new ForceDirectedDetail() { Id = "UX2_T1", Role = "Team-1", Manager = "UX_Mgr2", Color = "#20B2AA", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "UX2_T2", Role = "Team-2", Manager = "UX_Mgr2", Color = "#20B2AA", Width = 80, Height = 80 },
                new ForceDirectedDetail() { Id = "UX2_T3", Role = "Team-3", Manager = "UX_Mgr2", Color = "#20B2AA", Width = 80, Height = 80 },
            };
            return DataSources;
        }
    }

}
