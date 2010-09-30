﻿#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using Sharp3D.Math.Core;
using log4net;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewTruck : Form
    {
        #region Data members
        private Document _document;
        private TruckProperties _truckProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewTruck));
        #endregion

        #region Constructor
        public FormNewTruck(Document document)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            radioButtonTruck1.Checked = false;
            radioButtonTruck2.Checked = true;

            // initialize data
            TruckLength = 12100;
            TruckWidth = 2320;
            TruckHeight = 2350;
            TruckAdmissibleLoadWeight = 38000;
            TruckColor = Color.LightBlue;
            
            DrawTruck();
        }
        public FormNewTruck(Document document, TruckProperties truckProperties)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            _truckProperties = truckProperties;

            radioButtonTruck1.Checked = false;
            radioButtonTruck2.Checked = true;
            // set caption text
            Text = string.Format("Edit {0}...", _truckProperties.Name);
            // initialize data
            tbName.Text = _truckProperties.Name;
            tbDescription.Text = _truckProperties.Description;
            TruckLength = _truckProperties.Length;
            TruckWidth = _truckProperties.Width;
            TruckHeight = _truckProperties.Height;
            TruckAdmissibleLoadWeight = _truckProperties.AdmissibleLoadWeight;
            TruckColor = _truckProperties.Color;

            DrawTruck();
        }
        #endregion

        #region Form override
        protected override void OnResize(EventArgs e)
        {
            DrawTruck();
            base.OnResize(e);
        }
        #endregion

        #region Public properties
        public string TruckName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double TruckLength
        {
            get { return System.Convert.ToDouble(nudLength.Text); }
            set { nudLength.Text = string.Format("{0}", value); }
        }
        public double TruckWidth
        {
            get { return System.Convert.ToDouble(nudWidth.Text); }
            set { nudWidth.Text = string.Format("{0}", value); }
        }
        public double TruckHeight
        {
            get { return System.Convert.ToDouble(nudHeight.Text); }
            set { nudHeight.Text = string.Format("{0}", value); }
        }
        public double TruckAdmissibleLoadWeight
        {
            get { return System.Convert.ToDouble(nudAdmissibleLoadWeight.Text); }
            set { nudAdmissibleLoadWeight.Text = string.Format("{0}", value); }
        }
        public Color TruckColor
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        #endregion

        #region Draw truck
        private void DrawTruck()
        {
            try
            {
                // get horizontal angle
                double angle = trackBarHorizAngle.Value;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
                graphics.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);

                if (TruckLength == 0 || TruckWidth == 0 || TruckHeight == 0)
                    return;

                TruckProperties truckProperties = new TruckProperties(null, TruckLength, TruckWidth, TruckHeight);
                truckProperties.Color = TruckColor;
                Truck truck = new Truck(truckProperties);
                truck.Draw(graphics);

                graphics.Flush();
                // set to picture box
                pictureBox.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Handlers
        private void UpdateButtonOkStatus()
        {
            bnAccept.Enabled =
                tbName.Text.Length > 0
                && tbDescription.Text.Length > 0
                && _document.IsValidNewTypeName(tbName.Text, _truckProperties);
        }

        private void onTruckPropertyChanged(object sender, EventArgs e)
        {
            DrawTruck();
        }

        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawTruck();
        }

        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewTruck_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormNewTruckPosition)
                Settings.Default.FormNewTruckPosition.Restore(this);
            DrawTruck();
        }

        private void FormNewTruck_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewTruckPosition)
                Settings.Default.FormNewTruckPosition = new WindowSettings();
            Settings.Default.FormNewTruckPosition.Record(this);
        }
        #endregion
    }
}