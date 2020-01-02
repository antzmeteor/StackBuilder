﻿namespace treeDiM.StackBuilder.Basics
{
    public class LoadedCase : PackableLoaded
    {
        internal LoadedCase(AnalysisHomo analysis)
            : base(analysis)
        {
        }
        public override GlobID ID
        {
            get
            {
                return new GlobID(
                    ParentAnalysis.ID.IGuid,
                    $"{Properties.Resources.ID_NAMECASE}({ParentAnalysis.Name})",
                    ParentAnalysis.Description
                    );
            }
        }
        public Packable Container => Analysis.CaseProperties;

        #region Override PackableBrick
        public override bool IsCase => true;
        public override double Length => ParentSolution.BBoxGlobal.Length;
        public override double Width => ParentSolution.BBoxGlobal.Width;
        public override double Height => ParentSolution.BBoxGlobal.Height;
        #endregion

        public override bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = ParentAnalysis.Content;
            number = ParentSolution.ItemCount;
            return true;
        }
        public override bool InnerAnalysis(ref AnalysisHomo analysis)
        {
            analysis = Analysis;
            return true;
        }

        #region Non-Public Members
        private AnalysisPackableCase Analysis => ParentAnalysis as AnalysisPackableCase;
        protected override string TypeName => Properties.Resources.ID_LOADEDCASE;
        #endregion
    }
}
