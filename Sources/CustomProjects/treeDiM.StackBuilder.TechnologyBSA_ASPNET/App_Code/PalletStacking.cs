﻿#region Using directives
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Exporters;
#endregion

/// <summary>
/// Summary description for PalletStacking
/// </summary>
public static class PalletStacking
{
    public static void GetLayers(Vector3D caseDim, double caseWeight, Vector3D palletDim, double palletWeight, double maxPalletHeight, bool bestLayersOnly, ref List<LayerDetails> listLayers)
    {
        // case
        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.Tan,
            TapeWidth = new OptDouble(true, 50.0)
        };
        boxProperties.SetWeight(caseWeight);
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
        // pallet
        var palletProperties = new PalletProperties(null, "EUR2", palletDim.X, palletDim.Y, palletDim.Z)
        {
            Weight = palletWeight,
            Color = Color.Yellow
        };
        // ### define a constraintset object
        var constraintSet = new ConstraintSetCasePallet()
        {
            OptMaxNumber = new OptInt(false, 0),
            OptMaxWeight = new OptDouble(true, 1000.0),
            Overhang = Vector2D.Zero,
        };
        constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
        constraintSet.SetMaxHeight(new OptDouble(true, maxPalletHeight));
        Vector3D vPalletDim = palletProperties.GetStackingDimensions(constraintSet);
        // ###

