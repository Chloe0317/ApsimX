﻿using Models.Core;
using System;
using System.Collections.Generic;

namespace Models.PMF.SimplePlantModels
{
    /// <summary>
    /// Data structure that contains information for a specific planting of scrum
    /// </summary>
    [Serializable]
    public class ScrumManagementInstance : Model
    {
        /// <summary>Establishemnt Date</summary>
        public string CropName { get; set; }

        /// <summary>Establishemnt Date</summary>
        public DateTime EstablishDate { get; set; }

        /// <summary>Establishment Stage</summary>
        public string EstablishStage { get; set; }
        
        /// <summary>Planting depth (mm)</summary>
        public double PlantingDepth { get; set; }

        /// <summary>Harvest Date</summary>
        public Nullable <DateTime> HarvestDate { get; set; }

        /// <summary>Harvest Tt (oCd establishment to harvest)</summary>
        public double TtEstabToHarv { get; set; }

        /// <summary>Planting Stage</summary>
        public string HarvestStage { get; set; }
        
        /// <summary>Expected Yield (g FW/m2)</summary>
        public double ExpectedYield { get; set; }

        /// <summary>Field loss (i.e the proportion of expected yield that is left in the field 
        /// because of diseaese, poor quality or lack of market)</summary>
        public double FieldLoss { get; set; }

        /// <summary>Residue Removal (i.e the proportion of residues that are removed from the field 
        /// by bailing or some other means)</summary>
        public double ResidueRemoval { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public ScrumManagementInstance(){ }

        /// <summary>
        /// Management class constructor
        /// </summary>
        public ScrumManagementInstance(string cropName, DateTime establishmentDate, string establishStage, double plantingDepth, string harvestStage, double expectedYield,
             Nullable<DateTime> harvestDate = null, double harvestTt = Double.NaN, double fieldLoss = 0, double residueRemoval = 0)
        {
            CropName = cropName;
            EstablishDate = establishmentDate;
            EstablishStage = establishStage;
            PlantingDepth = plantingDepth;
            HarvestStage = harvestStage;
            ExpectedYield = expectedYield;
            HarvestDate = harvestDate;
            TtEstabToHarv = harvestTt;
            FieldLoss = fieldLoss;
            ResidueRemoval = residueRemoval;    
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cropParams"></param>
        /// <param name="today"></param>
        public ScrumManagementInstance(Dictionary<string, string> cropParams, DateTime today)
        {
            CropName = cropParams["CropName"];
            EstablishDate = DateTime.Parse(cropParams["EstablishDate"]+"-"+today.Year) ;
            EstablishStage = cropParams["EstablishStage"];
            PlantingDepth = Double.Parse(cropParams["PlantingDepth"]);
            HarvestStage = cropParams["HarvestStage"];
            ExpectedYield = Double.Parse(cropParams["ExpectedYield"]);
            if (cropParams["HarvestDate"] != "")
            {
                DateTime testHarvestDate = DateTime.Parse(cropParams["HarvestDate"] + "-" + today.Year);
                if (testHarvestDate > EstablishDate)
                {
                    HarvestDate = testHarvestDate;
                }
                else
                {
                    HarvestDate = DateTime.Parse(cropParams["HarvestDate"] + "-" + (today.Year + 1));
                }
            }
            if (cropParams["TtEstabToHarv"] != "")
            {
                TtEstabToHarv = Double.Parse(cropParams["TtEstabToHarv"]);
            }
            FieldLoss = Double.Parse(cropParams["FieldLoss"]);
            ResidueRemoval = Double.Parse(cropParams["ResidueRemoval"]);
        }
    }
}