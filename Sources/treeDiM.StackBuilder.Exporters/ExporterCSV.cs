﻿#region Using directives
using System.Text;
using System.IO;
using System.Globalization;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    public class ExporterCSV : Exporter
    {
        #region Static members
        public static string FormatName => "csv (default)";
        #endregion

        public ExporterCSV() {}
        public override string Name => FormatName;
        public override string Extension => "csv";
        public override string Filter => "Comma Separated Values (*.csv)|*.csv";
        public override void Export(AnalysisLayered analysis, ref Stream stream)
        {
            // number formatting
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = "",
                NumberDecimalDigits = 1
            };

            // initialize csv file
            var csv = new StringBuilder();
            SolutionLayered sol = analysis.SolutionLay;
            var layers = sol.Layers;
            foreach (ILayer layer in layers)
            {
                if (layer is Layer3DBox layerBox)
                {
                    foreach (BoxPosition bPosition in layerBox)
                    {
                        Vector3D pos = ConvertPosition(bPosition, analysis.ContentDimensions);
                        csv.AppendLine(
                            $"1;" +
                            $"{pos.X.ToString("0,0.0", nfi)};" +
                            $"{pos.Y.ToString("0,0.0", nfi)};" +
                            $"{pos.Z.ToString("0,0.0", nfi)};" +
                            $"{bPosition.DirectionLength};" +
                            $"{bPosition.DirectionWidth}");
                    }
                }
            }
            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }
    }
}