        // get a list of all possible layers and fill ListView control
        ILayerSolver solver = new LayerSolver();
        var layers = solver.BuildLayers(boxProperties.OuterDimensions, new Vector2D(vPalletDim.X, vPalletDim.Y), 0.0, constraintSet, bestLayersOnly);
        foreach (var layer in layers)
            listLayers.Add(
                new LayerDetails(
                    layer.Name,
                    layer.LayerDescriptor.ToString(),
                    layer.Count,
                    layer.NoLayers(caseDim.Z),
                    caseDim.X, caseDim.Y, caseDim.Z)
                );
    }

    public static void GetSolution(
        Vector3D caseDim, double caseWeight, Bitmap bmpTexture,
        Vector3D palletDim, double palletWeight,
        double maxPalletHeight,
        List<BoxPosition> boxPositions,
        bool mirrorLength, bool mirrorWidth,
        bool interlayerBottom, bool interlayerIntermediate, bool interlayerTop,
        double angle,
        Size sz,
        ref byte[] imageBytes,
        ref int caseCount, ref int layerCount,
        ref double weightLoad, ref double weightTotal,
        ref Vector3D bbLoad, ref Vector3D bbGlob
        )
    {
        SolutionLayered.SetSolver(new LayerSolver());
        // case
        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.Tan,
            TapeWidth = new OptDouble(true, 50.0)
        };
        if (null != bmpTexture)
        {
            double ratio = (double)bmpTexture.Height / bmpTexture.Width;

            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_N, TexturePosition(caseDim.Y, caseDim.Z, ratio), TextureSize(caseDim.Y, caseDim.Z, ratio), 0.0, bmpTexture);
            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_P, TexturePosition(caseDim.Y, caseDim.Z, ratio), TextureSize(caseDim.Y, caseDim.Z, ratio), 0.0, bmpTexture);
            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_N, TexturePosition(caseDim.X, caseDim.Z, ratio), TextureSize(caseDim.X, caseDim.Z, ratio), 0.0, bmpTexture);
            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_P, TexturePosition(caseDim.X, caseDim.Z, ratio), TextureSize(caseDim.X, caseDim.Z, ratio), 0.0, bmpTexture);

        }
        boxProperties.SetWeight(caseWeight);
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
        // pallet
        var palletProperties = new PalletProperties(null, "EUR2", palletDim.X, palletDim.Y, palletDim.Z)
        {
            Weight = palletWeight,
            Color = Color.Yellow
        };
        // constraint set
        var constraintSet = new ConstraintSetCasePallet();
        constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
        constraintSet.SetMaxHeight(new OptDouble(true, maxPalletHeight));
        // layer 2D
        var layer2D = new Layer2DBrickExp(caseDim, new Vector2D(), "", HalfAxis.HAxis.AXIS_Z_P);
        layer2D.SetPositions(boxPositions);
        // analysis
        var analysis = new AnalysisCasePallet(boxProperties, palletProperties, constraintSet);
        analysis.AddInterlayer(new InterlayerProperties(null, "interlayer", "", palletDim.X, palletDim.Y, 1.0, 0.0, Color.LightYellow));
        analysis.AddSolution(layer2D, mirrorLength, mirrorWidth);
        if (interlayerTop)
            analysis.PalletCapProperties = new PalletCapProperties(null, "palletcap", "", palletDim.X, palletDim.Y, 1, palletDim.X, palletDim.Y, 0.0, 0.0, Color.LightYellow);
        // solution
        SolutionLayered sol = analysis.SolutionLay;
        var solutionItems = sol.SolutionItems;
        int iCount = solutionItems.Count;
        for (int i = 0; i < iCount; ++i)
        {
            bool hasInterlayer = (i == 0 && interlayerBottom)
                || (i != 0 && interlayerIntermediate);
            solutionItems[i].InterlayerIndex = hasInterlayer ? 0 : -1;
        }
        layerCount = analysis.SolutionLay.LayerCount;
        caseCount = analysis.Solution.ItemCount;
        weightLoad = analysis.Solution.LoadWeight;
        weightTotal = analysis.Solution.Weight;
        bbGlob = analysis.Solution.BBoxGlobal.DimensionsVec;
        bbLoad = analysis.Solution.BBoxLoad.DimensionsVec;

        // generate image path
        Graphics3DImage graphics = new Graphics3DImage(sz)
        {
            BackgroundColor = Color.Transparent,
            FontSizeRatio = ConfigSettings.FontSizeRatio,
            ShowDimensions = true
        };
        graphics.SetCameraPosition(10000.0, angle, 45.0);

        using (ViewerSolution sv = new ViewerSolution(analysis.SolutionLay))
            sv.Draw(graphics, Transform3D.Identity);
        graphics.Flush();
        Bitmap bmp = graphics.Bitmap;
        ImageConverter converter = new ImageConverter();
        imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
    }

    public static void GenerateExport(Vector3D caseDim, double caseWeight, Bitmap bmpTexture,
        Vector3D palletDim, double palletWeight,
        double maxPalletHeight,
        List<BoxPosition> boxPositions,
        bool mirrorLength, bool mirrorWidth,
        bool interlayerBottom, bool interlayerIntermediate, bool interlayerTop,
        string filePath,
        ref int caseCount, ref int layerCount,
        ref double weightLoad, ref double weightTotal,
        ref Vector3D bbLoad, ref Vector3D bbGlob
        )
    {
        SolutionLayered.SetSolver(new LayerSolver());
        // case
        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.Tan,
            TapeWidth = new OptDouble(true, 50.0)
        };
        if (null != bmpTexture)
        {
            double ratio = (double)bmpTexture.Height / bmpTexture.Width;

            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_N, TexturePosition(caseDim.Y, caseDim.Z, ratio), TextureSize(caseDim.Y, caseDim.Z, ratio), 0.0, bmpTexture);
            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_P, TexturePosition(caseDim.Y, caseDim.Z, ratio), TextureSize(caseDim.Y, caseDim.Z, ratio), 0.0, bmpTexture);
            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_N, TexturePosition(caseDim.X, caseDim.Z, ratio), TextureSize(caseDim.X, caseDim.Z, ratio), 0.0, bmpTexture);
            boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_P, TexturePosition(caseDim.X, caseDim.Z, ratio), TextureSize(caseDim.X, caseDim.Z, ratio), 0.0, bmpTexture);

        }
        boxProperties.SetWeight(caseWeight);
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
        // pallet
        var palletProperties = new PalletProperties(null, "EUR2", palletDim.X, palletDim.Y, palletDim.Z)
        {
            Weight = palletWeight,
            Color = Color.Yellow
        };
        // constraint set
        var constraintSet = new ConstraintSetCasePallet();
        constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
        constraintSet.SetMaxHeight(new OptDouble(true, maxPalletHeight));
        // layer 2D
        var layer2D = new Layer2DBrickExp(caseDim, new Vector2D(), "", HalfAxis.HAxis.AXIS_Z_P);
        layer2D.SetPositions(boxPositions);
        // analysis
        var analysis = new AnalysisCasePallet(boxProperties, palletProperties, constraintSet);
        analysis.AddInterlayer(new InterlayerProperties(null, "interlayer", "", palletDim.X, palletDim.Y, 1.0, 0.0, Color.LightYellow));
        analysis.AddSolution(layer2D, mirrorLength, mirrorWidth);
        if (interlayerTop)
            analysis.PalletCapProperties = new PalletCapProperties(null, "palletcap", "", palletDim.X, palletDim.Y, 1, palletDim.X, palletDim.Y, 0.0, 0.0, Color.LightYellow);
        // solution
        SolutionLayered sol = analysis.SolutionLay;
        var solutionItems = sol.SolutionItems;
        int iCount = solutionItems.Count;
        for (int i = 0; i < iCount; ++i)
        {
            bool hasInterlayer = (i == 0 && interlayerBottom)
                || (i != 0 && interlayerIntermediate);
            solutionItems[i].InterlayerIndex = hasInterlayer ? 0 : -1;
        }
        layerCount = analysis.SolutionLay.LayerCount;
        caseCount = analysis.Solution.ItemCount;
        weightLoad = analysis.Solution.LoadWeight;
        weightTotal = analysis.Solution.Weight;
        bbGlob = analysis.Solution.BBoxGlobal.DimensionsVec;
        bbLoad = analysis.Solution.BBoxLoad.DimensionsVec;
        // export file
        var exporter = new ExporterGLB();
        exporter.Export(analysis as AnalysisLayered, filePath);
    }

    public static Vector2D TexturePosition(double W, double H, double szRatio)
    {
        double xL, yL;
        if (szRatio > H / W)
        {
            yL = H * 2.0/3.0;
            xL = yL / szRatio;
        }
        else
        {
            xL = W * 2.0 / 3.0;
            yL = xL * szRatio;
        }
        return new Vector2D(0.5 * (W - xL), 0.5 * (H - yL));
    }
    public static Vector2D TextureSize(double W, double H, double szRatio)
    {
        double xL, yL;
        if (szRatio > H / W)
        {
            yL = H * 2.0 / 3.0;
            xL = yL / szRatio;
        }
        else
        {
            xL = W * 2.0 / 3.0;
            yL = xL * szRatio;
        }
        return new Vector2D(xL, yL);
    }

    public static void Export(
        Vector3D caseDim, double caseWeight,
        Vector3D palletDim, double palletWeight,
        double maxPalletHeight,
        List<BoxPosition> boxPositions,
        bool mirrorLength, bool mirrorWidth,
        bool interlayerBottom, bool interlayerIntermediate, bool interlayerTop,
        ref byte[] fileBytes)
    {
        SolutionLayered.SetSolver(new LayerSolver());

        // case
        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.LightGray,
            TapeWidth = new OptDouble(true, 50.0)
        };
        boxProperties.SetWeight(caseWeight);
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
        // pallet
        var palletProperties = new PalletProperties(null, "EUR2", palletDim.X, palletDim.Y, palletDim.Z)
        {
            Weight = palletWeight,
            Color = Color.Yellow
        };
        // constraint set
        var constraintSet = new ConstraintSetCasePallet();
        constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
        constraintSet.SetMaxHeight(new OptDouble(true, maxPalletHeight));
        // layer
        var layer2D = new Layer2DBrickExp(caseDim, new Vector2D(palletDim.X, palletDim.Y), "", HalfAxis.HAxis.AXIS_Z_P);
        layer2D.SetPositions(boxPositions);
        // analysis
        var analysis = new AnalysisCasePallet(boxProperties, palletProperties, constraintSet);
        analysis.AddInterlayer(new InterlayerProperties(null, "interlayer", "", palletDim.X, palletDim.Y, 1.0, 0.0, Color.LightYellow));
        analysis.AddSolution(layer2D, mirrorLength, mirrorWidth);
        if (interlayerTop)
            analysis.PalletCapProperties = new PalletCapProperties(null, "palletcap", "", palletDim.X, palletDim.Y, 1, palletDim.X, palletDim.Y, 0.0, 0.0, Color.LightYellow);

        SolutionLayered sol = analysis.SolutionLay;
        var solutionItems = sol.SolutionItems;
        int iCount = solutionItems.Count;
        for (int i = 0; i < iCount; ++i)
        {
            bool hasInterlayer = (i == 0 && interlayerBottom)
                || (i != 0 && interlayerIntermediate);
            solutionItems[i].InterlayerIndex = hasInterlayer ? 0 : -1;
        }
        // export
        Exporter exporter = ExporterFactory.GetExporterByName("csv (TechnologyBSA)");
        exporter.PositionCoordinateMode = Exporter.CoordinateMode.CM_COG;
        Stream stream = new MemoryStream();
        exporter.Export(analysis, ref stream);
        using (BinaryReader br = new BinaryReader(stream))
            fileBytes = br.ReadBytes((int)stream.Length);
    }
}